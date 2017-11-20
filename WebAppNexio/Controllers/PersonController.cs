using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppNexio.Models.Person;

namespace WebAppNexio.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            Person person = new Person();
            
            return View("Person", person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult He(Person person)
        {
            Person.PersonList.Add(person);

            return PartialView("She", new Person());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult She(Person person)
        {
            Person.PersonList.Add(person);
            var names = Person.PersonList.ToArray();
            Result result = new Result();

            result.HisName = names[0].Name;
            result.HerName = names[1].Name;

            result.Success = Person.Compare();

            return PartialView("_Result", result);
        }


    }
}