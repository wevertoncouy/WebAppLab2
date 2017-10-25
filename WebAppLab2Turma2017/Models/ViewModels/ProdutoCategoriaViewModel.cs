using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppLab2Turma2017.Models.ViewModels
{
    public class ProdutoCategoriaViewModel
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int CodigoCategoria { get; set; }
        public string DescricaoCategoria { get; set; }

    }
}