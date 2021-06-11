using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement_Harkomal.Buss;
using EmployeeManagement_Harkomal.Data;

namespace EmployeeManagement_Harkomal.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeeManagement_Harkomal.Data.ApplicationDbContext _context;

        public DetailsModel(EmployeeManagement_Harkomal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job).FirstOrDefaultAsync(m => m.ID == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
