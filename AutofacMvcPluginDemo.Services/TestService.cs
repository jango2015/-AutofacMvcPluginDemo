using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacMvcPluginDemo.Services
{
    public class TestService : ITestService
    {

        public string GetPluginData()
        {
            return "this is the data that the plugin gets ";
        }

        public string GetWebData()
        {
            return "this tis the data that the main web gets";
        }
    }
}
