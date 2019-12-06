﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using header;
using header.Models.V100;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    [IgnoreOnTestServer(TestServerVersion.V2, "Too many missing or too strict recordings")]
    public class HeaderTests : TestServerTestBase
    {
        public HeaderTests(TestServerVersion version) : base(version, "header") { }

        [Test]
        public Task HeaderParameterExistingKey() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamExistingKeyAsync(pipeline, "overwrite", host: host));

        [Test]
        public Task HeaderResponseExistingKey() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseExistingKeyAsync(pipeline, host: host));

        [Test]
        [Ignore("Azure.Core doesn't send Content-Type without having some content")]
        public Task HeaderParameterProtectedKey() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamProtectedKeyAsync(pipeline, "text/html", host: host));

        [Test]
        public Task HeaderResponseProtectedKey() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseProtectedKeyAsync(pipeline, host: host));

        [Test]
        public Task HeaderParameterIntegerNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamIntegerAsync(pipeline, scenario: "negative", -2, host: host));

        [Test]
        public Task HeaderParameterIntegerPositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamIntegerAsync(pipeline, scenario: "positive", 1, host: host));

        [Test]
        public Task HeaderResponseIntegerPositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseIntegerAsync(pipeline, scenario: "positive", host: host));

        [Test]
        public Task HeaderResponseIntegerNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseIntegerAsync(pipeline, scenario: "negative", host: host));

        [Test]
        public Task HeaderParameterLongPositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamLongAsync(pipeline, scenario: "positive", 105, host: host));

        [Test]
        public Task HeaderParameterLongNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamLongAsync(pipeline, scenario: "negative", -2, host: host));

        [Test]
        public Task HeaderResponseLongPositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseLongAsync(pipeline, scenario: "positive", host: host));

        [Test]
        public Task HeaderResponseLongNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseLongAsync(pipeline, scenario: "negative", host: host));

        [Test]
        public Task HeaderParameterFloatPositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamFloatAsync(pipeline, scenario: "positive", 0.07, host: host));

        [Test]
        public Task HeaderParameterFloatNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamFloatAsync(pipeline, scenario: "negative", -3, host: host));

        [Test]
        public Task HeaderResponseFloatPositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseFloatAsync(pipeline, scenario: "positive", host: host));

        [Test]
        public Task HeaderResponseFloatNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseFloatAsync(pipeline, scenario: "negative", host: host));

        [Test]
        public Task HeaderParameterDoublePositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDoubleAsync(pipeline, scenario: "positive", 7e120, host: host));

        [Test]
        public Task HeaderParameterDoubleNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDoubleAsync(pipeline, scenario: "negative", -3.0, host: host));

        [Test]
        public Task HeaderResponseDoublePositive() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseDoubleAsync(pipeline, scenario: "positive", host: host));

        [Test]
        public Task HeaderResponseDoubleNegative() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseDoubleAsync(pipeline, scenario: "negative", host: host));

        [Test]
        [Ignore("bool.ToString() has wrong casing")]
        public Task HeaderParameterBoolFalse() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamBoolAsync(pipeline, scenario: "false", false, host: host));

        [Test]
        [Ignore("bool.ToString() has wrong casing")]
        public Task HeaderParameterBoolTrue() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamBoolAsync(pipeline, scenario: "true", true, host: host));

        [Test]
        public Task HeaderResponseBoolTrue() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseBoolAsync(pipeline, scenario: "true", host: host));

        [Test]
        public Task HeaderResponseBoolFalse() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseBoolAsync(pipeline, scenario: "false", host: host));

        [Test]
        public Task HeaderParameterStringValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamStringAsync(pipeline, scenario: "valid", "The quick brown fox jumps over the lazy dog", host: host));

        [Test]
        public Task HeaderParameterStringEmpty() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamStringAsync(pipeline, scenario: "empty", "", host: host));

        [Test]
        public Task HeaderParameterStringNull() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamStringAsync(pipeline, scenario: "null", null, host: host));

        [Test]
        public Task HeaderResponseStringValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseStringAsync(pipeline, scenario: "valid", host: host));

        [Test]
        public Task HeaderResponseStringNull() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseStringAsync(pipeline, scenario: "null", host: host));

        [Test]
        public Task HeaderResponseStringEmpty() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseStringAsync(pipeline, scenario: "empty", host: host));

        [Test]
        [Ignore("wrong date format")]
        public Task HeaderParameterDateValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDateAsync(pipeline, scenario: "valid", new DateTime(2010, 1, 1), host: host));

        [Test]
        [Ignore("wrong date format")]
        public Task HeaderParameterDateMin() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDateAsync(pipeline, scenario: "min", new DateTime(0001, 1, 1), host: host));

        [Test]
        public Task HeaderResponseDateValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseDateAsync(pipeline, scenario: "valid", host: host));

        [Test]
        public Task HeaderResponseDateMin() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseDateAsync(pipeline, scenario: "min", host: host));

        [Test]
        [Ignore("wrong date format")]
        public Task HeaderParameterDateTimeValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDatetimeAsync(pipeline, scenario: "valid", new DateTime(2010, 1, 1, 12, 34, 56), host: host));

        [Test]
        [Ignore("wrong date format")]
        public Task HeaderParameterDateTimeMin() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDatetimeAsync(pipeline, scenario: "valid", new DateTime(2010, 1, 1, 12, 34, 56), host: host));

        [Test]
        public Task HeaderResponseDateTimeValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseDatetimeAsync(pipeline, scenario: "valid", host: host));

        [Test]
        public Task HeaderResponseDateTimeMin() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseDatetimeAsync(pipeline, scenario: "min", host: host));

        [Test]
        [Ignore("wrong date format")]
        public Task HeaderParameterDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDatetimeRfc1123Async(pipeline, scenario: "valid", new DateTime(2010, 1, 1, 12, 34, 56), host: host));

        [Test]
        [Ignore("wrong date format")]
        public Task HeaderParameterDateTimeRfc1123Min() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDatetimeRfc1123Async(pipeline, scenario: "min", new DateTime(2010, 1, 1, 12, 34, 56), host: host));

        [Test]
        public Task HeaderResponseDateTimeRfc1123Valid() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseDatetimeRfc1123Async(pipeline, scenario: "valid", host: host));

        [Test]
        public Task HeaderResponseDateTimeRfc1123Min() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseDatetimeRfc1123Async(pipeline, scenario: "min", host: host));

        [Test]
        [Ignore("wrong duration format")]
        public Task HeaderParameterDurationValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamDurationAsync(pipeline, scenario: "valid", TimeSpan.FromSeconds(1), host: host));

        [Test]
        public Task HeaderResponseDurationValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseDurationAsync(pipeline, scenario: "valid", host: host));

        [Test]
        [Ignore("Byte[] not supported")]
        public Task HeaderParameterBytesValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamByteAsync(pipeline, scenario: "valid", new byte[1], host: host));

        [Test]
        public Task HeaderResponseBytesValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseByteAsync(pipeline, scenario: "valid", host: host));

        [Test]
        public Task HeaderParameterEnumValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamEnumAsync(pipeline, scenario: "valid", GreyscaleColors.GREY, host: host));

        [Test]
        public Task HeaderParameterEnumNull() => TestStatus(async (host, pipeline) => await HeaderOperations.ParamEnumAsync(pipeline, scenario: "null", null, host: host));

        [Test]
        public Task HeaderResponseEnumValid() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseEnumAsync(pipeline, scenario: "valid", host: host));

        [Test]
        public Task HeaderResponseEnumNull() => TestStatus(async (host, pipeline) => await HeaderOperations.ResponseEnumAsync(pipeline, scenario: "null", host: host));

        [Test]
        [Ignore("Azure.Core doesn't provide the feature yet")]
        public Task CustomHeaderInRequest() => TestStatus(async (host, pipeline) => await HeaderOperations.CustomRequestIdAsync(pipeline, host: host));
    }
}
