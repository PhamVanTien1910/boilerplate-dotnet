using AutoMapper;
using BCrypt.Net;
using dotnet_boilerplate.Domain.Entities;
using DotnetBoilerplate.Application.Dtos;
using DotnetBoilerplate.Application.Exceptions;
using DotnetBoilerplate.Application.Repositories;
using DotnetBoilerplate.Domain.Enums;
using DotnetBoilerplate.Domain.Payloads;
using DotnetBoilerplate.Domain.Specifications;
using DotnetBoilerplate.Domain.Specifications.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DotnetBoilerplate.Application.Utils;
using Microsoft.Extensions.Configuration;

namespace DotnetBoilerplate.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<TokenPayLoad> LoginAsync(TokenObtainPairDto tokenObtainPairDto)
        {
            var user = await _userRepository.FristOrDefaultAsync(new UserEmailSpecification(tokenObtainPairDto.Email!));
            if (user == null || !BCrypt.Net.BCrypt.Verify(tokenObtainPairDto.Password, user.Password)) 
            {
                throw new CustomExceptions(StatusCodes.Status401Unauthorized, ErrorCodeEnums.IncorrectEmailOrPassword, "Incorrect Email Or Password");
            }
            var tokenPayload = JwtUtil.GennerateAccessToken(user, _configuration);
            return tokenPayload;
        }

        public async Task<UserDto> RegisterAsync(RegistrationDto registrationDto)
        {
            if (await _userRepository.ExistsAsync(new UserEmailSpecification(registrationDto.Email!))) 
            {
                throw new EmailExistedExceptions();
            }
            var user = _mapper.Map<User>(registrationDto);
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;
            user.IsActive = true;
            user.IsSuperUser = false;
            user.IsStaff = false;
            user.RoleId = (int)RoleEnums.Member;
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }
    }
}
