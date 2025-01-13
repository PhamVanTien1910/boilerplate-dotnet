using DotnetBoilerplate.Application.Dtos;
using DotnetBoilerplate.Domain.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBoilerplate.Application.Services.Users
{
    public interface IUserService
    {
        Task<UserDto?> GetMe();
        Task<PaginatedResult<UserDto>> getPaginationUserAsync(int page, int pageSize);
        Task<UserDto> UpdateUserByIdAsysc(UpdateUserDto updateUserDto);
    }
}
