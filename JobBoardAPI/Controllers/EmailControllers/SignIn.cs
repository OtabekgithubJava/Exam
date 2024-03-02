using JobBoard.Application.Services.EmailServices;
using JobBoard.Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardAPI.Controllers.EmailControllers;

[ApiController]
[Route("api/[controller]")]
public class CodeController : Controller
{

    private readonly IEmailService _emailService;

    public CodeController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail([FromBody] Email model)
    {
        await _emailService.SendEmailAsync(model);

        return Ok("Email Sent Successfully");
    }


    [HttpPost("check")]
    public async Task<IActionResult> CheckCode([FromBody] string code)
    {
        bool isCodeCorrect = await _emailService.CheckEmailAsync(code);

        if (isCodeCorrect)
        {
            return Ok("Code is correct");
        }
        else
        {
            return Ok("Incorrect code");
        }
    }


    [HttpPost("set-password")]
    public async Task<IActionResult> SetPassword([FromBody] User user)
    {
        await _emailService.SetPassword(user);

        if (user.IsRegistered)
        {
            return Ok("Already Registered");
        }
        return Ok("Password set successfully");
    }
}    