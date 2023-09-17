using FluentValidation;
using System.Data;

namespace Task1.Models.FluentValidators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("This field is required.");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("This field is required.");
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("This field is required.");
        }
    }
}
