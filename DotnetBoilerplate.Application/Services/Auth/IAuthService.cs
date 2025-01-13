using DotnetBoilerplate.Application.Dtos;
using DotnetBoilerplate.Domain.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBoilerplate.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegistrationDto registrationDto);
        Task<TokenPayLoad> LoginAsync(TokenObtainPairDto tokenObtainPairDto);
    }
}
