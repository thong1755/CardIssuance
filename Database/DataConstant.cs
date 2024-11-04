using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardIssuance.Database
{
    static public class DataConstant
    {
        public static List<LoaiCan> listLoaiCan = new List<LoaiCan>
        {
            new LoaiCan(1, "Nhập kho", "NK"),
            new LoaiCan(2, "Xuất kho", "XK"),
            new LoaiCan(3, "Nhập tàu", "NT"),
            new LoaiCan(4, "Dịch vụ", "DV")
        };
    }

    public class LoaiCan
    {
        public int ID { get; set; }
        public string TenLoaiCan { get; set; }
        public string MaLoaiCan { get; set; }
        public LoaiCan(int id, string tenLoaiCan, string maLoaiCan) 
        {
            ID = id;
            TenLoaiCan = tenLoaiCan;
            MaLoaiCan = maLoaiCan;
        }

        public LoaiCan()
        {
        }
    }
}
