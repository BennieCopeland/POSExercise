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
        void when_the_string_is_null()
        {
            it["will display an error message"] = () =>
            {
                BarcodeHandler handler = new BarcodeHandler();

                handler.OnBarcode(null);

                handler.Message.Should().Be("Error");
            };
        }
    }
}
