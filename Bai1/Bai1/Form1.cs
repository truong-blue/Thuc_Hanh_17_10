using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bai1
{

    // 1. LOGIC BÊN TRONG FORM
    public partial class Form1 : Form
    {
        private BindingList<Appointment> _allAppointments = new BindingList<Appointment>();
        private BindingSource _bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();

            // Cấu hình DataGridView dùng BindingSource
            dgvAppointments.AutoGenerateColumns = false;
            dgvAppointments.DataSource = _bindingSource;

            // Đăng ký sự kiện lọc và chọn dòng
            txtSearch.TextChanged += (s, e) => ApplyFilter();
            dtpFilterDate.ValueChanged += (s, e) => ApplyFilter();
            dgvAppointments.SelectionChanged += DgvAppointments_SelectionChanged;

            SeedSampleData();
            ApplyFilter();
        }

        private void SeedSampleData()
        {
            _allAppointments.Add(new Appointment
            {
                AppointmentId = "LH001",
                PatientName = "Nguyễn Văn Trường",
                PhoneNumber = "0987654321",
                AppointmentDate = DateTime.Now.AddDays(1),
                DoctorName = "BS. Nguyễn Văn A",
                Reason = "Khám răng định kỳ",
                Status = "Chờ khám"
            });
            _allAppointments.Add(new Appointment
            {
                AppointmentId = "LH002",
                PatientName = "Trần Thị Mai",
                PhoneNumber = "0912345678",
                AppointmentDate = DateTime.Now.AddHours(3),
                DoctorName = "BS. Trần Thị B",
                Reason = "Tái khám tai mũi họng",
                Status = "Đang khám"
            });
        }

        // Đổ dữ liệu từ DataGridView lên các ô nhập liệu khi nhấp chọn dòng
        private void DgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow != null && dgvAppointments.CurrentRow.DataBoundItem is Appointment item)
            {
                txtId.Text = item.AppointmentId;
                txtName.Text = item.PatientName;
                txtPhone.Text = item.PhoneNumber;
                dtpAppointmentDate.Value = item.AppointmentDate > dtpAppointmentDate.MinDate ? item.AppointmentDate : DateTime.Now;
                txtReason.Text = item.Reason;

                // Tự động kiểm tra và gán Bác sĩ (tránh bị trống)
                if (!string.IsNullOrEmpty(item.DoctorName))
                {
                    if (!cboDoctor.Items.Contains(item.DoctorName))
                        cboDoctor.Items.Add(item.DoctorName);
                    cboDoctor.SelectedItem = item.DoctorName;
                }

                // Tự động kiểm tra và gán Trạng thái (tránh bị trống)
                if (!string.IsNullOrEmpty(item.Status))
                {
                    if (!cboStatus.Items.Contains(item.Status))
                        cboStatus.Items.Add(item.Status);
                    cboStatus.SelectedItem = item.Status;
                }

                // Khóa ô Mã khi đang chọn dòng có sẵn
                txtId.ReadOnly = true;
            }
        }

        // Hàm kiểm tra hợp lệ (Validation với ErrorProvider)
        private bool ValidateData(bool isUpdating = false)
        {
            bool isValid = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                errorProvider1.SetError(txtId, "Mã lịch hẹn không được để trống!");
                isValid = false;
            }
            else if (!isUpdating && _allAppointments.Any(x => x.AppointmentId.Equals(txtId.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                errorProvider1.SetError(txtId, "Mã lịch hẹn đã tồn tại!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Tên bệnh nhân không được để trống!");
                isValid = false;
            }

            if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^0\d{9}$"))
            {
                errorProvider1.SetError(txtPhone, "Số điện thoại phải gồm 10 chữ số, bắt đầu bằng 0!");
                isValid = false;
            }

            if (dtpAppointmentDate.Value < DateTime.Now.AddMinutes(-5))
            {
                errorProvider1.SetError(dtpAppointmentDate, "Ngày hẹn không được thuộc về quá khứ!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                errorProvider1.SetError(txtReason, "Lý do khám không được để trống!");
                isValid = false;
            }

            return isValid;
        }

        // Hàm xử lý lọc dữ liệu tức thời
        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cboFilterStatus.SelectedItem?.ToString();
            bool isDateFiltered = chkFilterByDate.Checked;
            DateTime filterDate = dtpFilterDate.Value.Date;

            var filteredList = _allAppointments.Where(a =>
                (string.IsNullOrEmpty(keyword) || a.PatientName.ToLower().Contains(keyword) || a.PhoneNumber.Contains(keyword)) &&
                (!isDateFiltered || a.AppointmentDate.Date == filterDate) &&
                (selectedStatus == "-- Tất cả trạng thái --" || string.IsNullOrEmpty(selectedStatus) || a.Status == selectedStatus)
            ).ToList();

            _bindingSource.DataSource = new BindingList<Appointment>(filteredList);
            lblStatusCount.Text = $"Tổng số lịch hẹn sau khi lọc: {filteredList.Count} / {_allAppointments.Count}";
        }

        private void ClearInputFields()
        {
            txtId.ReadOnly = false; // Mở khóa ô Mã để nhập mới
            txtId.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtReason.Clear();
            dtpAppointmentDate.Value = DateTime.Now.AddHours(1);

            if (cboDoctor.Items.Count > 0) cboDoctor.SelectedIndex = 0;
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;

            errorProvider1.Clear();
            dgvAppointments.ClearSelection(); // Bỏ chọn dòng trên DataGridView
        }

        #region CÁC SỰ KIỆN NÚT BẤM VÀ CONTROL

        // NÚT THÊM MỚI (Lưu ý: Nếu nút trên Designer tên button1_Click)
        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateData(isUpdating: false)) return;

            var newItem = new Appointment
            {
                AppointmentId = txtId.Text.Trim(),
                PatientName = txtName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                AppointmentDate = dtpAppointmentDate.Value,
                DoctorName = cboDoctor.SelectedItem?.ToString(),
                Reason = txtReason.Text.Trim(),
                Status = cboStatus.SelectedItem?.ToString()
            };

            _allAppointments.Add(newItem);
            ApplyFilter();
            ClearInputFields();
            MessageBox.Show("Thêm mới lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // NÚT CẬP NHẬT
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null) return;
            if (!ValidateData(isUpdating: true)) return;

            string id = txtId.Text.Trim();
            var target = _allAppointments.FirstOrDefault(x => x.AppointmentId.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (target != null)
            {
                target.PatientName = txtName.Text.Trim();
                target.PhoneNumber = txtPhone.Text.Trim();
                target.AppointmentDate = dtpAppointmentDate.Value;
                target.DoctorName = cboDoctor.SelectedItem?.ToString();
                target.Reason = txtReason.Text.Trim();
                target.Status = cboStatus.SelectedItem?.ToString();

                ApplyFilter();
                MessageBox.Show("Cập nhật thông tin lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // NÚT XÓA LỊCH HẸN
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentRow == null) return;

            string id = txtId.Text.Trim();
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa lịch hẹn [{id}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var target = _allAppointments.FirstOrDefault(x => x.AppointmentId.Equals(id, StringComparison.OrdinalIgnoreCase));
                if (target != null)
                {
                    _allAppointments.Remove(target);
                    ApplyFilter();
                    ClearInputFields();
                    MessageBox.Show("Đã xóa lịch hẹn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // NÚT LÀM MỚI FORM
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }

        // SỰ KIỆN LỌC THEO TRẠNG THÁI
        private void cboFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // SỰ KIỆN TÍCH BẬT/TẮT LỌC THEO NGÀY
        private void chkFilterByDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpFilterDate.Enabled = chkFilterByDate.Checked;
            ApplyFilter();
        }

        // CÁC SỰ KIỆN PHỤ (Có thể để rỗng)
        private void tlpInput_Paint(object sender, PaintEventArgs e) { }
        private void tlpMain_Paint(object sender, PaintEventArgs e) { }
        private void cboDoctor_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        // SỰ KIỆN MENU XUẤT CSV
        private void menuExportCSV_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv", FileName = $"LichHen_{DateTime.Now:yyyyMMdd_HHmmss}.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var currentDisplayedList = (_bindingSource.DataSource as BindingList<Appointment>)?.ToList();
                        if (currentDisplayedList == null || !currentDisplayedList.Any())
                        {
                            MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Mã Lịch Hẹn,Họ Tên Bệnh Nhân,Số Điện Thoại,Ngày Giờ Hẹn,Bác Sĩ,Lý Do Khám,Trạng Thái");

                        foreach (var item in currentDisplayedList)
                        {
                            sb.AppendLine($"\"{item.AppointmentId}\",\"{item.PatientName}\",\"{item.PhoneNumber}\",\"{item.AppointmentDate:dd/MM/yyyy HH:mm}\",\"{item.DoctorName}\",\"{item.Reason}\",\"{item.Status}\"");
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

        // 1. MODEL DỮ LIỆU LỊCH HẸN
        public class Appointment
        {
            public string AppointmentId { get; set; }
            public string PatientName { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string DoctorName { get; set; }
            public string Reason { get; set; }
            public string Status { get; set; }
        }

        #endregion
    }
}