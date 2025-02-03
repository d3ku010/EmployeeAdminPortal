using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Logs;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ILoggingService _logger;

        public EmployeesController(ApplicationDbContext dbContext, ILoggingService logger)
        {
            this.dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            _logger.LogInfo("Fetching all employees from the database.");
            var employees = dbContext.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            _logger.LogInfo($"Fetching employee with ID: {id}");

            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                _logger.LogWarning($"Employee with ID {id} not found.");
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            _logger.LogInfo("Adding a new employee.");

            var employeeEntity = new Employee
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            _logger.LogInfo($"Employee {employeeEntity.Name} added successfully with ID: {employeeEntity.Id}");
            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            _logger.LogInfo($"Updating employee with ID: {id}");

            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                _logger.LogWarning($"Employee with ID {id} not found.");
                return NotFound();
            }

            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();

            _logger.LogInfo($"Employee with ID {id} updated successfully.");
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            _logger.LogInfo($"Deleting employee with ID: {id}");

            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                _logger.LogWarning($"Employee with ID {id} not found.");
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            _logger.LogInfo($"Employee with ID {id} deleted successfully.");
            return Ok();
        }
    }
}
