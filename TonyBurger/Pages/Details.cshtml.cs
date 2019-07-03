﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

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
    }
}