namespace CasaDoCodigo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cadastro",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                        Complemento = c.String(nullable: false),
                        Bairro = c.String(nullable: false),
                        Municipio = c.String(nullable: false),
                        UF = c.String(nullable: false),
                        CEP = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemPedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Produto_Id = c.Int(nullable: false),
                        Pedido_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produto", t => t.Produto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.Pedido_Id, cascadeDelete: true)
                .Index(t => t.Produto_Id)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPedido", "Pedido_Id", "dbo.Pedido");
            DropForeignKey("dbo.ItemPedido", "Produto_Id", "dbo.Produto");
            DropForeignKey("dbo.Cadastro", "Id", "dbo.Pedido");
            DropIndex("dbo.ItemPedido", new[] { "Pedido_Id" });
            DropIndex("dbo.ItemPedido", new[] { "Produto_Id" });
            DropIndex("dbo.Cadastro", new[] { "Id" });
            DropTable("dbo.Produto");
            DropTable("dbo.ItemPedido");
            DropTable("dbo.Pedido");
            DropTable("dbo.Cadastro");
        }
    }
}
