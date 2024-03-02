namespace JobBoard.Domain.Entities.Models;

public class Email
{
    public string? Receiver { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}