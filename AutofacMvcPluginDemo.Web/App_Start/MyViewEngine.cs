using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutofacMvcPluginDemo.Web
{
    public class MyViewEngine : VirtualPathProviderViewEngine
    {
        public MyViewEngine()
        {
            AreaViewLocationFormats = new string[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml", 
                "~/Areas/{2}/Views/Shared/{0}.cshtml", 
                "~/Areas/{2}/Views/Shared/{0}.vbhtml" 
            };
            AreaMasterLocationFormats = new string[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml", 
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };
            AreaPartialViewLocationFormats = new string[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml", 
                "~/Areas/{2}/Views/Shared/{0}.cshtml", 
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };
            ViewLocationFormats = new string[]
            {
                "~/Plugins/Views/{1}/{0}.cshtml",
                "~/Plugins/Views/Shared/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
            MasterLocationFormats = new string[]
            {
                "~/T/{1}/{0}.cshtml", 
                "~/T/Shared/{0}.cshtml"
            };
            PartialViewLocationFormats = new string[]
            {
                "~/T/{1}/{0}.cshtml", 
                "~/T/Shared/{0}.cshtml"
            };
            FileExtensions = new string[] { "cshtml", "vbhtml" };
        }


        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return new WebFormView(controllerContext, partialPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new RazorView(controllerContext, viewPath, masterPath, true, null);
        }
    }
}