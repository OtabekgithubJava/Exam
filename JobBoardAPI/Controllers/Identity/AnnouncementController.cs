using JobBoard.Application.Services.UserServices;
using JobBoard.Domain.Entities.DTOs;
using JobBoard.Domain.Entities.Models;
using JobBoard.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardAPI.Controllers.Identity;

public class AnnouncementController : Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            var result = await _userService.GetAll();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> CreateUser(UserDTO model)
        {
            var result = await _userService.Create(model);

            return Ok(result);
        }
    }
}