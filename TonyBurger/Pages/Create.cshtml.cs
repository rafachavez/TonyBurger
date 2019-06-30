using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TonyBurger.Data;
using TonyBurger.Models;

namespace TonyBurger.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Microsoft.AspNetCore.Http.IFormFile file { get; set; }
        [BindProperty]
        public byte[] Image { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Burger Burger { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);
                this.Image = stream.ToArray();
            }

            Burger.Image = this.Image;
            Burger.ImageContentType = "file";
            _db.Burger.Add(Burger);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
