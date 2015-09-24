using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutofacMvcPluginDemo.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //启用autofac注入
            AutoFacBootStrapper.AutoFacInit();

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MyViewEngine());

        }
    }
}
