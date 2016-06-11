using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAG.Repository
{
    public static class ModelContainer
    {
        private static IUnityContainer _Instance;
        static ModelContainer()
        {
            _Instance = new UnityContainer();
        }

        public static IUnityContainer Instance
        {
            get
            {
                _Instance.RegisterType<IAccountRepository, IAccountRepository>(new HierarchicalLifetimeManager());
                _Instance.RegisterType<ISecurityRepository, SecurityRepository>(new HierarchicalLifetimeManager());
                _Instance.RegisterType<IMarketsAndNewsRepository, MarketAndNewsRepository>(new HierarchicalLifetimeManager());
                return _Instance;
            }
        }
    }
}
