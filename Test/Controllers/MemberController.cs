using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using Test.Models;


namespace Test.Controllers
{
    public class MemberController : ApiController
    {
        ABCEntities db = new ABCEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult DetailsEmp()
        {
            List<Employee> empList = new List<Employee>();
            empList = db.Details().ToList();
            if (empList.Count == 0)
            {
                return NotFound();
            }

            return Ok(empList);
        }
        
    }
}
