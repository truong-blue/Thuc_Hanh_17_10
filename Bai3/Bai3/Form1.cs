using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bai3
{

    // 1. LOGIC XỬ LÝ GIAO DIỆN FORM
    public partial class Form1 : Form
    {
        private BindingList<RepairOrder> _allOrders = new BindingList<RepairOrder>();
        private BindingSource _bindingSource = new BindingSource();
        private string _selectedImagePath = string.Empty;

        public Form1()
        {
            InitializeComponent();

            // Cấu hình DataGridView
            dgvRepairs.AutoGenerateColumns = false;
            dgvRepairs.DataSource = _bindingSource;

            // Bắt sự kiện chọn dòng DataGridView & Menu CSV / Thoát
            dgvRepairs.SelectionChanged += DgvRepairs_SelectionChanged;
            if (menuExportCSV != null) menuExportCSV.Click += MenuExportCSV_Click;
            if (menuExit != null) menuExit.Click += (s, e) => Application.Exit();

            // Sửa nhanh lỗi không hiện giá trị các cột nếu lệch tên trên Designer
            FixDataGridViewColumnMapping();

            SeedSampleData();
            ApplyFilter();
        }

        private void FixDataGridViewColumnMapping()
        {
            // Đảm bảo map chính xác tên thuộc tính C# với cột trên DataGridView
            if (dgvRepairs.Columns["colId"] != null) dgvRepairs.Columns["colId"].DataPropertyName = "RepairId";
            if (dgvRepairs.Columns["colName"] != null) dgvRepairs.Columns["colName"].DataPropertyName = "CustomerName";
            if (dgvRepairs.Columns["colPhone"] != null) dgvRepairs.Columns["colPhone"].DataPropertyName = "PhoneNumber";
            if (dgvRepairs.Columns["colDevice"] != null) dgvRepairs.Columns["colDevice"].DataPropertyName = "DeviceType";
            if (dgvRepairs.Columns["colDesc"] != null) dgvRepairs.Columns["colDesc"].DataPropertyName = "ErrorDescription";
            if (dgvRepairs.Columns["colDate"] != null) dgvRepairs.Columns["colDate"].DataPropertyName = "ReceiveDate";
            if (dgvRepairs.Columns["colCost"] != null) dgvRepairs.Columns["colCost"].DataPropertyName = "EstimatedCost";
            if (dgvRepairs.Columns["colStatus"] != null) dgvRepairs.Columns["colStatus"].DataPropertyName = "Status";
        }

        private void SeedSampleData()
        {
            _allOrders.Add(new RepairOrder
            {
                RepairId = "SC001",
                CustomerName = "Nguyễn Văn Trường",
                PhoneNumber = "0987654321",
                DeviceType = "Laptop",
                ErrorDescription = "Hỏng IC nguồn, bật không lên màn hình",
                ReceiveDate = DateTime.Now.AddDays(-1),
                EstimatedCost = 1500000,
                Status = "Đang sửa",
                ImagePath = ""
            });

            _allOrders.Add(new RepairOrder
            {
                RepairId = "SC002",
                CustomerName = "Trần Thị Mai",
                PhoneNumber = "0912345678",
                DeviceType = "Điện thoại",
                ErrorDescription = "Vỡ màn hình cảm ứng, liệt vạch dưới",
                ReceiveDate = DateTime.Now,
                EstimatedCost = 850000,
                Status = "Mới tiếp nhận",
                ImagePath = ""
            });
        }

        // Đổ thông tin từ DataGridView lên các ô nhập liệu khi chọn 1 dòng
        private void DgvRepairs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRepairs.CurrentRow != null && dgvRepairs.CurrentRow.DataBoundItem is RepairOrder item)
            {
                txtId.Text = item.RepairId;
                txtName.Text = item.CustomerName;
                txtPhone.Text = item.PhoneNumber;

                if (!cboDeviceType.Items.Contains(item.DeviceType)) cboDeviceType.Items.Add(item.DeviceType);
                cboDeviceType.SelectedItem = item.DeviceType;

                txtDescription.Text = item.ErrorDescription;
                dtpReceiveDate.Value = item.ReceiveDate;
                numEstimatedCost.Value = item.EstimatedCost;

                if (!cboStatus.Items.Contains(item.Status)) cboStatus.Items.Add(item.Status);
                cboStatus.SelectedItem = item.Status;

                // Tải ảnh thiết bị
                _selectedImagePath = item.ImagePath;
                LoadImageToPictureBox(_selectedImagePath);

                txtId.ReadOnly = true; // Khóa mã đơn khi xem/sửa đơn cũ
            }
        }

        private void LoadImageToPictureBox(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        picDevice.Image = Image.FromStream(stream);
                    }
                }
                catch
                {
                    picDevice.Image = null;
                }
            }
            else
            {
                picDevice.Image = null;
            }
        }

        // Kiểm tra hợp lệ dữ liệu (Validation với ErrorProvider)
        private bool ValidateData(bool isUpdating = false)
        {
            bool isValid = true;
            errorProvider1.Clear();

            // 1. Kiểm tra Mã đơn
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                errorProvider1.SetError(txtId, "Mã đơn không được để trống!");
                isValid = false;
            }
            else if (!isUpdating && _allOrders.Any(x => x.RepairId.Equals(txtId.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtId, "Mã đơn đã tồn tại trong hệ thống!");
                isValid = false;
            }

            // 2. Tên & SĐT bắt buộc
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Tên khách hàng không được để trống!");
                isValid = false;
            }

            if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^0\d{9}$"))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0!");
                isValid = false;
            }

            // 3. Chi phí không âm
            if (numEstimatedCost.Value < 0)
            {
                errorProvider1.SetError(numEstimatedCost, "Chi phí dự kiến không được là số âm!");
                isValid = false;
            }

            // 4. Mô tả lỗi bắt buộc
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorProvider1.SetError(txtDescription, "Mô tả lỗi thiết bị không được để trống!");
                isValid = false;
            }

            return isValid;
        }

        // Lọc dữ liệu & Cập nhật thống kê chi phí trên StatusStrip
        private void ApplyFilter()
        {
            string keyword = txtSearch != null ? txtSearch.Text.Trim().ToLower() : "";
            string selectedStatus = cboFilterStatus != null ? cboFilterStatus.SelectedItem?.ToString() : "";

            var filteredList = _allOrders.Where(a =>
                (string.IsNullOrEmpty(keyword) ||
                 a.RepairId.ToLower().Contains(keyword) ||
                 a.CustomerName.ToLower().Contains(keyword) ||
                 a.PhoneNumber.Contains(keyword)) &&
                (selectedStatus == "-- Tất cả trạng thái --" || string.IsNullOrEmpty(selectedStatus) || a.Status == selectedStatus)
            ).ToList();

            _bindingSource.DataSource = new BindingList<RepairOrder>(filteredList);

            // Tính tổng chi phí dự kiến các đơn chưa hoàn tất (Khác "Hoàn tất" và "Đã hủy")
            decimal pendingCost = _allOrders
                .Where(x => x.Status != "Hoàn tất" && x.Status != "Đã hủy")
                .Sum(x => x.EstimatedCost);

            if (lblStatusCount != null)
                lblStatusCount.Text = $"Số đơn hiển thị: {filteredList.Count} / {_allOrders.Count}";

            if (lblPendingCost != null)
                lblPendingCost.Text = $" | Tổng chi phí dự kiến (Chưa hoàn tất): {pendingCost:N0} VNĐ";
        }

        private void ClearInputFields()
        {
            txtId.ReadOnly = false;
            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtDescription.Clear();
            numEstimatedCost.Value = 0;
            dtpReceiveDate.Value = DateTime.Now;

            if (cboDeviceType.Items.Count > 0) cboDeviceType.SelectedIndex = 0;
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;

            _selectedImagePath = string.Empty;
            picDevice.Image = null;

            errorProvider1.Clear();
            dgvRepairs.ClearSelection();
        }

        #region CÁC SỰ KIỆN KHỚP VỚI HÀM VISUAL STUDIO ĐÃ SINH RA

        // NÚT CHỌN ẢNH THIẾT BỊ
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn ảnh thiết bị sửa chữa";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _selectedImagePath = ofd.FileName;
                    LoadImageToPictureBox(_selectedImagePath);
                }
            }
        }

        // NÚT XÓA ẢNH
        private void btnClearImage_Click(object sender, EventArgs e)
        {
            _selectedImagePath = string.Empty;
            picDevice.Image = null;
        }

        // NÚT THÊM ĐƠN
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData(isUpdating: false)) return;

            var newItem = new RepairOrder
            {
                RepairId = txtId.Text.Trim(),
                CustomerName = txtName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                DeviceType = cboDeviceType.SelectedItem?.ToString(),
                ErrorDescription = txtDescription.Text.Trim(),
                ReceiveDate = dtpReceiveDate.Value,
                EstimatedCost = numEstimatedCost.Value,
                Status = cboStatus.SelectedItem?.ToString(),
                ImagePath = _selectedImagePath
            };

            _allOrders.Add(newItem);
            ApplyFilter();
            ClearInputFields();
            MessageBox.Show("Thêm mới đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // NÚT CẬP NHẬT ĐƠN
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRepairs.CurrentRow == null) return;
            if (!ValidateData(isUpdating: true)) return;

            string id = txtId.Text.Trim();
            var target = _allOrders.FirstOrDefault(x => x.RepairId.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (target != null)
            {
                target.CustomerName = txtName.Text.Trim();
                target.PhoneNumber = txtPhone.Text.Trim();
                target.DeviceType = cboDeviceType.SelectedItem?.ToString();
                target.ErrorDescription = txtDescription.Text.Trim();
                target.ReceiveDate = dtpReceiveDate.Value;
                target.EstimatedCost = numEstimatedCost.Value;
                target.Status = cboStatus.SelectedItem?.ToString();
                target.ImagePath = _selectedImagePath;

                ApplyFilter();
                MessageBox.Show("Cập nhật đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // NÚT XÓA ĐƠN
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRepairs.CurrentRow == null) return;

            string id = txtId.Text.Trim();
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn [{id}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var target = _allOrders.FirstOrDefault(x => x.RepairId.Equals(id, StringComparison.OrdinalIgnoreCase));
                if (target != null)
                {
                    _allOrders.Remove(target);
                    ApplyFilter();
                    ClearInputFields();
                    MessageBox.Show("Đã xóa đơn sửa chữa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // NÚT LÀM MỚI FORM
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        // CÁC SỰ KIỆN PHỤ BỎ RỖNG CỦA CÁC CONTROL
        private void picDevice_Click(object sender, EventArgs e) { }
        private void cboDeviceType_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e) { }

        // SỰ KIỆN TÌM KIẾM TỨC THỜI & LỌC TRẠNG THÁI (Đăng ký trực tiếp)
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // XUẤT TẬP TIN CSV
        private void MenuExportCSV_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = $"DonSuaChua_{DateTime.Now:yyyyMMdd_HHmmss}.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var currentList = (_bindingSource.DataSource as BindingList<RepairOrder>)?.ToList();
                        if (currentList == null || !currentList.Any())
                        {
                            MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Mã Đơn,Tên Khách Hàng,Số Điện Thoại,Loại Thiết Bị,Mô Tả Lỗi,Ngày Tiếp Nhận,Chi Phí Dự Kiến (VNĐ),Trạng Thái");

                        foreach (var item in currentList)
                        {
                            sb.AppendLine($"\"{item.RepairId}\",\"{item.CustomerName}\",\"{item.PhoneNumber}\",\"{item.DeviceType}\",\"{item.ErrorDescription}\",\"{item.ReceiveDate:dd/MM/yyyy HH:mm}\",\"{item.EstimatedCost:N0}\",\"{item.Status}\"");
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
        // 2. MODEL DỮ LIỆU ĐƠN SỬA CHỮA
        public class RepairOrder
        {
            public string RepairId { get; set; }
            public string CustomerName { get; set; }
            public string PhoneNumber { get; set; }
            public string DeviceType { get; set; }
            public string ErrorDescription { get; set; }
            public DateTime ReceiveDate { get; set; }
            public decimal EstimatedCost { get; set; }
            public string Status { get; set; }
            public string ImagePath { get; set; } // Đường dẫn file ảnh thiết bị
        }

        #endregion
    }
}