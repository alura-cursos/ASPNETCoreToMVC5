using System;
using System.Web;
using System.Web.Mvc;
using CasaDoCodigo.Repositories;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace CasaDoCodigo
{
    public static class UnityConfig
    {
        public static Type IUserRepository { get; private set; }

        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDataService, DataService>();
            container.RegisterType<IProdutoRepository, ProdutoRepository>();
            container.RegisterType<IPedidoRepository, PedidoRepository>();
            container.RegisterType<ICadastroRepository, CadastroRepository>();
            container.RegisterType<IItemPedidoRepository, ItemPedidoRepository>();
            container.RegisterType<HttpSessionStateBase>(
                new InjectionFactory(x =>
                    new HttpSessionStateWrapper(System.Web.HttpContext.Current.Session)));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}