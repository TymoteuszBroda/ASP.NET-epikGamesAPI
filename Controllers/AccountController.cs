using epikGamesAPI.Data;
using epikGamesAPI.DTOs;
using epikGamesAPI.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace epikGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == loginDTO.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username");
            }
            if(loginDTO.Password != user.Password)
            {
                return Unauthorized("Invalid password");
            }
            return new UserDTO
            {
                Username = loginDTO.Username,
                Password = loginDTO.Password
            };


        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if(await UserExists(registerDTO.Username))
            {
                return BadRequest("User of that name already exists");
            }
            var user = new User
            {
                Login = registerDTO.Username,
                Password = registerDTO.password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                Username = registerDTO.Username,
                Password = registerDTO.password
            };
        }


        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.Login.ToLower() == username.ToLower());
        }
    }


}

