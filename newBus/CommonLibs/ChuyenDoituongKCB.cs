﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic;
using VNS.Libs;
using VNS.HIS.DAL;
using System.Transactions;
using VNS.Properties;
using System.Data;
using VNS.HIS.BusRule.Classes;

namespace VNS.Libs
{
    public class ChuyenDoituongKCB
    {
        public static ActionResult Chuyendoituong(KcbLuotkham objLuotkham, KcbLuotkham objLuotkhamCu, decimal PtramBHYTcu)
        {
            try
            {
            ActionResult _ActionResult = ActionResult.Success;
                using (var Scope = new TransactionScope())
                {
                    using (var dbScope = new SharedDbConnectionScope())
                    {
                        long _IdLichsuDoituongKcb = Utility.Int64Dbnull(objLuotkhamCu.IdLichsuDoituongKcb, -1);
                        if (objLuotkham.MaDoituongKcb != objLuotkhamCu.MaDoituongKcb || THU_VIEN_CHUNG.IsBaoHiem(objLuotkham.IdLoaidoituongKcb))
                        {
                            KcbLichsuDoituongKcb objLichsuKcb = new KcbLichsuDoituongKcb();
                            objLichsuKcb.IsNew = true;
                            objLichsuKcb.IdBenhnhan = objLuotkham.IdBenhnhan;
                            objLichsuKcb.MaLuotkham = objLuotkham.MaLuotkham;
                            objLichsuKcb.NgayHieuluc = objLuotkham.NgayTiepdon;
                            objLichsuKcb.IdDoituongKcb = objLuotkham.IdDoituongKcb;
                            objLichsuKcb.MaDoituongKcb = objLuotkham.MaDoituongKcb;
                            objLichsuKcb.IdLoaidoituongKcb = objLuotkham.IdLoaidoituongKcb;
                            objLichsuKcb.MatheBhyt = objLuotkham.MatheBhyt;
                            objLichsuKcb.PtramBhyt = objLuotkham.PtramBhyt;
                            objLichsuKcb.PtramBhytGoc = objLuotkham.PtramBhytGoc;
                            objLichsuKcb.NgaybatdauBhyt = objLuotkham.NgaybatdauBhyt;
                            objLichsuKcb.NgayketthucBhyt = objLuotkham.NgayketthucBhyt;
                            objLichsuKcb.NoicapBhyt = objLuotkham.NoicapBhyt;
                            objLichsuKcb.MaNoicapBhyt = objLuotkham.MaNoicapBhyt;
                            objLichsuKcb.MaDoituongBhyt = objLuotkham.MaDoituongBhyt;
                            objLichsuKcb.MaQuyenloi = objLuotkham.MaQuyenloi;
                            objLichsuKcb.NoiDongtrusoKcbbd = objLuotkham.NoiDongtrusoKcbbd;

                            objLichsuKcb.MaKcbbd = objLuotkham.MaKcbbd;
                            objLichsuKcb.TrangthaiNoitru = objLuotkhamCu.TrangthaiNoitru;
                            objLichsuKcb.DungTuyen = objLuotkham.DungTuyen;
                            objLichsuKcb.Cmt = objLuotkham.Cmt;
                            objLichsuKcb.IdRavien = objLuotkhamCu.IdRavien;
                            objLichsuKcb.IdBuong = objLuotkhamCu.IdBuong;
                            objLichsuKcb.IdGiuong = objLuotkhamCu.IdGiuong;
                            objLichsuKcb.IdKhoanoitru = objLuotkhamCu.IdKhoanoitru;
                            objLichsuKcb.NguoiTao = globalVariables.UserName;
                            objLichsuKcb.NgayTao = globalVariables.SysDate;

                            objLichsuKcb.IsNew = true;
                            objLichsuKcb.Save();
                            _IdLichsuDoituongKcb = objLichsuKcb.IdLichsuDoituongKcb;
                        }
                        objLuotkham.IdLichsuDoituongKcb = _IdLichsuDoituongKcb;
                           _ActionResult= CapnhatGiatheodoituong(objLuotkham,objLuotkhamCu);
                        if (_ActionResult == ActionResult.Cancel)
                        {
                            return _ActionResult;
                        }
                       
                        new Update(KcbLuotkham.Schema)
                           .Set(KcbLuotkham.Columns.LuongCoban).EqualTo(objLuotkham.LuongCoban)
                           .Set(KcbLuotkham.Columns.TthaiChuyendi).EqualTo(objLuotkham.TthaiChuyendi)
                           .Set(KcbLuotkham.Columns.MatheBhyt).EqualTo(objLuotkham.MatheBhyt)
                           .Set(KcbLuotkham.Columns.MaNoicapBhyt).EqualTo(objLuotkham.MaNoicapBhyt)
                           .Set(KcbLuotkham.Columns.MaQuyenloi).EqualTo(objLuotkham.MaQuyenloi)
                           .Set(KcbLuotkham.Columns.NgaybatdauBhyt).EqualTo(objLuotkham.NgaybatdauBhyt)
                           .Set(KcbLuotkham.Columns.NgayketthucBhyt).EqualTo(objLuotkham.NgayketthucBhyt)
                           .Set(KcbLuotkham.Columns.NoicapBhyt).EqualTo(objLuotkham.NoicapBhyt)
                           .Set(KcbLuotkham.Columns.IdDoituongKcb).EqualTo(objLuotkham.IdDoituongKcb)
                           .Set(KcbLuotkham.Columns.MaKcbbd).EqualTo(objLuotkham.MaKcbbd)
                           .Set(KcbLuotkham.Columns.NoiDongtrusoKcbbd).EqualTo(objLuotkham.NoiDongtrusoKcbbd)
                           .Set(KcbLuotkham.Columns.MaDoituongBhyt).EqualTo(objLuotkham.MaDoituongBhyt)
                           .Set(KcbLuotkham.Columns.DungTuyen).EqualTo(objLuotkham.DungTuyen)
                           .Set(KcbLuotkham.Columns.MaDoituongKcb).EqualTo(objLuotkham.MaDoituongKcb)
                           .Set(KcbLuotkham.Columns.NguoiSua).EqualTo(globalVariables.UserName)
                           .Set(KcbLuotkham.Columns.NgaySua).EqualTo(globalVariables.SysDate)
                           .Set(KcbLuotkham.Columns.MadtuongSinhsong).EqualTo(objLuotkham.MadtuongSinhsong)
                           .Set(KcbLuotkham.Columns.GiayBhyt).EqualTo(objLuotkham.GiayBhyt)
                           .Set(KcbLuotkham.Columns.PtramBhyt).EqualTo(objLuotkham.PtramBhyt)
                           .Set(KcbLuotkham.Columns.PtramBhytGoc).EqualTo(objLuotkham.PtramBhytGoc)
                           .Set(KcbLuotkham.Columns.DiachiBhyt).EqualTo(objLuotkham.DiachiBhyt)
                           .Set(KcbLuotkham.Columns.IdLichsuDoituongKcb).EqualTo(_IdLichsuDoituongKcb)
                           
                           .Where(KcbLuotkham.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham)
                           .And(KcbLuotkham.Columns.IdBenhnhan).IsEqualTo(objLuotkham.IdBenhnhan)
                           .Execute();

                       
                    }
                    Scope.Complete();
                    return ActionResult.Success;
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Lỗi khi chuyển đối tượng:\n"+ex.Message);
                return ActionResult.Exception;
            }
        }
        public static ActionResult CapnhatGiatheodoituong(KcbLuotkham objLuotkham,KcbLuotkham objLuotkhamCu )
        {
            using (var Scope = new TransactionScope())
            {
                ActionResult _ActionResult = ActionResult.Success;

                _ActionResult = CapnhatChiphiKCB(objLuotkham, objLuotkhamCu);
                if (_ActionResult == ActionResult.Cancel)
                    return _ActionResult;
                _ActionResult = CapnhatChiphiCLS(objLuotkham, objLuotkhamCu);
                if (_ActionResult == ActionResult.Cancel)
                    return _ActionResult;
                _ActionResult = CapnhatChiphiThuoc(objLuotkham, objLuotkhamCu);
                if (_ActionResult == ActionResult.Cancel)
                    return _ActionResult;
                Scope.Complete();
                return ActionResult.Success;
            }

        }
        private static ActionResult CapnhatChiphiThuoc(KcbLuotkham objLuotkham, KcbLuotkham objLuotkhamCu)
        {
            using (var Scope = new TransactionScope())
            {
                decimal BHYT_PTRAM_TRAITUYENNOITRU =Utility.DecimaltoDbnull( THU_VIEN_CHUNG.Laygiatrithamsohethong("BHYT_PTRAM_TRAITUYENNOITRU", "0", false),0m);
                THUOC_GIATHEO_KHOAKCB = THU_VIEN_CHUNG.Laygiatrithamsohethong("THUOC_GIATHEO_KHOAKCB", "0", true) == "1";

                KcbDonthuocCollection lstDonthuoc=
                    new Select(KcbDonthuoc.Columns.IdDonthuoc)
                    .From(KcbDonthuoc.Schema)
                    .Where(KcbDonthuoc.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham)
                    .And(KcbDonthuoc.Columns.IdBenhnhan).IsEqualTo(objLuotkham.IdBenhnhan)
                    .ExecuteAsCollection<KcbDonthuocCollection>();
                
                KcbDonthuocChitietCollection lstChitiet =
                    new Select().From(KcbDonthuocChitiet.Schema)
                    .Where(KcbDonthuocChitiet.Columns.IdDonthuoc).In(lstDonthuoc.Select(c=>c.IdDonthuoc).Distinct().ToList<long>())
                    .ExecuteAsCollection<KcbDonthuocChitietCollection>();

                bool ApdunggiathuocDoituong = THU_VIEN_CHUNG.Laygiatrithamsohethong("APDUNG_GIATHUOC_DOITUONG", "0", true) == "1";

                DmucDoituongkcb _DmucDoituongkcb = new Select().From(DmucDoituongkcb.Schema).Where(DmucDoituongkcb.Columns.MaDoituongKcb).IsEqualTo(objLuotkham.MaDoituongKcb).ExecuteSingle<DmucDoituongkcb>();
                if (_DmucDoituongkcb == null) return ActionResult.Success;
                //Kiểm tra nếu đối tượng ngoại trú đã có đơn thuốc thanh toán-->Ko cho phép chuyển nữa
                if (Utility.Byte2Bool(objLuotkham.TrangthaiNoitru) && lstChitiet.Select(c => c.TrangthaiThanhtoan > 0).Any())
                {
                    return ActionResult.Cancel;
                }
                bool saveParent = false;
                foreach (KcbDonthuoc objKcbDonthuoc in lstDonthuoc)
                {
                    objKcbDonthuoc.IdLichsuDoituongKcb = objLuotkham.IdLichsuDoituongKcb;
                    objKcbDonthuoc.MaDoituongKcb = objLuotkham.MaDoituongKcb;
                    
                    foreach (KcbDonthuocChitiet objChitietDonthuoc in lstChitiet.Where(c => c.IdDonthuoc.Equals(objKcbDonthuoc.IdDonthuoc)))
                    {
                        objChitietDonthuoc.MaDoituongKcb = objLuotkham.MaDoituongKcb;
                        objChitietDonthuoc.IdLichsuDoituongKcb = objLuotkham.IdLichsuDoituongKcb;
                        if (Utility.Int16Dbnull(objChitietDonthuoc.TrangthaiThanhtoan, 0) == 0)
                        {
                            saveParent = true;
                            objChitietDonthuoc.MadoituongGia = objLuotkham.MaDoituongKcb;
                            objChitietDonthuoc.PtramBhyt = objLuotkham.PtramBhyt;
                            objChitietDonthuoc.PtramBhytGoc = objLuotkham.PtramBhytGoc;
                            DmucThuoc _DmucThuoc = DmucThuoc.FetchByID(objChitietDonthuoc.IdThuoc);
                            if (ApdunggiathuocDoituong || Utility.Byte2Bool(_DmucDoituongkcb.GiathuocQuanhe.Value))//Giá theo bảng quan hệ-->
                            {
                                QheDoituongThuoc _item = THU_VIEN_CHUNG.LayQheDoituongThuoc(objLuotkham.MaDoituongKcb,
                                                                          objChitietDonthuoc.IdThuoc,
                                                                          objLuotkham.MaKhoaThuchien, THUOC_GIATHEO_KHOAKCB);
                                if (_item != null)//Tìm thấy quan hệ giá
                                {
                                    objChitietDonthuoc.DonGia = Utility.DecimaltoDbnull(_item.DonGia);
                                    objChitietDonthuoc.PhuThu = (Utility.isTrue(objLuotkham.DungTuyen.Value) ? Utility.DecimaltoDbnull(_item.PhuthuDungtuyen) : Utility.DecimaltoDbnull(_item.PhuthuTraituyen));
                                    objChitietDonthuoc.TuTuc = 0;
                                }
                                else//Tìm giá dịch vụ, chỉ xảy ra khi đối tượng BHYT ko tìm thấy giá, 
                                //còn đối tượng DV chắc chắn do thiếu quan hệ giá nên ko thay đổi gì dòng giá thuốc này
                                {
                                    _item = THU_VIEN_CHUNG.LayQheDoituongThuoc("DV",
                                                                           objChitietDonthuoc.IdThuoc,
                                                                           objLuotkham.MaKhoaThuchien, THUOC_GIATHEO_KHOAKCB);
                                    if (_item != null)
                                    {
                                        objChitietDonthuoc.MadoituongGia = "DV";
                                        objChitietDonthuoc.DonGia = Utility.DecimaltoDbnull(_item.DonGia);
                                        objChitietDonthuoc.PhuThu = (Utility.isTrue(objLuotkham.DungTuyen.Value) ? Utility.DecimaltoDbnull(_item.PhuthuDungtuyen) : Utility.DecimaltoDbnull(_item.PhuthuTraituyen));
                                        objChitietDonthuoc.TuTuc = 1;
                                        objChitietDonthuoc.PtramBhyt = 0;
                                    }
                                }
                            }
                            else //Giá theo kho-->
                            {
                                TThuockho objTK = TThuockho.FetchByID(objChitietDonthuoc.IdThuockho);
                                if (objTK != null)
                                {
                                    objChitietDonthuoc.DonGia = THU_VIEN_CHUNG.IsBaoHiem(objLuotkham.IdLoaidoituongKcb) ? Utility.DecimaltoDbnull(objTK.GiaBhyt.Value, objChitietDonthuoc.DonGia) : objTK.GiaBan;
                                    objChitietDonthuoc.PhuThu = (Utility.Byte2Bool(objLuotkham.DungTuyen)  ? Utility.DecimaltoDbnull(objTK.PhuthuDungtuyen) : Utility.DecimaltoDbnull(objTK.PhuthuTraituyen));
                                    if (!THU_VIEN_CHUNG.IsBaoHiem(objLuotkham.IdLoaidoituongKcb))//Đối tượng dịch vụ-->Ko tính phụ thu
                                        objChitietDonthuoc.PhuThu = 0;
                                }
                            }
                            //Tính lại các mục tự túc, BHYT chi trả, BN chi trả
                            if (_DmucThuoc != null && Utility.Int32Dbnull(_DmucThuoc.TuTuc, 0) == 1)
                                objChitietDonthuoc.TuTuc = 1;//Ke ca co trong bang quan he
                            if (objLuotkham.IdLoaidoituongKcb == 1)//Đối tượng dịch vụ-->ko cần phải đánh dấu tự túc
                                objChitietDonthuoc.TuTuc = 0;
                            if (!Utility.Byte2Bool(objChitietDonthuoc.TuTuc))//Nếu ko phải dịch vụ tự túc
                            {
                                decimal BHCT = 0m;
                                if (objLuotkham.DungTuyen == 1)//Chỉ xảy ra với đối tượng BHYT
                                {
                                    BHCT = Utility.DecimaltoDbnull(objChitietDonthuoc.DonGia, 0) * (Utility.DecimaltoDbnull(objLuotkham.PtramBhyt, 0) / 100);
                                }
                                else//Đối tượng DV hoặc BHYT trái tuyến
                                {
                                    if (objLuotkham.TrangthaiNoitru <= 0 || !Utility.Byte2Bool( objKcbDonthuoc.Noitru))//Ngoại trú
                                        BHCT = Utility.DecimaltoDbnull(objChitietDonthuoc.DonGia, 0) * (Utility.DecimaltoDbnull(objLuotkham.PtramBhyt, 0) / 100);
                                    else//Nội trú cần tính=đơn giá * % đầu thẻ * % tuyến
                                        BHCT = Utility.DecimaltoDbnull(objChitietDonthuoc.DonGia, 0) * (Utility.DecimaltoDbnull(objLuotkham.PtramBhytGoc, 0) / 100) * (BHYT_PTRAM_TRAITUYENNOITRU / 100);
                                }
                                decimal _BnhanChitra = Utility.DecimaltoDbnull(objChitietDonthuoc.DonGia, 0) - BHCT;
                                objChitietDonthuoc.BhytChitra = BHCT;
                                objChitietDonthuoc.BnhanChitra = _BnhanChitra;
                            }
                            else//Là tự túc
                            {
                                objChitietDonthuoc.PtramBhyt = 0;
                                objChitietDonthuoc.BhytChitra = 0;
                                objChitietDonthuoc.BnhanChitra = Utility.DecimaltoDbnull(objChitietDonthuoc.DonGia, 0);
                            }
                        }
                        else
                        {
                            //nếu đã thanh toán thì chỉ xử lý khi đối tượng đang ở trạng thái nội trú.
                            if (Utility.Byte2Bool(objLuotkham.TrangthaiNoitru))
                            {
                                saveParent = true;
                                if (THU_VIEN_CHUNG.IsBaoHiem(objLuotkham.IdLoaidoituongKcb))
                                {
                                    //Đối tượng mới là BHYT thì kiểm tra đổi các dịch vụ có giá DV về tự túc. 
                                    //Các dịch vụ có giá khác DV thì để nguyên(để nếu đối tượng cũ là BHYT thì ko bị thay đổi giá trị tự túc)
                                    if (objChitietDonthuoc.MadoituongGia == "DV")
                                        objChitietDonthuoc.TuTuc = 1;
                                }
                                else//Nếu đối tượng từ BHYT chuyển sang dịch vụ thì chuyển thành ko tự túc hết
                                {
                                    if (objLuotkham.MaDoituongKcb != objLuotkhamCu.MaDoituongKcb)//Mới=DV, Cũ=BHYT. Còn lại ko làm gì cả
                                        objChitietDonthuoc.TuTuc = 0;
                                }
                            }
                            else
                                return ActionResult.Cancel;
                        }
                        objChitietDonthuoc.Save();
                    }
                    if (saveParent)
                    {
                        objKcbDonthuoc.Save();
                        saveParent = false;
                    }
                }
                Scope.Complete();
                return ActionResult.Success;
            }
        }
        static bool CLS_GIATHEO_KHOAKCB = false;
        static bool THUOC_GIATHEO_KHOAKCB = false;
        private static ActionResult CapnhatChiphiCLS_old(KcbLuotkham objLuotkham, KcbLuotkham objLuotkhamCu)
        {
            using (var Scope = new TransactionScope())
            {
                CLS_GIATHEO_KHOAKCB = THU_VIEN_CHUNG.Laygiatrithamsohethong("CLS_GIATHEO_KHOAKCB","0", true) == "1";
                SqlQuery sqlQuery = new Select().From(KcbChidinhclsChitiet.Schema)
                    .Where(KcbChidinhclsChitiet.Columns.IdChidinh).In(
                        new Select(KcbChidinhcl.Columns.IdChidinh).From(KcbChidinhcl.Schema)
                        .Where(KcbChidinhcl.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham)
                        .And(KcbChidinhcl.Columns.IdBenhnhan).IsEqualTo(objLuotkham.IdBenhnhan)
                        );
                var objChidinhChitietCollection =
                    sqlQuery.ExecuteAsCollection<KcbChidinhclsChitietCollection>();
                foreach (KcbChidinhclsChitiet objChidinhChitiet in objChidinhChitietCollection)
                {
                    if (objChidinhChitiet.TrangthaiThanhtoan == 0)
                    {
                        QheDoituongDichvucl _Items = THU_VIEN_CHUNG.LayQheDoituongCLS(objLuotkham.MaDoituongKcb, objChidinhChitiet.IdChitietdichvu, objLuotkham.MaKhoaThuchien, CLS_GIATHEO_KHOAKCB);
                        if (_Items != null)
                        {

                            objChidinhChitiet.DonGia = Utility.DecimaltoDbnull(_Items.DonGia);
                            objChidinhChitiet.PhuThu = (Utility.isTrue(objLuotkham.DungTuyen) ? Utility.DecimaltoDbnull(_Items.PhuthuDungtuyen) : Utility.DecimaltoDbnull(_Items.PhuthuTraituyen));
                            objChidinhChitiet.TuTuc = 0;
                            objChidinhChitiet.IdDoituongKcb = objLuotkham.IdDoituongKcb;
                            objChidinhChitiet.PtramBhyt = objLuotkham.PtramBhyt;
                        }
                        else
                        {
                            _Items = THU_VIEN_CHUNG.LayQheDoituongCLS("DV", objChidinhChitiet.IdChitietdichvu, objLuotkham.MaKhoaThuchien, CLS_GIATHEO_KHOAKCB);
                            if (_Items != null)
                            {
                                objChidinhChitiet.DonGia = Utility.DecimaltoDbnull(_Items.DonGia);
                                objChidinhChitiet.PhuThu = (Utility.isTrue(objLuotkham.DungTuyen) ? Utility.DecimaltoDbnull(_Items.PhuthuDungtuyen) : Utility.DecimaltoDbnull(_Items.PhuthuTraituyen));
                                objChidinhChitiet.TuTuc = 1;
                                objChidinhChitiet.IdDoituongKcb = objLuotkham.IdDoituongKcb;
                                objChidinhChitiet.PtramBhyt = 0;
                            }
                        }
                        DmucDichvuclsChitiet _DmucDichvuclsChitiet = DmucDichvuclsChitiet.FetchByID(objChidinhChitiet.IdChitietdichvu);
                        if (_DmucDichvuclsChitiet != null && Utility.Int32Dbnull(_DmucDichvuclsChitiet.TuTuc, 0) == 1)
                            objChidinhChitiet.TuTuc = 1;//Ke ca co trong bang quan he
                        if (objLuotkham.IdLoaidoituongKcb == 1)//Đối tượng dịch vụ-->ko cần phải đánh dấu tự túc
                            objChidinhChitiet.TuTuc = 0;

                        objChidinhChitiet.NguoiSua = globalVariables.UserName;
                        objChidinhChitiet.NgaySua = DateTime.Now;
                        decimal PtramBHYT = Utility.DecimaltoDbnull(objLuotkham.PtramBhyt);
                        TinhCLS.GB_TinhPhtramBHYT(objChidinhChitiet, objLuotkham,false, PtramBHYT);
                    }
                    else
                    {
                        return ActionResult.Cancel;
                    }
                }
                objChidinhChitietCollection.SaveAll();
                Scope.Complete();
                return ActionResult.Success;
            }
        }
        /// <summary>
        /// Lấy toàn bộ dữ liệu CLS giống phần chỉ định CLS sau đó tính giá dựa trên dữ liệu lấy được đó. Thay vì select lại từ các bảng quan hệ
        /// </summary>
        /// <param name="objLuotkham"></param>
        /// <returns></returns>
        private static ActionResult CapnhatChiphiCLS(KcbLuotkham objLuotkham, KcbLuotkham objLuotkhamCu)
        {
            using (var Scope = new TransactionScope())
            {
                DataTable m_dtServiceDetail = new KCB_CHIDINH_CANLAMSANG().LaydanhsachCLS_chidinh(objLuotkham.MaDoituongKcb, objLuotkham.TrangthaiNoitru, Utility.ByteDbnull(objLuotkham.GiayBhyt, 0), -1, Utility.Int32Dbnull(objLuotkham.DungTuyen.Value, 0), objLuotkham.MaKhoaThuchien, "-GOI,-TIEN");//Ko lấy dữ liệu liên quan đến gói dịch vụ+tiền phí phụ thêm
                
                KcbChidinhclCollection lstChidinh= 
                    new Select(KcbChidinhcl.Columns.IdChidinh)
                    .From(KcbChidinhcl.Schema)
                    .Where(KcbChidinhcl.Columns.MaLuotkham).IsEqualTo(objLuotkham.MaLuotkham)
                    .And(KcbChidinhcl.Columns.IdBenhnhan).IsEqualTo(objLuotkham.IdBenhnhan)
                    .ExecuteAsCollection<KcbChidinhclCollection>();

                KcbChidinhclsChitietCollection lstChitiet = new Select().From(KcbChidinhclsChitiet.Schema)
                    .Where(KcbChidinhclsChitiet.Columns.IdChidinh).In(lstChidinh.Select(c=>c.IdChidinh).Distinct().ToList<long>())
                .ExecuteAsCollection<KcbChidinhclsChitietCollection>();
                if (lstChitiet.Count > 0)
                {
                    //Kiểm tra nếu đối tượng ngoại trú đã có dịch vụ thanh toán-->Ko cho phép chuyển nữa
                    if (Utility.Byte2Bool(objLuotkham.TrangthaiNoitru) && lstChitiet.Select(c => c.TrangthaiThanhtoan > 0).Any())
                    {
                        return ActionResult.Cancel;
                    }
                    bool saveParent = false;
                    foreach (KcbChidinhcl objChidinh in lstChidinh)
                    {
                        objChidinh.IdLichsuDoituongKcb = objLuotkham.IdLichsuDoituongKcb;
                        objChidinh.MaDoituongKcb = objLuotkham.MaDoituongKcb;
                        objChidinh.IdLoaidoituongKcb = objLuotkham.IdLoaidoituongKcb;
                        objChidinh.IdDoituongKcb = objLuotkham.IdDoituongKcb;
                        foreach (KcbChidinhclsChitiet objChidinhChitiet in lstChitiet.Where(c => c.IdChidinh.Equals(objChidinh.IdChidinh)))
                        {
                            objChidinhChitiet.IdDoituongKcb = objLuotkham.IdDoituongKcb;
                            if (objChidinhChitiet.TrangthaiThanhtoan == 0)//Chưa thanh toán
                            {
                                saveParent = true;
                                objChidinhChitiet.IdLichsuDoituongKcb = objLuotkham.IdLichsuDoituongKcb;
                                objChidinhChitiet.MadoituongGia = objLuotkham.MaDoituongKcb;
                                objChidinhChitiet.PtramBhyt = objLuotkham.PtramBhyt;
                                objChidinhChitiet.PtramBhytGoc = objLuotkham.PtramBhytGoc;
                                DataRow[] arrDr = m_dtServiceDetail.Select(KcbChidinhclsChitiet.Columns.IdChitietdichvu + "=" + Utility.Int32Dbnull(objChidinhChitiet.IdChitietdichvu, -1));
                                if (arrDr.Length > 0)
                                {
                                 
                                    objChidinhChitiet.PtramBhyt = objLuotkham.PtramBhyt;
                                    objChidinhChitiet.DonGia = Utility.DecimaltoDbnull(arrDr[0][KcbChidinhclsChitiet.Columns.DonGia], 0);
                                    objChidinhChitiet.GiaDanhmuc = Utility.DecimaltoDbnull(arrDr[0][KcbChidinhclsChitiet.Columns.DonGia], 0);
                                    objChidinhChitiet.TuTuc = Utility.ByteDbnull(arrDr[0][KcbChidinhclsChitiet.Columns.TuTuc], 0);
                                    objChidinhChitiet.PhuThu = Utility.DecimaltoDbnull(arrDr[0][KcbChidinhclsChitiet.Columns.PhuThu], 0);
                                    objChidinhChitiet.NguoiSua = globalVariables.UserName;
                                    objChidinhChitiet.NgaySua = DateTime.Now;
                                    TinhCLS.GB_TinhPhtramBHYT(objChidinhChitiet, objLuotkham, Utility.Byte2Bool(objChidinh.Noitru), Utility.DecimaltoDbnull(objLuotkham.PtramBhyt));

                                }
                                else//Rất khó nhảy vào nhánh này trừ phi lỗi dữ liệu đặc biệt nào đó
                                {
                                    CLS_GIATHEO_KHOAKCB = THU_VIEN_CHUNG.Laygiatrithamsohethong("CLS_GIATHEO_KHOAKCB", "0", true) == "1";
                                    QheDoituongDichvucl _Items = THU_VIEN_CHUNG.LayQheDoituongCLS(objLuotkham.MaDoituongKcb, objChidinhChitiet.IdChitietdichvu, objLuotkham.MaKhoaThuchien, CLS_GIATHEO_KHOAKCB);
                                    if (_Items != null)
                                    {
                                        objChidinhChitiet.DonGia = Utility.DecimaltoDbnull(_Items.DonGia);
                                        objChidinhChitiet.PhuThu = (Utility.isTrue(objLuotkham.DungTuyen) ? Utility.DecimaltoDbnull(_Items.PhuthuDungtuyen) : Utility.DecimaltoDbnull(_Items.PhuthuTraituyen));
                                        objChidinhChitiet.TuTuc = 0;
                                        objChidinhChitiet.IdDoituongKcb = objLuotkham.IdDoituongKcb;
                                        objChidinhChitiet.PtramBhyt = objLuotkham.PtramBhyt;
                                    }
                                    else
                                    {
                                        _Items = THU_VIEN_CHUNG.LayQheDoituongCLS("DV", objChidinhChitiet.IdChitietdichvu, objLuotkham.MaKhoaThuchien, CLS_GIATHEO_KHOAKCB);
                                        if (_Items != null)
                                        {
                                            objChidinhChitiet.MadoituongGia = "DV";
                                            objChidinhChitiet.DonGia = Utility.DecimaltoDbnull(_Items.DonGia);
                                            objChidinhChitiet.PhuThu = (Utility.isTrue(objLuotkham.DungTuyen) ? Utility.DecimaltoDbnull(_Items.PhuthuDungtuyen) : Utility.DecimaltoDbnull(_Items.PhuthuTraituyen));
                                            objChidinhChitiet.TuTuc = 1;
                                            objChidinhChitiet.IdDoituongKcb = objLuotkham.IdDoituongKcb;
                                            objChidinhChitiet.PtramBhyt = 0;
                                        }
                                    }
                                    DmucDichvuclsChitiet _DmucDichvuclsChitiet = DmucDichvuclsChitiet.FetchByID(objChidinhChitiet.IdChitietdichvu);
                                    if (_DmucDichvuclsChitiet != null && Utility.Int32Dbnull(_DmucDichvuclsChitiet.TuTuc, 0) == 1)
                                        objChidinhChitiet.TuTuc = 1;//Ke ca co trong bang quan he
                                    if (objLuotkham.IdLoaidoituongKcb == 1)//Đối tượng dịch vụ-->ko cần phải đánh dấu tự túc
                                        objChidinhChitiet.TuTuc = 0;

                                    objChidinhChitiet.NguoiSua = globalVariables.UserName;
                                    objChidinhChitiet.NgaySua = DateTime.Now;
                                    decimal PtramBHYT = Utility.DecimaltoDbnull(objLuotkham.PtramBhyt);
                                    TinhCLS.GB_TinhPhtramBHYT(objChidinhChitiet, objLuotkham, Utility.Byte2Bool(objChidinh.Noitru), PtramBHYT);
                                }

                            }
                            else
                            {
                                //nếu đã thanh toán thì chỉ xử lý khi đối tượng đang ở trạng thái nội trú.
                                if (Utility.Byte2Bool(objLuotkham.TrangthaiNoitru))
                                {
                                    saveParent = true;
                                    if (THU_VIEN_CHUNG.IsBaoHiem(objLuotkham.IdLoaidoituongKcb))
                                    {
                                        //Đối tượng mới là BHYT thì kiểm tra đổi các dịch vụ có giá DV về tự túc. 
                                        //Các dịch vụ có giá khác DV thì để nguyên(để nếu đối tượng cũ là BHYT thì ko bị thay đổi giá trị tự túc)
                                        if (objChidinhChitiet.MadoituongGia == "DV")
                                            objChidinhChitiet.TuTuc = 1;
                                    }
                                    else//Nếu đối tượng từ BHYT chuyển sang dịch vụ thì chuyển thành ko tự túc hết
                                    {
                                        if (objLuotkham.MaDoituongKcb != objLuotkhamCu.MaDoituongKcb)//Mới=DV, Cũ=BHYT. Còn lại ko làm gì cả
                                            objChidinhChitiet.TuTuc = 0;
                                    }
                                }
                                else
                                    return ActionResult.Cancel;
                            }
                            objChidinhChitiet.Save();
                            saveParent = true;
                        }
                        if (saveParent)
                        {
                            objChidinh.Save();
                            saveParent = false;
                        }
                    }
                }
                Scope.Complete();
                return ActionResult.Success;
            }
        }

        private static ActionResult CapnhatChiphiKCB(KcbLuotkham objLuotkham, KcbLuotkham objLuotkhamCu)
        {
            using (var Scope = new TransactionScope())
            {
                KcbDangkyKcbCollection objRegExamCollection =
                    new Select().From(KcbDangkyKcb.Schema).Where(KcbDangkyKcb.Columns.MaLuotkham).IsEqualTo(
                        objLuotkham.MaLuotkham).And(KcbDangkyKcb.Columns.IdBenhnhan).IsEqualTo(objLuotkham.IdBenhnhan)
                        .And(KcbDangkyKcb.Columns.LaPhidichvukemtheo).IsEqualTo(0)
                        .ExecuteAsCollection<KcbDangkyKcbCollection>();
                if (objRegExamCollection.Count > 0)
                {
                    //Kiểm tra nếu đối tượng ngoại trú đã có dịch vụ thanh toán-->Ko cho phép chuyển nữa
                    if (Utility.Byte2Bool(objLuotkham.TrangthaiNoitru) && objRegExamCollection.Select(c => c.TrangthaiThanhtoan > 0).Any())
                    {
                        return ActionResult.Cancel;
                    }
                    //CHUYỂN GIÁ KHÁM BỆNH VÀO PHÒNG
                    foreach (KcbDangkyKcb objRegExam in objRegExamCollection)
                    {
                        objRegExam.MaDoituongkcb = objLuotkham.MaDoituongKcb;
                        objRegExam.IdDoituongkcb = objLuotkham.IdDoituongKcb;
                        objRegExam.IdLoaidoituongkcb = objLuotkham.IdLoaidoituongKcb;
                        objRegExam.IdLichsuDoituongKcb = objLuotkham.IdLichsuDoituongKcb;
                        if (objRegExam.TrangthaiThanhtoan == 0)//Các mục chưa thanh toán thì cho phép chuyển
                        {
                           
                            DmucDichvukcb _DichvukcbCu =
                                DmucDichvukcb.FetchByID(objRegExam.IdDichvuKcb);
                            var _DichvukcbMoi =
                                new Select().From(DmucDichvukcb.Schema)
                                    .Where(DmucDichvukcb.Columns.IdKhoaphong).IsEqualTo(_DichvukcbCu.IdKhoaphong)
                                    .And(DmucDichvukcb.Columns.IdPhongkham).IsEqualTo(_DichvukcbCu.IdPhongkham)
                                         .And(DmucDichvukcb.Columns.IdKieukham).IsEqualTo(_DichvukcbCu.IdKieukham)
                                    .AndExpression(DmucDichvukcb.Columns.MaDoituongKcb).IsEqualTo(objLuotkham.MaDoituongKcb)
                                    .Or(DmucDichvukcb.Columns.MaDoituongKcb).IsEqualTo("ALL").CloseExpression()
                                    .ExecuteSingle<DmucDichvukcb>();
                            if (_DichvukcbMoi != null)
                            {
                                objRegExam.IdDichvuKcb = Utility.Int16Dbnull(_DichvukcbMoi.IdDichvukcb, -1);
                                if (Utility.Int32Dbnull(_DichvukcbMoi.TuTuc, 0) == 1)
                                    objRegExam.TuTuc = 1;//Ke ca co trong bang quan he
                                if (objLuotkham.IdLoaidoituongKcb == 1)//Đối tượng dịch vụ-->ko cần phải đánh dấu tự túc
                                    objRegExam.TuTuc = 0;
                                objRegExam.TenDichvuKcb = _DichvukcbMoi.TenDichvukcb;
                                objRegExam.DonGia = Utility.DecimaltoDbnull(_DichvukcbMoi.DonGia);
                                objRegExam.PhuThu = !Utility.Byte2Bool(objLuotkham.DungTuyen)
                                                   ? Utility.DecimaltoDbnull(_DichvukcbMoi.PhuthuDungtuyen)
                                                   : Utility.DecimaltoDbnull(_DichvukcbMoi.PhuthuTraituyen);
                                if (!THU_VIEN_CHUNG.IsBaoHiem(objLuotkham.IdLoaidoituongKcb))
                                    objRegExam.PhuThu = 0;
                                objRegExam.PtramBhyt = objLuotkham.PtramBhyt;//% BHYT ngoại trú
                                objRegExam.PtramBhytGoc = objLuotkham.PtramBhytGoc;
                                if (Utility.Byte2Bool( objRegExam.KhamNgoaigio))
                                {
                                    objRegExam.KhamNgoaigio = 1;
                                    objRegExam.DonGia = Utility.DecimaltoDbnull(_DichvukcbMoi.DongiaNgoaigio, 0);
                                    objRegExam.PhuThu = !Utility.Byte2Bool(objLuotkham.DungTuyen) ? Utility.DecimaltoDbnull(_DichvukcbMoi.PhuthuNgoaigio, 0) : Utility.DecimaltoDbnull(_DichvukcbMoi.PhuthuDungtuyen);
                                }

                                if (Utility.Int32Dbnull(objRegExam.TuTuc, 0) == 0)
                                {
                                    objRegExam.BhytChitra = Utility.DecimaltoDbnull(objRegExam.DonGia) *
                                                           Utility.DecimaltoDbnull(objLuotkham.PtramBhyt) / 100;
                                    objRegExam.BnhanChitra = Utility.DecimaltoDbnull(objRegExam.DonGia, 0) -
                                                              Utility.DecimaltoDbnull(objRegExam.BhytChitra, 0);
                                }
                                else
                                {
                                    objRegExam.BhytChitra = 0;
                                    objRegExam.BnhanChitra = Utility.DecimaltoDbnull(objRegExam.DonGia, 0);
                                }
                            }
                        }
                        else
                        {
                            //nếu đã thanh toán thì chỉ xử lý khi đối tượng đang ở trạng thái nội trú.
                            if (Utility.Byte2Bool(objLuotkham.TrangthaiNoitru))
                            {
                                if (THU_VIEN_CHUNG.IsBaoHiem(objLuotkham.IdLoaidoituongKcb))
                                {
                                    //Đối tượng mới là BHYT thì kiểm tra đổi các dịch vụ có giá DV về tự túc. 
                                    //Các dịch vụ có giá khác DV thì để nguyên(để nếu đối tượng cũ là BHYT thì ko bị thay đổi giá trị tự túc)
                                    if (objRegExam.MadoituongGia == "DV")
                                        objRegExam.TuTuc = 1;
                                }
                                else//Nếu đối tượng từ BHYT chuyển sang dịch vụ thì chuyển thành ko tự túc hết
                                {
                                    if (objLuotkham.MaDoituongKcb != objLuotkhamCu.MaDoituongKcb)//Mới=DV, Cũ=BHYT. Còn lại ko làm gì cả
                                        objRegExam.TuTuc = 0;
                                }
                            }
                            else 
                                return ActionResult.Cancel;
                        }
                    }
                    objRegExamCollection.SaveAll();
                }
                Scope.Complete();
                return ActionResult.Success;
            }
        }
       

      
       
    }
}
