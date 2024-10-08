﻿using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    [SwaggerOperation(Summary = "Get employee by id")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id)
    {
        return await _employeeService.GetEmployeeByIdAsync(id);
    }

    [SwaggerOperation(Summary = "Get all employees")]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll()
    {
        return await _employeeService.GetAllEmployeesAsync();
    }

    [SwaggerOperation(Summary = "Calculate employee paycheck")]
    [HttpGet("{id}/paycheck")]
    public async Task<ActionResult<decimal>> CalculatePaycheck(int id)
    {
        try
        {
            var paycheck = await _employeeService.CalculatePaycheckAsync(id);
            return Ok(paycheck);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
