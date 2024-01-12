using Microsoft.Reporting.WebForms;
using PROYECTO_WEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROYECTO_WEB.Controllers
{
    [Authorize]
    public class ReportesSPController : Controller
    {
        public ActionResult VistaReporteClientes(string id)
        {
            LocalReport reporte = new LocalReport();
            bases_ventasClientes db = new bases_ventasClientes();
            string ruta = Path.Combine(Server.MapPath("~/Reportes"),
           "ReporteSPClientes.rdlc");
            reporte.ReportPath = ruta;
            List<cliente> listado = new List<cliente>();
            listado = db.cliente.ToList();
            ReportDataSource verreporte = new ReportDataSource("ReporteSP_de_clientes", listado);
            reporte.DataSources.Add(verreporte);
            string tiporeporte = id;
            string mime, codificacion, archivo;
            string[] flujo;
            Warning[] aviso;
            string dispositivo = @"<DeviceInfo>" +
            " <OutputFormat>" + id + "</OutputFormat>" +
            " <PageWidth>8.5in</PageWidth>" +
            " <PageHeight>11in</PageHeight>" +
            " <MarginTop>0.5in</MarginTop>" +
            " <MarginLeft>1in</MarginLeft>" +
            " <MarginRight>1in</MarginRight>" +
            " <MarginBottom>0.5in</MarginBottom>" +
            " <EmbedFonts>None</EmbedFonts>" +
            "</DeviceInfo>";
            byte[] enviar = reporte.Render(id, dispositivo, out mime,
                out codificacion, out archivo, out flujo, out aviso);
            return File(enviar, mime);
        }

        public ActionResult VistaReporteEmpleados(string id)
        {
            LocalReport reporte = new LocalReport();
            bases_ventasEmpleados db = new bases_ventasEmpleados();
            string ruta = Path.Combine(Server.MapPath("~/Reportes"),
           "ReporteSPEmpleados.rdlc");
            reporte.ReportPath = ruta;
            List<empleado> listado = new List<empleado>();
            listado = db.empleado.ToList();
            ReportDataSource verreporte = new ReportDataSource("ReporteSP_de_empleados", listado);
            reporte.DataSources.Add(verreporte);
            string tiporeporte = id;
            string mime, codificacion, archivo;
            string[] flujo;
            Warning[] aviso;
            string dispositivo = @"<DeviceInfo>" +
            " <OutputFormat>" + id + "</OutputFormat>" +
            " <PageWidth>8.5in</PageWidth>" +
            " <PageHeight>11in</PageHeight>" +
            " <MarginTop>0.5in</MarginTop>" +
            " <MarginLeft>1in</MarginLeft>" +
            " <MarginRight></MarginRight>" +
            " <MarginBottom></MarginBottom>" +
            " <EmbedFonts>None</EmbedFonts>" +
            "</DeviceInfo>";
            byte[] enviar = reporte.Render(id, dispositivo, out mime,
                out codificacion, out archivo, out flujo, out aviso);
            return File(enviar, mime);
        }

        public ActionResult VistaReporteProductos(string id)
        {
            LocalReport reporte = new LocalReport();
            bases_ventasProductos db = new bases_ventasProductos();
            string ruta = Path.Combine(Server.MapPath("~/Reportes"),
           "ReporteSPProductos.rdlc");
            reporte.ReportPath = ruta;
            List<producto> listado = new List<producto>();
            listado = db.producto.ToList();
            ReportDataSource verreporte = new ReportDataSource("ReporteSP_de_producto", listado);
            reporte.DataSources.Add(verreporte);
            string tiporeporte = id;
            string mime, codificacion, archivo;
            string[] flujo;
            Warning[] aviso;
            string dispositivo = @"<DeviceInfo>" +
            " <OutputFormat>" + id + "</OutputFormat>" +
            " <PageWidth>8.5in</PageWidth>" +
            " <PageHeight>11in</PageHeight>" +
            " <MarginTop>0.5in</MarginTop>" +
            " <MarginLeft>1in</MarginLeft>" +
            " <MarginRight></MarginRight>" +
            " <MarginBottom></MarginBottom>" +
            " <EmbedFonts>None</EmbedFonts>" +
            "</DeviceInfo>";
            byte[] enviar = reporte.Render(id, dispositivo, out mime,
                out codificacion, out archivo, out flujo, out aviso);
            return File(enviar, mime);
        }

        public ActionResult VistaReporteProveedores(string id)
        {
            LocalReport reporte = new LocalReport();
            bases_ventasProveedores db = new bases_ventasProveedores();
            string ruta = Path.Combine(Server.MapPath("~/Reportes"),
           "ReporteSPProveedores.rdlc");
            reporte.ReportPath = ruta;
            List<proveedores> listado = new List<proveedores>();
            listado = db.proveedores.ToList();
            ReportDataSource verreporte = new ReportDataSource("ReporteSP_de_proveedores", listado);
            reporte.DataSources.Add(verreporte);
            string tiporeporte = id;
            string mime, codificacion, archivo;
            string[] flujo;
            Warning[] aviso;
            string dispositivo = @"<DeviceInfo>" +
            " <OutputFormat>" + id + "</OutputFormat>" +
            " <PageWidth>8.5in</PageWidth>" +
            " <PageHeight>11in</PageHeight>" +
            " <MarginTop>0.5in</MarginTop>" +
            " <MarginLeft>1in</MarginLeft>" +
            " <MarginRight></MarginRight>" +
            " <MarginBottom></MarginBottom>" +
            " <EmbedFonts>None</EmbedFonts>" +
            "</DeviceInfo>";
            byte[] enviar = reporte.Render(id, dispositivo, out mime,
                out codificacion, out archivo, out flujo, out aviso);
            return File(enviar, mime);
        }

        public ActionResult VistaReporteCompras(string id)
        {
            LocalReport reporte = new LocalReport();
            bases_ventasCompras db = new bases_ventasCompras();
            string ruta = Path.Combine(Server.MapPath("~/Reportes"),
           "ReporteSPCompras.rdlc");
            reporte.ReportPath = ruta;
            List<compras> listado = new List<compras>();
            listado = db.compras.ToList();
            ReportDataSource verreporte = new ReportDataSource("ReporteSP_de_compras", listado);
            reporte.DataSources.Add(verreporte);
            string tiporeporte = id;
            string mime, codificacion, archivo;
            string[] flujo;
            Warning[] aviso;
            string dispositivo = @"<DeviceInfo>" +
            " <OutputFormat>" + id + "</OutputFormat>" +
            " <PageWidth>8.5in</PageWidth>" +
            " <PageHeight>11in</PageHeight>" +
            " <MarginTop>0.5in</MarginTop>" +
            " <MarginLeft>1in</MarginLeft>" +
            " <MarginRight></MarginRight>" +
            " <MarginBottom></MarginBottom>" +
            " <EmbedFonts>None</EmbedFonts>" +
            "</DeviceInfo>";
            byte[] enviar = reporte.Render(id, dispositivo, out mime,
                out codificacion, out archivo, out flujo, out aviso);
            return File(enviar, mime);
        }

        public ActionResult VistaReporteVentas(string id)
        {
            LocalReport reporte = new LocalReport();
            bases_ventasVentas db = new bases_ventasVentas();
            string ruta = Path.Combine(Server.MapPath("~/Reportes"),
           "ReporteSPVentas.rdlc");
            reporte.ReportPath = ruta;
            List<ventas> listado = new List<ventas>();
            listado = db.ventas.ToList();
            ReportDataSource verreporte = new ReportDataSource("ReporteSP_de_ventas", listado);
            reporte.DataSources.Add(verreporte);
            string tiporeporte = id;
            string mime, codificacion, archivo;
            string[] flujo;
            Warning[] aviso;
            string dispositivo = @"<DeviceInfo>" +
            " <OutputFormat>" + id + "</OutputFormat>" +
            " <PageWidth></PageWidth>" +
            " <PageHeight></PageHeight>" +
            " <MarginTop></MarginTop>" +
            " <MarginLeft></MarginLeft>" +
            " <MarginRight></MarginRight>" +
            " <MarginBottom></MarginBottom>" +
            " <EmbedFonts>None</EmbedFonts>" +
            "</DeviceInfo>";
            byte[] enviar = reporte.Render(id, dispositivo, out mime,
                out codificacion, out archivo, out flujo, out aviso);
            return File(enviar, mime);
        }

        public ActionResult VistaReporteDetallesC(string id)
        {
            LocalReport reporte = new LocalReport();
            bases_ventasDetallesC db = new bases_ventasDetallesC();
            string ruta = Path.Combine(Server.MapPath("~/Reportes"),
           "ReporteSPDetallesC.rdlc");
            reporte.ReportPath = ruta;
            List<detalles_compras> listado = new List<detalles_compras>();
            listado = db.detalles_compras.ToList();
            ReportDataSource verreporte = new ReportDataSource("ReporteSP_de_detallesC", listado);
            reporte.DataSources.Add(verreporte);
            string tiporeporte = id;
            string mime, codificacion, archivo;
            string[] flujo;
            Warning[] aviso;
            string dispositivo = @"<DeviceInfo>" +
            " <OutputFormat>" + id + "</OutputFormat>" +
            " <PageWidth></PageWidth>" +
            " <PageHeight></PageHeight>" +
            " <MarginTop></MarginTop>" +
            " <MarginLeft></MarginLeft>" +
            " <MarginRight></MarginRight>" +
            " <MarginBottom></MarginBottom>" +
            " <EmbedFonts>None</EmbedFonts>" +
            "</DeviceInfo>";
            byte[] enviar = reporte.Render(id, dispositivo, out mime,
                out codificacion, out archivo, out flujo, out aviso);
            return File(enviar, mime);
        }

        public ActionResult VistaReporteDetallesv(string id)
        {
            LocalReport reporte = new LocalReport();
            bases_ventasDetallesV db = new bases_ventasDetallesV();
            string ruta = Path.Combine(Server.MapPath("~/Reportes"),
           "ReporteSPDetallesV.rdlc");
            reporte.ReportPath = ruta;
            List<detalles_ventas> listado = new List<detalles_ventas>();
            listado = db.detalles_ventas.ToList();
            ReportDataSource verreporte = new ReportDataSource("ReporteSP_de_detallesV", listado);
            reporte.DataSources.Add(verreporte);
            string tiporeporte = id;
            string mime, codificacion, archivo;
            string[] flujo;
            Warning[] aviso;
            string dispositivo = @"<DeviceInfo>" +
            " <OutputFormat>" + id + "</OutputFormat>" +
            " <PageWidth></PageWidth>" +
            " <PageHeight></PageHeight>" +
            " <MarginTop></MarginTop>" +
            " <MarginLeft></MarginLeft>" +
            " <MarginRight></MarginRight>" +
            " <MarginBottom></MarginBottom>" +
            " <EmbedFonts>None</EmbedFonts>" +
            "</DeviceInfo>";
            byte[] enviar = reporte.Render(id, dispositivo, out mime,
                out codificacion, out archivo, out flujo, out aviso);
            return File(enviar, mime);
        }
    }
}