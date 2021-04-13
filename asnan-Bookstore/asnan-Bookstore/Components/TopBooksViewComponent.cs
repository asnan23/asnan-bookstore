using asnan_Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asnan_Bookstore.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private IBookRepository _bookRepository;

        public TopBooksViewComponent(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {

            var books = await _bookRepository.GetTopBooksAsync(count);
            return View(books);
        }
    }
}
