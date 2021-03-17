using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebShop.Web.Models;
using Xunit;

namespace WebShop.Web.IntegrationTests
{
    public class TestFixture : IDisposable
    {
        private readonly TestServer _server;

        public TestFixture()
        {
            var builder = new WebHostBuilder()
                .UseStartup<WebShop.Web.Startup>()
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                    configBuilder.SetBasePath(Path.Combine(
                        Directory.GetCurrentDirectory(), "..\\..\\..\\..\\WebShop.Web"));

                    configBuilder.AddJsonFile("appsettings.json");
                });
            _server = new TestServer(builder);

            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost:5000");
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }



    }

    public class TransferTest : IClassFixture<TestFixture>
    {
        private readonly HttpClient _client;

        public TransferTest(TestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task DoTransfer()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/transfer");
            var transfer = new Transfer(new Account(100, "ercan"), new Account(100, "abdurrahman"), 25);
            request.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(transfer), Encoding.UTF8, "application/json");
            var response = await _client.SendAsync(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
