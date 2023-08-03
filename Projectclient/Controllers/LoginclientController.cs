using Projectclient.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Security;

namespace Projectclient.Controllers
{
    public class LoginclientController : Controller
    {
        // GET: Loginclient
        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Loginxyz(string s)
        {
            TempData["Job"] = s;
            return View();
        }
        //public ActionResult logout()
        //{
        //    return View();
        //}
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(Class1 c)
        {
            Loginentity l = null;
            string st = "";
            // HttpClient client = new HttpClient();
            // Class1 emps = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress=new Uri("https://localhost:44334/api/Project");
                var responseTask = client.PostAsJsonAsync<Class1>("Project", c);
                responseTask.Wait();
                var result = responseTask.Result;

                //client.BaseAddress=new Uri("https://localhost:44334/api/Project");
                //var responseTask = client.GetAsync("Project");
                //responseTask.Wait();
                //var result=responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readdata = result.Content.ReadAsAsync<Loginentity>();
                    readdata.Wait();
                    l=readdata.Result;

                    //var readdata = result.Content.ReadAsAsync<Class1>();
                    //readdata.Wait();
                    //emps=readdata.Result;
                    //if (st.Equals("1"))
                    //{
                    //    st="Invalid Credentials";
                    //    ViewBag.msg = st;
                    //}
                    //else
                    //{
                    //    FormsAuthentication.SetAuthCookie(st, false);
                    //    Session["type"]=st;
                    //    Session.Timeout=10;
                    //    //  object value = HttpContext.Session.SetString("type", st);

                    //    var x = Session["type"];
                    //    ViewBag.msg="Login Success";
                    //}

                    // result.Content.ReadAsStreamAsync<IList<EMP>>();



                    Session["type"]=l.type;
                    Session["email"]=l.email;
                    ViewBag.msg="Login Success";
                    return View("success");

                     

                }
                else
                {
                    var readdata = result.Content.ReadAsAsync<Loginentity>();
                    readdata.Wait();
                    l=readdata.Result;
                    ViewBag.msg="Invalid Credentials";
                    return View("Index");
                }
                //ModelState.AddModelError(string.Empty, "No emp found");
            }
        }
        //   ViewBag.msg=st;



        public ActionResult success()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();

            Session.Clear();


            Session.RemoveAll();
            System.Web.Security.FormsAuthentication.SignOut();
            Session["type"]=null;
            Session.Timeout=1;
            // return View();
            return RedirectToAction("Index");
        }


    }
    }


    
