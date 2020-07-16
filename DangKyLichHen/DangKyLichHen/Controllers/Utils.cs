using DangKyLichHen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace DangKyLichHen.Controllers
{
    public class Utils
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public ResponseBase SendEmail(String to_email, String subject, String body, String password, String from_email)
        {
            ResponseBase res = new ResponseBase();
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.UseDefaultCredentials = false;
            mail.From = new MailAddress(from_email);
            mail.To.Add(to_email);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpServer.EnableSsl = true;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(from_email, password);

            try
            {
                // Cần cho phép các ứng dụng kém an toàn truy cập vào tài khoản email
                // Cho phép tại: https://myaccount.google.com/lesssecureapps
                SmtpServer.Send(mail);
                res.Result = "true";
            }

            catch (Exception ex)
            {
                res.Result = "false";
                res.Message = ex.Message;
            }
            return res;
        }
    }
}