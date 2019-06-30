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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
            
        public IList<Burger> Burger { get; set; }

        public async Task OnGetAsync()
        {
            Burger = await _db.Burger.ToListAsync();
        }
    }
}
