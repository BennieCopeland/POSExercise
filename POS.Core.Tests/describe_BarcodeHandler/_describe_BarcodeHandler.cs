using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Tests.describe_BarcodeHandler
{
    class _describe_BarcodeHandler : nspec
    {
        void describe_Constructing()
        {
            context["when the products list is null"] = () =>
            {
                it["will throw an ArgumentNullException"] = expect<ArgumentNullException>(() =>
                {
                    Dictionary<string, decimal> productList = null;

                    new BarcodeHandler(productList);
                });
            };
        }
    }
}
