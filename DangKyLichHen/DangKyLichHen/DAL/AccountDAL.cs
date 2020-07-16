using DangKyLichHen.Common;
using DangKyLichHen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DangKyLichHen.DAL
{
    public class AccountDAL
    {
        private linqDataContext db;
        public AccountDAL()
        {
            db = new linqDataContext();
        }
        public IQueryable<user_save> Login(AccountModel obj)
        {
            var sp_result = from a in db.tb_users
                            where a.UserName == obj.UserName && a.PassWord == obj.UserPassword
                            select new user_save()
                            {
                                Full_Name = a.FullName,
                                UserID = a.ID,
                                Email = a.Email,
                                USER_NAME = a.UserName,
                                PASS_WORD = a.PassWord,

                            };
            return sp_result;
        }
        public IQueryable<user_save> LoginSV(AccountModel obj)
        {
            var sp_result = from a in db.tb_sinhviens
                            where a.UserName == obj.UserName && a.PassWord == obj.UserPassword && a.Active==1
                            select new user_save()
                            {
                                Full_Name = a.Ten_sv,
                                UserID = a.ID,
                                Email = a.Email,
                                USER_NAME = a.UserName,
                                PASS_WORD = a.PassWord,   

                            };
            return sp_result;
        }
        public IQueryable<user_save> LoginGV(AccountModel obj)
        {
            var sp_result = from a in db.tb_giaoviens
                            where a.UserName == obj.UserName && a.PassWord == obj.UserPassword && a.Active==1
                            select new user_save()
                            {
                                Full_Name = a.Ten_gv,
                                UserID = a.ID,
                                Email = a.Email,
                                USER_NAME = a.UserName,
                                PASS_WORD = a.PassWord,   

                            };
            return sp_result;
        }
        public bool ChangePassWord(AccountModel obj)
        {
            bool result = false;
            try
            {
                var sp_result = db.ChangePassword(obj.UserName, obj.PasswordOld, obj.PasswordNew);
                if (sp_result.FirstOrDefault().Updated == 1)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public IQueryable<tb_user> GetPassWord(AccountModel obj)
        {
            IQueryable<tb_user> result;
            try
            {
                result = (from a in db.tb_users
                          where a.UserName == obj.UserName && a.Email == obj.EmailAdress
                          select a);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public bool ChangePassWordSV(AccountModel obj)
        {
            bool result = false;
            try
            {
                var sp_result = db.ChangePasswordSV(obj.UserName, obj.PasswordOld, obj.PasswordNew);
                if (sp_result.FirstOrDefault().Updated == 1)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public IQueryable<tb_sinhvien> GetPassWordSV(AccountModel obj)
        {
            IQueryable<tb_sinhvien> result;
            try
            {
                result = (from a in db.tb_sinhviens
                          where a.UserName == obj.UserName && a.Email == obj.EmailAdress
                          select a);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public bool ChangePassWordGV(AccountModel obj)
        {
            bool result = false;
            try
            {
                var sp_result = db.ChangePasswordGV(obj.UserName, obj.PasswordOld, obj.PasswordNew);
                if (sp_result.FirstOrDefault().Updated == 1)
                    result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public IQueryable<tb_giaovien> GetPassWordGV(AccountModel obj)
        {
            IQueryable<tb_giaovien> result;
            try
            {
                result = (from a in db.tb_giaoviens
                          where a.UserName == obj.UserName && a.Email == obj.EmailAdress
                          select a);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}