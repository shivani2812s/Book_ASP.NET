using BookApplication.NewFolder2;
using System.Linq;

namespace BookApplication.NewFolder3
{
    public class BookRepository
    {

        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
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
