using EmployeePortal.Web.Data;
using EmployeePortal.Web.Models;
using EmployeePortal.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel viewModel)
        {
            var employee = new Employee
            {
                Name = viewModel.Name,
                Designation = viewModel.Designation,
                Experience = viewModel.Experience
            };

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Employees");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var employees = await dbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Edit (Guid id)
        {
            var student = await dbContext.Employees.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (Employee viewModel)
        {
            var employee = await dbContext.Employees.FindAsync(viewModel.Id);

            if (employee is not null)
            {
                employee.Name = viewModel.Name;
                employee.Designation = viewModel.Designation;
                employee.Experience = viewModel.Experience;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Employees");
        }

        [HttpPost]
        public async Task<IActionResult> Delete (Employee viewModel)
        {
            var employee = await dbContext.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (employee is not null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employees"); 
        }
    }
}
