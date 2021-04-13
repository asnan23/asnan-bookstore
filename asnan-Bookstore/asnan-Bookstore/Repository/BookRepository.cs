using asnan_Bookstore.Data;
using asnan_Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asnan_Bookstore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStroreContext _context = null;

        public BookRepository(BookStroreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var NewBook = new Books
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                LanguageId = model.LanguageId,
                TotalPage = model.TotalPage.HasValue ? model.TotalPage.Value : 0,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl
            };

            NewBook.bookGalery = new List<BookGalery>();
            foreach (var file in model.Galery)
            {
                NewBook.bookGalery.Add(new BookGalery()
                {
                    Name = file.Name,
                    Url = file.Url
                });
            }
            await _context.Books.AddAsync(NewBook);
            await _context.SaveChangesAsync();

            return NewBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books.Select(x => new BookModel()
            {
                Title = x.Title,
                Author = x.Author,
                Description = x.Description,
                Category = x.Category,
                TotalPage = x.TotalPage,
                LanguageId = x.LanguageId,
                Language = x.Language.Name,
                Id = x.Id,
                CoverImageUrl = x.CoverImageUrl
            }).ToListAsync();

        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books.Select(x => new BookModel()
            {
                Title = x.Title,
                Author = x.Author,
                Description = x.Description,
                Category = x.Category,
                TotalPage = x.TotalPage,
                LanguageId = x.LanguageId,
                Language = x.Language.Name,
                Id = x.Id,
                CoverImageUrl = x.CoverImageUrl
            }).Take(count).ToListAsync();

        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(t => t.Id == id).Select(book => new BookModel()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                TotalPage = book.TotalPage,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                Id = book.Id,
                CoverImageUrl = book.CoverImageUrl,
                Galery = book.bookGalery.Select(t => new GaleryModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Url = t.Url
                }).ToList(),
                BookPdfUrl = book.BookPdfUrl
            }).FirstOrDefaultAsync();
        }



    }
}
