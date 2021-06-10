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
    }

}