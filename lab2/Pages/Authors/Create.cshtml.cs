﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Crutoi_Alexandru_Lab2.Data;
using Crutoi_Alexandru_Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Crutoi_Alexandru_Lab2.Pages.Authors
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Crutoi_Alexandru_Lab2.Data.Crutoi_Alexandru_Lab2Context _context;
        public CreateModel(Crutoi_Alexandru_Lab2.Data.Crutoi_Alexandru_Lab2Context context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            var authorList = _context.Author.Select(x => new
             {
             x.ID,
             FullName = x.LastName + " " + x.FirstName
             });
            // daca am adaugat o proprietate FullName in clasa Author
            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID",
           "PublisherName");

            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories, Book book)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }

            book.BookCategories = newBook.BookCategories;
            _context.Book.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        PopulateAssignedCategoryData(_context, newBook);
        return Page();
        }
    }
}