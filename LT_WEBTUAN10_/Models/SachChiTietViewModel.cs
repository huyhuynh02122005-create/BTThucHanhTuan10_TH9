using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LT_WEBTUAN10_.Models
{
    
    public class TacGiaVaiTro
    {
        public string TenTacGia { get; set; }
        public string VaiTro { get; set; }
        public string TieuSu { get; set; }
    }

 
    public class SachChiTietViewModel
    {
        public SACH Sach { get; set; }
        public List<TacGiaVaiTro> TacGiaList { get; set; }

        public List<SACH> SachCungChuDe { get; set; }
        public List<SACH> SachCungNhaXuatBan { get; set; }
    }
}