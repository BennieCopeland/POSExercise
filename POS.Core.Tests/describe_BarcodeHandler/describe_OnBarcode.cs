﻿using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Tests.describe_BarcodeHandler
{
    class describe_OnBarcode : _describe_BarcodeHandler
    {
        void when_the_barcode_is_null()
        {
            it["will display an error message"] = () =>
            {
                Dictionary<string, decimal> productList = new Dictionary<string, decimal>();
                BarcodeHandler handler = new BarcodeHandler(productList);

                handler.OnBarcode(null);

                handler.Message.Should().Be("Error");
            };
        }

        void when_the_barcode_is_empty()
        {
            it["will display an error message"] = () =>
            {
                Dictionary<string, decimal> productList = new Dictionary<string, decimal>();
                BarcodeHandler handler = new BarcodeHandler(productList);

                handler.OnBarcode(string.Empty);

                handler.Message.Should().Be("Error");
            };
        }

        void when_a_listed_barcode_has_no_terminator()
        {
            it["will display the item price"] = () =>
            {
                Dictionary<string, decimal> productList = new Dictionary<string, decimal>()
                {
                    {"67890", 10.75m }
                };
                BarcodeHandler handler = new BarcodeHandler(productList);

                handler.OnBarcode("67890");

                handler.Message.Should().Be("$10.75");
            };
        }

        void when_a_listed_barcode_ends_with_a_newline()
        {
            it["will display the item price"] = () =>
            {
                Dictionary<string, decimal> productList = new Dictionary<string, decimal>()
                {
                    {"34567", 3.66m }
                };
                BarcodeHandler handler = new BarcodeHandler(productList);

                handler.OnBarcode("34567\n");

                handler.Message.Should().Be("$3.66");
            };
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
    }
}
