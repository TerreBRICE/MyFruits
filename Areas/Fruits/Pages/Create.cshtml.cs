using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myFruits.Data;
using myFruits.Models;

namespace myFruits.Areas.Fruits.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext ctx;

        public CreateModel(myFruits.Data.ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fruit Fruit { get; set; } = new();
        
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyFruit = new Fruit();

            if(await TryUpdateModelAsync(emptyFruit, "Fruit", f => f.Name, f => f.Description, f => f.Price))
            {
                ctx.Fruits.Add(Fruit);
                await ctx.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();

        }
    }
}
