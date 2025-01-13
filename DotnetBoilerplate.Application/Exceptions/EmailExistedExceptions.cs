using DotnetBoilerplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DotnetBoilerplate.Application.Exceptions
{
    public class EmailExistedExceptions : CustomExceptions
    {
        public EmailExistedExceptions() : base(StatusCodes.Status409Conflict, ErrorCodeEnums.ExistedEmail, "Email already exists")
        {
        }
    }
}
