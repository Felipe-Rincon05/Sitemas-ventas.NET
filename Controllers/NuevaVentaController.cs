using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Input;
using System.Xml.Linq;
using Antlr.Runtime;
using PROYECTO_WEB.Models;


namespace PROYECTO_WEB.Controllers
{
    [Authorize]
    public class NuevaVentaController : Controller
    {
        static List<Producto_VC> lista = new List<Producto_VC>();
        double total_venta = 0;
        int num_prueba = 0;
        // GET: NuevaVenta
        public ActionResult Index()
        {
            Session["id_c"] = "";
            Session["nombre_c"] = "";
            Session["id_p"] = "";
            Session["nombre_p"] = "";
            Session["precio_p"] = "";
            Session["stock_p"] = "";
            Session["numero_serie"] = "";
            Session["cantidad_p"] = "1";
            Session["total_v"] = "";
            lista.Clear();
            Num_serie();
            return View();
        }

        [HttpPost]
        public ActionResult BuscarCliente(string id)
        {
            lista.Clear();
            total_venta = 0;
            Session["total_v"] = "";
            Session["id_c"] = "";
            Session["nombre_c"] = "";
            if (id != null || id != "")
            {
                int id_cliente = int.Parse(id);
                SqlCommand comando;
                comando = new SqlCommand("SELECT id_c, nombre FROM cliente WHERE id_c = " + id_cliente, Conexion.GetConexion());
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    Session["id_c"] = (leer.GetInt64(0)).ToString();
                    Session["nombre_c"] = (leer.GetString(1));
                }
                leer.Close();
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult BuscarProducto(string id_p, string cantidad_p, string btn_enviar)
        {
            if (btn_enviar.Equals("Agregar"))
            {
                AgregarVenta(cantidad_p, id_p);
            }
            else
            {
                if (!id_p.Equals("") || id_p != null)
                {
                    int id_producto = int.Parse(id_p);
                    SqlCommand comando;
                    comando = new SqlCommand("SELECT id_producto, nombre, precio, stock FROM producto WHERE id_producto = " + id_producto,
                        Conexion.GetConexion());
                    SqlDataReader leer = comando.ExecuteReader();
                    if (leer.Read())
                    {
                        Session["id_p"] = (leer.GetInt64(0)).ToString();
                        Session["nombre_p"] = (leer.GetString(1));
                        Session["precio_p"] = (leer.GetDouble(2)).ToString();
                        Session["stock_p"] = (leer.GetInt64(3)).ToString();
                    }
                    leer.Close();
                    Session["cantidad_p"] = cantidad_p;
                }
            }
            return View("Index", lista);
        }

        public void Num_serie()
        {
            SqlCommand comando;
            comando = new SqlCommand("SELECT MAX(numero_serie) FROM ventas", Conexion.GetConexion());
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read())
            {
                if (leer.IsDBNull(0))
                {
                    Session["numero_serie"] = 1;
                }
                else
                {
                    Session["numero_serie"] = leer.GetInt64(0) + 1;
                }
            }
            leer.Close();
        }

        [HttpPost]
        public ActionResult AgregarVenta(string cantidad_p, string id_p)
        {
            if (!Session["id_p"].ToString().Equals("") && !Session["precio_p"].ToString().Equals("") && !Session["nombre_p"].ToString().Equals(""))
            {
                long stock = 0;
                SqlCommand comand = new SqlCommand("SELECT stock FROM producto WHERE id_producto = " + int.Parse(id_p), Conexion.GetConexion());
                SqlDataReader read = comand.ExecuteReader();
                if (read.Read())
                {
                    stock = read.GetInt64(0);
                }
                read.Close();
                stock = stock - int.Parse(cantidad_p);
                if (stock > 0)
                {
                    double subtotal = Double.Parse(Session["precio_p"].ToString()) * Double.Parse(cantidad_p);
                    Producto_VC ob = new Producto_VC(Session["id_p"].ToString(), Session["nombre_p"].ToString(), Session["precio_p"].ToString(), cantidad_p, subtotal.ToString());
                    lista.Add(ob);
                    total_venta = TotalVenta();
                    Session["total_v"] = "$" + total_venta;
                    Session["id_p"] = "";
                    Session["nombre_p"] = "";
                    Session["precio_p"] = "";
                    Session["stock_p"] = "";
                    Session["cantidad_p"] = "1";
                }
            }
            return RedirectToAction("Index", lista);
        }

