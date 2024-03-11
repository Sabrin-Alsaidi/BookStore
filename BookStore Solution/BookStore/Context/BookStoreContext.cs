using System;
using BookStore.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Context
{
	public class BookStoreContext:DbContext
	{
		public BookStoreContext(DbContextOptions<BookStoreContext>options):base (options)
		{
		}

        public DbSet<Book> books { get; set; }
    }
}

