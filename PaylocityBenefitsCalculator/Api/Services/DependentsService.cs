using Api.DBContext;
using Api.Dtos.Dependent;
using Api.Models;

namespace Api.Services;

public class DependentsService : IDependentsService
{
    private readonly ApplicationDbContext _context;

    public DependentsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApiResponse<List<GetDependentDto>>> GetAllDependentsAsync()
    {
        var dependents = _context.Dependents.Select(d => new GetDependentDto
        {
            Id = d.Id,
            FirstName = d.FirstName,
            LastName = d.LastName,
            DateOfBirth = d.DateOfBirth,
            Relationship = d.Relationship
        }).ToList();

        return new ApiResponse<List<GetDependentDto>>
        {
            Data = dependents,
            Success = true
        };
    }

    public async Task<ApiResponse<GetDependentDto>> GetDependentByIdAsync(int id)
    {
        var dependent = _context.Dependents.Where(d => d.Id == id).Select(d => new GetDependentDto
        {
            Id = d.Id,
            FirstName = d.FirstName,
            LastName = d.LastName,
            DateOfBirth = d.DateOfBirth,
            Relationship = d.Relationship
        }).FirstOrDefault();

        if (dependent == null)
        {
            return new ApiResponse<GetDependentDto>
            {
                Success = false,
                Message = "Dependent not found"
            };
        }

        return new ApiResponse<GetDependentDto>
        {
            Data = dependent,
            Success = true
        };
    }
}
