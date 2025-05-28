using cw09.models.DTO;
using cw09.Services;
namespace cw09.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class TemplateController(IDbService dbService) : ControllerBase

{
    [HttpPost("prescription")]
    public async Task<IActionResult> CreatePrescription(CreatePrescriptionDto dto)
    {
        try
        {
            await dbService.CreatePrescription(dto);
            return Ok("Prescription created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("patient/{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        try
        {
            var result = await dbService.GetPatient(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}