using asnan_Bookstore.Data;
using asnan_Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asnan_Bookstore.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private BookStroreContext _context;

        public LanguageRepository(BookStroreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Languages.Select(t => new LanguageModel()
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description
            }).ToListAsync();
        }
    }
}
