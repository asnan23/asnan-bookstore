using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asnan_Bookstore.Data
{
    public class BookStroreContext: DbContext
    {
        public BookStroreContext(DbContextOptions<BookStroreContext> options):base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
        public DbSet<BookGalery> Galery { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}
