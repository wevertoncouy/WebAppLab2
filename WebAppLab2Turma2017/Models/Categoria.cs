using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma2017.Models
{
    public class Categoria
    {

        public Categoria()
        {
            this.Produtos = new List<Produto>();
        }

        public int CategoriaID { get; set; }
      
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}