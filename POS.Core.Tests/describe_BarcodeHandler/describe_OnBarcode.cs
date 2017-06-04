using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Tests.describe_BarcodeHandler
{
    class describe_OnBarcode : _describe_BarcodeHandler
    {
        Dictionary<string, decimal> productList = null;
        BarcodeHandler handler = null;
        string barcode = null;

        void before_each()
        {
            productList = new Dictionary<string, decimal>();
            handler = new BarcodeHandler(productList);
        }

        void act_each()
        {
            handler.OnBarcode(barcode);
        }

        void when_the_barcode_is_null()
        {
            beforeEach = () => barcode = null;

            it["will display an error message"] = () => handler.Message.Should().Be("Error");
        }

        void when_the_barcode_is_empty()
        {
            beforeEach = () => barcode = string.Empty;

            it["will display an error message"] = () => handler.Message.Should().Be("Error");
        }

        void when_a_listed_barcode_has_no_terminator()
        {
            beforeEach = () =>
            {
                productList.Add("67890", 10.75m);
                barcode = "67890";
            };

            it["will display the item price"] = () => handler.Message.Should().Be("$10.75");
        }

        void when_a_listed_barcode_ends_with_a_newline()
        {
            beforeEach = () =>
            {
                productList.Add("34567", 3.66m);
                barcode = "34567\n";
            };

            it["will display the item price"] = () => handler.Message.Should().Be("$3.66");
        }

        void when_a_listed_barcode_ends_with_a_carriage_return()
        {
            beforeEach = () =>
            {
                productList.Add("134679", 5.48m);
                barcode = "134679\r";
            };

            it["will display the item price"] = () => handler.Message.Should().Be("$5.48");
        }

        void when_a_listed_barcode_ends_with_a_carriage_return_and_a_newline()
        {
            beforeEach = () =>
            {
                productList.Add("976431", 8.54m);
                barcode = "976431\r\n";
            };

            it["will display the item price"] = () => handler.Message.Should().Be("$8.54");
        }

        void when_a_listed_barcode_ends_with_multiple_carriage_returns_and_a_newlines()
        {
            beforeEach = () =>
            {
                productList.Add("852465", 6.45m);
                barcode = "852465\r\n\r\n\r\n\n\n\n\r\r\r\r";
            };

            it["will display the item price"] = () => handler.Message.Should().Be("$6.45");
        }

        void when_a_barcode_is_not_listed_in_the_products()
        {
            beforeEach = () =>
            {
                barcode = "235694\r\n";
            };

            it["will display Not Found"] = () => handler.Message.Should().Be("Not Found");
        }
    }
}
