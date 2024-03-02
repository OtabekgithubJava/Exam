using System.Linq.Expressions;
using JobBoard.Domain.Entities.DTOs;
using JobBoard.Domain.Entities.Models;
using JobBoard.Domain.Entities.ViewModels;

namespace JobBoard.Application.Services.UserServices;

public interface IUserService
{
    public Task<User> Create(UserDTO userDTO);
    public Task<User> GetByName(string name);
    public Task<User> GetById(int Id);
    public Task<User> GetByEmail(string email);
    public Task<User> GetByLogin(string email);
    public Task<IEnumerable<UserViewModel>> GetAll();
    public Task<bool> Delete(Expression<Func<User, bool>> expression);
    public Task<User> Update(int Id, UserDTO userDTO);
}