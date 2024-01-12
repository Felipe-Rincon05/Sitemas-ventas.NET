using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PROYECTO_WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void CerrarSesion()
        {
            Session["usuario"] = null;
            Session["nombre"] = null;
            Session["correo"] = null;
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}