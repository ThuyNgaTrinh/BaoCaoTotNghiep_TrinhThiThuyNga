using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DangKyLichHen.Controllers
{
    public class GiangVienController : Controller
    {
        // GET: GiangVien
        public ActionResult DangKy()
        {
            return View();
        } 
        public ActionResult TraCuu()
        {
            return View();
        }
    }
}