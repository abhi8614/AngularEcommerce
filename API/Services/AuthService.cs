using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace API.Services
{
    public class AuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Task<Response<bool>> ChangePassword(int userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public string GetUserEmail()
        {
            throw new NotImplementedException();
        }

        public int GetUserId()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserDto>> Login(LogingDto logingDto)
        {
            var response = new Response<UserDto>();
            var user = await _userManager.FindByEmailAsync(logingDto.UserName);
            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, logingDto.Password, false);
            if (result.Succeeded)
            {
                response.Data = CreatUserObject(user);
                response.Success = true;
                response.Message = String.Empty;
            }
            else
            {
                response.Success = false;
                response.Message = "Unauthorized";
            }
            return response;

        }
        private UserDto CreatUserObject(AppUser user)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Username = user.UserName,
                ImageUrl = user.ImageUrl,
                Token = _tokenService.CreateToken(user)
            };
        }

        public Task<Response<int>> Register(RegisterDto registerDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
