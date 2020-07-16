using DangKyLichHen.Common;
using DangKyLichHen.DAL;
using DangKyLichHen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace DangKyLichHen.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DSSV()
        {
            return View();
        }
        public ActionResult DSGV()
        {
            return View();
        }
        public ActionResult DSLH()
        {
            return View();
        }
        public JsonResult Get_User()
        {
            user_save datas = new user_save();

            var ses = (user_save)Session[constant.USER_SESSION];
            if (ses == null)
            {
                datas.UserID = 0;
            }
            else
            {
                datas.UserID = ses.UserID;
                datas.USER_NAME = ses.USER_NAME;
                datas.Full_Name = ses.Full_Name;
            }
            return Json(datas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_SV()
        {
            user_save datas = new user_save();

            var ses = (user_save)Session[constant.SV_SESSION];
            if (ses == null)
            {
                datas.UserID = 0;
            }
            else
            {
                datas.UserID = ses.UserID;
                datas.USER_NAME = ses.USER_NAME;
                datas.Full_Name = ses.Full_Name;
            }
            return Json(datas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_GV()
        {
            user_save datas = new user_save();

            var ses = (user_save)Session[constant.GV_SESSION];
            if (ses == null)
            {
                datas.UserID = 0;
            }
            else
            {
                datas.UserID = ses.UserID;
                datas.USER_NAME = ses.USER_NAME;
                datas.Full_Name = ses.Full_Name;
            }
            return Json(datas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SinhVien_load_list()
        {

            linqDataContext db = new linqDataContext();
            QLDanhMucDAL obj = new QLDanhMucDAL();
            var sp_result = obj.SinhVien_load_list();
            var data = (from a in sp_result
                        select new SinhvienModel
                        {
                            ID = a.ID.ToString(),
                            Ma_sv = a.Ma_sv,
                            Ten_sv = a.Ten_sv,
                            CMND = a.CMND,
                            SĐT=a.Sđt,
                            Email=a.Email,
                            Ngay_sinh=a.Ngay_sinh.ToString(),
                            Gioi_tinh=a.Gioi_tinh,
                            Active=a.Active.ToString(),
                            UserName=a.UserName,
                            PassWord=a.PassWord
                        });

            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
        public JsonResult Sinhvien_insert(SinhvienModel m)
        {
            var ses = (user_save)Session[constant.USER_SESSION];
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {

                var a = obj.SinhVien_insert(m);
                dt = a;
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Sinhvien_update(SinhvienModel m)
        {
            var ses = (user_save)Session[constant.USER_SESSION];
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {

                var a = obj.SinhVien_update(m);
                dt = a;
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Sinhvien_delete(SinhvienModel m)
        {
            var ses = (user_save)Session[constant.USER_SESSION];
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {

                var a = obj.SinhVien_delete(m);
                dt = a;
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Load_thong_tinSV()
        {
            var ses = (user_save)Session[constant.SV_SESSION];            
            linqDataContext db = new linqDataContext();
            var data = (from a in db.tb_sinhviens
                        where a.ID==ses.UserID
                        select new SinhvienModel
                        {
                            ID = a.ID.ToString(),
                            Ma_sv = a.Ma_sv,
                            Ten_sv = a.Ten_sv,
                            CMND = a.CMND,
                            SĐT = a.Sđt,
                            Email = a.Email,
                            Ngay_sinh = a.Ngay_sinh.ToString(),
                            Gioi_tinh = a.Gioi_tinh,
                            Active = a.Active.ToString(),
                            UserName = a.UserName,
                            PassWord = a.PassWord
                        });

            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
        public JsonResult Load_thong_tinGV()
        {
            linqDataContext db = new linqDataContext();
            var data = (from a in db.tb_giaoviens
                        orderby a.Ten_gv
                        select new GiaoVienModel
                        {
                            ID = a.ID.ToString(),
                            Ma_gv = a.Ma_gv,
                            Ten_gv = a.Ten_gv,
                            Sđt = a.Sđt,
                            Email = a.Email,
                            Ngay_sinh = a.Ngay_sinh.ToString(),
                            Gioi_tinh = a.Gioi_tinh,
                            Active = a.Active.ToString(),
                            UserName = a.UserName,
                            PassWord = a.PassWord
                        });

            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
        public JsonResult LichHen_load_list()
        {

            linqDataContext db = new linqDataContext();
            QLDanhMucDAL obj = new QLDanhMucDAL();
            var sp_result = obj.LichHen_load_list();
            var data = (from a in sp_result
                        select new LichHenModel
                        {
                            ID_lich_hen=a.ID_lich_hen.ToString(),
                            Noi_dung_hen=a.Noi_dung_hen,
                            ID_sv=a.ID_sv.ToString(),
                            Ten_sv=a.Ten_sv,
                            ID_gv=a.ID_gv.ToString(),
                            Ten_gv=a.Ten_gv,
                            Ngay_hen=a.Ngay_hen.ToString(),
                            Gio_hen=a.Gio_hen.ToString(),
                            Active=a.Active.ToString(),
                            Ly_do_huy=a.Ly_do_huy,
                            CreateUser=a.CreateUser,
                            CreateDate=a.CreateDate.ToString(),
                            ModifyUser=a.ModifyUser,
                            ModifyDate=a.ModifyDate==null?"":a.ModifyDate.ToString()
                        });

            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
        public JsonResult LichHen_load_listSV()
        {
            var ses = (user_save)Session[constant.SV_SESSION];
            linqDataContext db = new linqDataContext();
            QLDanhMucDAL obj = new QLDanhMucDAL();
            var sp_result = obj.LichHen_load_list();
            var data = (from a in sp_result
                        where a.ID_sv==ses.UserID.ToString()
                        select new LichHenModel
                        {
                            ID_lich_hen = a.ID_lich_hen.ToString(),
                            Noi_dung_hen = a.Noi_dung_hen,
                            ID_sv = a.ID_sv.ToString(),
                            Ten_sv = a.Ten_sv,
                            ID_gv = a.ID_gv.ToString(),
                            Ten_gv = a.Ten_gv,
                            Ngay_hen = a.Ngay_hen.ToString(),
                            Gio_hen = a.Gio_hen.ToString(),
                            Active = a.Active.ToString(),
                            Ly_do_huy = a.Ly_do_huy,
                            CreateUser = a.CreateUser,
                            CreateDate = a.CreateDate.ToString(),
                            ModifyUser = a.ModifyUser,
                            ModifyDate = a.ModifyDate == null ? "" : a.ModifyDate.ToString()
                        });

            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
        public JsonResult LichHen_load_ID()
        {
            var ses = (user_save)Session[constant.GV_SESSION];
            linqDataContext db = new linqDataContext();
            QLDanhMucDAL obj = new QLDanhMucDAL();
            var sp_result = obj.LichHen_load_list();
            var data = (from a in sp_result
                        where a.ID_gv==ses.UserID.ToString()
                        select new LichHenModel
                        {
                            ID_lich_hen = a.ID_lich_hen.ToString(),
                            Noi_dung_hen = a.Noi_dung_hen,
                            ID_sv = a.ID_sv.ToString(),
                            Ten_sv = a.Ten_sv,
                            ID_gv = a.ID_gv.ToString(),
                            Ten_gv = a.Ten_gv,
                            Ngay_hen = a.Ngay_hen.ToString(),
                            Gio_hen = a.Gio_hen.ToString(),
                            Active = a.Active.ToString(),
                            Ly_do_huy = a.Ly_do_huy,
                            CreateUser = a.CreateUser,
                            CreateDate = a.CreateDate.ToString(),
                            ModifyUser = a.ModifyUser,
                            ModifyDate = a.ModifyDate == null ? "" : a.ModifyDate.ToString()
                        });

            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
        public JsonResult LichHen_insert(LichHenModel m)
        {
            var ses = (user_save)Session[constant.SV_SESSION];
            m.ID_sv = ses.UserID.ToString();
            m.CreateUser = ses.USER_NAME;
            m.Active = "0";
            m.Ma_lich_hen =""+ ses.UserID + DateTime.Now.Year + DateTime.Now.Day+DateTime.Now.Second+"";
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {

                var a = obj.LichHen_insert(m);
                dt = a;
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LichHen_update(LichHenModel m)
        {
            var ses = (user_save)Session[constant.USER_SESSION];
            m.ModifyUser = ses.USER_NAME;
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {

                var a = obj.LichHen_update(m);
                dt = a;
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LichHen_updateGV(LichHenModel m)
        {
            var ses = (user_save)Session[constant.GV_SESSION];
            m.ModifyUser = ses.USER_NAME;
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {
                var sp = obj.LichHen_update(m);
                if (sp == "true")
                {
                    linqDataContext db = new linqDataContext();
                    var data = (from x in db.tb_giaoviens
                                where x.ID == ses.UserID
                                select x).ToList();
                    var info = data.FirstOrDefault();
                    var data2 = (from x in db.tb_sinhviens
                                where x.ID == int.Parse(m.ID_sv)
                                select x).ToList();
                    var info2 = data2.FirstOrDefault();
                    var data3 = (from x in db.tb_lichhens
                                 where x.ID_lich_hen == int.Parse(m.ID_lich_hen)
                                 select x).ToList();
                    var info3 = data3.FirstOrDefault();
                    Utils s = new Utils();
                    string email = WebConfigurationManager.AppSettings["Email_Support"];
                    string password = WebConfigurationManager.AppSettings["PassWord_Email_Support"];
                    var subject = "Thông báo lịch hẹn đã được duyệt";
                    var body = "Lịch hẹn của bạn và giảng viên : " + info.Ten_gv + " vào "+ info3.Gio_hen+" giờ ngày "+ (info3.Ngay_hen.ToString()).Substring(0,10)+" đã được xác nhận,  vui lòng đến địa điểm hẹn theo lịch đã đặt ra";
                    var a = s.SendEmail(info2.Email, subject, body, password, email);
                    if (a.Result == "true")
                    {

                        dt = "Đã xác nhận lịch hẹn!";
                    }
                    else
                    {
                        dt = a.Message;
                    }
                }
                else
                {
                    dt = sp;
                }
               
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GiaoVien_load_list()
        {

            linqDataContext db = new linqDataContext();
            QLDanhMucDAL obj = new QLDanhMucDAL();
            var sp_result = obj.GiaoVien_load_list();
            var data = (from a in sp_result
                        select new GiaoVienModel
                        {
                            ID = a.ID.ToString(),
                            Ma_gv = a.Ma_gv,
                            Ten_gv = a.Ten_gv,
                            Gioi_tinh = a.Gioi_tinh,
                            Ngay_sinh = a.Ngay_sinh.ToString(),
                            Sđt = a.Sđt,
                            Email = a.Email,
                            Active = a.Active.ToString(),
                            UserName = a.UserName,
                            PassWord = a.PassWord
                        });

            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
        public JsonResult GiaoVien_load_ID()
        {
            var ses = (user_save)Session[constant.GV_SESSION];
            linqDataContext db = new linqDataContext();
            QLDanhMucDAL obj = new QLDanhMucDAL();
            var sp_result = obj.GiaoVien_load_list();
            var data = (from a in sp_result
                        where a.ID==ses.UserID
                        select new GiaoVienModel
                        {
                            ID = a.ID.ToString(),
                            Ma_gv = a.Ma_gv,
                            Ten_gv = a.Ten_gv,
                            Gioi_tinh = a.Gioi_tinh,
                            Ngay_sinh = a.Ngay_sinh.ToString(),
                            Sđt = a.Sđt,
                            Email = a.Email,
                            Active = a.Active.ToString(),
                            UserName = a.UserName,
                            PassWord = a.PassWord
                        });

            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
        [HttpPost]
        [Route("GiaoVien_insert")]
        public JsonResult GiaoVien_insert(GiaoVienModel m)
        {
            var ses = (user_save)Session[constant.USER_SESSION];
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {

                var a = obj.GiaoVien_insert(m);
                dt = a;
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Route("GiaoVien_update")]
        public JsonResult GiaoVien_update(GiaoVienModel m)
        {
            var ses = (user_save)Session[constant.USER_SESSION];
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {

                var a = obj.GiaoVien_update(m);
                dt = a;
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GiaoVien_update_thongtin(GiaoVienModel m)
        {
            var ses = (user_save)Session[constant.GV_SESSION];
            m.ID = ses.UserID.ToString();
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {

                var a = obj.GiaoVien_update_tt(m);
                dt = a;
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Route("GiaoVien_delete")]
        public JsonResult GiaoVien_delete(GiaoVienModel m)
        {
            var ses = (user_save)Session[constant.USER_SESSION];
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {
                var a = obj.GiaoVien_delete(m);
                dt = a;
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GiaoVien_load_lichnghi()
        {
            var ses = (user_save)Session[constant.GV_SESSION];
            linqDataContext db = new linqDataContext();
            QLDanhMucDAL obj = new QLDanhMucDAL();
            var sp_result = obj.GiaoVien_load_lichnghi(ses.UserID);
            var data = (from a in sp_result
                        select new LichNghiModel
                        {
                            IDchitiet = a.IDChiTiet,
                            ID_gv = a.ID_gv.ToString(),
                            Ngay_nghi = a.Ngay_nghi.ToString()
                        });

            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        } 
        public JsonResult GiaoVien_load_lichnghi_ID(int ID)
        {
            linqDataContext db = new linqDataContext();
            QLDanhMucDAL obj = new QLDanhMucDAL();
            var sp_result = obj.GiaoVien_load_lichnghi(ID);
            var data = (from a in sp_result
                        select new LichNghiModel
                        {
                            IDchitiet = a.IDChiTiet,
                            ID_gv = a.ID_gv.ToString(),
                            Ngay_nghi = a.Ngay_nghi.ToString()
                        });

            return new JsonResult()
            {
                Data = data,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
      
        public JsonResult LichNghi_insert(LichNghiModel m)
        {
            var ses = (user_save)Session[constant.GV_SESSION];
            m.ID_gv = ses.UserID.ToString();
            linqDataContext db = new linqDataContext();
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {
                var check = (from x in db.tb_lichnghis
                             where x.Ngay_nghi.ToString().Substring(0,10) == m.Ngay_nghi.Substring(0,10) && x.ID_gv==int.Parse(m.ID_gv)
                             select x).ToList();
                if (check.Count == 0)
                {
                    var a = obj.LichNghi_insert(m);
                    dt = a;
                }
                else
                {
                    dt = "false";
                }
               
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }

   ///     [HttpPost]
    //    [Route("GiaoVien_delete")]
        public JsonResult LichNghi_delete(LichNghiModel m)
        {
            var ses = (user_save)Session[constant.GV_SESSION];
            QLDanhMucDAL obj = new QLDanhMucDAL();
            string dt;
            try
            {
                var a = obj.LichNghi_delete(m);
                dt = a;
            }
            catch (Exception ex)
            {
                dt = "Lỗi dữ liệu";
            }

            return Json(dt, JsonRequestBehavior.AllowGet);
        }

    }
}
