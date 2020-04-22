using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApplication.Utils
{
    public class SessionCookie
    {
        public static void AddSessionCookie(string key, string value)
        {
            var cookie = HttpContext.Current.Request.Cookies["SessionCookie"];
            if (cookie == null)
            {
                cookie = new HttpCookie("SessionCookie");
                cookie.Expires = DateTime.Now.AddMinutes(15); // Set this timeout to match that of the SAML SSO IDP spec.
            }

            HttpContext.Current.Session[key] = value;
            cookie[key] = value;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static string GetSessionCookie(string key)
        {
            if (HttpContext.Current.Session[key] == null)
                return string.Empty;

            string cook = HttpContext.Current.Session[key].ToString();
            if (!String.IsNullOrEmpty(cook))
            {
                var cookie = HttpContext.Current.Request.Cookies["SessionCookie"];
                if (cookie == null)
                {
                    cookie = new HttpCookie("SessionCookie");
                    cookie.Expires = DateTime.Now.AddHours(12);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    HttpContext.Current.Request.Cookies.Add(cookie);
                }
                if (cookie != null)
                    cookie[key] = cook;

                return cook;
            }
            return cook;
        }
    }
}
