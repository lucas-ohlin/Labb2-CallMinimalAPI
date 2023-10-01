using Labb1_MinimalAPI.Models.DTOs;
using Labb1_MinimalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Labb2_CallMinimalAPI.Services;
using Labb2_CallMinimalAPI.Models;

namespace Labb2_CallMinimalAPI.Controllers {
    public class BookController : Controller {

        private readonly IBookService _bookService;
        public BookController(IBookService bookService) {
            _bookService = bookService;
        }
        public async Task<IActionResult> BookIndex() {

            List<Book> list = new List<Book>();
            var response = await _bookService.GetAllBooks<ResponseDTO>();

            if (response != null && response.IsSuccess) {
                list = JsonConvert.DeserializeObject<List<Book>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> TitleIndex(string title) {

            List<Book> list = new List<Book>();
            var response = await _bookService.GetBooksByTitle<ResponseDTO>(title);

            if (response != null && response.IsSuccess) {
                list = JsonConvert.DeserializeObject<List<Book>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> Details(Guid id) {

            var response = await _bookService.GetBookById<ResponseDTO>(id);

            if (response != null && response.IsSuccess) {
                Book book = JsonConvert.DeserializeObject<Book>(Convert.ToString(response.Result));
                return View(book);
            }

            return NotFound();
        }

        public async Task<IActionResult> BookCreate() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookCreate(BookCreateDTO model) {
            if (ModelState.IsValid) {
                var response = await _bookService.CreateBookAsync<ResponseDTO>(model);
                if (response != null && response.IsSuccess) {
                    return RedirectToAction(nameof(BookIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> UpdateBook(Guid id) {

            var response = await _bookService.GetBookById<ResponseDTO>(id);

            if (response != null && response.IsSuccess) {
                BookUpdateDTO book = JsonConvert.DeserializeObject<BookUpdateDTO>(Convert.ToString(response.Result));
                return View(book);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookUpdateDTO model) {

            if (ModelState.IsValid) {
                var response = await _bookService.UpdateBookAsync<ResponseDTO>(model);
                if (response != null && response.IsSuccess) {
                    return RedirectToAction(nameof(BookIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteBook(Guid id) {

            var response = await _bookService.GetBookById<ResponseDTO>(id);

            if (response != null && response.IsSuccess) {
                Book book = JsonConvert.DeserializeObject<Book>(Convert.ToString(response.Result));
                return View(book);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(Book model) {
            if (ModelState.IsValid) {
                var response = await _bookService.DeleteBookAsync<ResponseDTO>(model.Id);
                if (response != null && response.IsSuccess) {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return NotFound();
        }
    }

}

