using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Helper
{

    public class UnityDependencyResolver : IDependencyResolver
    {
        IUnityContainer _Container;
        public UnityDependencyResolver(IUnityContainer container)
        {
            _Container = container;
        }
        public object GetService(Type serviceType)
        {
            if(!_Container.IsRegistered(serviceType)&& (serviceType.IsAbstract))
            {
                return null;
            }

            return _Container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _Container.ResolveAll(serviceType);
        }
    }
}