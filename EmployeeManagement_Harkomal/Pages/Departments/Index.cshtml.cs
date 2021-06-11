using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement_Harkomal.Buss;
using EmployeeManagement_Harkomal.Data;

namespace EmployeeManagement_Harkomal.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeManagement_Harkomal.Data.ApplicationDbContext _context;

        public IndexModel(EmployeeManagement_Harkomal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }

        public async Task OnGetAsync()
        {
            Department = await _context.Departments.ToListAsync();
        }
    }
}
