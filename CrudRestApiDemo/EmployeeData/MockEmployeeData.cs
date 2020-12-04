﻿

using CrudRestApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudRestApiDemo.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name= "Employee One"
            },
            new Employee()
            {
                Id = Guid.NewGuid(),
                Name= "Employee Two"
            }
        };


        public Employee AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee EditEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);

        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
