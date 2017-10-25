namespace WebAppLab2Turma2017.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAppLab2Turma2017.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppLab2Turma2017.Models.ContextoEF>
    {
        public Configuration()
        {

            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebAppLab2Turma2017.Models.ContextoEF context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Categorias.AddOrUpdate(
           Cat => Cat.CategoriaID,

            new Categoria() { CategoriaID = 1, Descricao = "Informática" },
            new Categoria() { CategoriaID = 2, Descricao = "Games" },
            new Categoria() { CategoriaID = 3, Descricao = "Eletrodomésticos" }
          );

            context.Produtos.AddOrUpdate(
            Pro => Pro.ProdutoID,

              new Produto() { ProdutoID = 1, CategoriaID = 1, Descricao = "Notebook", Valor = 1500 },
              new Produto() { ProdutoID = 2, CategoriaID = 1, Descricao = "Mouse", Valor = 100 },
              new Produto() { ProdutoID = 3, CategoriaID = 1, Descricao = "Teclado", Valor = 120.5M },
              new Produto() { ProdutoID = 4, CategoriaID = 2, Descricao = "Console XBOX ONE", Valor = 1.800M },
              new Produto() { ProdutoID = 5, CategoriaID = 2, Descricao = "Console Play Sation 4", Valor = 2000 }
            );

            context.Clientes.AddOrUpdate(
           Cli => Cli.ClienteID,

               new Cliente() { ClienteID = 1, Nome = "João", Idade = 18 },
               new Cliente() { ClienteID = 2, Nome = "José", Idade = 21 },
               new Cliente() { ClienteID = 3, Nome = "Romário", Idade = 12 },
               new Cliente() { ClienteID = 4, Nome = "Felipe", Idade = 20 },
               new Cliente() { ClienteID = 5, Nome = "Ricardo", Idade = 31 },
               new Cliente() { ClienteID = 6, Nome = "Natália", Idade = 17 },
               new Cliente() { ClienteID = 7, Nome = "Tatiane", Idade = 19 }
                 );

            context.Pedidos.AddOrUpdate(
           Ped => Ped.PedidoID,

           new Pedido() { PedidoID = 1, ClienteID = 1, DataPedido = DateTime.Parse("01/01/2016"), DataEnvio = DateTime.Parse("05/01/2016"), DataEntrega = DateTime.Parse("10/01/2016") },
            new Pedido() { PedidoID = 2, ClienteID = 1, DataPedido = DateTime.Parse("02/01/2016"), DataEnvio = DateTime.Parse("06/01/2016"), DataEntrega = null },
           new Pedido() { PedidoID = 3, ClienteID = 1, DataPedido = DateTime.Parse("03/01/2016"), DataEnvio = DateTime.Parse("07/01/2016"), DataEntrega = null },
            new Pedido() { PedidoID = 4, ClienteID = 2, DataPedido = DateTime.Parse("02/02/2016"), DataEnvio = null, DataEntrega = null },
            new Pedido() { PedidoID = 5, ClienteID = 2, DataPedido = DateTime.Parse("05/02/2016"), DataEnvio = null, DataEntrega = null }
            );

            context.ItemDoPedido.AddOrUpdate(
          Item => Item.ID,

          new ItemDoPedido() { PedidoID = 1, ProdutoID = 1, Quantidade = 1 },
          new ItemDoPedido() { PedidoID = 1, ProdutoID = 2, Quantidade = 1 },
          new ItemDoPedido() { PedidoID = 1, ProdutoID = 3, Quantidade = 1 },
          new ItemDoPedido() { PedidoID = 2, ProdutoID = 4, Quantidade = 2 },
          new ItemDoPedido() { PedidoID = 3, ProdutoID = 5, Quantidade = 1 }
          );
        }
    }
}
