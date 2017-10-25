using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppLab2Turma2017.Models;

namespace WebAppLab2Turma2017.Controllers
{
    public class ClienteController : Controller
    {
        private ContextoEF db = new ContextoEF();

        //Pessoas com maior idade na table
        public ActionResult ClientesMaioresIdade()
        {
            var clientesMaioresIdade = db.Clientes.Where(c => c.Idade > 18).ToList();
            return View(clientesMaioresIdade);
        }

        //CLiente Mais velho da tabela 
        public ActionResult ClienteMaisVelho()
        {

            var clienteMaisVelho = db.Clientes.Max(c => c.Idade);
            ViewBag.Idade = clienteMaisVelho;
            return View();
        }

        //Média de idade dos Clientes
        public ActionResult MediaIdadeClientes()
        {
            var mediaIdadeClientes = db.Clientes.Average(c => c.Idade);
            ViewBag.MediaIdadeClientes = mediaIdadeClientes;
            return View();
        }

        //Ultimo Cliente Cadastrado
        public ActionResult UltimoClienteCadastrado()
        {
            var ultimoClienteCadastrado = db.Clientes.ToList().LastOrDefault();         
            return View(ultimoClienteCadastrado);
        }
        //Exibe Quantidade Total de clientes 




        // GET: Cliente
        public ActionResult Index()
        {//Conta total de Cliente 
            var totalClientes = db.Clientes.Count();
            ViewBag.TotalClientes = totalClientes;
            return View(db.Clientes.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,Nome,Idade")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,Nome,Idade")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
