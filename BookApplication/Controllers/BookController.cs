using BookApplication.NewFolder2;
using BookApplication.NewFolder3;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.NewFolder
{
    public class BookController:Controller
    {
        private readonly BookRepository repository;

        public BookController(BookRepository bookRepository) { 
            repository = bookRepository;
        }

        public async Task<ViewResult> getallbooks()
        {
            var data= await  repository.GetAllBooks();
            return View(data);
        }

        public  async Task<ViewResult> Book(int id)
        {
            var data=await repository.GetBookById(id);
             return View(data);

        }

       public List<BookModel> SearchBooks(string Title,string author)
        {
            return repository.SearchBook(Title, author);
        }
        public ViewResult AddBook(bool isSuccess=false,int bookid=0){
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookid;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel model)
        {
            int id=await repository.ADDbook(model);
            if(id>0)
            {
                return RedirectToAction(nameof(AddBook), new { isSuccess =true,bookId=id});
            }
            return View(); 
        }

    }
}
