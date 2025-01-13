using AutoMapper;
using dotnet_boilerplate.Domain.Entities;
using DotnetBoilerplate.Application.Repositories;
using DotnetBoilerplate.Infrastructure.Migrations.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBoilerplate.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User> , IUserRepository
    {
        public UserRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper) { }
    }
}
