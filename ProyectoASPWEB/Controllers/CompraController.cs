using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoASPWEB.Models;
using Rotativa;

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

        public ActionResult Edit(int id)

        {
            try
            {
                using (var db = new inventario2021_2Entities())

                {
                    compra compra = db.compra.Where(a => a.id == id).FirstOrDefault();
                    return View(compra);
                }

            }
            catch (Exception ex)

            {
                ModelState.AddModelError("", "error" + ex);
                return View();

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(compra compraEdit)
        {
            try
            {
                using (var db = new inventario2021_2Entities())
                {
                    var compra = db.compra.Find(compraEdit.id);
                    compra.fecha = compraEdit.fecha;
                    compra.total = compraEdit.total;
                    compra.id_usuario = compraEdit.id_usuario;
                    compra.id_cliente = compraEdit.id_cliente;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)

            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021_2Entities())

            {
                compra compraDetalle = db.compra.Where(a => a.id == id).FirstOrDefault();
                return View(compraDetalle);
            }
        }

        public ActionResult Delete(int id)
        {

            using (var db = new inventario2021_2Entities())
            {
                var compraDelete = db.compra.Find(id);
                db.compra.Remove(compraDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Reporte1()
        {
            try
            {
                var db = new inventario2021_2Entities();
                var query = from tabCliente in db.cliente
                            join tabCompra in db.compra on tabCliente.id equals tabCompra.id_cliente
                            select new Reporte1
                            {
                                nombreCliente = tabCliente.nombre,
                                documentoCliente = tabCliente.documento,
                                emailCliente = tabCliente.email,
                                fechaCompra = tabCompra.fecha,
                                totalCompra = tabCompra.total
                            };

                return View(query);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult ImprimirReporte1()
        {
            return new ActionAsPdf("Reporte1") { FileName = "Reporte1.pdf" };
        }
    }
}