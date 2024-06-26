﻿using Buisness.DTOs.Command.Customer;
using FluentValidation;

namespace Buisness.Buisness.FluentValidations.Customer
{
    public class CustomerUpdateDTOValidation : AbstractValidator<CustomerRequestUpdateDTO>
    {
        public CustomerUpdateDTOValidation()
        {
            RuleFor(x => x.oldPIN)
            .NotEmpty().WithMessage("Validation Error: The oldPIN field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The oldPIN field must be guid");

            RuleFor(x => x.newPIN)
           .NotEmpty().WithMessage("Validation Error: The newPIN field can not be null")
           .Must(BeAnGuid).WithMessage("Validation Error: The newPIN field must be guid");
        }
        private bool BeAnGuid(Guid time)
        {
            return time.GetType() == typeof(Guid);
        }
    }
}
