using System;
using System.Web.Mvc;
using AutofacMvcPluginDemo.Services;

namespace AutofacMvcPluginDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        ITestService _service;
        public HomeController(ITestService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Show = _service.GetWebData();
            return View();
        }
    }
}