using LT_WEBTUAN10_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace LT_WEBTUAN10_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Model1 data = new Model1();
            List<SACH> dsSach = data.SACHes.OrderByDescending(s => s.NGAYCAPNHAT).Take(5).ToList();
            return View(dsSach);
        }
        public ActionResult DSMenu_ChuDe()
        {
            Model1 data = new Model1();
            List<CHUDE> dsCD = data.CHUDEs.Take(10).ToList();
            return PartialView(dsCD);
        }
        public ActionResult DSMenu_NXB()
        {
            Model1 data = new Model1();
            List<NHAXUATBAN> dsXB = data.NHAXUATBANs.Take(10).ToList();
            return PartialView(dsXB);
        }

        public ActionResult ChiTiet(int? MaSach)
        {
            if (MaSach == null)
            {
                return RedirectToAction("Index");
            }

            Model1 data = new Model1();

            SACH sach = data.SACHes.FirstOrDefault(m => m.MASACH == MaSach.Value);

            if (sach == null)
                return HttpNotFound();

            
            var tacGiaList = (from tg in data.TACGIAs
                              join THAMGIA in data.THAMGIAs on tg.MATACGIA equals THAMGIA.MATACGIA
                              where THAMGIA.MASACH == MaSach.Value
                              select new TacGiaVaiTro
                              {
                                  TenTacGia = tg.TENTACGIA,
                                  VaiTro = THAMGIA.VAITRO,
                                  TieuSu = tg.TIEUSU
                              }).ToList();
            var sachCungChuDe = data.SACHes
                .Where(s => s.MACHUDE == sach.MACHUDE && s.MASACH != MaSach.Value)
                .Take(5)
                .ToList();

            
            var sachCungNXB = data.SACHes
                .Where(s => s.MANXB == sach.MANXB && s.MASACH != MaSach.Value)
                .Take(5)
                .ToList();

            SachChiTietViewModel viewModel = new SachChiTietViewModel
            {
                Sach = sach,
                TacGiaList = tacGiaList,
                SachCungChuDe = sachCungChuDe,
                SachCungNhaXuatBan = sachCungNXB
            };

            return View(viewModel);
        }
        public ActionResult TimKiemNangCao(string tuKhoa, int? maChuDe, string mucGia)
        {
            Model1 data = new Model1();

            ViewBag.MaChuDeList = new SelectList(data.CHUDEs, "MACHUDE", "TENCHUDE", maChuDe);

            var dsSach = data.SACHes.AsQueryable(); 

            bool daTimKiem = false;

            if (!String.IsNullOrEmpty(tuKhoa))
            {
                dsSach = dsSach.Where(s => s.TENSACH.Contains(tuKhoa));
                daTimKiem = true;
            }

            if (maChuDe != null)
            {
                dsSach = dsSach.Where(s => s.MACHUDE == maChuDe);
                daTimKiem = true;
            }

            if (!String.IsNullOrEmpty(mucGia))
            {
                daTimKiem = true;
                switch (mucGia)
                {
                    case "1":
                        dsSach = dsSach.Where(s => s.GIABAN >= 0 && s.GIABAN <= 100000);
                        break;
                    case "2":
                        dsSach = dsSach.Where(s => s.GIABAN >= 110000 && s.GIABAN <= 200000);
                        break;
                    case "3":
                        dsSach = dsSach.Where(s => s.GIABAN >= 210000 && s.GIABAN <= 400000);
                        break;
                    case "4":
                        dsSach = dsSach.Where(s => s.GIABAN > 400000);
                        break;
                }
            }

            ViewBag.DaTimKiem = daTimKiem;
            if (daTimKiem)
            {

                return View(dsSach.ToList());
            }
            else
            {

                return View(new List<SACH>());
            }
        }



    }
}