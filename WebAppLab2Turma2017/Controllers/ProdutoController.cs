using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppLab2Turma2017.Models;
using WebAppLab2Turma2017.Models.ViewModels;

namespace WebAppLab2Turma2017.Controllers
{
    public class ProdutoController : Controller
    {
        private ContextoEF db = new ContextoEF();

        public ActionResult FiltroPorIntervalor()
        {
            var FiltroPorIntervalor = db.Produtos
                .Where(p => p.Valor >= 100 && p.Valor <= 1800)
                .Select(
                p=> new ProdutoPorIntervalorViewModel
                {
                    CodigoProduto = p.ProdutoID,
                    ValorProduto = p.Valor,
                    NomeProduto = p.Descricao
                }).ToList();
            return View(FiltroPorIntervalor);
        }


        //Produtos X Categorias
        public ActionResult ProdutosCategorias()
        {
            var ProdutosCategorias = (from p in db.Produtos
                                      join c in db.Categorias
                                      on p.CategoriaID equals c.CategoriaID
                                      orderby p.Descricao
                                      select new ProdutoCategoriaViewModel
                                      {
                                          CodigoProduto = p.ProdutoID,
                                          DescricaoProduto = p.Descricao,
                                          CodigoCategoria = c.CategoriaID,
                                          DescricaoCategoria = c.Descricao
                                      }).ToList();
            return View(ProdutosCategorias);
        }



        // GET: Produto
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(produtos.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao");
            return View();
        }

        // POST: Produto/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoID,CategoriaID,Descricao,Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID,CategoriaID,Descricao,Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
