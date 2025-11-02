using LT_WEBTUAN10_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LT_WEBTUAN10_.Controllers
{
    public class ChuDeController : Controller
    {
        // GET: ChuDe
        Model1 data = new Model1();
        public ActionResult SachTheoCD(int MaCD)
        {
            List<SACH> dsSach = data.SACHes.Where(s =>s.MACHUDE == MaCD).OrderBy(s => s.GIABAN).ToList();  
            
            var ChuDe = data.CHUDEs.Find(MaCD);
            if (ChuDe != null)
            {
                ViewBag.TenChuDe = ChuDe.TENCHUDE;
            }
            else
            {
                ViewBag.TenChuDe = "Không xác định";
            }

            if(dsSach.Count == 0)
            {
                ViewBag.ThongBao = "Không có sách nào thuộc chủ đề này!";
            }
            return View(dsSach);
        }
    }
}