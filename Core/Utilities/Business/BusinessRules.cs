using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //params: IResult tipinde istediğin kadar metot gönderebilirisn.(CheckCategory(int categoryId),CheckProduct(int productId)....gibi)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        } 

    }
}
