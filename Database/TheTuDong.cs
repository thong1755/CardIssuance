using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardIssuance.Database
{
    public class TheTuDong
    {
        public string MaThe { get; set; }
        public string KhachHang { get; set; }
        public string LoaiHang { get; set; }
        public int DonGia { get; set; }
        public string NguoiCan { get; set; }
        public string LaiXe { get; set; }
        public string ChungTu { get; set; }
        public DateTime NgayCapThe { get; set; }
        public string LoaiCan { get; set; }

        // Constructor
        public TheTuDong(string maThe, string khachHang, string loaiHang, int donGia, string nguoiCan, string laiXe, string chungTu, DateTime ngayCapThe, string loaiCan)
        {
            MaThe = maThe;
            KhachHang = khachHang;
            LoaiHang = loaiHang;
            DonGia = donGia;
            NguoiCan = nguoiCan;
            LaiXe = laiXe;
            ChungTu = chungTu;
            NgayCapThe = ngayCapThe;
            LoaiCan = loaiCan;
        }
    }
}
