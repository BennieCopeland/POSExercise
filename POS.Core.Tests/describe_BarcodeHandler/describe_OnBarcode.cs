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
            it["will display the item price"] = () =>
            {
                Dictionary<string, decimal> productList = new Dictionary<string, decimal>()
                {
                    {"134679", 5.48m }
                };
                BarcodeHandler handler = new BarcodeHandler(productList);

                handler.OnBarcode("134679\r");

                handler.Message.Should().Be("$5.48");
            };
        }

        void when_a_listed_barcode_ends_with_a_carriage_return_and_a_newline()
        {
            it["will display the item price"] = () =>
            {
                Dictionary<string, decimal> productList = new Dictionary<string, decimal>()
                {
                    {"976431", 8.54m }
                };
                BarcodeHandler handler = new BarcodeHandler(productList);

                handler.OnBarcode("976431\r\n");

                handler.Message.Should().Be("$8.54");
            };
        }

        void when_a_listed_barcode_ends_with_multiple_carriage_returns_and_a_newlines()
        {
            it["will display the item price"] = () =>
            {
                Dictionary<string, decimal> productList = new Dictionary<string, decimal>()
                {
                    {"852465", 6.45m }
                };
                BarcodeHandler handler = new BarcodeHandler(productList);

                handler.OnBarcode("852465\r\n\r\n\r\n\n\n\n\r\r\r\r");

                handler.Message.Should().Be("$6.45");
            };
        }
    }
}
