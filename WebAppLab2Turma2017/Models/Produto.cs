using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma2017.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public int CategoriaID { get; set; }
        public String Descricao { get; set; }
        public decimal Valor { get; set; }


        public  virtual Categoria Categoria { get; set; }
        public virtual ICollection<ItemDoPedido> ItemDoPedido{ get; set; }

    }
}       