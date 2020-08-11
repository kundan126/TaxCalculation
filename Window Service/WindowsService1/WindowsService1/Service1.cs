using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var config = new HttpSelfHostConfiguration("https://localhost:5001/api/TaxCalculation");
            config.Routes.MapHttpRoute(
                name :"API",
                routeTemplate : "{controller}/{action}/{id}",
                defaults : new {id = RouteParameter.Optional}
                );
            HttpSelfHostServer server = new HttpSelfHostServer(config);
            server.CloseAsync().Wait();

        }

        protected override void OnStop()
        {
        }
    }
}
