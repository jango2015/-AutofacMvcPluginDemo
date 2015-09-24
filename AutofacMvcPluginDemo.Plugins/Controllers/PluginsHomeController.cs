using System.Web.Mvc;
using AutofacMvcPluginDemo.Services;

namespace AutofacMvcPluginDemo.Plugins.Controllers
{
    public class PluginsHomeController : Controller
    {
        //public ITestService Service { get; set; }
        //public PluginsHomeController(ITestService iTestService)
        //{
        //    Service = iTestService;
        //}
        //public PluginsHomeController() { }

        public ActionResult Index()
        {
            var service = DependencyResolver.Current.GetService<ITestService>();
            ViewBag.Show = service.GetWebData();
            return View();
        }
    }
}