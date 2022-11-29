using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toth_Ardelean_Cynthia_Lab2.Models
{
    public class Author
    {
        public int AuthorID { get; set; }

        [Column(TypeName = "text")]
        public string FirstName { get; set; }

        [Column(TypeName = "text")]
        public string LastName { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}