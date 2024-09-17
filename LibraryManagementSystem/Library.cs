using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(string isbn)
        {
            var bookToRemove = books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public List<Book> SearchBooks(string searchTerm)
        {
            return books.Where(b => b.Title.Contains(searchTerm) || b.Author.Contains(searchTerm)).ToList();
        }
    }
}