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
    public class IndexModel : PageModel
    {
        private readonly myFruits.Data.ApplicationDbContext _context;

        public IndexModel(myFruits.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Fruit> Fruit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Fruits != null)
            {
                Fruit = await _context.Fruits.ToListAsync();
            }
        }
    }
}
