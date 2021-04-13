using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asnan_Bookstore.Data
{
    public class BookGalery
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Books Book { get; set; }
    }
}
