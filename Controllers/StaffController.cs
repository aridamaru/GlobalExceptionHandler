using GEH.Services;
using Microsoft.AspNetCore.Mvc;

namespace GEH.Controllers;

[ApiController]
[Route("[controller]")]
public class StaffController : ControllerBase
{
    private readonly ILogger<StaffController> _logger;
    private readonly IStaffRepository _staffRepository;

    public StaffController(ILogger<StaffController> logger, IStaffRepository staffRepository)
    {
        _logger = logger;
        _staffRepository = staffRepository;
    }

    [HttpGet(nameof(GetAllEmployees))]
    public IActionResult GetAllEmployees()
    {
        var employees = _staffRepository.GetAllEmployees();
        return Ok(employees);
    }


    [HttpGet(nameof(LoadIrakli))]
    public IActionResult LoadIrakli()
    {
        var irakli = _staffRepository.LoadIrakli();
        return Ok(irakli);
    }
}