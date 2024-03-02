using JobBoard.Application.Services.EmailServices;
using JobBoard.Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardAPI.Controllers.EmailControllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : Controller
{

    private readonly IEmailService _emailService;

    public LoginController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        bool isValidCredentials = await _emailService.VerifyCredentials(user);
    
        if (isValidCredentials)
        {
            return Ok("Login successful");
        }
        else
        {
            return Ok("Invalid credentials\tCreate an account");
        }
    }
}