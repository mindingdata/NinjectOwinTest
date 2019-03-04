using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace ServiceFactoryLibrary
{
    public class ServiceFactoryModule : NinjectModule
    {
        public override void Load()
        {
            ServiceFactory.SetKernel(Kernel);
        }
    }
}
