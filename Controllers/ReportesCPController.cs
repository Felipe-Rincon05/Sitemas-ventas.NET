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
    public class ReportesCPController : Controller
    {
        List<cliente> lista_cl = new List<cliente>();
        List<empleado> lista_emp = new List<empleado>();
        List<proveedores> lista_prov = new List<proveedores>();
        List<producto> lista_prod = new List<producto>();
        List<compras> lista_com = new List<compras>();
        List<ventas> lista_v = new List<ventas>();
        List<detalles_compras> lista_detc = new List<detalles_compras>();
        List<detalles_ventas> lista_detv = new List<detalles_ventas>();

        // GET: ReportesCP
        public ActionResult ReporteCPClientes()
        {
            Session["id_c_rep"] = "";
            return View(lista_cl);
        }

        public ActionResult ReporteCPClientes_Click(string id_cl)
        {
            if (id_cl != null)
            {
                bases_ventasClientes db = new bases_ventasClientes();
                int id_c = int.Parse(id_cl);
                Session["id_c_rep"] = id_c;
                lista_cl = db.cliente.Where(c => c.id_c == id_c).ToList();
            }

            return View("ReporteCPClientes", lista_cl);
        }

        public ActionResult VistaReporteClientes(string id)
        {
            if (Session["id_c_rep"].ToString() != "" || Session["id_c_rep"].ToString() != null)
            {
                int id_c = int.Parse(Session["id_c_rep"].ToString());
                LocalReport reporte = new LocalReport();
                bases_ventasClientes db = new bases_ventasClientes();
                string ruta = Path.Combine(Server.MapPath("~/Reportes"),
               "ReporteSPClientes.rdlc");
                reporte.ReportPath = ruta;
                List<cliente> listado = new List<cliente>();
                listado = db.cliente.Where(c => c.id_c == id_c).ToList();
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
            } else
            {
                return View("ReporteCPClientes", lista_cl);
            }
        }

        public ActionResult ReporteCPEmpleados()
        {
            Session["id_emp_rep"] = "";
            return View(lista_emp);
        }

        public ActionResult ReporteCPEmpleados_Click(string id_emp)
        {
            if (id_emp != null)
            {
                bases_ventasEmpleados db = new bases_ventasEmpleados();
                int id_e = int.Parse(id_emp);
                Session["id_emp_rep"] = id_e;
                lista_emp = db.empleado.Where(c => c.id_e == id_e).ToList();
            }

            return View("ReporteCPEmpleados", lista_emp);
        }

        public ActionResult VistaReporteEmpleados(string id)
        {
            if (Session["id_emp_rep"].ToString() != null || Session["id_emp_rep"].ToString() != "")
            {
                int id_e = int.Parse(Session["id_emp_rep"].ToString());
                LocalReport reporte = new LocalReport();
                bases_ventasEmpleados db = new bases_ventasEmpleados();
                string ruta = Path.Combine(Server.MapPath("~/Reportes"),
               "ReporteSPEmpleados.rdlc");
                reporte.ReportPath = ruta;
                List<empleado> listado = new List<empleado>();
                listado = db.empleado.Where(c => c.id_e == id_e).ToList();
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
            } else
            {
                return View("ReporteCPEmpleados", lista_emp);
            }
            
        }

        public ActionResult ReporteCPProveedores()
        {
            Session["nombre_prov_rep"] = "";
            return View(lista_prov);
        }

        public ActionResult ReporteCPProveedores_Click(string nombre_prov)
        {
            if (nombre_prov != null)
            {
                bases_ventasProveedores db = new bases_ventasProveedores();
                Session["nombre_prov_rep"] = nombre_prov;
                lista_prov = db.proveedores.Where(c => c.nombre == nombre_prov).ToList();
            }

            return View("ReporteCPProveedores", lista_prov);
        }

        public ActionResult VistaReporteProveedores(string id)
        {
            if (Session["nombre_prov_rep"].ToString() != null || Session["nombre_prov_rep"].ToString() != "")
            {
                string nombre_prov = Session["nombre_prov_rep"].ToString();
                LocalReport reporte = new LocalReport();
                bases_ventasProveedores db = new bases_ventasProveedores();
                string ruta = Path.Combine(Server.MapPath("~/Reportes"),
               "ReporteSPProveedores.rdlc");
                reporte.ReportPath = ruta;
                List<proveedores> listado = new List<proveedores>();
                listado = db.proveedores.Where(c => c.nombre == nombre_prov).ToList();
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
            } else
            {
                return View("ReporteCPProveedores", lista_prov);
            }
        }

        public ActionResult ReporteCPProductos()
        {
            Session["id_prod_rep"] = "";
            return View(lista_prod);
        }

        public ActionResult ReporteCPProductos_Click(string id_prod)
        {
            if (id_prod != null)
            {
                int id_p = int.Parse(id_prod);
                bases_ventasProductos db = new bases_ventasProductos();
                Session["id_prod_rep"] = id_p;
                lista_prod = db.producto.Where(c => c.id_producto == id_p).ToList();
            }
            return View("ReporteCPProductos", lista_prod);
        }

        public ActionResult VistaReporteProductos(string id)
        {
            if (Session["id_prod_rep"].ToString() != null || Session["id_prod_rep"].ToString() != "")
            {
                int id_p = int.Parse(Session["id_prod_rep"].ToString());
                LocalReport reporte = new LocalReport();
                bases_ventasProductos db = new bases_ventasProductos();
                string ruta = Path.Combine(Server.MapPath("~/Reportes"),
               "ReporteSPProductos.rdlc");
                reporte.ReportPath = ruta;
                List<producto> listado = new List<producto>();
                listado = db.producto.Where(c => c.id_producto == id_p).ToList();
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
            } else
            {
                return View("ReporteCPProductos", lista_prod);
            }
        }

        public ActionResult ReporteCPCompras()
        {
            Session["id_com_rep"] = "";
            return View(lista_com);
        }

        public ActionResult ReporteCPCompras_Click(string id_com)
        {
            if (id_com != null)
            {
                int id_co = int.Parse(id_com);
                bases_ventasCompras db = new bases_ventasCompras();
                Session["id_com_rep"] = id_co;
                lista_com = db.compras.Where(c => c.Id_compras == id_co).ToList();
            }
            return View("ReporteCPCompras", lista_com);
        }

        public ActionResult VistaReporteCompras(string id)
        {
            if (Session["id_com_rep"].ToString() != null || Session["id_com_rep"].ToString() != "")
            {
                int id_co = int.Parse(Session["id_com_rep"].ToString());
                LocalReport reporte = new LocalReport();
                bases_ventasCompras db = new bases_ventasCompras();
                string ruta = Path.Combine(Server.MapPath("~/Reportes"),
               "ReporteSPCompras.rdlc");
                reporte.ReportPath = ruta;
                List<compras> listado = new List<compras>();
                listado = db.compras.Where(c => c.Id_compras == id_co).ToList();
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
            } else
            {
                return View("ReporteCPCompras", lista_com);
            }
        }

        public ActionResult ReporteCPVentas()
        {
            Session["id_ven_rep"] = "";
            return View(lista_v);
        }

        public ActionResult ReporteCPVentas_Click(string id_ven)
        {
            if (id_ven != null)
            {
                int id_v = int.Parse(id_ven);
                bases_ventasVentas db = new bases_ventasVentas();
                Session["id_ven_rep"] = id_v;
                lista_v = db.ventas.Where(c => c.id_ventas == id_v).ToList();
            }
            return View("ReporteCPVentas", lista_v);
        }

        public ActionResult VistaReporteVentas(string id)
        {
            if(Session["id_ven_rep"].ToString() != null || Session["id_ven_rep"].ToString() != "")
            {
                int id_v = int.Parse(Session["id_ven_rep"].ToString());
                LocalReport reporte = new LocalReport();
                bases_ventasVentas db = new bases_ventasVentas();
                string ruta = Path.Combine(Server.MapPath("~/Reportes"),
               "ReporteSPVentas.rdlc");
                reporte.ReportPath = ruta;
                List<ventas> listado = new List<ventas>();
                listado = db.ventas.Where(c => c.id_ventas == id_v).ToList();
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
            } else
            {
                return View("ReporteCPVentas", lista_v);
            }
        }

        public ActionResult ReporteCPDetallesC()
        {
            Session["id_detc_rep"] = "";
            return View(lista_detc);
        }

        public ActionResult ReporteCPDetallesC_Click(string id_dc)
        {
            if (id_dc != null)
            {
                int id_detc = int.Parse(id_dc);
                bases_ventasDetallesC db = new bases_ventasDetallesC();
                Session["id_detc_rep"] = id_detc;
                lista_detc = db.detalles_compras.Where(c => c.id_compra == id_detc).ToList();
            }
            return View("ReporteCPDetallesC", lista_detc);
        }

        public ActionResult VistaReporteDetallesC(string id)
        {
            if (Session["id_detc_rep"].ToString() != null || Session["id_detc_rep"].ToString() != "")
            {
                int id_detc = int.Parse(Session["id_detc_rep"].ToString());
                LocalReport reporte = new LocalReport();
                bases_ventasDetallesC db = new bases_ventasDetallesC();
                string ruta = Path.Combine(Server.MapPath("~/Reportes"),
               "ReporteSPDetallesC.rdlc");
                reporte.ReportPath = ruta;
                List<detalles_compras> listado = new List<detalles_compras>();
                listado = db.detalles_compras.Where(c => c.id_compra == id_detc).ToList();
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
            return View("ReporteCPDetallesC", lista_detc);
        }

        public ActionResult ReporteCPDetallesV()
        {
            Session["id_detv_rep"] = "";
            return View(lista_detv);
        }

        public ActionResult ReporteCPDetallesV_Click(string id_dv)
        {
            if (id_dv != null)
            {
                int id_detv = int.Parse(id_dv);
                bases_ventasDetallesV db = new bases_ventasDetallesV();
                Session["id_detv_rep"] = id_detv;
                lista_detv = db.detalles_ventas.Where(c => c.id_ventas == id_detv).ToList();
            }
            return View("ReporteCPDetallesV", lista_detv);
        }

        public ActionResult VistaReporteDetallesv(string id)
        {
            if (Session["id_detv_rep"].ToString() != null || Session["id_detv_rep"].ToString() != "")
            {
                int id_detv = int.Parse(Session["id_detv_rep"].ToString());
                LocalReport reporte = new LocalReport();
                bases_ventasDetallesV db = new bases_ventasDetallesV();
                string ruta = Path.Combine(Server.MapPath("~/Reportes"),
               "ReporteSPDetallesV.rdlc");
                reporte.ReportPath = ruta;
                List<detalles_ventas> listado = new List<detalles_ventas>();
                listado = db.detalles_ventas.Where(c => c.id_ventas == id_detv).ToList();
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
            return View("ReporteCPDetallesV", lista_detv);
        }
    }
}