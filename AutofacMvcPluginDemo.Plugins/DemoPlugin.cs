using System.Web.Routing;
using System.Web.Mvc;
using Plugin;

namespace AutofacMvcPluginDemo.Plugins
{
    public class DemoPlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "Plugin"; //Assembly.GetExecutingAssembly().GetName().Name;            
            }
        }
        public void Initialize()
        {
            var route = RouteTable.Routes.MapRoute(
                 name: Name,
                 url: Name + "/{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, pluginName = Name }
             );

            route.DataTokens["area"] = Name;
        }

        public void Unload()
        {
            RouteTable.Routes.Remove(RouteTable.Routes[Name]);
        }
    }
}