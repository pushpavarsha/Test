using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class EmployeeController : Controller
    {
        ABCEntities db = new ABCEntities();
        // GET: Employee
        public ActionResult Details(string search="",string sortColumn="Name",string IconClass="fa-sort-asc")
        {
            List<Employee> empList = new List<Employee>();
            empList = db.Details().ToList();
            return View(empList);
        }
        public ActionResult EmpDetails()
        {
            IEnumerable<Employee> students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44339/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Member/DetailsEmp");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Employee>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else 
                {
                  

                    students = Enumerable.Empty<Employee>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(students);
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search(string search = "")
        {
            // int id = 4;
            List<Employee> emp = new List<Employee>();
            emp=db.Employees.Where(x => x.Name.Contains(search)).ToList();
            return View("Details", emp);
        }

    }
}