using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers;
[Area("Admin")]
public class CausesController : Controller
{
    private readonly ICausesServices _causesService;

    public CausesController(ICausesServices causesService)
    {
        _causesService = causesService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _causesService.GetCauses());
    }

    public IActionResult Add()
    {
        return View(new AddCausesDto());
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddCausesDto causes)
    {
        if (ModelState.IsValid)
        {
            await _causesService.AddCauses(causes);
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update(int id)
    {
        var causes = await _causesService.GetCausesById(id);
        return View(new AddCausesDto()
        {
            Id = causes.Id,
            Header = causes.Header,
            Goal = causes.Goal,
            Raised = causes.Raised,
            Explanation = causes.Explanation,
        });
    }

    [HttpPost]
    public async Task<IActionResult> Update(AddCausesDto causes)
    {
        if (ModelState.IsValid)
        {
            await _causesService.UpdateCauses(causes);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _causesService.DeleteCauses(id);
        return RedirectToAction("Index");
    }
}
