using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma2017.Models
{
    public class Cliente
    {

        public Cliente()
        {
            this.Pedidos = new List<Pedido>();
        }


        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

    }
}