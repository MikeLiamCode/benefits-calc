using Api.Dtos.Employee;
using Api.Models;

namespace Api.Services;

public interface IEmployeeService
{
    Task<ApiResponse<List<GetEmployeeDto>>> GetAllEmployeesAsync();
    Task<ApiResponse<GetEmployeeDto>> GetEmployeeByIdAsync(int id);
    Task<decimal> CalculatePaycheckAsync(int employeeId);
}
