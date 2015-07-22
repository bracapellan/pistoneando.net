using Pistoneando.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data;
using System.Data.Entity;


namespace Pistoneando.Controllers
{
    public class HomeController : Controller
    {
        private PistoneandoContext db = new PistoneandoContext();
        public ActionResult Index()
        {
            var lista = (from noticia in db.Noticia select noticia).ToList();
            return View(lista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Pistoneando begins";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "¿Tienes algo que decir? ¡Contactanos!";

            return View();
        }
    }
}