using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CausesServices : ICausesServices
{
    private readonly DataContext _context;

    public CausesServices(DataContext context)
    {
        _context = context;
    }
    public async Task<AddCausesDto> AddCauses(AddCausesDto causes)
    {
        var Causes = new Causes()
        {
            Header = causes.Header,
            Image = causes.Image,
            Explanation = causes.Explanation,
            Raised = causes.Raised,
            Goal = causes.Goal,
        };
        await _context.Causes.AddAsync(Causes);
        await _context.SaveChangesAsync();
        return causes;
    
    }

    public async Task<bool> DeleteCauses(int id)
    {
        var deleteCauses = await _context.Causes.FirstOrDefaultAsync(x => x.Id == id);
        if (deleteCauses == null)
        {
            return false;
        }
        _context.Causes.Remove(deleteCauses);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<GetCausesDto>> GetCauses()
    {
        return await _context.Causes.Select(x => new GetCausesDto()
        {
            Id = x.Id,
            Header = x.Header,
            Goal = x.Goal,
            Raised = x.Raised,
            Image = x.Image,
            Explanation = x.Explanation,

        }).ToListAsync();
    }

    public async Task<GetCausesDto?> GetCausesById(int id)
    {
        return await _context.Causes.Where(x => x.Id == id).Select(x => new GetCausesDto()
        {
            Id = x.Id,
            Header = x.Header,
            Goal = x.Goal,
            Raised = x.Raised,
            Explanation = x.Explanation,
        }).FirstOrDefaultAsync();
    }

    public async Task<GetCausesDto> UpdateCauses(AddCausesDto causes)
    {
        var updateCauses = await _context.Causes.FirstOrDefaultAsync(x => x.Id == causes.Id);
        if (updateCauses == null)
        {
            return null;
        }
        updateCauses.Header = causes.Header;
        updateCauses.Goal = causes.Goal;
        updateCauses.Raised = causes.Raised;
        updateCauses.Explanation = causes.Explanation;
        await _context.SaveChangesAsync();
        return new GetCausesDto()
        {
            Id = updateCauses.Id,
            Header = updateCauses.Header,            Goal = updateCauses.Goal,
            Raised = updateCauses.Raised,
            Explanation = updateCauses.Explanation,
        };
    }
}
