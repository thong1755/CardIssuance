using CardIssuance.Database;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CardIssuance
{
    public partial class MainCardIssuance : MetroForm
    {
        public Database.DataClass.Login mLogin = new Database.DataClass.Login();
        private DataTable dtHangHoa;
        public MainCardIssuance()
        {
            InitializeComponent();

            this.MinimizeBox = false; 
            this.FormBorderStyle = FormBorderStyle.None; 
            this.Resizable = false; 

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Font = new Font("Segoe UI", 11); // Đặt font cho ListView

            listView1.Columns.Add("ID", 0);
            listView1.Columns.Add("Mã số thẻ", 0);
            listView1.Columns.Add("Khách hàng", 0);
            listView1.Columns.Add("Loại hàng", 0);
            listView1.Columns.Add("Đơn giá", 0);
            listView1.Columns.Add("Người cân", 0);
            listView1.Columns.Add("Lái xe", 0);
            listView1.Columns.Add("Chứng từ", 0);

            string[] row1 = {"1" ,"123456789", "Nguyễn Văn A", "Xi măng", "Nguyễn Văn Cân", "Tài xế", "Đà Nẵng" };
            var listViewItem1 = new ListViewItem(row1);
            listView1.Items.Add(listViewItem1);

            listView1.ColumnWidthChanging += ListView1_ColumnWidthChanging;
        }

        private void MainCardIssuance_Load(object sender, EventArgs e)
        {
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml"); 
            ReadConfigData(filePath);

            LoadDataToListView();
            LoadHangHoaToComboBox();
            LoadKhachHangToComboBox();
            LoadNguoiCanToComboBox();
            LoadLoaiCanComboBox();
            ResizeColumns();
        }

        // Hàm xử lý sự kiện ngăn thay đổi kích thước cột
        private void ListView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            // Giữ chiều rộng cột như cũ
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
            e.Cancel = true; // Ngăn người dùng thay đổi kích thước cột
        }

        private void ReadConfigData(string filePath)
        {
            XDocument xdoc = XDocument.Load(filePath);
            mLogin.IP = xdoc.Root.Element("Credentials").Element("IP").Value;
            mLogin.User = xdoc.Root.Element("Credentials").Element("User").Value;
            mLogin.Pass = xdoc.Root.Element("Credentials").Element("Pass").Value;
            mLogin.PassDatabase = xdoc.Root.Element("Credentials").Element("PassDatabase").Value;    

        }


        public void LoadDataToListView()
        {
            var database = new MyDatabase(mLogin);
            DataTable dt = database.Load_TheCanTuDong();

            listView1.Items.Clear(); // Xóa các mục hiện có trong ListView

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["ID"].ToString());
                item.SubItems.Add(row["mathe"].ToString());
                item.SubItems.Add(row["khachhang"].ToString());
                item.SubItems.Add(row["loaihang"].ToString());
                item.SubItems.Add(row["dongia"].ToString());
                item.SubItems.Add(row["nguoican"].ToString());
                item.SubItems.Add(row["laixe"].ToString());
                item.SubItems.Add(row["chungtu"].ToString());

                listView1.Items.Add(item);
            }
        }

        public void LoadDataToListView(DataTable dt)
        {
            listView1.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["ID"].ToString());
                item.SubItems.Add(row["mathe"].ToString());
                item.SubItems.Add(row["khachhang"].ToString());
                item.SubItems.Add(row["loaihang"].ToString());
                item.SubItems.Add(row["dongia"].ToString());
                item.SubItems.Add(row["nguoican"].ToString());
                item.SubItems.Add(row["laixe"].ToString());
                item.SubItems.Add(row["chungtu"].ToString());

                listView1.Items.Add(item);
            }
        }

        public void LoadHangHoaToComboBox()
        {
            var database = new MyDatabase(mLogin);
            dtHangHoa = database.Load_Goods(); // Gọi hàm Load_Goods để lấy dữ liệu

            cbHangHoa.Items.Clear(); // Xóa các mục hiện có trong ComboBox

            foreach (DataRow row in dtHangHoa.Rows)
            {
                cbHangHoa.Items.Add(row["tenhang"].ToString()); // Thêm tenhang vào ComboBox
            }
        }


        // Định kích thước cột theo tỷ lệ phần trăm
        private void ResizeColumns()
        {
            if (listView1.Columns.Count == 0)
                return; // Không có cột nào, không làm gì cả

            int totalWidth = listView1.Width - SystemInformation.VerticalScrollBarArrowHeight; // Trừ đi chiều rộng của thanh cuộn
            int column1Width = (int)(totalWidth * 0.05); 
            int column2Width = (int)(totalWidth * 0.15); 
            int column3Width = (int)(totalWidth * 0.15); 
            int column4Width = (int)(totalWidth * 0.15); 
            int column5Width = (int)(totalWidth * 0.1); 
            int column6Width = (int)(totalWidth * 0.15); 
            int column7Width = (int)(totalWidth * 0.15); 
            int column8Width = (int)(totalWidth * 0.1); 

            listView1.Columns[0].Width = column1Width; 
            listView1.Columns[1].Width = column2Width; 
            listView1.Columns[2].Width = column3Width; 
            listView1.Columns[3].Width = column4Width; 
            listView1.Columns[4].Width = column5Width; 
            listView1.Columns[5].Width = column6Width; 
            listView1.Columns[6].Width = column7Width; 
            listView1.Columns[7].Width = column7Width; 
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ResizeColumns();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedHang = cbHangHoa.SelectedItem.ToString();
            LoadDonGia(selectedHang);
        }

        private void LoadDonGia(string tenhang)
        {
            DataRow[] foundRows = dtHangHoa.Select($"tenhang = '{tenhang}'");
            if (foundRows.Length > 0)
            {
                txtDonGia.Text = foundRows[0]["dongia"].ToString(); 
            }
            else
            {
                txtDonGia.Text = ""; 
            }
        }

        private void LoadKhachHangToComboBox()
        {
            var database = new MyDatabase(mLogin);
            DataTable dt = database.Load_Customer(); 

            cbKhachHang.Items.Clear(); 

            foreach (DataRow row in dt.Rows)
            {
                cbKhachHang.Items.Add(row["tenkhachhang"].ToString());
            }
        }

        private void LoadNguoiCanToComboBox()
        {
            var database = new MyDatabase(mLogin);
            DataTable dt = database.Load_Weigher(); // Gọi hàm Load_Weigher để lấy dữ liệu

            cbNguoiCan.Items.Clear(); // Xóa các mục hiện có trong ComboBox

            foreach (DataRow row in dt.Rows)
            {
                cbNguoiCan.Items.Add(row["tennguoican"].ToString()); // Thêm tennguoican vào ComboBox
            }
        }

        private void LoadLoaiCanComboBox()
        {
            cbLoaiCan.DataSource = DataConstant.listLoaiCan;
            cbLoaiCan.DisplayMember = "TenLoaiCan"; 
            cbLoaiCan.ValueMember = "MaLoaiCan"; 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var database = new MyDatabase(mLogin);

            int donGia;
            if (!int.TryParse(txtDonGia.Text, out donGia))
            {
                donGia = 0;
            }

            TheTuDong theTuDong = new TheTuDong(
                txtMaThe.Text.ToString(),
                cbKhachHang.Text.ToString(),
                cbHangHoa.Text.ToString(),
                donGia,
                cbNguoiCan.Text.ToString(),
                cbLaiXa.Text.ToString(),
                txtChungTu.Text.ToString(),
                DateTime.Now,
                cbLoaiCan.SelectedValue.ToString()

            );

            if (database.AddTheTuDong(theTuDong))
            {
                LoadDataToListView();
                MetroMessageBox.Show(this, "Đã thêm mã thẻ "+ theTuDong.MaThe.ToString() + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void clearForm()
        {
            txtMaThe.Text = "";
            cbKhachHang.SelectedIndex = -1;
            cbHangHoa.SelectedIndex = -1;
            txtDonGia.Text = "";
            cbNguoiCan.SelectedIndex = -1;
            cbLaiXa.SelectedIndex = -1;
            txtChungTu.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var database = new MyDatabase(mLogin);
            if (listView1.SelectedItems.Count == 0)
            {
                MetroMessageBox.Show(this,"Vui lòng chọn một mục để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Thoát nếu không có hàng nào được chọn
            }

            int id = Convert.ToInt32(listView1.SelectedItems[0].Text); // Giả sử ID nằm ở cột đầu tiên

            if (database.DeleteTheTuDong(id))
            {
                MetroMessageBox.Show(this,"Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataToListView(); // Cập nhật lại ListView sau khi xóa
                clearForm();
            }
            else
            {
                MetroMessageBox.Show(this,"Xóa không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            ListViewItem selectedItem = listView1.SelectedItems[0];
            txtMaThe.Text = selectedItem.SubItems[1].Text;
            cbKhachHang.Text = selectedItem.SubItems[2].Text;
            cbHangHoa.Text = selectedItem.SubItems[3].Text;
            txtDonGia.Text = selectedItem.SubItems[4].Text;
            cbNguoiCan.Text = selectedItem.SubItems[5].Text;
            cbLaiXa.Text = selectedItem.SubItems[6].Text;
            txtChungTu.Text = selectedItem.SubItems[7].Text;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var database = new MyDatabase(mLogin);
            if (listView1.SelectedItems.Count == 0)
            {
                MetroMessageBox.Show(this, "Vui lòng chọn một mục để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(listView1.SelectedItems[0].Text); // Giả sử ID nằm ở cột đầu tiên

            int donGia;
            if (!int.TryParse(txtDonGia.Text, out donGia))
            {
                donGia = 0;
            }

            TheTuDong theTuDong = new TheTuDong(
                txtMaThe.Text,
                cbKhachHang.Text,
                cbHangHoa.Text,
                donGia,
                cbNguoiCan.Text,
                cbLaiXa.Text,
                txtChungTu.Text,
                DateTime.Now,
                cbLoaiCan.SelectedValue.ToString()
            );

            if (database.UpdateTheTuDong(id, theTuDong)) // Giả sử bạn có phương thức UpdateTheTuDong
            {
                LoadDataToListView();
                MetroMessageBox.Show(this, "Cập nhật thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MetroMessageBox.Show(this, "Cập nhật không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string cardNumber = txtSearchCard.Text;

            if (rbMaSoThe.Checked)
            {
                if (cardNumber == "")
                {
                    MetroMessageBox.Show(this, "Vui lòng nhập mã thẻ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var database = new MyDatabase(mLogin);

                    DataTable dt = database.SearchCard(cardNumber);
                    LoadDataToListView(dt);
                }
            }

            if(rbNgay.Checked)
            {
                var database = new MyDatabase(mLogin);
                DateTime issueDate = dateIssueCard.Value;
                DataTable dt = database.SearchByDate(issueDate);
                LoadDataToListView(dt);
            }

            if(rbThang.Checked)
            {
                var database = new MyDatabase(mLogin);
                DateTime issueDate = dateIssueCard.Value;
                DataTable dt = database.SearchByDate(issueDate, "month");
                LoadDataToListView(dt);
            }

            if (rbNam.Checked)
            {
                var database = new MyDatabase(mLogin);
                DateTime issueDate = dateIssueCard.Value;
                DataTable dt = database.SearchByDate(issueDate, "year");
                LoadDataToListView(dt);
            }

        }
    }
}
