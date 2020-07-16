using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DangKyLichHen.Models
{
    public class GiaoVienModel
    {
        public string ID { get; set; }
        public string Ma_gv { get; set; }
        public string Ten_gv { get; set; }
        public string Gioi_tinh { get; set; }
        public string Ngay_sinh { get; set; }
        public string Email { get; set; }
        public string Sđt { get; set; }
        public string Active { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}