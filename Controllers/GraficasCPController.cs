using PROYECTO_WEB.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROYECTO_WEB.Controllers
{
    public class GraficasCPController : Controller
    {
        // GET: GraficasCP
        public ActionResult Clientes()
        {
            ViewBag.ListaCl = DatosClientes();
            ViewBag.Tipo = TipoGrafica();
            Session["flag_c"] = "";
            return View();
        }

        public List<SelectListItem> DatosClientes()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Seleccione una opcion...",
                    Value = ""
                },
                new SelectListItem()
                {
                    Text = "Id",
                    Value = "id_c"
                },
                new SelectListItem()
                {
                    Text = "Nombre",
                    Value = "nombre"
                },
                new SelectListItem()
                {
                    Text = "Correo",
                    Value = "correo"
                },
                new SelectListItem()
                {
                    Text = "Direccion",
                    Value = "direccion"
                },
                new SelectListItem()
                {
                    Text = "Estado",
                    Value = "estado_c"
                }
            };
        }

        public ActionResult VistaGraficaClientes(string eje_x, string eje_y, string tipo, string titulo)
        {
            if(eje_x != "" && eje_y != "" && tipo != "" && titulo != "" && titulo != null && eje_x != null && eje_y != null && tipo != null)
            {
                bases_ventasClientes db = new bases_ventasClientes();
                ArrayList xvalores = new ArrayList();
                ArrayList yvalores = new ArrayList();
                var resultados = db.cliente.ToList();
                resultados.ToList().ForEach(rs => xvalores.Add(rs.GetType().GetProperty(eje_x)?.GetValue(rs, null)));
                resultados.ToList().ForEach(rs => yvalores.Add(rs.GetType().GetProperty(eje_y)?.GetValue(rs, null)));
                var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
                .AddTitle(titulo)
                .AddSeries(chartType: tipo, name: "Barras", xValue: xvalores, yValues:
               yvalores);
                Session["flag_c"] = "true";
                var imagenBytes = grafico.GetBytes("png");
                Session["imagen"] = Convert.ToBase64String(imagenBytes);
                // File(grafico.GetBytes("png"), "Image/png")
                ViewBag.ListaCl = DatosClientes();
                ViewBag.Tipo = TipoGrafica();
                return View("Clientes");
            }
            ViewBag.ListaCl = DatosClientes();
            ViewBag.Tipo = TipoGrafica();
            return View("Clientes");
        }

        public ActionResult Empleados()
        {
            ViewBag.ListaEm = DatosEmpleados();
            ViewBag.Tipo = TipoGrafica();
            Session["flag_e"] = "";
            return View();
        }

        public ActionResult VistaGraficaEmpleados(string eje_x, string eje_y, string tipo, string titulo)
        {
            if (eje_x != "" && eje_y != "" && tipo != "" && titulo != "" && titulo != null && eje_x != null && eje_y != null && tipo != null)
            {
                bases_ventasEmpleados db = new bases_ventasEmpleados();
                ArrayList xvalores = new ArrayList();
                ArrayList yvalores = new ArrayList();
                var resultados = db.empleado.ToList();
                resultados.ToList().ForEach(rs => xvalores.Add(rs.GetType().GetProperty(eje_x)?.GetValue(rs, null)));
                resultados.ToList().ForEach(rs => yvalores.Add(rs.GetType().GetProperty(eje_y)?.GetValue(rs, null)));
                var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
                .AddTitle(titulo)
                .AddSeries(chartType: tipo, name: "Barras", xValue: xvalores, yValues:
               yvalores);
                Session["flag_e"] = "true";
                var imagenBytes = grafico.GetBytes("png");
                Session["imagen"] = Convert.ToBase64String(imagenBytes);
                // File(grafico.GetBytes("png"), "Image/png")
                ViewBag.ListaEm = DatosEmpleados();
                ViewBag.Tipo = TipoGrafica();
                return View("Empleados");
            }
            ViewBag.ListaEm = DatosEmpleados();
            ViewBag.Tipo = TipoGrafica();
            return View("Empleados");
        }

        public List<SelectListItem> DatosEmpleados()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Seleccione una opcion...",
                    Value = ""
                },
                new SelectListItem()
                {
                    Text = "Id",
                    Value = "id_e"
                },
                new SelectListItem()
                {
                    Text = "Nombre",
                    Value = "nombre"
                },
                new SelectListItem()
                {
                    Text = "Correo",
                    Value = "correo"
                },
                new SelectListItem()
                {
                    Text = "Telefono",
                    Value = "telefono"
                },
                new SelectListItem()
                {
                    Text = "Estado",
                    Value = "estado_e"
                }
            };
        }

        public ActionResult Productos()
        {
            ViewBag.ListaProd = DatosProductos();
            ViewBag.Tipo = TipoGrafica();
            Session["flag_prod"] = "";
            return View();
        }

        public ActionResult VistaGraficaProductos(string eje_x, string eje_y, string tipo, string titulo)
        {
            if (eje_x != "" && eje_y != "" && tipo != "" && titulo != "" && titulo != null && eje_x != null && eje_y != null && tipo != null)
            {
                bases_ventasProductos db = new bases_ventasProductos();
                ArrayList xvalores = new ArrayList();
                ArrayList yvalores = new ArrayList();
                var resultados = db.producto.ToList();
                resultados.ToList().ForEach(rs => xvalores.Add(rs.GetType().GetProperty(eje_x)?.GetValue(rs, null)));
                resultados.ToList().ForEach(rs => yvalores.Add(rs.GetType().GetProperty(eje_y)?.GetValue(rs, null)));
                var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
                .AddTitle(titulo)
                .AddSeries(chartType: tipo, name: "Barras", xValue: xvalores, yValues:
               yvalores);
                Session["flag_prod"] = "true";
                var imagenBytes = grafico.GetBytes("png");
                Session["imagen"] = Convert.ToBase64String(imagenBytes);
                // File(grafico.GetBytes("png"), "Image/png")
                ViewBag.ListaProd = DatosProductos();
                ViewBag.Tipo = TipoGrafica();
                return View("Productos");
            }
            ViewBag.ListaProd = DatosProductos();
            ViewBag.Tipo = TipoGrafica();
            return View("Productos");
        }

        public List<SelectListItem> DatosProductos()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Seleccione una opcion...",
                    Value = ""
                },
                new SelectListItem()
                {
                    Text = "Id",
                    Value = "id_producto"
                },
                new SelectListItem()
                {
                    Text = "Nombre",
                    Value = "nombre"
                },
                new SelectListItem()
                {
                    Text = "Precio",
                    Value = "precio"
                },
                new SelectListItem()
                {
                    Text = "Stock",
                    Value = "stock"
                },
                new SelectListItem()
                {
                    Text = "Estado",
                    Value = "estado"
                }
            };
        }

        public ActionResult Proveedores()
        {
            ViewBag.ListaProv = DatosProveedores();
            ViewBag.Tipo = TipoGrafica();
            Session["flag_prov"] = "";
            return View();
        }

        public ActionResult VistaGraficaProveedores(string eje_x, string eje_y, string tipo, string titulo)
        {
            if (eje_x != "" && eje_y != "" && tipo != "" && titulo != "" && titulo != null && eje_x != null && eje_y != null && tipo != null)
            {
                bases_ventasProveedores db = new bases_ventasProveedores();
                ArrayList xvalores = new ArrayList();
                ArrayList yvalores = new ArrayList();
                var resultados = db.proveedores.ToList();
                resultados.ToList().ForEach(rs => xvalores.Add(rs.GetType().GetProperty(eje_x)?.GetValue(rs, null)));
                resultados.ToList().ForEach(rs => yvalores.Add(rs.GetType().GetProperty(eje_y)?.GetValue(rs, null)));
                var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
                .AddTitle(titulo)
                .AddSeries(chartType: tipo, name: "Barras", xValue: xvalores, yValues:
               yvalores);
                Session["flag_prov"] = "true";
                var imagenBytes = grafico.GetBytes("png");
                Session["imagen"] = Convert.ToBase64String(imagenBytes);
                // File(grafico.GetBytes("png"), "Image/png")
                ViewBag.ListaProv = DatosProveedores();
                ViewBag.Tipo = TipoGrafica();
                return View("Proveedores");
            }
            ViewBag.ListaProv = DatosProveedores();
            ViewBag.Tipo = TipoGrafica();
            return View("Proveedores");
        }

        public List<SelectListItem> DatosProveedores()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Seleccione una opcion...",
                    Value = ""
                },
                new SelectListItem()
                {
                    Text = "Id",
                    Value = "id_proveedores"
                },
                new SelectListItem()
                {
                    Text = "Nombre",
                    Value = "nombre"
                },
                new SelectListItem()
                {
                    Text = "Telefono",
                    Value = "telefono"
                },
                new SelectListItem()
                {
                    Text = "Direccion",
                    Value = "direccion"
                }
            };
        }

        public ActionResult Compras()
        {
            ViewBag.ListaCom = DatosCompras();
            ViewBag.Tipo = TipoGrafica();
            Session["flag_com"] = "";
            return View();
        }

        public ActionResult VistaGraficaCompras(string eje_x, string eje_y, string tipo, string titulo)
        {
            if (eje_x != "" && eje_y != "" && tipo != "" && titulo != "" && titulo != null && eje_x != null && eje_y != null && tipo != null)
            {
                bases_ventasCompras db = new bases_ventasCompras();
                ArrayList xvalores = new ArrayList();
                ArrayList yvalores = new ArrayList();
                var resultados = db.compras.ToList();
                resultados.ToList().ForEach(rs => xvalores.Add(rs.GetType().GetProperty(eje_x)?.GetValue(rs, null)));
                resultados.ToList().ForEach(rs => yvalores.Add(rs.GetType().GetProperty(eje_y)?.GetValue(rs, null)));
                var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
                .AddTitle(titulo)
                .AddSeries(chartType: tipo, name: "Barras", xValue: xvalores, yValues:
               yvalores);
                Session["flag_com"] = "true";
                var imagenBytes = grafico.GetBytes("png");
                Session["imagen"] = Convert.ToBase64String(imagenBytes);
                // File(grafico.GetBytes("png"), "Image/png")
                ViewBag.ListaCom = DatosCompras();
                ViewBag.Tipo = TipoGrafica();
                return View("Compras");
            }
            ViewBag.ListaCom = DatosCompras();
            ViewBag.Tipo = TipoGrafica();
            return View("Compras");
        }

        public List<SelectListItem> DatosCompras()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Seleccione una opcion...",
                    Value = ""
                },
                new SelectListItem()
                {
                    Text = "Id",
                    Value = "id_compras"
                },
                new SelectListItem()
                {
                    Text = "Numero serie",
                    Value = "num_serie"
                },
                new SelectListItem()
                {
                    Text = "Fecha compra",
                    Value = "fecha_compra"
                },
                new SelectListItem()
                {
                    Text = "Monto",
                    Value = "monto"
                },
                new SelectListItem()
                {
                    Text = "Empleado",
                    Value = "id_e"
                },
                new SelectListItem()
                {
                    Text = "Proveedor",
                    Value = "id_p"
                }
            };
        }

        public ActionResult Ventas()
        {
            ViewBag.ListaVen = DatosVentas();
            ViewBag.Tipo = TipoGrafica();
            Session["flag_ven"] = "";
            return View();
        }

        public ActionResult VistaGraficaVentas(string eje_x, string eje_y, string tipo, string titulo)
        {
            if (eje_x != "" && eje_y != "" && tipo != "" && titulo != "" && titulo != null && eje_x != null && eje_y != null && tipo != null)
            {
                bases_ventasVentas db = new bases_ventasVentas();
                ArrayList xvalores = new ArrayList();
                ArrayList yvalores = new ArrayList();
                var resultados = db.ventas.ToList();
                resultados.ToList().ForEach(rs => xvalores.Add(rs.GetType().GetProperty(eje_x)?.GetValue(rs, null)));
                resultados.ToList().ForEach(rs => yvalores.Add(rs.GetType().GetProperty(eje_y)?.GetValue(rs, null)));
                var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
                .AddTitle(titulo)
                .AddSeries(chartType: tipo, name: "Barras", xValue: xvalores, yValues:
               yvalores);
                Session["flag_ven"] = "true";
                var imagenBytes = grafico.GetBytes("png");
                Session["imagen"] = Convert.ToBase64String(imagenBytes);
                // File(grafico.GetBytes("png"), "Image/png")
                ViewBag.ListaVen = DatosVentas();
                ViewBag.Tipo = TipoGrafica();
                return View("Ventas");
            }
            ViewBag.ListaVen = DatosVentas();
            ViewBag.Tipo = TipoGrafica();
            return View("Ventas");
        }

        public List<SelectListItem> DatosVentas()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Seleccione una opcion...",
                    Value = ""
                },
                new SelectListItem()
                {
                    Text = "Id",
                    Value = "id_ventas"
                },
                new SelectListItem()
                {
                    Text = "Numero serie",
                    Value = "numero_serie"
                },
                new SelectListItem()
                {
                    Text = "Fecha venta",
                    Value = "fecha_venta"
                },
                new SelectListItem()
                {
                    Text = "Monto",
                    Value = "monto"
                },
                new SelectListItem()
                {
                    Text = "Estado",
                    Value = "estado"
                },
                new SelectListItem()
                {
                    Text = "Cliente",
                    Value = "id_c"
                },
                new SelectListItem()
                {
                    Text = "Empleado",
                    Value = "id_e"
                }
            };
        }

        public ActionResult DetallesC()
        {
            ViewBag.ListaDetC = DatosDetallesC();
            ViewBag.Tipo = TipoGrafica();
            Session["flag_detc"] = "";
            return View();
        }

        public ActionResult VistaGraficaDetallesC(string eje_x, string eje_y, string tipo, string titulo)
        {
            if (eje_x != "" && eje_y != "" && tipo != "" && titulo != "" && titulo != null && eje_x != null && eje_y != null && tipo != null)
            {
                bases_ventasDetallesC db = new bases_ventasDetallesC();
                ArrayList xvalores = new ArrayList();
                ArrayList yvalores = new ArrayList();
                var resultados = db.detalles_compras.ToList();
                resultados.ToList().ForEach(rs => xvalores.Add(rs.GetType().GetProperty(eje_x)?.GetValue(rs, null)));
                resultados.ToList().ForEach(rs => yvalores.Add(rs.GetType().GetProperty(eje_y)?.GetValue(rs, null)));
                var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
                .AddTitle(titulo)
                .AddSeries(chartType: tipo, name: "Barras", xValue: xvalores, yValues:
               yvalores);
                Session["flag_detc"] = "true";
                var imagenBytes = grafico.GetBytes("png");
                Session["imagen"] = Convert.ToBase64String(imagenBytes);
                // File(grafico.GetBytes("png"), "Image/png")
                ViewBag.ListaDetC = DatosDetallesC();
                ViewBag.Tipo = TipoGrafica();
                return View("DetallesC");
            }
            ViewBag.ListaDetC = DatosDetallesC();
            ViewBag.Tipo = TipoGrafica();
            return View("DetallesC");
        }

        public List<SelectListItem> DatosDetallesC()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Seleccione una opcion...",
                    Value = ""
                },
                new SelectListItem()
                {
                    Text = "Id",
                    Value = "Id_detcom"
                },
                new SelectListItem()
                {
                    Text = "Cantidad",
                    Value = "cantidad"
                },
                new SelectListItem()
                {
                    Text = "Precio compra",
                    Value = "precio_compra"
                },
                new SelectListItem()
                {
                    Text = "Compra",
                    Value = "id_compra"
                },
                new SelectListItem()
                {
                    Text = "Producto",
                    Value = "id_producto"
                }
            };
        }

        public ActionResult DetallesV()
        {
            ViewBag.ListaDetV = DatosDetallesV();
            ViewBag.Tipo = TipoGrafica();
            Session["flag_detv"] = "";
            return View();
        }

        public ActionResult VistaGraficaDetallesV(string eje_x, string eje_y, string tipo, string titulo)
        {
            if (eje_x != "" && eje_y != "" && tipo != "" && titulo != "" && titulo != null && eje_x != null && eje_y != null && tipo != null)
            {
                bases_ventasDetallesV db = new bases_ventasDetallesV();
                ArrayList xvalores = new ArrayList();
                ArrayList yvalores = new ArrayList();
                var resultados = db.detalles_ventas.ToList();
                resultados.ToList().ForEach(rs => xvalores.Add(rs.GetType().GetProperty(eje_x)?.GetValue(rs, null)));
                resultados.ToList().ForEach(rs => yvalores.Add(rs.GetType().GetProperty(eje_y)?.GetValue(rs, null)));
                var grafico = new System.Web.Helpers.Chart(width: 500, height: 600)
                .AddTitle(titulo)
                .AddSeries(chartType: tipo, name: "Barras", xValue: xvalores, yValues:
               yvalores);
                Session["flag_detv"] = "true";
                var imagenBytes = grafico.GetBytes("png");
                Session["imagen"] = Convert.ToBase64String(imagenBytes);
                // File(grafico.GetBytes("png"), "Image/png")
                ViewBag.ListaDetV = DatosDetallesV();
                ViewBag.Tipo = TipoGrafica();
                return View("DetallesV");
            }
            ViewBag.ListaDetV = DatosDetallesV();
            ViewBag.Tipo = TipoGrafica();
            return View("DetallesV");
        }

        public List<SelectListItem> DatosDetallesV()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Seleccione una opcion...",
                    Value = ""
                },
                new SelectListItem()
                {
                    Text = "Id",
                    Value = "id_detven"
                },
                new SelectListItem()
                {
                    Text = "Cantidad",
                    Value = "cantidad"
                },
                new SelectListItem()
                {
                    Text = "Precio venta",
                    Value = "precio_venta"
                },
                new SelectListItem()
                {
                    Text = "Venta",
                    Value = "id_ventas"
                },
                new SelectListItem()
                {
                    Text = "Producto",
                    Value = "id_producto"
                }
            };
        }


        public List<SelectListItem> TipoGrafica()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Seleccione una opcion...",
                    Value = ""
                },
                new SelectListItem()
                {
                    Text = "Barras",
                    Value = "Bar"
                },
                new SelectListItem()
                {
                    Text = "Columnas",
                    Value = "Column"
                },
                new SelectListItem()
                {
                    Text = "Redonda",
                    Value = "Pie"
                }
            };
        }
    }
}