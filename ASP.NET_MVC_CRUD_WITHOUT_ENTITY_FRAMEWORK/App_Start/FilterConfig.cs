using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_CRUD_WITHOUT_ENTITY_FRAMEWORK
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
