using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Ninject.Web.Common;
using ServiceFactoryLibrary;

namespace OWinTest
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRequestScopedService>().To<RequestScopedService>().InRequestScope();
        }
    }
}