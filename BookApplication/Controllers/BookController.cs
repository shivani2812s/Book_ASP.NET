using BookApplication.NewFolder2;
using BookApplication.NewFolder3;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.NewFolder
{
    public class BookController:Controller
    {
        private readonly BookRepository repository;

        public BookController() { 
            repository = new BookRepository();
        }

        public ViewResult getallbooks()
        {
            var data= repository.GetAllBooks();
            return View(data);
        }

        public ViewResult Book(int id)
        {
            var data= repository.GetBookById(id);
             return View(data);

        }

       public List<BookModel> SearchBooks(string Title,string author)
        {
            return repository.SearchBook(Title, author);
        }
    }
}
