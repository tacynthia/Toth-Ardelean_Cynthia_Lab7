using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Toth_Ardelean_Cynthia_Lab2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Column(TypeName = "text")]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

