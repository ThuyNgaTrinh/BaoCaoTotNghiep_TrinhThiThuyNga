using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DangKyLichHen.Models
{
    public class SinhvienModel
    {
        public string ID { get; set; }
        public string Ma_sv { get; set; }
        public string Ten_sv { get; set; }
        public string CMND { get; set; }
        public string SĐT { get; set; }
        public string Email { get; set; }
        public string Ngay_sinh { get; set; }
        public string Gioi_tinh { get; set; }
        public string Active { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}