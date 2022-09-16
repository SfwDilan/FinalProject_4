using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{

    public class ValidationAspect : MethodInterception   //ValidationAspect:Bizim Aspect'imiz.
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding:programcı, attrbute'lere yanlış tip yollamasın diye yazıyoruz. yapmasak da çalışır yoksa. 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Gelen validator için (mesela productvalidator) çalışma anında(Activator kodu) instance üretmesini sağlıyoruz. Yani=> ProductValidator pv=new ProductValidator();
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}

