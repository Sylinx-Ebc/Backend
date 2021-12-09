using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    [Table("accounts", Schema = "public")]
    public class Account
    {
        [Key]
        public int accountid { get; set; }
        public string username { get; set; }
        public string userpassword { get; set; }

    }
}
