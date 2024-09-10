using Api.DBContext;
using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _context;

    public EmployeeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<List<GetEmployeeDto>>> GetAllEmployeesAsync()
    {
        var employees = _context.Employees.Select(e => new GetEmployeeDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Salary = e.Salary,
            DateOfBirth = e.DateOfBirth,
            Dependents = e.Dependents.Select(d => new GetDependentDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                DateOfBirth = d.DateOfBirth,
                Relationship = d.Relationship
            }).ToList()
        }).ToList();

        return new ApiResponse<List<GetEmployeeDto>>
        {
            Data = employees,
            Success = true
        };
    }

    public async Task<ApiResponse<GetEmployeeDto>> GetEmployeeByIdAsync(int id)
    {
        var employee = _context.Employees.Where(e => e.Id == id).Select(e => new GetEmployeeDto
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Salary = e.Salary,
            DateOfBirth = e.DateOfBirth,
            Dependents = e.Dependents.Select(d => new GetDependentDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                DateOfBirth = d.DateOfBirth,
                Relationship = d.Relationship
            }).ToList()
        }).FirstOrDefault();

        if (employee == null)
        {
            return new ApiResponse<GetEmployeeDto>
            {
                Success = false,
                Message = "Employee not found"
            };
        }

        return new ApiResponse<GetEmployeeDto>
        {
            Data = employee,
            Success = true
        };
    }

    public async Task<decimal> CalculatePaycheckAsync(int employeeId)
    {
        var employee = _context.Employees.Include(e => e.Dependents).FirstOrDefault(e => e.Id == employeeId);
        if (employee == null)
            throw new InvalidOperationException("Employee not found.");

        var benefitsCost = employee.CalculateBenefitsCost();
        var annualSalary = employee.Salary;
        var paycheckAmount = (annualSalary - benefitsCost) / 26; // 26 paychecks per year

        return paycheckAmount;
    }
}