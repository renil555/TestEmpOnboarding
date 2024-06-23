using Utility;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using API.Services.Interface;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmpController : Controller
    {
        private readonly IEmployeeService _empService;

        public EmpController(IEmployeeService employeeService)
        {
            _empService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                var employeeList = await _empService.GetAllEmployees();
                return Ok(employeeList.OrderBy(x => x.EmployeeId));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _empService.GetEmployee(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee employee)
        {
            try
            {
                await _empService.AddEmployee(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(Employee employee)
        {
            try
            {
               await _empService.UpdateEmployee(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int Id)
        {
            try
            {
                await _empService.DeleteEmployee(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
