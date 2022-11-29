using System;
namespace Toth_Ardelean_Cynthia_Lab2.Models
{
    public class PublishedBook
    {
        public int? PublisherID { get; set; }
        public int? BookID { get; set; }
        public Publisher? Publisher { get; set; }
        public Book? Book { get; set; }
    }
}

