using System;

namespace WebAPI.Infrastructure.DTOs.Requests
{
    public record PaymentDto(int ClientId, string Account, decimal Amount, DateTime Date);
}