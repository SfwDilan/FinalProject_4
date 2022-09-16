using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        //Burda hangi nesne için iş kuralı yazıcaksak Constructor kullanırız.Constructor içine yazaırz
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
           
        }

        //Mesela Ürün isminin A ile başlamsı zorunlu olsun istiyorum 
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
