using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using ServiceFactoryLibrary;

namespace OWinTest
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseNinjectMiddleware(CreateKernel);



            appBuilder.UseNinjectWebApi(config);

            appBuilder.Use(async (context, next) =>
            {
                var something = new ServiceFactory().GetScopedService();
                await next();
            });


        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel(new NinjectSettings(), new ServiceFactoryModule());
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
    }
}