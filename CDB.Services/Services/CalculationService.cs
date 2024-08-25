using CDB.Application.Dto;
using CDB.Application.Statment;
using CDB.Domain.Entities;
using CDB.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Services.Services
{
    public class CalculationService : ICalculationService
    {
        private const decimal TaxBenefit = 1.08m;
        private const decimal CDI = 0.009m;

        public InvestmentResponse Calculate(InvestmentRequestDto request)
        {
            //Validating Request
            if (request.Months < 1 || request.InitialValue <= 0)
            {
                throw new ArgumentException("Invalid investment parameters.");
            }

            decimal value = request.InitialValue;
            for (int i = 0; i < request.Months; i++)
            {
                value *= 1 + (CDI * TaxBenefit);
            }

            var grossReturn = value;
            var taxRate = TaxRate.GetRate(request.Months);
            var netReturn = grossReturn * (1 - taxRate);

            return new InvestmentResponse
            {
                GrossReturn = grossReturn,
                NetReturn = netReturn
            };
        }
    }
}