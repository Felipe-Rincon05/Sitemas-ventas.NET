using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROYECTO_WEB.Controllers
{
    [Authorize]
    public class NuevaCompraController : Controller
    {
        static List<Producto_VC> lista = new List<Producto_VC>();
        double total_compra = 0;
        // GET: NuevaCompra
        public ActionResult Index()
        {
            Session["id_pro"] = "";
            Session["nombre_pr"] = "";
            Session["id_p_prov"] = "";
            Session["nombre_p_prov"] = "";
            Session["precio_p_prov"] = "";
            Session["stock_p_prov"] = "";
            Session["cantidad_p_prov"] = "1";
            Session["numero_serie_co"] = "";
            Session["total_v_prov"] = "";
            lista.Clear();
            Num_serie();
            return View();
        }

        [HttpPost]
        public ActionResult BuscarProveedor(string nombre_pr)
        {
            lista.Clear();
            total_compra = 0;
            Session["total_v_prov"] = "";
            Session["id_pro"] = "";
            Session["nombre_pr"] = "";
            if (nombre_pr != null || nombre_pr != "")
            {
                SqlCommand comando;
                comando = new SqlCommand("SELECT id_proveedores, nombre FROM proveedores WHERE nombre = '" + nombre_pr + "'", Conexion.GetConexion());
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    Session["id_pro"] = (leer.GetInt64(0)).ToString();
                    Session["nombre_pr"] = (leer.GetString(1));
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
                AgregarCompra(cantidad_p, id_p);
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
                        Session["id_p_prov"] = (leer.GetInt64(0)).ToString();
                        Session["nombre_p_prov"] = (leer.GetString(1));
                        Session["precio_p_prov"] = (leer.GetDouble(2)).ToString();
                        Session["stock_p_prov"] = (leer.GetInt64(3)).ToString();
                    }
                    leer.Close();
                    Session["cantidad_p_prov"] = cantidad_p;
                }
            }
            return View("Index", lista);
        }

        public void Num_serie()
        {
            SqlCommand comando;
            comando = new SqlCommand("SELECT MAX(num_serie) FROM compras", Conexion.GetConexion());
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read())
            {
                if (leer.IsDBNull(0))
                {
                    Session["numero_serie_co"] = 1;
                }
                else
                {
                    Session["numero_serie_co"] = leer.GetInt64(0) + 1;
                }
            }
            leer.Close();
        }

        [HttpPost]
        public ActionResult AgregarCompra(string cantidad_p, string id_p)
        {
            if (!Session["id_p_prov"].ToString().Equals("") && !Session["precio_p_prov"].ToString().Equals("") && !Session["nombre_p_prov"].ToString().Equals(""))
            {
                double subtotal = Double.Parse(Session["precio_p_prov"].ToString()) * Double.Parse(cantidad_p);
                Producto_VC ob = new Producto_VC(Session["id_p_prov"].ToString(), Session["nombre_p_prov"].ToString(), Session["precio_p_prov"].ToString(), cantidad_p, subtotal.ToString());
                lista.Add(ob);
                total_compra = TotalCompra();
                Session["total_v_prov"] = "$" + total_compra;
                Session["id_p_prov"] = "";
                Session["nombre_p_prov"] = "";
                Session["precio_p_prov"] = "";
                Session["stock_p_prov"] = "";
                Session["cantidad_p_prov"] = "1";
            }
            return RedirectToAction("Index", lista);
        }

        public double TotalCompra()
        {
            double total = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                total += Double.Parse(lista[i].subtotal);
            }
            return total;
        }

        [HttpPost]
        public ActionResult BorrarProducto(string btn_borrar)
        {
            int index = int.Parse(btn_borrar);
            lista.Remove(lista[index]);
            total_compra = TotalCompra();
            Session["total_v_prov"] = "$" + total_compra;
            return View("Index", lista);
        }

        public ActionResult CancelarCompra()
        {
            lista.Clear();
            total_compra = 0;
            Session["total_v_prov"] = "";
            return View("Index", lista);
        }

        public ActionResult GenerarCompra()
        {
            double total_v = TotalCompra();
            using (SqlCommand comando = new SqlCommand("INSERT INTO compras([num_serie], [monto], [id_e], [id_p]) " +
            "VALUES (@numero_serie, @monto, @id_e, @id_p)", Conexion.GetConexion()))
            {
                comando.Parameters.AddWithValue("@numero_serie", int.Parse(Session["numero_serie_co"].ToString()));
                comando.Parameters.AddWithValue("@monto", total_v);
                comando.Parameters.AddWithValue("@id_e", int.Parse(Session["id_usuario"].ToString()));
                comando.Parameters.AddWithValue("@id_p", int.Parse(Session["id_pro"].ToString()));

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex) { }
            }

            Num_serie();

            long id_compra = 0;
            SqlCommand comand = new SqlCommand("SELECT MAX(id_compras) FROM compras", Conexion.GetConexion());
            SqlDataReader leer = comand.ExecuteReader();
            if (leer.Read())
            {
                id_compra = leer.GetInt64(0);
            }
            leer.Close();

            for (int i = 0; i < lista.Count; i++)
            {
                using (SqlCommand comando = new SqlCommand("INSERT INTO detalles_compras([cantidad], [precio_compra], [id_compra], [id_producto]) " +
                    "VALUES (@cantidad, @precio_compra, @id_compra, @id_producto)", Conexion.GetConexion()))
                {
                    comando.Parameters.AddWithValue("@cantidad", int.Parse(lista[i].cantidad));
                    comando.Parameters.AddWithValue("@precio_compra", float.Parse(lista[i].subtotal));
                    comando.Parameters.AddWithValue("@id_compra", id_compra);
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
                long neto = stock + int.Parse(lista[i].cantidad);
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
            Session["id_pro"] = "";
            Session["nombre_pr"] = "";
            Session["id_p_prov"] = "";
            Session["nombre_p_prov"] = "";
            Session["precio_p_prov"] = "";
            Session["stock_p_prov"] = "";
            Session["cantidad_p_prov"] = "1";
            total_compra = 0;
            Session["total_v_prov"] = "";
            lista.Clear();
            return View("Index", lista);
        }
    }
}