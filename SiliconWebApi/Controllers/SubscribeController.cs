using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SiliconWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController(ApiDBContext context) : ControllerBase
{

    private readonly ApiDBContext _context = context;

    [HttpPost]
    public async Task<IActionResult> Subscribe(string email)
    {
        if (ModelState.IsValid)
        {
            if (await _context.Subscriptions.AnyAsync(x => x.Email == email))
                return Conflict("Email already subscribed");
            
            _context.Add(new SubscriberEntity { Email = email });
            await _context.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        if (ModelState.IsValid)
        {
            var subscriber = await _context.Subscriptions.FirstOrDefaultAsync(x => x.Email == email);
            if (subscriber == null)
                return NotFound("Email not found");

            _context.Remove(subscriber);
            await _context.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }
}
