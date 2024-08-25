using CDB.Application.Dto;
using FluentValidation;

namespace CDB.Api.Validators;

public class InvestmentRequestValidator : AbstractValidator<InvestmentRequestDto>
{
    public InvestmentRequestValidator()
    {
        RuleFor(x => x.InitialValue).GreaterThan(0).WithMessage("Initial value must be positive.");
        RuleFor(x => x.Months).GreaterThan(1).WithMessage("Months must be greater than 1.");
    }
}