using BookApplication.Data;
using BookApplication.NewFolder2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace BookApplication.NewFolder3
{
    public class BookRepository
    {
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> ADDbook(BookModel model)
        {
            var newbook = new Books()
            {
                Title = model.Title,
                Author = model.Author,
            };
           await _context.Books.AddAsync(newbook);
          await  _context.SaveChangesAsync(); 
            return newbook.Id;
        }

        public async Task< List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if (allBooks != null)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Title = book.Title,
                        Author = book.Author
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.SingleOrDefaultAsync(b => b.Id == id);
            if (book != null)
            {
                var bookModel = new BookModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author
                };
                return bookModel;
            }
            return null;
        }
        public List<BookModel> SearchBook(string bookname,string authorname)
        {
            return DataSource().Where(x => x.Title == bookname&&x.Author == authorname).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>() {
                new BookModel() {Id=1,Title="java",Author="Alex" },
                   new BookModel() {Id=2,Title="python",Author="Falex" },
                    new BookModel() {Id=3,Title="C++",Author="Dalex" },
                     new BookModel() {Id=4,Title="C",Author="Salex" },
                      new BookModel() {Id=5,Title="C#",Author="Nalex" },
         };
        }

    }
}
