using System;
using BookStore.Context;
using BookStore.Interface;
using BookStore.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class BookRepository: IBookRepository
	{
        private readonly BookStoreContext _bookStoreContext;
		public BookRepository(BookStoreContext bookStoreContext)
		{
            _bookStoreContext = bookStoreContext;
		}

        public int Create(Book book)
        {
            _bookStoreContext.books.Add(book);
            return _bookStoreContext.SaveChanges();
        }

        public int Delete(Book book)
        {
            _bookStoreContext.books.Remove(book);
            return _bookStoreContext.SaveChanges();
            
        }

        public Book Get(int id)
        {
            return _bookStoreContext.books.Find(id);
        }

        public IEnumerable<Book> GetAll() =>_bookStoreContext.books.ToList();

        public int Update(Book book)
        {
            _bookStoreContext.books.Update(book);
            return _bookStoreContext.SaveChanges();
        }
    }
}

