using FluentValidation;
using FlexiBooks.DTOs;

namespace FlexiBooks.Validators
{
    public class InvoiceCreateDtoValidator : AbstractValidator<InvoiceCreateDto>
    {
        public InvoiceCreateDtoValidator()
        {
            RuleFor(x => x.ClientId).GreaterThan(0);
            RuleFor(x => x.DateIssued).NotEmpty();

            RuleForEach(x => x.Items).SetValidator(new InvoiceItemDtoValidator());
        }
    }

    public class InvoiceItemDtoValidator : AbstractValidator<InvoiceItemDto>
    {
        public InvoiceItemDtoValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
            RuleFor(x => x.UnitPrice).GreaterThan(0);
        }
    }
}
