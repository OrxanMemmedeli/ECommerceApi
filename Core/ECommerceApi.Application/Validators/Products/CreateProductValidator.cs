using ECommerceApi.Application.ViewModels;
using ECommerceApi.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Ad boş ola bilməz")
                .NotNull().WithMessage("Ad boş ola bilməz")
                .MaximumLength(150).WithMessage("Ad maksimum 150 simvol ola bilər")
                .MinimumLength(2).WithMessage("Ad minmum 2 simvol ola bilər");

            RuleFor(p => p.Stock)
                .NotEmpty().WithMessage("Stock boş ola bilməz")
                .NotNull().WithMessage("Stock boş ola bilməz")
                .Must(s => s >= 0).WithMessage("Stock 0 və ya 0 dan böyük olmalıdır");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Price boş ola bilməz")
                .NotNull().WithMessage("Price boş ola bilməz")
                .Must(s => s >= 0).WithMessage("Price 0 və ya 0 dan böyük olmalıdır");
        }
    }
}
