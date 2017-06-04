using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core
{
    public class BarcodeHandler
    {
        public void OnBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                Message = "Error";
            }
        }

        public string Message
        {
            get; private set;
        }
    }
}
