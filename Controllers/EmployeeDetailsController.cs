using hapiservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using Dapper;
using System.Text;
using System.Web.Mvc;
using Mvc.JQuery.Datatables;
using hapiservice.Helpers;

namespace hapiservice.Controllers
{
    public class EmployeeDetailsController : ApiController
    {
        public EmployeeDetailModel Get([FromUri] string param)
        {
            return new EmployeeDetails().GetEmployeeDetails(param.ToLower());
        }      
    }
}
