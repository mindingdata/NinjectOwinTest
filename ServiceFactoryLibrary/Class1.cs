using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Syntax;

namespace ServiceFactoryLibrary
{
    public class ServiceFactory
    {
        public static IResolutionRoot _resolutionRoot;

        public static void SetKernel(IResolutionRoot resolutionRoot)
        {
            if (_resolutionRoot != null)
            {
                throw new InvalidOperationException("Resolution Root has already been set");
            }
            _resolutionRoot = resolutionRoot;
        }

        public IRequestScopedService GetScopedService()
        {
            return _resolutionRoot.Get<IRequestScopedService>();
        }

    }
}
