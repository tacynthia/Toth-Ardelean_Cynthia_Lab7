using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Toth_Ardelean_Cynthia_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        public int AuthorID { get; set; }
        [Column(TypeName = "text")]
        public string Title { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public Author? Author { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public ICollection<PublishedBook>? PublishedBooks { get; set; }
    }
}