using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPExample.Models;

namespace SPExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISalaryRepository _salaryRepository;
        public HomeController(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }
        [HttpGet]
        public ViewResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(EmployeeSalary employeeSalary)
        {
            if (employeeSalary.EmployeeName != null)
            {
                return RedirectToAction("GetSalary", new { name = employeeSalary.EmployeeName });
            }
            return RedirectToAction("search");
        }

        public ViewResult GetSalary(string name)
        {
            EmployeeSalary _employeeSalary = _salaryRepository.GetSalaryByName(name);
            var model = _employeeSalary;
            return View(model);
        }

        public ViewResult GetAllSalary()
        {
            IEnumerable<EmployeeSalary> _employeeSalary = _salaryRepository.GetAllSalary();
            var model = _employeeSalary;
            return View(model);
        }
    }
}