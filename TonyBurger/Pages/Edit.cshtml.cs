using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TonyBurger.Data;
using TonyBurger.Models;

namespace TonyBurger.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Microsoft.AspNetCore.Http.IFormFile file { get; set; }
        [BindProperty]
        public byte[] Image { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Burger Burger { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Burger = await _db.Burger.FirstOrDefaultAsync(m => m.Id == id);

            if (Burger == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _db.Attach(Burger).State = EntityState.Modified;

            try
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    file.CopyTo(stream);
                    this.Image = stream.ToArray();
                }

                Burger.Image = this.Image;
                Burger.ImageContentType = "file";

                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BurgerExists(Burger.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return RedirectToPage("./Index");
        }

        private bool BurgerExists(int id)
        {
            return _db.Burger.Any(e => e.Id == id);
        }
    }
}