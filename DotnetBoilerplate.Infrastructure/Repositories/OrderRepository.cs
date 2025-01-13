using AutoMapper;
using DotnetBoilerplate.Application.Repositories;
using DotnetBoilerplate.Domain.Entities;
using DotnetBoilerplate.Infrastructure.Migrations.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBoilerplate.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepositoty
    {
        public OrderRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
    }
}
