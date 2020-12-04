using CrudRestApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiDemo.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }


        public void AddEmployee(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
        }


        public void DeleteEmployee(int id)
        {
            var employeeToDelete = _employeeContext.Employees.Find(id);
            _employeeContext.Remove(employeeToDelete);
            _employeeContext.SaveChanges();
        }

        public void EditEmployee(int id ,Employee employee)
        {
            //throw new NullReferenceException();
            var EditAbleEmployee = _employeeContext.Employees.Find(id);
            EditAbleEmployee.Name = employee.Name;
            _employeeContext.SaveChanges();
        }

        public Employee GetEmployee(int id)
        {
            var employee = _employeeContext.Employees.Find(id);
            return employee;
            //return _employeeContext.Employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}
