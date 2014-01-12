using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hapiservice.Models
{
    public class QueueModel
    {
        [Key]
        public int CallTypeID { get; set; }
        public int IsDisabled { get; set; }
        public string QueueType { get; set; } // QueueType: CL, PH, CB, DN
        public int RouterCallsQNow { get; set; }
        public string RouterLongestCallQ { get; set; }
        public int ServiceLevelCallsToday { get; set; }
        public int ServiceLevelCallsOfferedToday { get; set; }
    }
    public class QueueModelContext : DbContext
    {
        public DbSet<QueueModel> Queues { get; set; }
    }
}