using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement_Harkomal.Buss;
using EmployeeManagement_Harkomal.Data;

namespace EmployeeManagement_Harkomal.Pages.Jobs
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeeManagement_Harkomal.Data.ApplicationDbContext _context;

        public DetailsModel(EmployeeManagement_Harkomal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Job Job { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Job = await _context.Jobs.FirstOrDefaultAsync(m => m.ID == id);

            if (Job == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
