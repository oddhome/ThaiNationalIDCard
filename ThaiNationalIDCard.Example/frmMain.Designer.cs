namespace ThaiNationalIDCard.Example
{
    partial class frmMain
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("รหัสประชาชน");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("คำนำหน้า");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("ชื่อ");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("นามสกุล");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnRefreshReaderList = new System.Windows.Forms.Button();
            this.chkBoxMonitor = new System.Windows.Forms.CheckBox();
            this.cbxReaderList = new System.Windows.Forms.ComboBox();
            this.btnReadWithPhoto = new System.Windows.Forms.Button();
            this.PhotoProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbl_th_firstname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_cid = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxLog = new System.Windows.Forms.TextBox();
            this.lbLibVersion = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label_counter = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cb_tt_project_id = new System.Windows.Forms.ComboBox();
            this.btn_add_project = new System.Windows.Forms.Button();
            this.btn_send_to_sever = new System.Windows.Forms.Button();
            this.btn_delete_member = new System.Windows.Forms.Button();
            this.btn_delete_project = new System.Windows.Forms.Button();
            this.tb_mobile = new System.Windows.Forms.TextBox();
            this.btn_save_mobile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_org_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_member_type = new System.Windows.Forms.ComboBox();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefreshReaderList
            // 
            this.btnRefreshReaderList.Location = new System.Drawing.Point(922, 137);
            this.btnRefreshReaderList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefreshReaderList.Name = "btnRefreshReaderList";
            this.btnRefreshReaderList.Size = new System.Drawing.Size(160, 49);
            this.btnRefreshReaderList.TabIndex = 56;
            this.btnRefreshReaderList.Text = "Refresh reader list";
            this.btnRefreshReaderList.UseVisualStyleBackColor = true;
            this.btnRefreshReaderList.Click += new System.EventHandler(this.btnRefreshReaderList_Click_1);
            // 
            // chkBoxMonitor
            // 
            this.chkBoxMonitor.AutoSize = true;
            this.chkBoxMonitor.Location = new System.Drawing.Point(922, 722);
            this.chkBoxMonitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBoxMonitor.Name = "chkBoxMonitor";
            this.chkBoxMonitor.Size = new System.Drawing.Size(126, 24);
            this.chkBoxMonitor.TabIndex = 55;
            this.chkBoxMonitor.Text = "Auto/Monitor";
            this.chkBoxMonitor.UseVisualStyleBackColor = true;
            this.chkBoxMonitor.Visible = false;
            this.chkBoxMonitor.CheckedChanged += new System.EventHandler(this.chkBoxMonitor_CheckedChanged_1);
            // 
            // cbxReaderList
            // 
            this.cbxReaderList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxReaderList.FormattingEnabled = true;
            this.cbxReaderList.Location = new System.Drawing.Point(753, 51);
            this.cbxReaderList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbxReaderList.Name = "cbxReaderList";
            this.cbxReaderList.Size = new System.Drawing.Size(328, 28);
            this.cbxReaderList.TabIndex = 54;
            // 
            // btnReadWithPhoto
            // 
            this.btnReadWithPhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReadWithPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnReadWithPhoto.ForeColor = System.Drawing.Color.White;
            this.btnReadWithPhoto.Location = new System.Drawing.Point(753, 137);
            this.btnReadWithPhoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReadWithPhoto.Name = "btnReadWithPhoto";
            this.btnReadWithPhoto.Size = new System.Drawing.Size(160, 49);
            this.btnReadWithPhoto.TabIndex = 53;
            this.btnReadWithPhoto.Text = "Read Card";
            this.btnReadWithPhoto.UseVisualStyleBackColor = false;
            this.btnReadWithPhoto.Click += new System.EventHandler(this.btnReadWithPhoto_Click_1);
            // 
            // PhotoProgressBar1
            // 
            this.PhotoProgressBar1.Location = new System.Drawing.Point(753, 92);
            this.PhotoProgressBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PhotoProgressBar1.MarqueeAnimationSpeed = 0;
            this.PhotoProgressBar1.Name = "PhotoProgressBar1";
            this.PhotoProgressBar1.Size = new System.Drawing.Size(330, 35);
            this.PhotoProgressBar1.TabIndex = 52;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(879, 497);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lbl_th_firstname
            // 
            this.lbl_th_firstname.AutoSize = true;
            this.lbl_th_firstname.Font = new System.Drawing.Font("TH SarabunPSK", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_th_firstname.Location = new System.Drawing.Point(75, 127);
            this.lbl_th_firstname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_th_firstname.Name = "lbl_th_firstname";
            this.lbl_th_firstname.Size = new System.Drawing.Size(302, 62);
            this.lbl_th_firstname.TabIndex = 43;
            this.lbl_th_firstname.Text = "lbl_th_firstname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH SarabunPSK", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(17, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 62);
            this.label3.TabIndex = 36;
            this.label3.Text = "ชื่อ";
            // 
            // lbl_cid
            // 
            this.lbl_cid.AutoSize = true;
            this.lbl_cid.Font = new System.Drawing.Font("TH SarabunPSK", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_cid.Location = new System.Drawing.Point(416, 75);
            this.lbl_cid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cid.Name = "lbl_cid";
            this.lbl_cid.Size = new System.Drawing.Size(140, 62);
            this.lbl_cid.TabIndex = 34;
            this.lbl_cid.Text = "lbl_cid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(17, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 62);
            this.label1.TabIndex = 33;
            this.label1.Text = "รหัสประจำตัวประชาชน";
            // 
            // txtBoxLog
            // 
            this.txtBoxLog.Location = new System.Drawing.Point(141, 711);
            this.txtBoxLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxLog.Multiline = true;
            this.txtBoxLog.Name = "txtBoxLog";
            this.txtBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBoxLog.Size = new System.Drawing.Size(944, 35);
            this.txtBoxLog.TabIndex = 32;
            this.txtBoxLog.Visible = false;
            // 
            // lbLibVersion
            // 
            this.lbLibVersion.AutoSize = true;
            this.lbLibVersion.Location = new System.Drawing.Point(18, 728);
            this.lbLibVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLibVersion.Name = "lbLibVersion";
            this.lbLibVersion.Size = new System.Drawing.Size(60, 20);
            this.lbLibVersion.TabIndex = 61;
            this.lbLibVersion.Text = "label10";
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.GridLines = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(22, 195);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.ShowGroups = false;
            this.listView1.Size = new System.Drawing.Size(1063, 504);
            this.listView1.TabIndex = 63;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label_counter
            // 
            this.label_counter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_counter.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label_counter.Font = new System.Drawing.Font("TH SarabunPSK", 71.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label_counter.ForeColor = System.Drawing.Color.White;
            this.label_counter.Location = new System.Drawing.Point(1092, 14);
            this.label_counter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_counter.Name = "label_counter";
            this.label_counter.Size = new System.Drawing.Size(226, 166);
            this.label_counter.TabIndex = 64;
            this.label_counter.Text = "000";
            this.label_counter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("TH SarabunPSK", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.Location = new System.Drawing.Point(24, 6);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 31);
            this.label10.TabIndex = 65;
            this.label10.Text = "รหัสโครงการ TT :";
            // 
            // cb_tt_project_id
            // 
            this.cb_tt_project_id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tt_project_id.FormattingEnabled = true;
            this.cb_tt_project_id.Location = new System.Drawing.Point(184, 9);
            this.cb_tt_project_id.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_tt_project_id.Name = "cb_tt_project_id";
            this.cb_tt_project_id.Size = new System.Drawing.Size(248, 28);
            this.cb_tt_project_id.TabIndex = 66;
            this.cb_tt_project_id.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btn_add_project
            // 
            this.btn_add_project.Location = new System.Drawing.Point(444, 6);
            this.btn_add_project.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_add_project.Name = "btn_add_project";
            this.btn_add_project.Size = new System.Drawing.Size(112, 35);
            this.btn_add_project.TabIndex = 67;
            this.btn_add_project.Text = "Add Project";
            this.btn_add_project.UseVisualStyleBackColor = true;
            this.btn_add_project.Click += new System.EventHandler(this.btn_add_project_Click);
            // 
            // btn_send_to_sever
            // 
            this.btn_send_to_sever.Enabled = false;
            this.btn_send_to_sever.Location = new System.Drawing.Point(585, 150);
            this.btn_send_to_sever.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_send_to_sever.Name = "btn_send_to_sever";
            this.btn_send_to_sever.Size = new System.Drawing.Size(160, 35);
            this.btn_send_to_sever.TabIndex = 68;
            this.btn_send_to_sever.Text = "Send to Server";
            this.btn_send_to_sever.UseVisualStyleBackColor = true;
            this.btn_send_to_sever.Visible = false;
            this.btn_send_to_sever.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_delete_member
            // 
            this.btn_delete_member.BackColor = System.Drawing.Color.Red;
            this.btn_delete_member.Enabled = false;
            this.btn_delete_member.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_delete_member.ForeColor = System.Drawing.Color.White;
            this.btn_delete_member.Location = new System.Drawing.Point(1096, 195);
            this.btn_delete_member.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_delete_member.Name = "btn_delete_member";
            this.btn_delete_member.Size = new System.Drawing.Size(112, 35);
            this.btn_delete_member.TabIndex = 69;
            this.btn_delete_member.Text = "Delete";
            this.btn_delete_member.UseVisualStyleBackColor = false;
            this.btn_delete_member.Click += new System.EventHandler(this.btn_delete_member_Click);
            // 
            // btn_delete_project
            // 
            this.btn_delete_project.BackColor = System.Drawing.Color.Red;
            this.btn_delete_project.Enabled = false;
            this.btn_delete_project.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btn_delete_project.ForeColor = System.Drawing.Color.White;
            this.btn_delete_project.Location = new System.Drawing.Point(566, 6);
            this.btn_delete_project.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_delete_project.Name = "btn_delete_project";
            this.btn_delete_project.Size = new System.Drawing.Size(148, 35);
            this.btn_delete_project.TabIndex = 70;
            this.btn_delete_project.Text = "Delete Project";
            this.btn_delete_project.UseVisualStyleBackColor = false;
            this.btn_delete_project.Click += new System.EventHandler(this.btn_delete_project_Click);
            // 
            // tb_mobile
            // 
            this.tb_mobile.Enabled = false;
            this.tb_mobile.Location = new System.Drawing.Point(1096, 260);
            this.tb_mobile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_mobile.Name = "tb_mobile";
            this.tb_mobile.Size = new System.Drawing.Size(220, 26);
            this.tb_mobile.TabIndex = 71;
            // 
            // btn_save_mobile
            // 
            this.btn_save_mobile.Enabled = false;
            this.btn_save_mobile.Location = new System.Drawing.Point(1096, 482);
            this.btn_save_mobile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_save_mobile.Name = "btn_save_mobile";
            this.btn_save_mobile.Size = new System.Drawing.Size(222, 35);
            this.btn_save_mobile.TabIndex = 72;
            this.btn_save_mobile.Text = "Save";
            this.btn_save_mobile.UseVisualStyleBackColor = true;
            this.btn_save_mobile.Click += new System.EventHandler(this.btn_save_mobile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1096, 235);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 73;
            this.label2.Text = "เบอร์โทร";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1096, 295);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 73;
            this.label4.Text = "Email";
            // 
            // tb_email
            // 
            this.tb_email.Enabled = false;
            this.tb_email.Location = new System.Drawing.Point(1096, 320);
            this.tb_email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(220, 26);
            this.tb_email.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1096, 355);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 73;
            this.label5.Text = "หน่วยงาน";
            // 
            // tb_org_name
            // 
            this.tb_org_name.Enabled = false;
            this.tb_org_name.Location = new System.Drawing.Point(1096, 380);
            this.tb_org_name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_org_name.Name = "tb_org_name";
            this.tb_org_name.Size = new System.Drawing.Size(220, 26);
            this.tb_org_name.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1096, 415);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 73;
            this.label6.Text = "ประเภท";
            // 
            // cb_member_type
            // 
            this.cb_member_type.Enabled = false;
            this.cb_member_type.FormattingEnabled = true;
            this.cb_member_type.Location = new System.Drawing.Point(1096, 440);
            this.cb_member_type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cb_member_type.Name = "cb_member_type";
            this.cb_member_type.Size = new System.Drawing.Size(220, 28);
            this.cb_member_type.TabIndex = 74;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Enabled = false;
            this.btnExportExcel.Location = new System.Drawing.Point(753, 6);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(329, 35);
            this.btnExportExcel.TabIndex = 75;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 762);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.cb_member_type);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_save_mobile);
            this.Controls.Add(this.tb_org_name);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.tb_mobile);
            this.Controls.Add(this.btn_delete_project);
            this.Controls.Add(this.btn_delete_member);
            this.Controls.Add(this.btn_send_to_sever);
            this.Controls.Add(this.btn_add_project);
            this.Controls.Add(this.cb_tt_project_id);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_counter);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lbLibVersion);
            this.Controls.Add(this.btnRefreshReaderList);
            this.Controls.Add(this.chkBoxMonitor);
            this.Controls.Add(this.cbxReaderList);
            this.Controls.Add(this.btnReadWithPhoto);
            this.Controls.Add(this.PhotoProgressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_th_firstname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_cid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AGRITEC TT Card Reader | Build: 2019-05-30";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRefreshReaderList;
        private System.Windows.Forms.CheckBox chkBoxMonitor;
        private System.Windows.Forms.ComboBox cbxReaderList;
        private System.Windows.Forms.Button btnReadWithPhoto;
        private System.Windows.Forms.ProgressBar PhotoProgressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbl_th_firstname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_cid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxLog;
        private System.Windows.Forms.Label lbLibVersion;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label_counter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cb_tt_project_id;
        private System.Windows.Forms.Button btn_add_project;
        private System.Windows.Forms.Button btn_send_to_sever;
        private System.Windows.Forms.Button btn_delete_member;
        private System.Windows.Forms.Button btn_delete_project;
        private System.Windows.Forms.TextBox tb_mobile;
        private System.Windows.Forms.Button btn_save_mobile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_org_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_member_type;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}