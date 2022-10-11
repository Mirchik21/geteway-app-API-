using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Infrastructure.DTOs.Requests;
using WebAPI.Infrastructure.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        /// <summary>
        /// Action for check user
        /// </summary>
        /// <param name="check">CheckDto</param>
        /// <returns>Return message if success</returns>
        [HttpPost("check")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Check([FromBody] CheckDto check)
        {
            return Ok(await _paymentService.Check(check));
        }

        /// <summary>
        /// Action save payment
        /// </summary>
        /// <param name="payment">PaymentDto</param>
        /// <returns>Return message if success</returns>
        [HttpPost("payment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Check([FromBody] PaymentDto payment)
        {
            return Ok(await _paymentService.SavePayment(payment));
        }
    }
}