using CDB.Application.Dto;
using CDB.Application.Statment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Services.Interfaces
{
    public interface ICalculationService
    {
        InvestmentResponse Calculate(InvestmentRequestDto request);
    }
}
