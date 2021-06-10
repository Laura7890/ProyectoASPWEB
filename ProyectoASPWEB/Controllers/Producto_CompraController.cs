using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoASPWEB.Models;

namespace ProyectoASPWEB.Controllers
{
    public class Producto_CompraController : Controller
    {
        // GET: Producto_Compra
        public ActionResult Index()
        {
            using (var db = new inventario2021_2Entities())
            {
                return View(db.producto_compra.ToList());
            }
        }

        public static int NombreCompra(int idCompra)
        {
            using (var db = new inventario2021_2Entities())
            {
                return db.compra.Find(idCompra).id_cliente;
            }
        }

        public ActionResult ListarCompra()
        {
            using (var db = new inventario2021_2Entities())
            {
                return PartialView(db.compra.ToList());
            }
        }

        public static string NombreProducto(int idProducto)
        {
            using (var db = new inventario2021_2Entities())
            {
                return db.producto.Find(idProducto).nombre;
            }
        }

        public ActionResult ListarProducto()
        {
            using (var db = new inventario2021_2Entities())
            {
                return PartialView(db.producto.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_compra ProductoCompra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021_2Entities())
                {
                    db.producto_compra.Add(ProductoCompra);
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
                    producto_compra productoCompra = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                    return View(productoCompra);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_compra productoCompraEdit)
        {
            try
            {
                using (var db = new inventario2021_2Entities())
                {
                    var productoCompra = db.producto_compra.Find(productoCompraEdit.id);
                    productoCompra.id_compra = productoCompraEdit.id_compra;
                    productoCompra.id_producto = productoCompraEdit.id_producto;
                    productoCompra.cantidad = productoCompraEdit.cantidad;
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

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021_2Entities())
            {
                producto_compra productoCompraDetalle = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                return View(productoCompraDetalle);
            }
        }
    }

}