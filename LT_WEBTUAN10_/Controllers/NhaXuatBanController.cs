using LT_WEBTUAN10_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LT_WEBTUAN10_.Controllers
{
    public class NhaXuatBanController : Controller
    {
        Model1 data = new Model1();
        // GET: NhaXuatBan
        public ActionResult SachTheoNXB(int MaNXB)
        {
            List<SACH> dsSach = data.SACHes.Where(s=>s.MANXB == MaNXB).OrderBy(s => s.MANXB == MaNXB).ToList();
            var nxb = data.NHAXUATBANs.Find(MaNXB);
            if (nxb != null)
            {
                ViewBag.TenNhaXuatBan = nxb.TENNXB;
            }
            else
            {
                ViewBag.TenNhaXuatBan = "Không xác định";
            }
            if (dsSach.Count == 0)
            {
                ViewBag.ThongBao = "Không có sách nào thuộc nhà xuất bản này!";
            }
            return View(dsSach);
        }
    }
}