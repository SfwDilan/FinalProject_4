using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool //Bu tarz araçlar static oluşturulur ki sürekli new'lenmesin
    {
        public static void Validate(IValidator validator,object entity) //burada entity,DTO hepsini kullaabileyim diye object tipi verildi
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }




            /*
             * ProductManager içerisinde kullandığımız Bu kodu burada evrensel hale getiricez.Çünkü heryerde kullanılacak
             * 
            var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            */
        }
    }
}
