using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using MyNewAspWebApi.Models;
using System.Web.Mvc;

namespace MyNewAspWebApi.Controllers
{
    public class ConsumeController : Controller
    {
        // GET: Consume
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<stud> list = new List<stud>();
            client.BaseAddress = new Uri("http://localhost:49734/api/NewApi");
            var response = client.GetAsync("NewApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<stud>>();
                display.Wait();

                list = display.Result;
            }


            return View(list);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(stud cre)
        {

            client.BaseAddress = new Uri("http://localhost:49734/api/NewApi");
            var response = client.PostAsJsonAsync<stud>("NewApi", cre);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create ");
        }
        public ActionResult Details(int id)
        {
            stud e = null;
            client.BaseAddress = new Uri("http://localhost:49734/api/NewApi");
            var response = client.GetAsync("NewApi?id="+id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<stud>();
                display.Wait();

                e = display.Result;
            }
            return View(e);
        }

        public ActionResult Edit(int id)
        {

            stud e = null;
            client.BaseAddress = new Uri("http://localhost:49734/api/NewApi");
            var response = client.GetAsync("NewApi?id=" + id.ToString());
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<stud>();
                display.Wait();

                e = display.Result;
            }
           
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit( stud e)
        {
            client.BaseAddress = new Uri("http://localhost:49734/api/NewApi");
            var response = client.PutAsJsonAsync<stud>("NewApi", e);
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");
        }



    }
}