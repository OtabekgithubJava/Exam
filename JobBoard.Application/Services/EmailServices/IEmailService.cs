using JobBoard.Domain.Entities.Models;

namespace JobBoard.Application.Services.EmailServices;

public interface IEmailService
{
    Task SendEmailAsync(Email model);
    Task<bool> CheckEmailAsync(string code);
    Task SetPassword(User user);
    Task<bool> IsUserRegistered(string email);
    Task<bool> VerifyCredentials(User user);
}