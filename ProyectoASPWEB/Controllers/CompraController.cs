using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoASPWEB.Models;

namespace ProyectoASPWEB.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            using (var db = new inventario2021_2Entities())
            {
                return View(db.compra.ToList());
            }
        }

        public static string NombreUsuario(int idUsuario)
        {
            using (var db = new inventario2021_2Entities())
            {
                return db.usuario.Find(idUsuario).nombre;
            }
        }

        public ActionResult ListarUsuario()
        {
            using (var db = new inventario2021_2Entities())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public static string NombreCliente(int idCliente)
        {
            using (var db = new inventario2021_2Entities())
            {
                return db.cliente.Find(idCliente).nombre;
            }
        }

        public ActionResult ListarCliente()
        {
            using (var db = new inventario2021_2Entities())
            {
                return PartialView(db.cliente.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(compra Compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021_2Entities())
                {
                    db.compra.Add(Compra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }
    }
}