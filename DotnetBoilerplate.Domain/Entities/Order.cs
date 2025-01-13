using dotnet_boilerplate.Domain.Common;
using DotnetBoilerplate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBoilerplate.Domain.Entities
{
    public class Order : IntergerIdTrackable
    {
        public string CustomerName { get; set; } = null!;
        public string CustomerPhone { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = null!;
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.WaitingForPayment;
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = null!;
        public string? PaymentOrderId { get; set; } = null;
        public int UserId { get; set; }

    }
}
