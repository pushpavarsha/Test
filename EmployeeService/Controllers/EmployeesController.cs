using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeService.Controllers
{
   
    public class EmployeesController : ApiController
    {
        [Authorize]
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {
            using(ABCEntities db = new ABCEntities())
            {
                return db.Employees.ToList();
            }

        }
    }
}
