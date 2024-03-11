using System;
using BookStore.Model;

namespace BookStore.Interface
{
	public interface IBookRepository
	{
        IEnumerable<Book> GetAll();
        Book Get(int id);
        int Create(Book item);
        int Update(Book item);
        int Delete(Book item);
    }
}

