using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo  
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("ApplicationContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var cadastroEntity = modelBuilder.Entity<Cadastro>();
            cadastroEntity.HasKey(t => t.Id);
            
            var produtoEntity = modelBuilder.Entity<Produto>();
            produtoEntity.HasKey(t => t.Id);

            var pedidoEntity = modelBuilder.Entity<Pedido>();
            pedidoEntity.HasKey(t => t.Id);
            pedidoEntity.HasMany(t => t.Itens).WithRequired(t => t.Pedido);

            pedidoEntity
                .HasOptional(t => t.Cadastro)
                .WithRequired(t => t.Pedido);

            var itemPedidoEntity = modelBuilder.Entity<ItemPedido>();
            itemPedidoEntity.HasKey(t => t.Id);
            itemPedidoEntity.HasRequired(t => t.Pedido);
            itemPedidoEntity.HasRequired(t => t.Produto);
        }
    }
}
