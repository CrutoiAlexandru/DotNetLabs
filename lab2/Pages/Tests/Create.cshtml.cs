﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crutoi_Alexandru_Lab2.Data;
using Crutoi_Alexandru_Lab2.Models;

namespace Crutoi_Alexandru_Lab2.Pages.Tests
{
    public class CreateModel : PageModel
    {
        private readonly Crutoi_Alexandru_Lab2.Data.Crutoi_Alexandru_Lab2Context _context;

        public CreateModel(Crutoi_Alexandru_Lab2.Data.Crutoi_Alexandru_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Test Test { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Test.Add(Test);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
