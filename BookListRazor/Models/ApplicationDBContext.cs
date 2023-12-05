using System;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Models
{
	public class ApplicationDBContext : DbContext 
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{

		}
			
		public DbSet<Book> Book { get; set; }
	}
}

