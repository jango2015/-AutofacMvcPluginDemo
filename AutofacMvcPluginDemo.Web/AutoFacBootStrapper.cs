using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using System.IO;
using Autofac;
using Autofac.Integration.Mvc;
//using AutofacMvcPluginDemo.Services;

namespace AutofacMvcPluginDemo.Web
{
    public class AutoFacBootStrapper
    {
        public static void AutoFacInit()
        {
            var builder = new ContainerBuilder();

            //注册DomainServices
            var services = Assembly.Load("AutofacMvcPluginDemo.Services");
            builder.RegisterAssemblyTypes(services, services)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces().PropertiesAutowired();

            //实现插件Controllers注入
            var assemblies = new DirectoryInfo(
                     HttpContext.Current.Server.MapPath("~/Plugins/"))
               .GetFiles("*.dll")
               .Select(r => Assembly.LoadFrom(r.FullName)).ToArray();
            foreach (var assembly in assemblies)
            {
                builder.RegisterControllers(assembly).PropertiesAutowired().InstancePerRequest();
            }
            
            //注册主项目的Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            var container = builder.Build();

            var beginLifetimeScope = container.BeginLifetimeScope();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}