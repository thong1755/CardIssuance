using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardIssuance.Database
{
    public class MyDatabase
    {
        // Database
        public MySqlConnection m_MysqlConn = new MySqlConnection();
        private string m_Str_User = "root";
        private string m_Str_CSDL = "datacanxe";
        private DataClass.Login mDataLogin;

        public MyDatabase(DataClass.Login DataLogin)
        {
            mDataLogin = DataLogin;
        }

        public DataTable Load_User()
        {
            DataTable dt = new DataTable();

            try
            {
                MySQLConn(); // Gọi hàm kết nối MySQL
                m_MysqlConn.Open();

                string str = "SELECT iduser, ten FROM user;";
                MySqlDataAdapter da = new MySqlDataAdapter(str, m_MysqlConn);
                da.Fill(dt);

                dt.Columns.Add("Index");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Index"] = (i + 1).ToString();
                }

                m_MysqlConn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                m_MysqlConn.Close();
                MessageBox.Show(ex.Message); // Sử dụng MessageBox để hiển thị thông báo lỗi
            }

            return dt; // Trả về DataTable, có thể rỗng nếu có lỗi
        }

        public DataTable Load_TheCanTuDong()
        {
            DataTable dt = new DataTable();

            try
            {
                MySQLConn();
                m_MysqlConn.Open();

                string str = "SELECT ID, mathe, khachhang, loaihang, dongia, nguoican, laixe, chungtu FROM thecantudong;";
                MySqlDataAdapter da = new MySqlDataAdapter(str, m_MysqlConn);
                da.Fill(dt);

                dt.Columns.Add("Index");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Index"] = (i + 1).ToString();
                }

                m_MysqlConn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                m_MysqlConn.Close();
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public DataTable Load_Goods()
        {
            DataTable dt = new DataTable();

            try
            {
                MySQLConn();
                m_MysqlConn.Open();
                string str = "SELECT mahang, tenhang, tykhoi, dongia FROM loaihang ORDER BY mahang;";
                MySqlDataAdapter da = new MySqlDataAdapter(str, m_MysqlConn);
                da.Fill(dt);

                dt.Columns.Add("Index");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Index"] = (i + 1).ToString();
                }

                m_MysqlConn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                m_MysqlConn.Close();
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public DataTable Load_Customer()
        {
            DataTable dt = new DataTable();

            try
            {
                MySQLConn();
                m_MysqlConn.Open();
                string str = "SELECT makhachhang, tenkhachhang, diachikhachhang, ghichukhachhang, loaihang FROM khachhang ORDER BY makhachhang;";
                MySqlDataAdapter da = new MySqlDataAdapter(str, m_MysqlConn);
                da.Fill(dt);

                dt.Columns.Add("Index");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Index"] = (i + 1).ToString();
                }

                m_MysqlConn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                m_MysqlConn.Close();
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public DataTable Load_Weigher()
        {
            DataTable dt = new DataTable();

            try
            {
                MySQLConn();
                m_MysqlConn.Open();
                string str = "SELECT manguoican, tennguoican, dtnguoican, ghichunguoican FROM nguoican ORDER BY manguoican;";
                MySqlDataAdapter da = new MySqlDataAdapter(str, m_MysqlConn);
                da.Fill(dt);

                dt.Columns.Add("Index");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Index"] = (i + 1).ToString();
                }

                m_MysqlConn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                m_MysqlConn.Close();
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public bool AddTheTuDong(TheTuDong theTuDong)
        {
            try
            {
                MySQLConn();
                m_MysqlConn.Open();

                string query = "INSERT INTO thecantudong (mathe, khachhang, loaihang, dongia, nguoican, laixe, chungtu, ngaycapthe, loaican) " +
                               "VALUES (@mathe, @khachhang, @loaihang, @dongia, @nguoican, @laixe, @chungtu, @ngaycapthe, @loaican)";

                MySqlCommand cmd = new MySqlCommand(query, m_MysqlConn);

                cmd.Parameters.AddWithValue("@mathe", theTuDong.MaThe);
                cmd.Parameters.AddWithValue("@khachhang", theTuDong.KhachHang);
                cmd.Parameters.AddWithValue("@loaihang", theTuDong.LoaiHang);
                cmd.Parameters.AddWithValue("@dongia", theTuDong.DonGia);
                cmd.Parameters.AddWithValue("@nguoican", theTuDong.NguoiCan);
                cmd.Parameters.AddWithValue("@laixe", theTuDong.LaiXe);
                cmd.Parameters.AddWithValue("@chungtu", theTuDong.ChungTu);
                cmd.Parameters.AddWithValue("@ngaycapthe", theTuDong.NgayCapThe);
                cmd.Parameters.AddWithValue("@loaican", theTuDong.LoaiCan);

                cmd.ExecuteNonQuery();
                return true; // Thêm thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return false; // Thêm không thành công
            }
            finally
            {
                m_MysqlConn.Close(); // Đảm bảo đóng kết nối
            }
        }

        public bool DeleteTheTuDong(int id)
        {
            try
            {
                MySQLConn();
                m_MysqlConn.Open();

                string query = "DELETE FROM thecantudong WHERE ID = @id";
                MySqlCommand cmd = new MySqlCommand(query, m_MysqlConn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                return true; // Xóa thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return false; // Xóa không thành công
            }
            finally
            {
                m_MysqlConn.Close(); // Đảm bảo đóng kết nối
            }
        }

        public bool UpdateTheTuDong(int id, TheTuDong theTuDong)
        {
            try
            {
                MySQLConn();
                m_MysqlConn.Open();

                string query = "UPDATE thecantudong SET mathe = @mathe, khachhang = @khachhang, loaihang = @loaihang, " +
                               "dongia = @dongia, nguoican = @nguoican, laixe = @laixe, chungtu = @chungtu " +
                               "WHERE ID = @id";

                MySqlCommand cmd = new MySqlCommand(query, m_MysqlConn);
                cmd.Parameters.AddWithValue("@mathe", theTuDong.MaThe);
                cmd.Parameters.AddWithValue("@khachhang", theTuDong.KhachHang);
                cmd.Parameters.AddWithValue("@loaihang", theTuDong.LoaiHang);
                cmd.Parameters.AddWithValue("@dongia", theTuDong.DonGia);
                cmd.Parameters.AddWithValue("@nguoican", theTuDong.NguoiCan);
                cmd.Parameters.AddWithValue("@laixe", theTuDong.LaiXe);
                cmd.Parameters.AddWithValue("@chungtu", theTuDong.ChungTu);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return false;
            }
            finally
            {
                m_MysqlConn.Close();
            }
        }

        public DataTable SearchCard(string cardNumber)
        {
            DataTable dt = new DataTable();

            try
            {
                MySQLConn();
                m_MysqlConn.Open();

                string query = "SELECT ID, mathe, khachhang, loaihang, nguoican, laixe, chungtu, dongia, ngaycapthe, sophieu, loaican FROM thecantudong WHERE mathe = @cardNumber;";

                MySqlCommand cmd = new MySqlCommand(query, m_MysqlConn);
                cmd.Parameters.AddWithValue("@cardNumber", cardNumber);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                dt.Columns.Add("Index");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Index"] = (i + 1).ToString();
                }

                m_MysqlConn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                m_MysqlConn.Close();
                MessageBox.Show(ex.Message);
            }

            return dt;
        }

        public DataTable SearchByDate(DateTime? issueDate = null, string searchType = "day")
        {
            DataTable dt = new DataTable();

            try
            {
                MySQLConn();
                m_MysqlConn.Open();

                string query = "SELECT ID, mathe, khachhang, loaihang, nguoican, laixe, chungtu, dongia, ngaycapthe, sophieu, loaican FROM thecantudong WHERE 1=1";

                if (issueDate.HasValue)
                {
                    if (searchType == "day")
                    {
                        query += " AND DAY(ngaycapthe) = @day";
                    }
                    else if (searchType == "month")
                    {
                        query += " AND MONTH(ngaycapthe) = @month";
                    }
                    else if (searchType == "year")
                    {
                        query += " AND YEAR(ngaycapthe) = @year";
                    }
                }

                MySqlCommand cmd = new MySqlCommand(query, m_MysqlConn);

                if (issueDate.HasValue)
                {
                    if (searchType == "day")
                    {
                        cmd.Parameters.AddWithValue("@day", issueDate.Value.Day);
                    }
                    else if (searchType == "month")
                    {
                        cmd.Parameters.AddWithValue("@month", issueDate.Value.Month);
                    }
                    else if (searchType == "year")
                    {
                        cmd.Parameters.AddWithValue("@year", issueDate.Value.Year);
                    }
                }

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                m_MysqlConn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                m_MysqlConn.Close();
                MessageBox.Show(ex.Message);
            }

            return dt;
        }


        public bool MySQLConn()
        {
            string str = "server=" + mDataLogin.IP + ";" +
                         "user id=" + m_Str_User + ";" +
                         "password=" + mDataLogin.PassDatabase + ";" +
                         "database=" + m_Str_CSDL + ";";
            m_MysqlConn.ConnectionString = str;
            return true;
        }
    }
}
