using Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SiliconWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(ApiDBContext context) : ControllerBase
{
    private readonly ApiDBContext _context = context;


    [HttpGet]
    public async Task<IActionResult> GetAllCoursesAsync()
    {
        var courses = await _context.Courses.ToListAsync();
        return Ok(courses);
    }
}
