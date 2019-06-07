using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace ThaiNationalIDCard.Example
{
    
    public partial class frmMain : Form
    {
        private ThaiIDCard idcard;
        public frmMain()
        {
            InitializeComponent();
        }

        public void Log(string text = "")
        {
            if (txtBoxLog.InvokeRequired)
            {
                txtBoxLog.BeginInvoke(new MethodInvoker(delegate { txtBoxLog.AppendText(text); }));
            }
            else
            {
                txtBoxLog.AppendText(text);
            }
        }

        public void LogLine(string text = "")
        {
            if (txtBoxLog.InvokeRequired)
            {
                txtBoxLog.BeginInvoke(new MethodInvoker(delegate { txtBoxLog.AppendText(text + Environment.NewLine); }));
            }
            else
            {
                txtBoxLog.AppendText(text + Environment.NewLine);
            }
        }



        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_cid.Text = "Reading...";
                //Refresh();
     
                Personal personal = idcard.readAll();
                if (personal != null)
                {
                    lbl_cid.Text = personal.Citizenid;
                    AddDatabase(personal);
                }
                else if (idcard.ErrorCode() > 0)
                {
                    MessageBox.Show(idcard.Error());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void photoProgress(int value, int maximum)
        {
            if (txtBoxLog.InvokeRequired)
            {
                if (PhotoProgressBar1.Maximum != maximum)
                    PhotoProgressBar1.BeginInvoke(new MethodInvoker(delegate { PhotoProgressBar1.Maximum = maximum; }));

                // fix progress bar sync.
                if (PhotoProgressBar1.Maximum > value)
                    PhotoProgressBar1.BeginInvoke(new MethodInvoker(delegate { PhotoProgressBar1.Value = value + 1; }));

                PhotoProgressBar1.BeginInvoke(new MethodInvoker(delegate { PhotoProgressBar1.Value = value; }));
            }
            else
            {
                if (PhotoProgressBar1.Maximum != maximum)
                    PhotoProgressBar1.Maximum = maximum;

                // fix progress bar sync.
                if (PhotoProgressBar1.Maximum > value)
                    PhotoProgressBar1.Value = value + 1;

                PhotoProgressBar1.Value = value;
            }

            //Refresh();
        }

        public void refreshMemberType()
        {
            cb_member_type.Items.Clear();

            //Connect to DB
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }


            //Query
            string strAccessSelect = "SELECT * FROM tbl_tt_member_type ORDER BY member_type ASC";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "Members");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }

            // A dataset can contain multiple tables, so let's get them
            // all into an array:
            DataTableCollection dta = myDataSet.Tables;
            if (dta.Count > 0)
            {
                DataColumnCollection drc = myDataSet.Tables["Members"].Columns;
                DataRowCollection dra = myDataSet.Tables["Members"].Rows;
                //label_counter.Text = dra.Count.ToString();
                foreach (DataRow dr in dra)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = dr["member_type"].ToString();
                    item.Value = dr["member_type"];

                    cb_member_type.Items.Add(item);
                }
            }
        }

        public void refreshMobile(int id)
        {
            tb_mobile.Text = "";
            tb_email.Text = "";
            tb_org_name.Text = "";
            cb_member_type.Text = "";
            refreshMemberType();

            //Connect to DB
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }


            //Query
            string strAccessSelect = "SELECT * FROM tbl_tt_members WHERE ID = " + id + " ORDER BY ID DESC";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "Members");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }

            // A dataset can contain multiple tables, so let's get them
            // all into an array:
            DataTableCollection dta = myDataSet.Tables;
            if (dta.Count > 0)
            {
                DataColumnCollection drc = myDataSet.Tables["Members"].Columns;
                DataRowCollection dra = myDataSet.Tables["Members"].Rows;
                //label_counter.Text = dra.Count.ToString();
                foreach (DataRow dr in dra)
                {
                    tb_mobile.Text = dr["mobile"].ToString();
                    tb_email.Text = dr["email"].ToString();
                    tb_org_name.Text = dr["org_name"].ToString();
                    cb_member_type.Text = dr["member_type"].ToString();
                }
            }
            


        }

        public void refreshProject()
        {
            cb_tt_project_id.Items.Clear();
            cb_tt_project_id.Text = "";
            //Connect to DB
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }


            //Query
            string strAccessSelect = "SELECT * FROM tbl_tt_project_id ORDER BY ID DESC";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "TT_Project");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }

            // A dataset can contain multiple tables, so let's get them
            // all into an array:
            DataTableCollection dta = myDataSet.Tables;
            DataColumnCollection drc = myDataSet.Tables["TT_Project"].Columns;
            DataRowCollection dra = myDataSet.Tables["TT_Project"].Rows;
            label_counter.Text = dra.Count.ToString();
            foreach (DataRow dr in dra)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = dr[1].ToString();
                item.Value = dr[0];

                cb_tt_project_id.Items.Add(item);
            }

            if (cb_tt_project_id.Items.Count > 0)
            {
                cb_tt_project_id.SelectedIndex = 0;
                btnExportExcel.Enabled = true;
            }
            else
            {
                btnExportExcel.Enabled = false;
            }
        }

        public void refreshList(string tt_project_id)
        {
            listView1.Items.Clear();

            
            //Connect to DB
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }


            //Query
            string strAccessSelect = "SELECT * FROM tbl_tt_members WHERE tt_project_id = '" + tt_project_id + "' ORDER BY ID DESC";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "Members");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }

            // A dataset can contain multiple tables, so let's get them
            // all into an array:
            DataTableCollection dta = myDataSet.Tables;
            DataColumnCollection drc = myDataSet.Tables["Members"].Columns;
            DataRowCollection dra = myDataSet.Tables["Members"].Rows;
            label_counter.Text = dra.Count.ToString();
            foreach (DataRow dr in dra)
            {
                string[] row = {
                    dr["ID"].ToString(),
                    dr["pid"].ToString(),
                    dr["th_title"].ToString(),
                    dr["th_fname"].ToString(),
                    dr["th_lname"].ToString(),
                    dr["mobile"].ToString(),
                    dr["email"].ToString(),
                    dr["org_name"].ToString(),
                    dr["member_type"].ToString(),
                };
                ListViewItem lvi = new ListViewItem(row);
                listView1.Items.Add(lvi);
            }
        }

        public void AddDatabase(Personal personal)
        {
            //Read Card to DB
            //Connect to DB
            //if (comboBox1.Text == "") return;

            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }

            OleDbCommand sql = new OleDbCommand();
            sql.CommandType = CommandType.Text;
            sql.CommandText = "INSERT INTO tbl_tt_members (tt_project_id,pid,birthday,sex,th_title,th_fname,th_lname,en_title,en_fname,en_lname,issue,expire,address,address_number,address_moo,address_lane,address_road,address_tambon,address_amphur,address_province) VALUES ('" +
                cb_tt_project_id.Text + "','" +
                personal.Citizenid + "','";
            try
            {
                sql.CommandText = sql.CommandText + personal.Birthday.ToString("yyyy-MM-dd") + "',";
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                sql.CommandText = sql.CommandText + personal.Issue.ToString("yyyy-MM-dd") + "','";
            }
            
            sql.CommandText = sql.CommandText +
                personal.Sex + ",'" +
                personal.Th_Prefix + "','" +
                personal.Th_Firstname + "','" +
                personal.Th_Lastname + "','" +
                personal.En_Prefix + "','" +
                personal.En_Firstname + "','" +
                personal.En_Lastname + "','" +
                personal.Issue.ToString("yyyy-MM-dd") + "','";
            try
            {
                sql.CommandText = sql.CommandText + personal.Expire.ToString("yyyy-MM-dd") + "','";
            }
            catch ( Exception e )
            {
                Console.WriteLine("{0} Exception caught.", e);
                sql.CommandText = sql.CommandText + personal.Issue.ToString("yyyy-MM-dd") + "','";
            }
            sql.CommandText = sql.CommandText +
                personal.Address + "','" +
                personal.addrHouseNo + "','" +
                personal.addrVillageNo + "','" +
                personal.addrLane + "','" +
                personal.addrRoad + "','" +
                personal.addrTambol + "','" +
                personal.addrAmphur + "','" +
                personal.addrProvince + "');";

            sql.Connection = myAccessConn;
            myAccessConn.Open();
            Console.WriteLine(sql.CommandText);
            sql.ExecuteNonQuery();
            myAccessConn.Close();

            refreshList(cb_tt_project_id.Text);
        }


        public void CardInserted(Personal personal)
        {
            if (personal == null)
                return;
            //lbl_cid.BeginInvoke(new MethodInvoker(delegate { lbl_cid.Text = personal.Citizenid; }));
            //lbl_birthday.BeginInvoke(new MethodInvoker(delegate { lbl_birthday.Text = personal.Birthday.ToString("dd/MM/yyyy"); }));
            //lbl_sex.BeginInvoke(new MethodInvoker(delegate { lbl_sex.Text = personal.Sex; }));
            //lbl_th_prefix.BeginInvoke(new MethodInvoker(delegate { lbl_th_prefix.Text = personal.Th_Prefix; }));
            //lbl_th_firstname.BeginInvoke(new MethodInvoker(delegate { lbl_th_firstname.Text = personal.Th_Firstname; }));
            //lbl_th_lastname.BeginInvoke(new MethodInvoker(delegate { lbl_th_lastname.Text = personal.Th_Lastname; }));
            //lbl_en_prefix.BeginInvoke(new MethodInvoker(delegate { lbl_en_prefix.Text = personal.En_Prefix; }));
            //lbl_en_firstname.BeginInvoke(new MethodInvoker(delegate { lbl_en_firstname.Text = personal.En_Firstname; }));
            //lbl_en_lastname.BeginInvoke(new MethodInvoker(delegate { lbl_en_lastname.Text = personal.En_Lastname; }));
            //lbl_issue.BeginInvoke(new MethodInvoker(delegate { lbl_issue.Text = personal.Issue.ToString("dd/MM/yyyy"); }));
            //lbl_expire.BeginInvoke(new MethodInvoker(delegate { lbl_expire.Text = personal.Expire.ToString("dd/MM/yyyy"); }));
            //pictureBox1.BeginInvoke(new MethodInvoker(delegate { pictureBox1.Image = personal.PhotoBitmap; }));

            //btnReadWithPhoto.PerformClick();

            //AddDatabase(personal);
        }

        private void btnReadWithPhoto_Click_1(object sender, EventArgs e)
        {
            
            lbl_cid.Text = "Reading...";
            Refresh();
            idcard.eventPhotoProgress += new handlePhotoProgress(photoProgress);
            Personal personal = idcard.readAllPhoto();
            if (personal != null)
            {
                lbl_cid.Text = personal.Citizenid;
                pictureBox1.Image = personal.PhotoBitmap;

                AddDatabase(personal);
                string picture_path = Environment.CurrentDirectory + "\\" + personal.Citizenid + ".jpg";

                String picture_name = personal.Citizenid + ".jpg";
                try
                {
                    var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(bitmap, pictureBox1.ClientRectangle);
                    bitmap.Save(picture_name, ImageFormat.Jpeg);

                }
                catch (Exception _Exception)
                {
                    // Error
                    Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
                }
            }
            else if (idcard.ErrorCode() > 0)
            {
                MessageBox.Show(idcard.Error());
            }
        }

        private void btnRefreshReaderList_Click_1(object sender, EventArgs e)
        {
            cbxReaderList.Items.Clear();
            cbxReaderList.SelectedIndex = -1;
            cbxReaderList.SelectedText = String.Empty;
            cbxReaderList.Text = string.Empty;
            cbxReaderList.Refresh();

            try
            {
                ThaiIDCard idcard = new ThaiIDCard();
                string[] readers = idcard.GetReaders();

                if (readers == null) return;


                foreach (string r in readers)
                {
                    cbxReaderList.Items.Add(r);
                }
                //cbxReaderList.DroppedDown = true;
                cbxReaderList.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void chkBoxMonitor_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkBoxMonitor.Checked)
            {
                if (cbxReaderList.SelectedItem == null)
                {
                    MessageBox.Show("No reader select to monitoring.");
                    chkBoxMonitor.Checked = false;
                    return;
                }
                idcard.MonitorStart(cbxReaderList.SelectedItem.ToString());
                idcard.eventCardInsertedWithPhoto += new handleCardInserted(CardInserted);
                idcard.eventPhotoProgress += new handlePhotoProgress(photoProgress);

            }
            else
            {
                if (cbxReaderList.SelectedItem != null)
                    idcard.MonitorStop(cbxReaderList.SelectedItem.ToString());
            }
        }

        public void refreshSendButton()
        {
            if (PingHost("www.nnr.nstda.or.th", 80) == true)
            {
                btn_send_to_sever.Enabled = true;
            }
            else
            {
                btn_send_to_sever.Enabled = false;
            }
        }

        private System.Windows.Forms.Timer timer1;
        private void frmMain_Load(object sender, EventArgs e)
        {
            idcard = new ThaiIDCard();
            lbLibVersion.Text = "LibThaiIDCard version: " + idcard.Version();

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();

            refreshProject();
            refreshList(cb_tt_project_id.Text);

            clearDefault();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshSendButton();
        }

        public void clearDefault()
        {
            lbl_cid.Text = "";
            lbl_th_firstname.Text = "";
            
            btnRefreshReaderList.PerformClick();

            int max_width = listView1.Width;

            //init column
            listView1.Columns.Add("ID");
            listView1.Columns.Add("รหัสประชาชน");
            listView1.Columns.Add("คำนำหน้า");
            listView1.Columns.Add("ชื่อ");
            listView1.Columns.Add("นามสกุล");
            listView1.Columns.Add("เบอร์โทร");
            listView1.Columns.Add("Email");
            listView1.Columns.Add("หน่วยงาน");
            listView1.Columns.Add("ประเภท");

            double column_width = 0;
            listView1.Columns[0].Width = 40;
            listView1.Columns[1].Width = 80;
            listView1.Columns[2].Width = 40;
            listView1.Columns[3].Width = 80;
            listView1.Columns[4].Width = 80;
            listView1.Columns[5].Width = 80;
            listView1.Columns[6].Width = 80;
            listView1.Columns[7].Width = 80;
            listView1.Columns[8].Width = 80;
            //chkBoxMonitor.Checked = true;
        }


        private void btn_add_project_Click(object sender, EventArgs e)
        {
            string tt_project_id = Prompt.ShowDialog("กรุณาระบุรหัสโครงการ !", "กรุณากรอกโดยระวัง");

            if (tt_project_id == "")
            {
                return;
            }


            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }

            OleDbCommand sql = new OleDbCommand();
            sql.CommandType = CommandType.Text;
            sql.CommandText = "INSERT INTO tbl_tt_project_id ([tt_project_id]) VALUES (?);";
            sql.Parameters.AddWithValue("@tt_project_id", tt_project_id);

            sql.Connection = myAccessConn;
            myAccessConn.Open();
            sql.ExecuteNonQuery();
            myAccessConn.Close();
            refreshProject();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshList(cb_tt_project_id.Text);

            if (label_counter.Text == "0")
            {
                btn_delete_project.Enabled = true;
            }
            else
            {
                btn_delete_project.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_send_to_sever.Enabled = false;
            //Connect to DB
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }


            //Query
            string strAccessSelect = "SELECT * FROM tbl_tt_members WHERE tt_project_id = '" + cb_tt_project_id.Text + "' ORDER BY ID DESC";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "Members");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }

            // A dataset can contain multiple tables, so let's get them
            // all into an array:
            DataTableCollection dta = myDataSet.Tables;
            DataColumnCollection drc = myDataSet.Tables["Members"].Columns;
            DataRowCollection dra = myDataSet.Tables["Members"].Rows;
            label_counter.Text = dra.Count.ToString();
            foreach (DataRow dr in dra)
            {
                //Send to Server
                String url = "https://www.nnr.nstda.or.th/agritec_portal/tt_project/save_id_card/" + cb_tt_project_id.Text + "/" + dr["pid"];
                String Response;
                Response = postHtml(url, "birthday", dr["birthday"].ToString());
                Response = postHtml(url, "sex", dr["sex"].ToString());
                Response = postHtml(url, "title_name_th", dr["th_title"].ToString());
                Response = postHtml(url, "fname_th", dr["th_fname"].ToString());
                Response = postHtml(url, "lname_th", dr["th_lname"].ToString());
                Response = postHtml(url, "title_name_en", dr["en_title"].ToString());
                Response = postHtml(url, "fname_en", dr["en_fname"].ToString());
                Response = postHtml(url, "lname_en", dr["en_lname"].ToString());
                Response = postHtml(url, "issue_date", dr["issue"].ToString());
                Response = postHtml(url, "expire_date", dr["expire"].ToString());
                Response = postHtml(url, "address", dr["address"].ToString());
                Response = postHtml(url, "address_number", dr["address_number"].ToString());
                Response = postHtml(url, "moo", dr["address_moo"].ToString());
                Response = postHtml(url, "lane_name", dr["address_lane"].ToString());
                Response = postHtml(url, "road_name", dr["address_road"].ToString());
                Response = postHtml(url, "tambon_name", dr["address_tambon"].ToString());
                Response = postHtml(url, "city_name", dr["address_amphur"].ToString());
                Response = postHtml(url, "province_name", dr["address_province"].ToString());
                Response = postHtml(url, "mobile", dr["mobile"].ToString());
                Response = postHtml(url, "email", dr["email"].ToString());
                Response = postHtml(url, "org_name", dr["org_name"].ToString());
                Response = postHtml(url, "member_type", dr["member_type"].ToString());

                //send picture to server
                //save picture
                String picture_name = dr["pid"].ToString() + ".jpg";

                url = "https://www.nnr.nstda.or.th/agritec_portal/tt_project/save_id_card_img/" + dr["pid"].ToString();
                String[] filename = new string[1] { picture_name };
                Response = PostMultipleFiles(url, filename);
            }
            btn_send_to_sever.Enabled = true;
            MessageBox.Show("Send Members to Server Successful");
        }

        public String PostMultipleFiles(string url, string[] files)
        {
            string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "multipart/form-data; boundary=" + boundary;
            httpWebRequest.Method = "POST";
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
            Stream memStream = new System.IO.MemoryStream();
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
            string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition:  form-data; name=\"{0}\";\r\n\r\n{1}";
            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n Content-Type: application/octet-stream\r\n\r\n";
            memStream.Write(boundarybytes, 0, boundarybytes.Length);
            for (int i = 0; i < files.Length; i++)
            {
                string header = string.Format(headerTemplate, "file" + i, files[i]);
                //string header = string.Format(headerTemplate, "uplTheFile", files[i]);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                memStream.Write(headerbytes, 0, headerbytes.Length);
                FileStream fileStream = new FileStream(files[i], FileMode.Open,
                FileAccess.Read);
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStream.Write(buffer, 0, bytesRead);
                }
                memStream.Write(boundarybytes, 0, boundarybytes.Length);
                fileStream.Close();
            }
            httpWebRequest.ContentLength = memStream.Length;
            Stream requestStream = httpWebRequest.GetRequestStream();
            memStream.Position = 0;
            byte[] tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();
            requestStream.Write(tempBuffer, 0, tempBuffer.Length);
            requestStream.Close();
            try
            {
                WebResponse webResponse = httpWebRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string var = reader.ReadToEnd();
                return var;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            httpWebRequest = null;
        }

        private String postHtml(string url, string field_name, string field_value)
        {
            url = url + "/" + field_name;
            string myParameters = "field_value=" + field_value;
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                byte[] byteArray = Encoding.UTF8.GetBytes(myParameters);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                //using (HttpClient client = new HttpClient());

                //Console.WriteLine(HtmlResult);
                return ((HttpWebResponse)response).StatusDescription;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static bool PingHost(string _HostURI, int _PortNumber)
        {
            try
            {
                TcpClient client = new TcpClient(_HostURI, _PortNumber);
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error pinging host:'" + _HostURI + ":" + _PortNumber.ToString() + "'");
                return false;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                btn_delete_member.Enabled = true;
                tb_mobile.Enabled = true;
                tb_email.Enabled = true;
                tb_org_name.Enabled = true;
                cb_member_type.Enabled = true;
                btn_save_mobile.Enabled = true;

                //Load Mobile
                refreshMobile(Int32.Parse(listView1.SelectedItems[0].Text.ToString()));
            }
            else
            {
                btn_delete_member.Enabled = false;
                clearEditField();
            }
        }

        private void btn_delete_member_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            //Connect to DB
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }


            //Query
            string strAccessSelect = "DELETE FROM tbl_tt_members WHERE ID = " + listView1.SelectedItems[0].Text;

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "TT_Project");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }

            btn_delete_member.Enabled = false;
            refreshList(cb_tt_project_id.Text);
        }

        private void btn_delete_project_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete ?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            
            //Connect to DB
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }


            //Query
            string strAccessSelect = "DELETE FROM tbl_tt_project_id WHERE tt_project_id = '" + cb_tt_project_id.Text + "';";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "TT_Project");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }

            btn_delete_project.Enabled = false;
            refreshProject();
        }

        private void btn_save_mobile_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count==0)
            {
                return;
            }


            //Connect to DB
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }


            //Query
            string strAccessSelect = "UPDATE tbl_tt_members SET mobile='" + tb_mobile.Text + "',email='" + tb_email.Text + "',org_name='" + tb_org_name.Text + "',member_type='" + cb_member_type.Text + "' WHERE ID = " + listView1.SelectedItems[0].Text + ";";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "Members");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }
            refreshList(cb_tt_project_id.Text);
            clearEditField();
            
        }

        public void clearEditField()
        {
            tb_email.Text = "";
            tb_mobile.Text = "";
            tb_org_name.Text = "";
            cb_member_type.Text = "";

            tb_mobile.Enabled = false;
            tb_email.Enabled = false;
            tb_org_name.Enabled = false;
            cb_member_type.Enabled = false;
            btn_save_mobile.Enabled = false;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string tt_project_id = cb_tt_project_id.Text;
            //Connect to DB
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(dbTT.strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }


            //Query
            string strAccessSelect = "SELECT * FROM tbl_tt_members WHERE tt_project_id = '" + tt_project_id + "' ORDER BY ID DESC";

            // Create the dataset and add the Categories table to it:
            DataSet myDataSet = new DataSet();

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "Members");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }

            // A dataset can contain multiple tables, so let's get them
            // all into an array:
            DataTableCollection dta = myDataSet.Tables;
            DataColumnCollection drc = myDataSet.Tables["Members"].Columns;
            DataRowCollection dra = myDataSet.Tables["Members"].Rows;


           
            try
            {
                int iCol = 1;
                int iRow = 1;
                int i;
                var excelDoc = new Excel.Application();
                excelDoc.Visible = true;
                excelDoc.Workbooks.Add();
                Excel._Worksheet wksht = (Excel.Worksheet)excelDoc.ActiveSheet;
                
                foreach (DataColumn dc in drc)
                {
                    wksht.Cells[iRow, iCol] = dc.ColumnName;
                    iCol++;
                }
                iRow++;
                
                foreach (DataRow dr in dra)
                {
                    iCol = 1;
                    for (i = 0; i < drc.Count; i++)
                    {
                        Console.WriteLine(dr[i].ToString());
                        wksht.Cells[iRow, iCol] = dr[i].ToString();
                        iCol++;
                    }
                    iRow++;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }

    public static class dbTT
    {
        public static string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=nnr_tt_local.mdb";
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

    
}
