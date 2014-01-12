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
    public class NewQueuesController : ODataController
    {
        QueueModelContext _db = new QueueModelContext();

        [Queryable]
        IQueryable<QueueModel> Get()
        {
            return _db.Queues;
        }



    }


    //public class QueuesController : EntitySetController<QueueModel, int>
    //{
    //    static IEnumerable<QueueModel> queues
    //    {
    //        get
    //        {
    //            using (var connection = Helpers.SqlHelper.GetOpenConnectionEZView())
    //            {
    //                const string queryString = @"SELECT CallTypeID, ServiceLevelCallsToday, ServiceLevelCallsOfferedToday, RouterCallsQNow, ISNULL(CONVERT(VARCHAR(10), RouterLongestCallQ, 8), '00:00') as RouterLongestCallQ FROM t_Call_Type_Real_Time";
    //                return connection.Query<QueueModel>(queryString);
    //            }
    //        }
    //    }        

    //    protected override QueueModel GetEntityByKey(int key)
    //    {
    //        return queues.FirstOrDefault(q => q.CallTypeID == key);
    //    }

    //    [Queryable]
    //    public override IQueryable<QueueModel> Get()
    //    {
    //        return queues.AsQueryable();
    //    }

    //    public IEnumerable<QueueModel> GetEntityByKeys(int key, int key2)
    //    {
    //        return queues.Where(p => p.CallTypeID == key || p.IsDisabled == key2);
    //    }

        

    //}
}