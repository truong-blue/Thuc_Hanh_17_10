using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bai2
{

    // 1. PHẦN XỬ LÝ LOGIC FORM
    public partial class Form1 : Form
    {
        private BindingList<EquipmentCheckout> _allCheckouts = new BindingList<EquipmentCheckout>();
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            // Cấu hình DataGridView dùng BindingSource
            dgvCheckouts.AutoGenerateColumns = false;
            dgvCheckouts.DataSource = _bindingSource;

            // Đăng ký sự kiện chọn dòng DataGridView & Menu Xuất CSV
            dgvCheckouts.SelectionChanged += DgvCheckouts_SelectionChanged;
            if (menuExportCSV != null) menuExportCSV.Click += MenuExportCSV_Click;

            SeedSampleData();
            UpdateOverdueStatuses();
            ApplyFilter();
        }

        private void SeedSampleData()
        {
            _allCheckouts.Add(new EquipmentCheckout
            {
                CheckoutId = "PM001",
                StudentId = "241001",
                StudentName = "Nguyễn Văn Trường",
                EquipmentName = "Laptop Dell",
                Quantity = 1,
                BorrowDate = DateTime.Now.AddDays(-5),
                DueDate = DateTime.Now.AddDays(2),
                ActualReturnDate = null,
                Status = "Đang mượn"
            });

            _allCheckouts.Add(new EquipmentCheckout
            {
                CheckoutId = "PM002",
                StudentId = "241002",
                StudentName = "Trần Văn Nam",
                EquipmentName = "Máy oscilloscopes",
                Quantity = 2,
                BorrowDate = DateTime.Now.AddDays(-10),
                DueDate = DateTime.Now.AddDays(-2), // Quá hạn 2 ngày
                ActualReturnDate = null,
                Status = "Quá hạn"
            });
        }

        // Tự động cập nhật trạng thái "Quá hạn" cho phiếu chưa trả có hạn trả < hôm nay
        private void UpdateOverdueStatuses()
        {
            foreach (var item in _allCheckouts)
            {
                if (item.ActualReturnDate == null && item.DueDate.Date < DateTime.Now.Date)
                {
                    item.Status = "Quá hạn";
                }
            }
        }

        // Nạp dữ liệu từ dòng được chọn lên các ô nhập liệu
        private void DgvCheckouts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCheckouts.CurrentRow != null && dgvCheckouts.CurrentRow.DataBoundItem is EquipmentCheckout item)
            {
                txtId.Text = item.CheckoutId;
                txtStudentId.Text = item.StudentId;
                txtStudentName.Text = item.StudentName;

                if (!cboEquipment.Items.Contains(item.EquipmentName)) cboEquipment.Items.Add(item.EquipmentName);
                cboEquipment.SelectedItem = item.EquipmentName;

                numQuantity.Value = item.Quantity > 0 ? item.Quantity : 1;
                dtpBorrowDate.Value = item.BorrowDate;
                dtpDueDate.Value = item.DueDate;

                if (item.ActualReturnDate.HasValue)
                {
                    dtpReturnDate.Value = item.ActualReturnDate.Value;
                    dtpReturnDate.Checked = true;
                }
                else
                {
                    dtpReturnDate.Checked = false;
                }

                if (!cboStatus.Items.Contains(item.Status)) cboStatus.Items.Add(item.Status);
                cboStatus.SelectedItem = item.Status;

                txtId.ReadOnly = true; // Khóa không cho sửa Mã phiếu khi đang chọn dòng
            }
        }

        // Kiểm tra hợp lệ dữ liệu (Validation với ErrorProvider)
        private bool ValidateData(bool isUpdating = false)
        {
            bool isValid = true;
            errorProvider1.Clear();

            // 1. Kiểm tra Mã phiếu
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                errorProvider1.SetError(txtId, "Mã phiếu không được để trống!");
                isValid = false;
            }
            else if (!isUpdating && _allCheckouts.Any(x => x.CheckoutId.Equals(txtId.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtId, "Mã phiếu đã tồn tại!");
                isValid = false;
            }

            // 2. Mã sinh viên & Thiết bị
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                errorProvider1.SetError(txtStudentId, "Mã sinh viên không được để trống!");
                isValid = false;
            }

            if (cboEquipment.SelectedItem == null)
            {
                errorProvider1.SetError(cboEquipment, "Vui lòng chọn thiết bị!");
                isValid = false;
            }

            // 3. Số lượng > 0
            if (numQuantity.Value <= 0)
            {
                errorProvider1.SetError(numQuantity, "Số lượng mượn phải lớn hơn 0!");
                isValid = false;
            }

            // 4. Hạn trả không trước ngày mượn
            if (dtpDueDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                errorProvider1.SetError(dtpDueDate, "Hạn trả không được trước ngày mượn!");
                isValid = false;
            }

            // 5. Ngày trả thực tế không trước ngày mượn
            if (dtpReturnDate.Checked && dtpReturnDate.Value.Date < dtpBorrowDate.Value.Date)
            {
                errorProvider1.SetError(dtpReturnDate, "Ngày trả thực tế không được trước ngày mượn!");
                isValid = false;
            }

            return isValid;
        }

        // Hàm Lọc dữ liệu & Cập nhật StatusStrip
        private void ApplyFilter()
        {
            UpdateOverdueStatuses();

            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString();

            var filteredList = _allCheckouts.Where(a =>
                (string.IsNullOrEmpty(keyword) || a.StudentId.ToLower().Contains(keyword) || a.EquipmentName.ToLower().Contains(keyword)) &&
                (selectedStatus == "-- Tất cả trạng thái --" || string.IsNullOrEmpty(selectedStatus) || a.Status == selectedStatus)
            ).ToList();

            _bindingSource.DataSource = new BindingList<EquipmentCheckout>(filteredList);

            // Cập nhật thống kê trên StatusStrip
            int overdueCount = _allCheckouts.Count(x => x.Status == "Quá hạn");
            if (lblTotal != null) lblTotal.Text = $"Tổng số phiếu: {filteredList.Count} / {_allCheckouts.Count}";
            if (lblOverdue != null) lblOverdue.Text = $" |  Số phiếu quá hạn: {overdueCount}";
        }

        private void ClearInputFields()
        {
            txtId.ReadOnly = false;
            txtId.Clear();
            txtStudentId.Clear();
            txtStudentName.Clear();
            numQuantity.Value = 1;
            dtpBorrowDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now.AddDays(7);
            dtpReturnDate.Checked = false;

            if (cboEquipment.Items.Count > 0) cboEquipment.SelectedIndex = 0;
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;

            errorProvider1.Clear();
            dgvCheckouts.ClearSelection();
        }

        #region CÁC SỰ KIỆN NÚT BẤM VÀ CONTROL (ĐÃ RÁP CHUẨN MÃ XỬ LÝ)

        // NÚT THÊM MỚI PHIẾU
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData(isUpdating: false)) return;

            string status = dtpReturnDate.Checked ? "Đã trả" : (dtpDueDate.Value.Date < DateTime.Now.Date ? "Quá hạn" : "Đang mượn");

            var newItem = new EquipmentCheckout
            {
                CheckoutId = txtId.Text.Trim(),
                StudentId = txtStudentId.Text.Trim(),
                StudentName = txtStudentName.Text.Trim(),
                EquipmentName = cboEquipment.SelectedItem?.ToString(),
                Quantity = (int)numQuantity.Value,
                BorrowDate = dtpBorrowDate.Value.Date,
                DueDate = dtpDueDate.Value.Date,
                ActualReturnDate = dtpReturnDate.Checked ? (DateTime?)dtpReturnDate.Value.Date : null,
                Status = status
            };

            _allCheckouts.Add(newItem);
            ApplyFilter();
            ClearInputFields();
            MessageBox.Show("Thêm mới phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // NÚT CẬP NHẬT PHIẾU
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCheckouts.CurrentRow == null) return;
            if (!ValidateData(isUpdating: true)) return;

            string id = txtId.Text.Trim();
            var target = _allCheckouts.FirstOrDefault(x => x.CheckoutId.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (target != null)
            {
                target.StudentId = txtStudentId.Text.Trim();
                target.StudentName = txtStudentName.Text.Trim();
                target.EquipmentName = cboEquipment.SelectedItem?.ToString();
                target.Quantity = (int)numQuantity.Value;
                target.BorrowDate = dtpBorrowDate.Value.Date;
                target.DueDate = dtpDueDate.Value.Date;
                target.ActualReturnDate = dtpReturnDate.Checked ? (DateTime?)dtpReturnDate.Value.Date : null;

                if (target.ActualReturnDate.HasValue)
                    target.Status = "Đã trả";
                else if (target.DueDate.Date < DateTime.Now.Date)
                    target.Status = "Quá hạn";
                else
                    target.Status = "Đang mượn";

                ApplyFilter();
                MessageBox.Show("Cập nhật thông tin phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // NÚT XÓA PHIẾU
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCheckouts.CurrentRow == null) return;

            string id = txtId.Text.Trim();
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu [{id}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var target = _allCheckouts.FirstOrDefault(x => x.CheckoutId.Equals(id, StringComparison.OrdinalIgnoreCase));
                if (target != null)
                {
                    _allCheckouts.Remove(target);
                    ApplyFilter();
                    ClearInputFields();
                    MessageBox.Show("Đã xóa phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // NÚT LÀM MỚI FORM
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        // NÚT ĐÁNH DẤU ĐÃ TRẢ NHANH
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvCheckouts.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần đánh dấu trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = txtId.Text.Trim();
            var target = _allCheckouts.FirstOrDefault(x => x.CheckoutId.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (target != null)
            {
                target.ActualReturnDate = DateTime.Now.Date;
                target.Status = "Đã trả";

                dtpReturnDate.Value = DateTime.Now.Date;
                dtpReturnDate.Checked = true;
                cboStatus.SelectedItem = "Đã trả";

                ApplyFilter();
                MessageBox.Show($"Đã chuyển trạng thái phiếu [{id}] thành ĐÃ TRẢ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // LỌC TỨC THỜI KHI GÕ MÃ SV / TÊN THIẾT BỊ
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // LỌC THEO TRẠNG THÁI
        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // CÁC SỰ KIỆN KHÁC
        private void label2_Click(object sender, EventArgs e) { }
        private void cboEquipment_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e) { }

        // SỰ KIỆN MENU XUẤT CSV
        private void MenuExportCSV_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = $"PhieuMuon_{DateTime.Now:yyyyMMdd_HHmmss}.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var currentList = (_bindingSource.DataSource as BindingList<EquipmentCheckout>)?.ToList();
                        if (currentList == null || !currentList.Any())
                        {
                            MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Mã Phiếu,Mã Sinh Viên,Họ Tên Sinh Viên,Thiết Bị,Số Lượng,Ngày Mượn,Hạn Trả,Ngày Trả Thực Tế,Trạng Thái");

                        foreach (var item in currentList)
                        {
                            string returnDateStr = item.ActualReturnDate.HasValue ? item.ActualReturnDate.Value.ToString("dd/MM/yyyy") : "Chưa trả";
                            sb.AppendLine($"\"{item.CheckoutId}\",\"{item.StudentId}\",\"{item.StudentName}\",\"{item.EquipmentName}\",\"{item.Quantity}\",\"{item.BorrowDate:dd/MM/yyyy}\",\"{item.DueDate:dd/MM/yyyy}\",\"{returnDateStr}\",\"{item.Status}\"");
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất tập tin CSV thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // 1. MODEL DỮ LIỆU PHIẾU MƯỢN THIẾT BỊ
        public class EquipmentCheckout
        {
            public string CheckoutId { get; set; }
            public string StudentId { get; set; }
            public string StudentName { get; set; }
            public string EquipmentName { get; set; }
            public int Quantity { get; set; }
            public DateTime BorrowDate { get; set; }
            public DateTime DueDate { get; set; }
            public DateTime? ActualReturnDate { get; set; } // Có thể null nếu chưa trả
            public string Status { get; set; }
        }


        #endregion
    }
}