using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hapiservice.Models
{
    public class ProductModel
    {
        [Key]
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public int IsDisabled { get; set; }
        public ICollection<QueueModel> Queues { get; set; }      
       
    }
    public class ProductModelContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
    }
}