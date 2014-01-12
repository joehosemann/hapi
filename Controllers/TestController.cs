using hapiservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using Dapper;

namespace hapiservice.Controllers
{
    public class TestController : EntitySetController<TestModel, int>
    {
        static IEnumerable<TestModel> test
        {
            get
            {
                using (var connection = Helpers.SqlHelper.GetOpenConnectionEZView())
                {
                    const string queryString = @"select CURRENT_TIMESTAMP as CurrentDate";
                    return connection.Query<TestModel>(queryString);
                }
            }

        }
        public override IQueryable<TestModel> Get()
        {
            return test.AsQueryable();
        }
    }
}