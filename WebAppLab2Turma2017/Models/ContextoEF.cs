using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma2017.Models
{
    public class ContextoEF : DbContext
    {
        public ContextoEF() : base("name=DefaultConnection")
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemDoPedido> ItemDoPedido{ get; set; }


        //o metodo onmodelcreating Remoce a puralização de nome de tabelas quando sistema gera o banco
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}