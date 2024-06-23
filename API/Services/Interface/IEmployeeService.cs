using Utility;

namespace API.Services.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task AddEmployee(Employee emp);
        Task UpdateEmployee(Employee emp);
        Task DeleteEmployee(int id);
        Task<Employee> GetEmployee(int id);
    }
}