        [HttpPost]
        public ActionResult BorrarProducto(string btn_borrar)
        {
            int index = int.Parse(btn_borrar);
            lista.Remove(lista[index]);
            total_venta = TotalVenta();
            Session["total_v"] = "$" + total_venta;
            return View("Index", lista);
        }

        public ActionResult CancelarVenta()
        {
            lista.Clear();
            total_venta = 0;
            Session["total_v"] = "";
            return View("Index", lista);
        }

        public double TotalVenta()
        {
            double total = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                total += Double.Parse(lista[i].subtotal);
            }
            return total;
        }

        public ActionResult GenerarVenta()
        {
            double total_v = TotalVenta();
            using (SqlCommand comando = new SqlCommand("INSERT INTO ventas([numero_serie], [monto], [estado], [id_c], [id_e]) " +
            "VALUES (@numero_serie, @monto, @estado, @id_c, @id_e)", Conexion.GetConexion()))
            {
                comando.Parameters.AddWithValue("@numero_serie", int.Parse(Session["numero_serie"].ToString()));
                comando.Parameters.AddWithValue("@monto", total_v);
                comando.Parameters.AddWithValue("@estado", 1);
                comando.Parameters.AddWithValue("@id_c", int.Parse(Session["id_c"].ToString()));
                comando.Parameters.AddWithValue("@id_e", int.Parse(Session["id_usuario"].ToString()));

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex) { }
            }

            Num_serie();

            long id_ventas = 0;
            SqlCommand comand = new SqlCommand("SELECT MAX(id_ventas) FROM ventas", Conexion.GetConexion());
            SqlDataReader leer = comand.ExecuteReader();
            if (leer.Read())
            {
                id_ventas = leer.GetInt64(0);
            }
            leer.Close();
            
            for (int i = 0; i < lista.Count; i++)
            {
                using (SqlCommand comando = new SqlCommand("INSERT INTO detalles_ventas([cantidad], [precio_venta], [id_ventas], [id_producto]) " +
                    "VALUES (@cantidad, @precio_venta, @id_ventas, @id_producto)", Conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@cantidad", int.Parse(lista[i].cantidad));
                    comando.Parameters.AddWithValue("@precio_venta", float.Parse(lista[i].subtotal));
                    comando.Parameters.AddWithValue("@id_ventas", id_ventas);
                    comando.Parameters.AddWithValue("@id_producto", int.Parse(lista[i].codigo));

                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }

                long stock = 0;
                SqlCommand coman = new SqlCommand("SELECT stock FROM producto WHERE id_producto = " + int.Parse(lista[i].codigo), Conexion.GetConexion());
                SqlDataReader read = coman.ExecuteReader();
                if (read.Read())
                {
                    stock = read.GetInt64(0);
                }
                read.Close();
                long neto = stock - int.Parse(lista[i].cantidad);
                using (SqlCommand com = new SqlCommand("UPDATE producto SET [stock] = @stock WHERE " +
                    "id_producto = @id_p", Conexion.GetConexion()))
                {
                    com.Parameters.AddWithValue("@stock", neto);
                    com.Parameters.AddWithValue("@id_p", int.Parse(lista[i].codigo));

                    try
                    {
                        com.ExecuteNonQuery();
                    }
                    catch (Exception ex) { }
                }
            }
            Session["id_c"] = "";
            Session["nombre_c"] = "";
            Session["id_p"] = "";
            Session["nombre_p"] = "";
            Session["precio_p"] = "";
            Session["stock_p"] = "";
            Session["cantidad_p"] = "1";
            total_venta = 0;
            Session["total_v"] = "";
            lista.Clear();
            return View("Index", lista);
        }
    }
}