using System.Net;
using System.Net.Mail;
using JobBoard.Domain.Entities.Models;
using Microsoft.Extensions.Configuration;

namespace JobBoard.Application.Services.EmailServices;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(Email model)
    {
        var emailSettings = _configuration.GetSection("EmailSettings");

        string path = @"/Users/otabek_coding/C# codes/RiderProjects/Exam/JobBoard.Application/Additionals/Code.html";
        
        using(var stream = new StreamReader(path))
        {
            model.Body = await stream.ReadToEndAsync();
        }
        
        var mailMessage = new MailMessage
        {
            From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
            Subject = model.Subject,
            Body = model.Body,
            IsBodyHtml = true
        };
        mailMessage.To.Add(model.Receiver);

        using var smtpClient = new SmtpClient(emailSettings["EmailServer"], int.Parse(emailSettings["MailPort"]))
        {
            Port = Convert.ToInt32(emailSettings["MailPort"]),
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
            EnableSsl = true,
        };
        
        await smtpClient.SendMailAsync(mailMessage);
    }

    public async Task<bool> CheckEmailAsync(string code)
    {
        return code == "CR7";
    }

    public async Task SetPassword(User user)
    {
        string filePath = @"/Users/otabek_coding/C# codes/RiderProjects/Exam/JobBoard.Application/Additionals/RegisteredUsers.txt";

        string userEntry = $"{user.Email},{user.Password}\n";

        string[] userEntries = await File.ReadAllLinesAsync(filePath);

        foreach (var entry in userEntries)
        {
            var parts = entry.Split(',');

            if (parts.Length == 2 && parts[0] == user.Email)
            {
                return;
            }
        }
        await File.AppendAllTextAsync(filePath, userEntry);

    }

    public async Task<bool> IsUserRegistered(string email)
    {
        string filePath = @"/Users/otabek_coding/C# codes/RiderProjects/Exam/JobBoard.Application/Additionals/RegisteredUsers.txt";

        string[] userEntries = await File.ReadAllLinesAsync(filePath);

        foreach (var entry in userEntries)
        {
            var parts = entry.Split(',');

            if (parts.Length == 2 && parts[0] == email)
            {
                return true;
            }
        }
        return false;
    }

    public async Task<bool> VerifyCredentials(User user) // for login as well
    {
        string filePath = @"/Users/otabek_coding/C# codes/RiderProjects/Exam/JobBoard.Application/Additionals/RegisteredUsers.txt";
    
        string[] userEntries = await File.ReadAllLinesAsync(filePath);
    
        foreach (var entry in userEntries)
        {
            var parts = entry.Split(',');
    
            if (parts.Length == 2 && parts[0] == user.Email && parts[1] == user.Password)
            {
                return true;
            }
        }
        return false;
    }
}