using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma2017.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public int ClienteID { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime? DataEnvio { get; set; }
        public DateTime? DataEntrega { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemDoPedido> ItemDoPedido { get; set; }


    }
}