using Api.Dtos.Dependent;
using Api.Models;

namespace Api.Services;

public interface IDependentsService
{
    Task<ApiResponse<List<GetDependentDto>>> GetAllDependentsAsync();
    Task<ApiResponse<GetDependentDto>> GetDependentByIdAsync(int id);
}
