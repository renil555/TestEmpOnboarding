using API.Models;
using API.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Utility;

namespace API.Services
{
    public class EmployeeService:IEmployeeService
    {
       
       
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeService(EmployeeDbContext employeeDbContext)
        {
           _employeeDbContext = employeeDbContext;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                var employeeList = await _employeeDbContext.EmployeeDetails.Select(x => new Employee
                {
                    EmployeeId = x.EmployeeId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBrith = x.DateofBirth,
                    Department = x.Department,
                    Email = x.Email

                }).ToListAsync();
                return employeeList;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }
        public async Task<Employee> GetEmployee(int id)
        {
            try
            {
                var employee = new Employee();
                var existingEmployee = await _employeeDbContext.EmployeeDetails.FindAsync(id);

                if (existingEmployee != null)
                {
                    employee.EmployeeId = existingEmployee.EmployeeId;
                    employee.FirstName = existingEmployee.FirstName;
                    employee.LastName = existingEmployee.LastName;
                    employee.Email = existingEmployee.Email;
                    employee.DateOfBrith = existingEmployee.DateofBirth;
                    employee.Department = existingEmployee.Department;
                    
                }
                return employee;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task AddEmployee(Employee emp)
        {
            try
            {
                var employee = new EmployeeDetail();
                employee.EmployeeId = emp.EmployeeId;
                employee.FirstName = emp.FirstName;
                employee.LastName = emp.LastName;
                employee.DateofBirth = emp.DateOfBrith.HasValue ? emp.DateOfBrith.Value : DateTime.Now;
                employee.Department = emp.Department;
                employee.Email = emp.Email;
                await _employeeDbContext.EmployeeDetails.AddAsync(employee);
                await _employeeDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateEmployee(Employee emp)
        {
            try
            {
                var employee = await _employeeDbContext.EmployeeDetails.FindAsync(emp.EmployeeId);
                if (employee != null)
                {
                    employee.FirstName = emp.FirstName;
                    employee.LastName = emp.LastName;
                    employee.DateofBirth= emp.DateOfBrith.HasValue ? emp.DateOfBrith.Value : DateTime.Now;
                    employee.Department= emp.Department;
                    employee.Email = emp.Email;
                    _employeeDbContext.EmployeeDetails.Update(employee);
                    await _employeeDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteEmployee(int id)
        {
            try
            {
               var employee =  await _employeeDbContext.EmployeeDetails.FindAsync(id);
                if (employee != null)
                {
                    _employeeDbContext.EmployeeDetails.Remove(employee);
                    await _employeeDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
