using System;

namespace ProyectoASPWEB.Controllers
{
    internal class ReporteCompra
    {
        public string nombreCliente { get; set; }
        public string documentoCliente { get; set; }
        public DateTime fechaCompra { get; set; }
        public int totalCompra { get; set; }
    }
}