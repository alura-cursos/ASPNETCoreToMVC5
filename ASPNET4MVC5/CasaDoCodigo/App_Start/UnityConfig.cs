using System;
using System.Web.Mvc;
using CasaDoCodigo.Repositories;
using Microsoft.Practices.Unity;
using Unity;
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
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}