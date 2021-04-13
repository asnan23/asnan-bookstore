using asnan_Bookstore.Data;
using asnan_Bookstore.Models;
using asnan_Bookstore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace asnan_Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IBookRepository bookRepository, 
            ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var books = await  _bookRepository.GetAllBooks();

            return View(books);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }


        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;

            var model = new BookModel()
            {
                LanguageId = 2
            };

            //ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                if (book.ConvertPhoto != null)
                {
                    string folder = "books/cover/";
                    book.CoverImageUrl = await UploadImage(folder, book.ConvertPhoto);
                }

                if (book.ConvertPhoto != null)
                {
                    string folder = "books/galery/";
                    book.Galery = new List<GaleryModel>();
                    foreach (var file in book.GaleryFiles)
                    {
                        var galery = new GaleryModel
                        {
                            Name = file.FileName,
                            Url = await UploadImage(folder, file)
                        };
                        book.Galery.Add(galery);
                    }                                
                }

                if (book.BookPdf != null)
                {
                    string folder = "books/pdf/";
                    book.BookPdfUrl = await UploadImage(folder, book.BookPdf);
                }

                int id = await _bookRepository.AddNewBook(book);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.IsSuccess = false;
            ViewBag.BookId = 0;

            //ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
