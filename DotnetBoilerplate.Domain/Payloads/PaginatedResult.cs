using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBoilerplate.Domain.Payloads
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(int total, IEnumerable<T>? data)
        {
            Total = total;
            Data = data;
        }

        public int Total { get; set; }
        public IEnumerable<T>? Data { get; set; }
    }
}