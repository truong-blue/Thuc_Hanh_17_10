
namespace Bai3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTopContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInput = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cboDeviceType = new System.Windows.Forms.ComboBox();
            this.dtpReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.numEstimatedCost = new System.Windows.Forms.NumericUpDown();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.picDevice = new System.Windows.Forms.PictureBox();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.dgvRepairs = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátỨngDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPendingCost = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpTopContainer.SuspendLayout();
            this.tlpInput.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEstimatedCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairs)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpTopContainer, 0, 0);
            this.tlpMain.Controls.Add(this.dgvRepairs, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 24);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(800, 426);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpTopContainer
            // 
            this.tlpTopContainer.ColumnCount = 2;
            this.tlpTopContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.69521F));
            this.tlpTopContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.30479F));
            this.tlpTopContainer.Controls.Add(this.tlpInput, 0, 0);
            this.tlpTopContainer.Controls.Add(this.panel2, 1, 0);
            this.tlpTopContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTopContainer.Location = new System.Drawing.Point(3, 3);
            this.tlpTopContainer.Name = "tlpTopContainer";
            this.tlpTopContainer.RowCount = 2;
            this.tlpTopContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTopContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTopContainer.Size = new System.Drawing.Size(794, 254);
            this.tlpTopContainer.TabIndex = 0;
            // 
            // tlpInput
            // 
            this.tlpInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpInput.Controls.Add(this.txtDescription);
            this.tlpInput.Controls.Add(this.label8);
            this.tlpInput.Controls.Add(this.cboStatus);
            this.tlpInput.Controls.Add(this.numEstimatedCost);
            this.tlpInput.Controls.Add(this.dtpReceiveDate);
            this.tlpInput.Controls.Add(this.cboDeviceType);
            this.tlpInput.Controls.Add(this.txtPhone);
            this.tlpInput.Controls.Add(this.txtName);
            this.tlpInput.Controls.Add(this.txtId);
            this.tlpInput.Controls.Add(this.label7);
            this.tlpInput.Controls.Add(this.label6);
            this.tlpInput.Controls.Add(this.label5);
            this.tlpInput.Controls.Add(this.label4);
            this.tlpInput.Controls.Add(this.label3);
            this.tlpInput.Controls.Add(this.label2);
            this.tlpInput.Controls.Add(this.label1);
            this.tlpInput.Location = new System.Drawing.Point(3, 3);
            this.tlpInput.Name = "tlpInput";
            this.tlpTopContainer.SetRowSpan(this.tlpInput, 2);
            this.tlpInput.Size = new System.Drawing.Size(332, 248);
            this.tlpInput.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.cboFilterStatus);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnClearImage);
            this.panel2.Controls.Add(this.btnChooseImage);
            this.panel2.Controls.Add(this.picDevice);
            this.panel2.Location = new System.Drawing.Point(341, 3);
            this.panel2.Name = "panel2";
            this.tlpTopContainer.SetRowSpan(this.panel2, 2);
            this.panel2.Size = new System.Drawing.Size(450, 248);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loại thiết bị";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày tiếp nhận";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Chi phí dự kiến (VNĐ)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Trạng thái";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(124, 6);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(201, 20);
            this.txtId.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(124, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(201, 20);
            this.txtName.TabIndex = 8;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(124, 58);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(201, 20);
            this.txtPhone.TabIndex = 9;
            // 
            // cboDeviceType
            // 
            this.cboDeviceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeviceType.FormattingEnabled = true;
            this.cboDeviceType.Items.AddRange(new object[] {
            "Điện thoại",
            "Laptop",
            "Máy tính bảng",
            "PC/Desktop",
            "Thiết bị khác"});
            this.cboDeviceType.Location = new System.Drawing.Point(124, 84);
            this.cboDeviceType.Name = "cboDeviceType";
            this.cboDeviceType.Size = new System.Drawing.Size(201, 21);
            this.cboDeviceType.TabIndex = 10;
            this.cboDeviceType.SelectedIndexChanged += new System.EventHandler(this.cboDeviceType_SelectedIndexChanged);
            // 
            // dtpReceiveDate
            // 
            this.dtpReceiveDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceiveDate.Location = new System.Drawing.Point(125, 113);
            this.dtpReceiveDate.Name = "dtpReceiveDate";
            this.dtpReceiveDate.Size = new System.Drawing.Size(200, 20);
            this.dtpReceiveDate.TabIndex = 11;
            // 
            // numEstimatedCost
            // 
            this.numEstimatedCost.Location = new System.Drawing.Point(125, 145);
            this.numEstimatedCost.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numEstimatedCost.Name = "numEstimatedCost";
            this.numEstimatedCost.Size = new System.Drawing.Size(200, 20);
            this.numEstimatedCost.TabIndex = 12;
            this.numEstimatedCost.ThousandsSeparator = true;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Mới tiếp nhận",
            "Đang sửa",
            "Chờ linh kiện",
            "Hoàn tất",
            "Đã hủy"});
            this.cboStatus.Location = new System.Drawing.Point(124, 171);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(201, 21);
            this.cboStatus.TabIndex = 13;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Mô tả lỗi";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(124, 200);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(201, 16);
            this.txtDescription.TabIndex = 15;
            // 
            // picDevice
            // 
            this.picDevice.Location = new System.Drawing.Point(18, 9);
            this.picDevice.Name = "picDevice";
            this.picDevice.Size = new System.Drawing.Size(197, 191);
            this.picDevice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDevice.TabIndex = 0;
            this.picDevice.TabStop = false;
            this.picDevice.Click += new System.EventHandler(this.picDevice_Click);
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Location = new System.Drawing.Point(18, 206);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(75, 23);
            this.btnChooseImage.TabIndex = 1;
            this.btnChooseImage.Text = "Chọn ảnh";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // btnClearImage
            // 
            this.btnClearImage.Location = new System.Drawing.Point(140, 206);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(75, 23);
            this.btnClearImage.TabIndex = 2;
            this.btnClearImage.Text = "Xóa ảnh";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(233, 164);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(356, 164);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(233, 206);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(356, 206);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Làm mới";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Tìm kiếm";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(285, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(146, 20);
            this.txtSearch.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(238, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Lọc";
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Items.AddRange(new object[] {
            "-- Tất cả trạng thái --",
            "Mới tiếp nhận",
            "Đang sửa",
            "Chờ linh kiện",
            "Hoàn tất",
            "Đã hủy"});
            this.cboFilterStatus.Location = new System.Drawing.Point(285, 39);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(146, 21);
            this.cboFilterStatus.TabIndex = 10;
            // 
            // dgvRepairs
            // 
            this.dgvRepairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepairs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colPhone,
            this.colDevice,
            this.colDesc,
            this.colDate,
            this.colCost,
            this.colStatus});
            this.dgvRepairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRepairs.Location = new System.Drawing.Point(3, 263);
            this.dgvRepairs.Name = "dgvRepairs";
            this.dgvRepairs.ReadOnly = true;
            this.dgvRepairs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRepairs.Size = new System.Drawing.Size(794, 160);
            this.dgvRepairs.TabIndex = 1;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "RepairId";
            this.colId.HeaderText = "Mã đơn";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 80;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "CustomerName";
            this.colName.HeaderText = "Tên khách hàng";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 130;
            // 
            // colPhone
            // 
            this.colPhone.DataPropertyName = "PhoneNumber";
            this.colPhone.HeaderText = "Số điện thoại";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colDevice
            // 
            this.colDevice.DataPropertyName = "DeviceType";
            this.colDevice.HeaderText = "Loại thiết bị";
            this.colDevice.Name = "colDevice";
            this.colDevice.ReadOnly = true;
            // 
            // colDesc
            // 
            this.colDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDesc.DataPropertyName = "ErrorDescription";
            this.colDesc.HeaderText = "Mô tả lỗi";
            this.colDesc.Name = "colDesc";
            this.colDesc.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "ReceiveDate";
            this.colDate.HeaderText = "Ngày tiếp nhận";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colCost
            // 
            this.colCost.DataPropertyName = "EstimatedCost";
            this.colCost.HeaderText = "Chi phí dự kiến";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Trạng thái";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 110;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuExit
            // 
            this.menuExit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExportCSV,
            this.thoátỨngDụngToolStripMenuItem});
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(69, 20);
            this.menuExit.Text = "Hệ thống";
            // 
            // menuExportCSV
            // 
            this.menuExportCSV.Name = "menuExportCSV";
            this.menuExportCSV.Size = new System.Drawing.Size(180, 22);
            this.menuExportCSV.Text = "Xuất sang CSV";
            
            // 
            // thoátỨngDụngToolStripMenuItem
            // 
            this.thoátỨngDụngToolStripMenuItem.Name = "thoátỨngDụngToolStripMenuItem";
            this.thoátỨngDụngToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.thoátỨngDụngToolStripMenuItem.Text = "Thoát ứng dụng";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusCount,
            this.lblPendingCost});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusCount
            // 
            this.lblStatusCount.Name = "lblStatusCount";
            this.lblStatusCount.Size = new System.Drawing.Size(116, 17);
            this.lblStatusCount.Text = "Số đơn hiển thị: 0 / 0";
            // 
            // lblPendingCost
            // 
            this.lblPendingCost.Name = "lblPendingCost";
            this.lblPendingCost.Size = new System.Drawing.Size(246, 17);
            this.lblPendingCost.Text = "| Tổng chi phí dự kiến (Chưa hoàn tất): 0 VNĐ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Repair Service Tracker";
            this.tlpMain.ResumeLayout(false);
            this.tlpTopContainer.ResumeLayout(false);
            this.tlpInput.ResumeLayout(false);
            this.tlpInput.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEstimatedCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairs)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpTopContainer;
        private System.Windows.Forms.Panel tlpInput;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.NumericUpDown numEstimatedCost;
        private System.Windows.Forms.DateTimePicker dtpReceiveDate;
        private System.Windows.Forms.ComboBox cboDeviceType;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picDevice;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.DataGridView dgvRepairs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuExportCSV;
        private System.Windows.Forms.ToolStripMenuItem thoátỨngDụngToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusCount;
        private System.Windows.Forms.ToolStripStatusLabel lblPendingCost;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

