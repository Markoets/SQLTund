using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoredProcedure.Data;
using StoredProcedure.Models;

namespace StoredProcedure.Controllers
{
    public class EmployeeController : Controller
    {

        public StoredProcDbContext _context;

        public EmployeeController(StoredProcDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<Employee> SearchResult()
        {
            var result = _context.Employee
                .FromSqlRaw<Employee>("spSerachEmployees")
                .ToList();

            return result;
        }
    }
}
