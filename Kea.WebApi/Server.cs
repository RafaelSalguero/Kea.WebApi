using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Http.SelfHost;
using Autofac;
using Autofac.Integration.WebApi;

namespace Kea.WebApi
{
    public class Server : IDisposable
    {
        public HttpSelfHostServer server { get; private set; }

        public Server(string address)
        {
            var config = new HttpSelfHostConfiguration(address);
            config.Routes.MapHttpRoute(
                "API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            config.DependencyResolver = GetContainer();

            server = new HttpSelfHostServer(config);
        }

        /// <summary>
        /// Obtiene el IoC
        /// </summary>
        /// <returns></returns>
        public static IDependencyResolver GetContainer()
        {
            var builder = new ContainerBuilder();

            //Add application dependencies here (Database, services, etc...)

            //Register controllers:
            var r = builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            var container = builder.Build();
            return new AutofacWebApiDependencyResolver(container);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (server != null) server.Dispose();
            }
        }
    }
}
