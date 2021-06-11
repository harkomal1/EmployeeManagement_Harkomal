using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeManagement_Harkomal.Buss;
using EmployeeManagement_Harkomal.Data;

namespace EmployeeManagement_Harkomal.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeManagement_Harkomal.Data.ApplicationDbContext _context;

        public CreateModel(EmployeeManagement_Harkomal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartmentID"] = new SelectList(_context.Departments, "ID", "Name");
        ViewData["JobID"] = new SelectList(_context.Jobs, "ID", "JobName");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
