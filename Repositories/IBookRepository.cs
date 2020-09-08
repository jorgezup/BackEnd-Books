using System.Collections.Generic;
using BooksApi.Models;

namespace BooksApi.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();

        Book GetBookById(int id);
    }
}