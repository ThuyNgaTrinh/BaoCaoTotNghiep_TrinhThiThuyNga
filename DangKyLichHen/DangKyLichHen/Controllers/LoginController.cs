using DangKyLichHen.Common;
using DangKyLichHen.Controllers;
using DangKyLichHen.DAL;
using DangKyLichHen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace DangKyLichHen.App_Start
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SinhVien()
        {
            return View();
        }
        public ActionResult GiaoVien()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(AccountModel model)
        {
            var data = new ResponseBase();
            try
            {
                AccountDAL obj = new AccountDAL();
                var rs = obj.Login(model).ToList();
                if (rs.Count() != 1)
                {
                    data.Result = "False";
                    data.Message = "Thông tin đăng nhập không chính xác";
                }
                else
                {
                    var dt = rs.FirstOrDefault();
                    var us = new user_save();
                    us.USER_NAME = dt.USER_NAME;
                    us.Email = dt.Email;
                    us.Full_Name = dt.Full_Name;
                    us.UserID = dt.UserID;
                    Session.Add(constant.USER_SESSION, us);
                    data.Result = "True";
                    data.Message = "Đăng nhập thành công!";

                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                data.Result = "False";
                data.Message = "Lỗi kết nối " + e;
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult LoginSV(AccountModel model)
        {
            var data = new ResponseBase();
            try
            {
                AccountDAL obj = new AccountDAL();
                var rs = obj.LoginSV(model).ToList();
                if (rs.Count() != 1)
                {
                    data.Result = "False";
                    data.Message = "Thông tin đăng nhập không chính xác";
                }
                else
                {
                    var dt = rs.FirstOrDefault();
                    var us = new user_save();
                    us.USER_NAME = dt.USER_NAME;
                    us.Email = dt.Email;
                    us.Full_Name = dt.Full_Name;
                    us.UserID = dt.UserID;
                    Session.Add(constant.SV_SESSION, us);
                    data.Result = "True";
                    data.Message = "Đăng nhập thành công!";

                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                data.Result = "False";
                data.Message = "Lỗi kết nối " + e;
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult LoginGV(AccountModel model)
        {
            var data = new ResponseBase();
            try
            {
                AccountDAL obj = new AccountDAL();
                var rs = obj.LoginGV(model).ToList();
                if (rs.Count() != 1)
                {
                    data.Result = "False";
                    data.Message = "Thông tin đăng nhập không chính xác";
                }
                else
                {
                    var dt = rs.FirstOrDefault();
                    var us = new user_save();
                    us.USER_NAME = dt.USER_NAME;
                    us.Email = dt.Email;
                    us.Full_Name = dt.Full_Name;
                    us.UserID = dt.UserID;
                    Session.Add(constant.GV_SESSION, us);
                    data.Result = "True";
                    data.Message = "Đăng nhập thành công!";

                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                data.Result = "False";
                data.Message = "Lỗi kết nối " + e;
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult Logout()
        {
            var ses = (user_save)Session[constant.USER_SESSION];
            Session.Abandon();
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LogoutSV()
        {
            var ses = (user_save)Session[constant.SV_SESSION];
            Session.Abandon();
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LogoutGV()
        {
            var ses = (user_save)Session[constant.GV_SESSION];
            Session.Abandon();
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangePassWord(AccountModel model)
        {
            string dt = "";
            try
            {
                var ses = (user_save)Session[constant.USER_SESSION];
                model.UserName = ses.USER_NAME;
                AccountDAL obj = new AccountDAL();

                var rs = obj.ChangePassWord(model);

                if (rs)
                {
                    dt = "Mật khẩu đã được thay đổi";
                }
                else
                {
                    dt = "Thông tin không chính xác, vui lòng kiểm tra lại!";
                }
                return Json(dt, JsonRequestBehavior.AllowGet);
            }
            catch
            {

                dt = "Lỗi kết nối, Hãy thử lại sau!";
                return Json(dt, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult GetPassWord(AccountModel model)
        {
            string data = "";
            try
            {

                AccountDAL obj = new AccountDAL();
                var rs = obj.GetPassWord(model);

                if (rs.Count() == 1)
                {
                    var us = rs.FirstOrDefault();
                    Random generator = new Random();
                    String r = generator.Next(0, 999999).ToString("D6");
                    AccountModel m = new AccountModel();
                    m.UserName = us.UserName;
                    m.PasswordOld = us.PassWord;
                    m.PasswordNew = r;
                    var dt = obj.ChangePassWord(m);
                    if (dt)
                    {
                        Utils s = new Utils();
                        string email = WebConfigurationManager.AppSettings["Email_Support"];
                        string password = WebConfigurationManager.AppSettings["PassWord_Email_Support"];
                        var subject = "Cấp lại mật khẩu truy cập ";
                        var body = "Tài khoản : " + us.FullName + " - " + us.UserName + ", mật khẩu mới của quý khách là: " + r;
                        var a = s.SendEmail(us.Email, subject, body, password, email);
                        if (a.Result == "true")
                        {

                            data = "Mật khẩu đã được gửi đến địa chỉ email của bạn!";
                        }
                        else
                        {
                            data = a.Message;
                        }

                    }
                    else
                    {
                        data = "Chúng tôi chưa thể thay đổi mật khẩu của bạn vào lúc này! Hãy thử lại sau";
                    }
                }
                else
                {
                    data = "Thông tin không chính xác, vui lòng kiểm tra lại!";
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                data = "Lỗi kết nối, Hãy thử lại sau! \n" + ex;
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ChangePassWordSV(AccountModel model)
        {
            string dt = "";
            try
            {
                var ses = (user_save)Session[constant.SV_SESSION];
                model.UserName = ses.USER_NAME;
                AccountDAL obj = new AccountDAL();

                var rs = obj.ChangePassWordSV(model);

                if (rs)
                {
                    dt = "Mật khẩu đã được thay đổi";
                }
                else
                {
                    dt = "Thông tin không chính xác, vui lòng kiểm tra lại!";
                }
                return Json(dt, JsonRequestBehavior.AllowGet);
            }
            catch
            {

                dt = "Lỗi kết nối, Hãy thử lại sau!";
                return Json(dt, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult GetPassWordSV(AccountModel model)
        {
            string data = "";
            try
            {

                AccountDAL obj = new AccountDAL();
                var rs = obj.GetPassWordSV(model);

                if (rs.Count() == 1)
                {
                    var us = rs.FirstOrDefault();
                    Random generator = new Random();
                    String r = generator.Next(0, 999999).ToString("D6");
                    AccountModel m = new AccountModel();
                    m.UserName = us.UserName;
                    m.PasswordOld = us.PassWord;
                    m.PasswordNew = r;
                    var dt = obj.ChangePassWordSV(m);
                    if (dt)
                    {
                        Utils s = new Utils();
                        string email = WebConfigurationManager.AppSettings["Email_Support"];
                        string password = WebConfigurationManager.AppSettings["PassWord_Email_Support"];
                        var subject = "Cấp lại mật khẩu truy cập ";
                        var body = "Tài khoản : " + us.Ten_sv + " - " + us.UserName + ", mật khẩu mới của quý khách là: " + r;
                        var a = s.SendEmail(us.Email, subject, body, password, email);
                        if (a.Result == "true")
                        {

                            data = "Mật khẩu đã được gửi đến địa chỉ email của bạn!";
                        }
                        else
                        {
                            data = a.Message;
                        }

                    }
                    else
                    {
                        data = "Chúng tôi chưa thể thay đổi mật khẩu của bạn vào lúc này! Hãy thử lại sau";
                    }
                }
                else
                {
                    data = "Thông tin không chính xác, vui lòng kiểm tra lại!";
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                data = "Lỗi kết nối, Hãy thử lại sau! \n" + ex;
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ChangePassWordGV(AccountModel model)
        {
            string dt = "";
            try
            {
                var ses = (user_save)Session[constant.GV_SESSION];
                model.UserName = ses.USER_NAME;
                AccountDAL obj = new AccountDAL();

                var rs = obj.ChangePassWordGV(model);

                if (rs)
                {
                    dt = "Mật khẩu đã được thay đổi";
                }
                else
                {
                    dt = "Thông tin không chính xác, vui lòng kiểm tra lại!";
                }
                return Json(dt, JsonRequestBehavior.AllowGet);
            }
            catch
            {

                dt = "Lỗi kết nối, Hãy thử lại sau!";
                return Json(dt, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult GetPassWordGV(AccountModel model)
        {
            string data = "";
            try
            {

                AccountDAL obj = new AccountDAL();
                var rs = obj.GetPassWordGV(model);

                if (rs.Count() == 1)
                {
                    var us = rs.FirstOrDefault();
                    Random generator = new Random();
                    String r = generator.Next(0, 999999).ToString("D6");
                    AccountModel m = new AccountModel();
                    m.UserName = us.UserName;
                    m.PasswordOld = us.PassWord;
                    m.PasswordNew = r;
                    var dt = obj.ChangePassWordGV(m);
                    if (dt)
                    {
                        Utils s = new Utils();
                        string email = WebConfigurationManager.AppSettings["Email_Support"];
                        string password = WebConfigurationManager.AppSettings["PassWord_Email_Support"];
                        var subject = "Cấp lại mật khẩu truy cập ";
                        var body = "Tài khoản : " + us.Ten_gv + " - " + us.UserName + ", mật khẩu mới của quý khách là: " + r;
                        var a = s.SendEmail(us.Email, subject, body, password, email);
                        if (a.Result == "true")
                        {

                            data = "Mật khẩu đã được gửi đến địa chỉ email của bạn!";
                        }
                        else
                        {
                            data = a.Message;
                        }

                    }
                    else
                    {
                        data = "Chúng tôi chưa thể thay đổi mật khẩu của bạn vào lúc này! Hãy thử lại sau";
                    }
                }
                else
                {
                    data = "Thông tin không chính xác, vui lòng kiểm tra lại!";
                }
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                data = "Lỗi kết nối, Hãy thử lại sau! \n" + ex;
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }
    }
}