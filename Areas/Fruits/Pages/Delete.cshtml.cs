using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using myFruits.Data;
using myFruits.Models;

namespace myFruits.Areas.Fruits.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly myFruits.Data.ApplicationDbContext _context;

        public DeleteModel(myFruits.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Fruit Fruit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fruits == null)
            {
                return NotFound();
            }

            var fruit = await _context.Fruits.FirstOrDefaultAsync(m => m.Id == id);

            if (fruit == null)
            {
                return NotFound();
            }
            else 
            {
                Fruit = fruit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Fruits == null)
            {
                return NotFound();
            }
            var fruit = await _context.Fruits.FindAsync(id);

            if (fruit != null)
            {
                Fruit = fruit;
                _context.Fruits.Remove(Fruit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
