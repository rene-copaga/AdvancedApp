using AdvancedApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedApp.Controllers
{
    public class HomeController : Controller
    {
        private AdvancedContext context;

        public HomeController(AdvancedContext ctx) => context = ctx;

        public IActionResult Index()
        {
            return View(context.Employees);
        }

        public IActionResult Edit(string SSN)
        {
            return View(string.IsNullOrWhiteSpace(SSN)
            ? new Employee() : context.Employees.Include(e => e.OtherIdentity)
                .First(e => e.SSN == SSN));
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (context.Employees.Count(e => e.SSN == employee.SSN) == 0)
            {
                context.Add(employee);
            }
            else
            {
                context.Update(employee);
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
