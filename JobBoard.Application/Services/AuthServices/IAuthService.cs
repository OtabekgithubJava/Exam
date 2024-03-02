using JobBoard.Domain.Entities.DTOs;

namespace JobBoard.Application.Services.AuthServices;

public interface IAuthService
{
    public Task<ResponseLogin> GenerateToken(RequestLogin user);
}