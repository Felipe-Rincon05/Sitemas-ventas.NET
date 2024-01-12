using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROYECTO_WEB.Controllers
{
    public class Producto_VC
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
        public string cantidad { get; set; }
        public string subtotal { get; set; }

        public Producto_VC(string codigo, string descripcion, string precio, string cantidad, string subtotal)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.precio = precio;
            this.cantidad = cantidad;
            this.subtotal = subtotal;
        }
    }
}