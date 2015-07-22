using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pistoneando.Models;

namespace Pistoneando.Controllers
{
    public class NoticiaController : Controller
    {
        private PistoneandoContext db = new PistoneandoContext();

        // GET: /Noticia/
        public ActionResult Index()
        {
            var noticia = db.Noticia.Include(n => n.Categoria);
            return View(noticia.ToList());
        }

        // GET: /Noticia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = db.Noticia.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        // GET: /Noticia/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categoria, "ID", "Nombre");
            return View();
        }

        // POST: /Noticia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,CategoriaID,Titulo,FechaPublicacion,ImagenPortada,DescripcionCorta,DescripcionLarga,Contenido")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                db.Noticia.Add(noticia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categoria, "ID", "Nombre", noticia.CategoriaID);
            return View(noticia);
        }

        // GET: /Noticia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = db.Noticia.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "ID", "Nombre", noticia.CategoriaID);
            return View(noticia);
        }

        // POST: /Noticia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,CategoriaID,Titulo,FechaPublicacion,ImagenPortada,DescripcionCorta,DescripcionLarga,Contenido")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categoria, "ID", "Nombre", noticia.CategoriaID);
            return View(noticia);
        }

        // GET: /Noticia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = db.Noticia.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        // POST: /Noticia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Noticia noticia = db.Noticia.Find(id);
            db.Noticia.Remove(noticia);
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
