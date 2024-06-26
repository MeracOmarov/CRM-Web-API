﻿using Domen.DTOs.CommandDTOs.CustomerDTOs;
using FluentValidation;

namespace Buisness.Buisness.FluentValidations.Customer
{
    public class CustomerRemoveDTOValidation : AbstractValidator<CustomerRequestDeleteDTO>
    {
        public CustomerRemoveDTOValidation()
        {
            RuleFor(x => x.PIN)
            .NotEmpty().WithMessage("Validation Error: The PIN field can not be null")
            .Must(BeAnGuid).WithMessage("Validation Error: The PIN field must be guid");
        }

        private bool BeAnGuid(Guid guid)
        {
            return guid.GetType() == typeof(Guid);
        }
    }
}
