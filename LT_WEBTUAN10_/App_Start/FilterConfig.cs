using System.Web;
using System.Web.Mvc;

namespace LT_WEBTUAN10_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
