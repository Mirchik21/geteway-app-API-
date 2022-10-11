using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Infrastructure.DTOs.Requests;
using WebAPI.Infrastructure.DTOs.Responses;
using WebAPI.Infrastructure.Interfaces;

namespace WebAPI.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<Result> Check(CheckDto check)
        {
            try
            {
                if (!IsNumber(check.Account) || check.Account.Length != 10)
                    return Result.Failure("Недопустимое значение для лицевого счета");

                var clients = await GetClients();

                var result = clients.FirstOrDefault(x => x.ClientId == check.ClientId
                                                      && x.Account == check.Account);

                return Result.Success("Абонент найден");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Возникла непредвиденная ошибка {ex.ToString()}");
            }
        }

        public async Task<Result> SavePayment(PaymentDto payment)
        {
            try
            {
                Guid id = Guid.NewGuid();
                using (FileStream fs = new FileStream($"./Infrastructure/JsonData/{id}.json", FileMode.OpenOrCreate))
                    await JsonSerializer.SerializeAsync(fs, payment);

                return Result.Success($"Успешно сохранено");
            }
            catch (Exception ex)
            {
                return Result.Failure($"Возникли ошибки {ex.ToString()}");
            }
        }

        private async Task<List<CheckDto>> GetClients()
        {
            
                using (FileStream fs = new FileStream($"./Infrastructure/JsonData/Clients.json", FileMode.OpenOrCreate))
                    return await JsonSerializer.DeserializeAsync<List<CheckDto>>(fs);
            
           
        }

        private bool IsNumber(string number)
        {
            return int.TryParse(number, out _);
        }
    }
}