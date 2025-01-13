using DotnetBoilerplate.Application.Dtos;
using DotnetBoilerplate.Application.Services.Auth;
using DotnetBoilerplate.Domain.Payloads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBoilerplate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] TokenObtainPairDto tokenObtainPairDto)
        {
            var tokenPayload = await _authService.LoginAsync(tokenObtainPairDto);
            return Ok(tokenPayload);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationDto payload)
        {
            var userDto = await _authService.RegisterAsync(payload);
            return StatusCode(201, userDto);
        }
    }
}
