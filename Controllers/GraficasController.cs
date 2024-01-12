using PROYECTO_WEB.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROYECTO_WEB.Controllers
{
    [Authorize]
    public class GraficasController : Controller
    {
        public ActionResult Clientes()
        {
            return View();
        }

        public ActionResult GraficaClientes()
        {
            bases_ventasClientes db = new bases_ventasClientes();
            ArrayList xvalores = new ArrayList();
            ArrayList yvalores = new ArrayList();
            var resultados = db.cliente.ToList();
            resultados.ToList().ForEach(rs => xvalores.Add(rs.nombre));
            resultados.ToList().ForEach(rs => yvalores.Add(rs.estado_c));
            var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
            .AddTitle("Clientes Activos")
            .AddSeries(chartType: "Column", name: "Columnas", xValue: xvalores, yValues:
           yvalores);
            return File(grafico.GetBytes("png"), "Image/png");
        }

        public ActionResult Productos()
        {
            return View();
        }

        public ActionResult GraficaProductos()
        {
            bases_ventasProductos db = new bases_ventasProductos();
            ArrayList xvalores = new ArrayList();
            ArrayList yvalores = new ArrayList();
            var resultados = db.producto.ToList();
            resultados.ToList().ForEach(rs => xvalores.Add(rs.nombre));
            resultados.ToList().ForEach(rs => yvalores.Add(rs.stock));
            var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
            .AddTitle("Stock Productos")
            .AddSeries(chartType: "Column", name: "Columnas", xValue: xvalores, yValues:
           yvalores);
            return File(grafico.GetBytes("png"), "Image/png");
        }

        public ActionResult Empleados()
        {
            return View();
        }

        public ActionResult GraficaEmpleados()
        {
            bases_ventasEmpleados db = new bases_ventasEmpleados();
            ArrayList xvalores = new ArrayList();
            ArrayList yvalores = new ArrayList();
            var resultados = db.empleado.ToList();
            resultados.ToList().ForEach(rs => xvalores.Add(rs.nombre));
            resultados.ToList().ForEach(rs => yvalores.Add(rs.estado_e));
            var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
            .AddTitle("Empleados Activos")
            .AddSeries(chartType: "Column", name: "Columnas", xValue: xvalores, yValues:
           yvalores);
            return File(grafico.GetBytes("png"), "Image/png");
        }

        public ActionResult Proveedores()
        {
            return View();
        }

        public ActionResult GraficaProveedores()
        {
            bases_ventasProveedores db = new bases_ventasProveedores();
            ArrayList xvalores = new ArrayList();
            ArrayList yvalores = new ArrayList();
            var resultados = db.proveedores.ToList();
            resultados.ToList().ForEach(rs => xvalores.Add(rs.nombre));
            resultados.ToList().ForEach(rs => yvalores.Add(rs.Id_proveedores));
            var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
            .AddTitle("ID Proveedores")
            .AddSeries(chartType: "Column", name: "Columnas", xValue: xvalores, yValues:
           yvalores);
            return File(grafico.GetBytes("png"), "Image/png");
        }

        public ActionResult Ventas()
        {
            return View();
        }

        public ActionResult GraficaVentas()
        {
            bases_ventasVentas db = new bases_ventasVentas();
            ArrayList xvalores = new ArrayList();
            ArrayList yvalores = new ArrayList();
            var resultados = db.ventas.ToList();
            resultados.ToList().ForEach(rs => xvalores.Add(rs.id_ventas));
            resultados.ToList().ForEach(rs => yvalores.Add(rs.monto));
            var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
            .AddTitle("Valor Ventas")
            .AddSeries(chartType: "Column", name: "Columnas", xValue: xvalores, yValues:
           yvalores);
            return File(grafico.GetBytes("png"), "Image/png");
        }

        public ActionResult Compras()
        {
            return View();
        }

        public ActionResult GraficaCompras()
        {
            bases_ventasCompras db = new bases_ventasCompras();
            ArrayList xvalores = new ArrayList();
            ArrayList yvalores = new ArrayList();
            var resultados = db.compras.ToList();
            resultados.ToList().ForEach(rs => xvalores.Add(rs.Id_compras));
            resultados.ToList().ForEach(rs => yvalores.Add(rs.monto));
            var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
            .AddTitle("Valor Compras")
            .AddSeries(chartType: "Column", name: "Columnas", xValue: xvalores, yValues:
           yvalores);
            return File(grafico.GetBytes("png"), "Image/png");
        }

        public ActionResult DetallesC()
        {
            return View();
        }

        public ActionResult GraficaDetallesC()
        {
            bases_ventasDetallesC db = new bases_ventasDetallesC();
            ArrayList xvalores = new ArrayList();
            ArrayList yvalores = new ArrayList();
            var resultados = db.detalles_compras.ToList();
            resultados.ToList().ForEach(rs => xvalores.Add(rs.id_producto));
            resultados.ToList().ForEach(rs => yvalores.Add(rs.precio_compra));
            var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
            .AddTitle("Productos mas comprados")
            .AddSeries(chartType: "Column", name: "Columnas", xValue: xvalores, yValues:
           yvalores);
            return File(grafico.GetBytes("png"), "Image/png");
        }

        public ActionResult DetallesV()
        {
            return View();
        }

        public ActionResult GraficaDetallesV()
        {
            bases_ventasDetallesV db = new bases_ventasDetallesV();
            ArrayList xvalores = new ArrayList();
            ArrayList yvalores = new ArrayList();
            var resultados = db.detalles_ventas.ToList();
            resultados.ToList().ForEach(rs => xvalores.Add(rs.id_producto));
            resultados.ToList().ForEach(rs => yvalores.Add(rs.precio_venta));
            var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
            .AddTitle("Productos mas vendidos")
            .AddSeries(chartType: "Column", name: "Columnas", xValue: xvalores, yValues:
           yvalores);
            return File(grafico.GetBytes("png"), "Image/png");
        }
    }
}