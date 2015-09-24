using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacMvcPluginDemo.Services
{
   public interface ITestService
   {
       string GetPluginData();
       string GetWebData();
   }
}
