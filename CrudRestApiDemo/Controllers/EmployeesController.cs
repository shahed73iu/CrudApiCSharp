using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudRestApiDemo.EmployeeData;
using CrudRestApiDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudRestApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet("/api/Employees/{id}")]

        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with ID : {id} was not found!");
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody]Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Ok();
        }

        [HttpDelete("/api/Employees/{id}")]
        public void Delete(int id)
        {
            _employeeData.DeleteEmployee(id);
        }

        
        [HttpPut("/api/Employees/{id}")]
        public void EditEmployee(int id, [FromBody] Employee employee)
        {
            _employeeData.EditEmployee(id, employee);
        }

    }
}
