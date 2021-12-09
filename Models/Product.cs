using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    [Table("product",Schema = "public")]
    public class Product
    {
        [Key]
        public int productid { get; set; }

        public string productname { get; set; }

        public double productcost { get; set; }


    }
}
