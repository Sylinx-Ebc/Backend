using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    [Table("purchase", Schema = "public")]
    public class Purchase
    {
        [Key] 
        public int purchaseserial { get; set; }
        public string productname { get; set; }
        public int accountid { get; set; }
        public double productcost { get; set; }


    }
}
