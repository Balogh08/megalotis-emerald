﻿using ASP.NET_Core_Webapp.IntegrationTests.Fixtures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ASP.NET_Core_Webapp.IntegrationTests.Scenarios
{
    [Collection("BaseCollection")]
    public class PitchTest
    {
        private readonly TestContext testContext;

        public PitchTest(TestContext testContext)
        {
            this.testContext = testContext;
        }

        [Fact]
        public async Task Pitch_GetPitches_Return200()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/pitches");
            var response = await testContext.Client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("/api/pitches")]
        public async Task Pitch_GetPitchesInLineData_Return200(string url)
        {
            var request = url;
            var response = await testContext.Client.GetAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Pitch_ContentTypeJson_Success()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/pitches");
            var response = await testContext.Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Pitch_UserNotNull_NotEqual()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/pitches");
            var response = await testContext.Client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            Assert.NotEqual("{\"myPitches\":null,\"pitchesToReview\":null}", response.Content.ReadAsStringAsync().Result);
        }
    }
}
