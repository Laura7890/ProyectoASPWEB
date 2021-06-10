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

        public static string NombreProducto(int idProducto)
        {
            using (var db = new inventario2021_2Entities())
            {
                return db.producto.Find(idProducto).nombre;
            }
        }
    }

}