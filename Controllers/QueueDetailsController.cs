﻿using hapiservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using Dapper;
using System.Net;

namespace hapiservice.Controllers
{
    /// <summary>
    /// Users will download the QueueDetails after loading the application.
    /// </summary>
    public class QueueDetailsController : EntitySetController<QueueDetailModel, int>
    {
        static IEnumerable<QueueDetailModel> queueDetails
        {
            get
            {
                using (var connection = Helpers.SqlHelper.GetOpenConnectionBBApps())
                {
                    const string queryString = "SELECT * FROM QUEUEDETAILS";
                    return connection.Query<QueueDetailModel>(queryString);
                }
            }
        }

        protected override QueueDetailModel GetEntityByKey(int key)
        {
            return queueDetails.FirstOrDefault(q => q.CallTypeID == key);
        }       
        [Queryable]
        public override IQueryable<QueueDetailModel> Get()
        {
            return queueDetails.AsQueryable();
        }
    }
}