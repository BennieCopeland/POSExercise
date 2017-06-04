using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POS.Core
{
    public class BarcodeHandler
    {
        private readonly IDictionary<string, decimal> productList;

        public BarcodeHandler(IDictionary<string, decimal> productList)
        {
            this.productList = productList;
        }

        public void OnBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                Message = "Error";
                return;
            }

            barcode = barcode.TrimEnd(new char[] { '\n', '\r' });

            if(productList.TryGetValue(barcode, out decimal price))
            {
                Message = $"${price.ToString()}";
            }
            else
            {
                Message = "Not Found";
            }
        }

        public string Message
        {
            get; private set;
        }
    }
}
