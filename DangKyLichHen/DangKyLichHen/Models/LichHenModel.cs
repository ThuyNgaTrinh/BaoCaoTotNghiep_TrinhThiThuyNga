using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DangKyLichHen.Models
{
    public class LichHenModel
    {
        public string ID_lich_hen { get; set; }
        public string Ma_lich_hen { get; set; }
        public string Noi_dung_hen { get; set; }
        public string ID_sv { get; set; }
        public string Ten_sv { get; set; }
        public string ID_gv { get; set; }
        public string Ten_gv { get; set; }
        public string Ngay_hen { get; set; }
        public string Gio_hen { get; set; }
        public string Active { get; set; }
        public string Ly_do_huy { get; set; }
        public string CreateUser { get; set; }
        public string CreateDate { get; set; }
        public string ModifyUser { get; set; }
        public string ModifyDate { get; set; }
    }
}