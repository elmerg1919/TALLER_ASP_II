using System.Web;
using System.Web.Mvc;

namespace TALLER_ASP_II
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
