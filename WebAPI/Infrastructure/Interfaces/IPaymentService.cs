using System.Threading.Tasks;
using WebAPI.Infrastructure.DTOs.Requests;
using WebAPI.Infrastructure.DTOs.Responses;

namespace WebAPI.Infrastructure.Interfaces
{
    public interface IPaymentService
    {
        Task<Result> Check(CheckDto check);

        Task<Result> SavePayment(PaymentDto payment);
    }
}