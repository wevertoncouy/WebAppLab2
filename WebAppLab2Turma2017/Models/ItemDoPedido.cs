using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma2017.Models
{
    public class ItemDoPedido
    {
        public int ID { get; set; }
        public int PedidoID { get; set; }
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido{ get; set; }
        
    }
}