using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SampleMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string status)
        {
            if (status == "LoggedOut")
            {
                FormsAuthentication.SignOut();
                Session.Abandon();

                // Above kills the sessionCookie from the ASP Classic side
                HttpCookie cookie1 = new HttpCookie("SessionCookie");
                cookie1.Expires = DateTime.Now.AddYears(-1);
                Response.Cookies.Add(cookie1);

                System.Web.HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            }
            else
            {
                var identity = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;

                foreach (var c in identity.Claims)
                {
                    Utils.SessionCookie.AddSessionCookie(c.Type, c.Value);
                }
            }

            return View();
        }

        [Authorize]
        public ActionResult Secure()
        {            
            var identity = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;

            foreach(var c in identity.Claims)
            {
                Utils.SessionCookie.AddSessionCookie(c.Type, c.Value);
            }

            return View(identity.Claims);
        }
    }
}