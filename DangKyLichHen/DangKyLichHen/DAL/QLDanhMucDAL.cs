using DangKyLichHen.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace DangKyLichHen.DAL
{
    public class QLDanhMucDAL
    {
        private linqDataContext db;
        public QLDanhMucDAL()
        {
            db = new linqDataContext();
        }
        public ISingleResult<SinhVien_load_listResult> SinhVien_load_list()
        {
            var sp_result = db.SinhVien_load_list();
            return sp_result;
        }
        public string SinhVien_update(SinhvienModel m)
        {
            string dt;
            try
            {
                var sp_result = db.SinhVien_update(
                               int.Parse(m.ID),
                               m.Ma_sv,
                               m.Ten_sv,
                               m.CMND,
                               m.SĐT,
                               m.Email,
                               DateTime.Parse(m.Ngay_sinh),
                               m.Gioi_tinh,
                               int.Parse(m.Active),
                               m.UserName,
                               m.PassWord
                                 );
               
                if (sp_result.FirstOrDefault().Updated == 1)
                {
                    dt = "Sửa thành công";
                }
                else
                {
                    dt = "Sửa thất bại";
                }

            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại SinhVien_update" + e;
            }
            return dt;
        }
        public string SinhVien_insert(SinhvienModel m)
        {
            string dt;
            try
            {
                var sp_result = db.SinhVien_insert(
                               m.Ma_sv,
                               m.Ten_sv,
                               m.CMND,
                               m.SĐT,
                               m.Email,
                               DateTime.Parse(m.Ngay_sinh),
                               m.Gioi_tinh,
                               int.Parse(m.Active),
                               m.UserName,
                               m.PassWord
                                 );
                
                if (sp_result.FirstOrDefault().Identity <= 0)
                {
                    dt = "Thêm thất bại";
                }
                else
                {
                    dt = "Thêm thành công";
                }

            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại SinhVien_insert" + e;
            }
            return dt;
        }
        public string SinhVien_delete(SinhvienModel m)
        {
            string dt;
            try
            {
                var sp_result = db.SinhVien_delete(int.Parse(m.ID));
                dt = "Xoá thành công";


            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại SinhVien_delete" + e;
            }
            return dt;
        }

        public ISingleResult<LichHen_load_listResult> LichHen_load_list()
        {
            var sp_result = db.LichHen_load_list();
            return sp_result;
        }
        public string LichHen_insert(LichHenModel m)
        {
            string dt;
            try
            {
                var Lich = (from a in db.tb_lichhens
                            where a.Ngay_hen == DateTime.Parse(m.Ngay_hen) && a.Gio_hen == int.Parse(m.Gio_hen) && a.ID_gv==m.ID_gv
                            select a).ToList();
                if (Lich.Count == 0)
                {
                    var sp_result = db.LichHen_insert(
                               m.Ma_lich_hen,
                               m.Noi_dung_hen,
                               m.ID_sv,
                               m.ID_gv,
                               DateTime.Parse(m.Ngay_hen),
                               int.Parse(m.Gio_hen),
                               int.Parse(m.Active),
                               m.Ly_do_huy,
                               m.CreateUser
                                 );

                    if (sp_result.FirstOrDefault().Identity <= 0)
                    {
                        dt = "Đặt lịch hẹn thất bại";
                    }
                    else
                    {
                        dt = "Lịch hẹn của bạn đang chờ được duyệt.";
                    }
                }
                else
                {
                    dt = "Thời gian này giáo viên đã có lịch hẹn khác, vui lòng chọn lại";
                }
            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại LichHen_insert" + e;
            }
            return dt;
        }
        public string LichHen_update(LichHenModel m)
        {
            string dt;
            try
            {
                var sp_result = db.LichHen_update(
                               int.Parse(m.ID_lich_hen),
                               int.Parse(m.Active),
                               m.Ly_do_huy,
                               m.ModifyUser
                                 );

                if (sp_result.FirstOrDefault().Updated == 1)
                {
                    dt = "true";
                }
                else
                {
                    dt = "Cập nhật trạng thái thất bại";
                }

            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại SinhVien_update" + e;
            }
            return dt;
        }

        public ISingleResult<GiaoVien_load_listResult> GiaoVien_load_list()
        {
            var sp_result = db.GiaoVien_load_list();
            return sp_result;
        }
        public string GiaoVien_update(GiaoVienModel m)
        {
            string dt;
            try
            {
                var sp_result = db.GiaoVien_update(
                               int.Parse(m.ID),
                               m.Ma_gv,
                               m.Ten_gv,
                               m.Gioi_tinh,
                              DateTime.Parse(m.Ngay_sinh),
                               m.Email,
                               m.Sđt,
                               int.Parse(m.Active),
                               m.UserName,
                               m.PassWord
                                 );

                if (sp_result.FirstOrDefault().Updated == 1)
                {
                    dt = "Sửa thành công";
                }
                else
                {
                    dt = "Sửa thất bại";
                }

            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại GiaoVien_update" + e;
            }
            return dt;
        } 
        public string GiaoVien_update_tt(GiaoVienModel m)
        {
            string dt;
            try
            {
                var sp_result = db.GiaoVien_update_tt(
                               int.Parse(m.ID),
                               m.Ma_gv,
                               m.Ten_gv,
                               m.Gioi_tinh,
                              DateTime.Parse(m.Ngay_sinh),
                               m.Email,
                               m.Sđt
                                 );

                if (sp_result.FirstOrDefault().Updated == 1)
                {
                    dt = "Cập nhật thông tin thành công";
                }
                else
                {
                    dt = "Cập nhật thông tin thất bại";
                }

            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại GiaoVien_update" + e;
            }
            return dt;
        }
        public string GiaoVien_insert(GiaoVienModel m)
        {
            string dt;
            try
            {
                var sp_result = db.GiaoVien_insert(
                               m.Ma_gv,
                               m.Ten_gv,
                               m.Gioi_tinh,
                               DateTime.Parse(m.Ngay_sinh),
                               m.Email,
                               m.Sđt,
                               int.Parse(m.Active),
                               m.UserName,
                               m.PassWord
                                 );

                if (sp_result.FirstOrDefault().Identity <= 0)
                {
                    dt = "Thêm thất bại";
                }
                else
                {
                    dt = "Thêm thành công";
                }

            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại GiaoVien_insert" + e;
            }
            return dt;
        }
        public string GiaoVien_delete(GiaoVienModel m)
        {
            string dt;
            try
            {
                var sp_result = db.GiaoVien_delete(int.Parse(m.ID));
                dt = "Xoá thành công";


            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại GiaoVien_delete" + e;
            }
            return dt;
        }
        public ISingleResult<GiaoVien_load_lichnghiResult> GiaoVien_load_lichnghi(int ID)
        {
            var sp_result = db.GiaoVien_load_lichnghi(ID);
            return sp_result;
        }
        public string LichNghi_insert(LichNghiModel m)
        {
            string dt;
            try
            {
                var sp_result = db.LichNghi_insert(
                               m.ID_gv,
                               DateTime.Parse(m.Ngay_nghi)
                                 );

                if (sp_result.FirstOrDefault().Identity <= 0)
                {
                    dt = "Thêm thất bại";
                }
                else
                {
                    dt = "Thêm thành công";
                }

            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại LichNghi_insert" + e;
            }
            return dt;
        }
        public string LichNghi_delete(LichNghiModel m)
        {
            string dt;
            try
            {
                var sp_result = db.LichNghi_delete(m.IDchitiet.ToString());
                dt = "Xoá thành công";


            }
            catch (Exception e)
            {
                dt = "Đã có lỗi tại LichNghi_delete" + e;
            }
            return dt;
        }
    }
}