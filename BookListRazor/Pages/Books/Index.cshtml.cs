using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public IEnumerable<Book> Books;

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var bookFromDb = await _db.Book.FindAsync(id);
            if (bookFromDb == null)
            {
                return NotFound();
            }

            _db.Book.Remove(bookFromDb);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
