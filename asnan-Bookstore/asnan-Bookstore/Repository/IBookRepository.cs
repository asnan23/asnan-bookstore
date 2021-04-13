﻿using asnan_Bookstore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace asnan_Bookstore.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
    }
}