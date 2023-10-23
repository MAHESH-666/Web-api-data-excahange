using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using MyNewAspWebApi.Models;

namespace MyNewAspWebApi.Controllers
{
    public class NewApiController : ApiController
    {
        practicEntities2 db = new practicEntities2();

        [System.Web.Http.HttpGet]

        public IHttpActionResult Action()
        {
            List<stud> obj = db.studs.ToList();
            return Ok(obj);
        }


        [System.Web.Http.HttpGet]

        public IHttpActionResult GetEmployeeById(int id)
        {
            var emp = db.studs.Where(model => model.id == id).FirstOrDefault();
            return Ok(emp);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(stud e)
        {
            db.studs.Add(e);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult EmpUpdate(stud e)
        {

            db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            //var emp = db.studs.Where(model => model.id == e.std_id).FirstOrDefault();
            //if(emp != null)
            //{
            //    emp.std_id = e.std_id;
            //    emp.std_name = e.std_name;
            //    emp.std_gender = e.std_gender;
            //    emp.std_age = e.std_age;
            //    emp.std_claaas = e.std_claaas;
            //    emp.t_id = e.t_id;
            //    db.SaveChanges();

            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok();
        }


    }
}
