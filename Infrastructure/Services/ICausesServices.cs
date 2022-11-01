using Domain.Dtos;

namespace Infrastructure.Services;

public interface ICausesServices
{
    Task<List<GetCausesDto>> GetCauses();
    Task<AddCausesDto> AddCauses(AddCausesDto causes);
    Task<GetCausesDto> UpdateCauses(AddCausesDto causes);
    Task<bool> DeleteCauses(int id);
    Task<GetCausesDto?> GetCausesById(int id);
}
