using MediatorApi.Services.Messages;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorApi.Services.Handlers
{
    public class ChangeAddressHandler : INotificationHandler<ChangeAddressMessage>
    {
        const string firebaseUrl = "-rtdb.firebaseio.com";
        private readonly IConfiguration _configuration;
        public ChangeAddressHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task Handle(ChangeAddressMessage notification, CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var url = $"https://{_configuration["fbproject"]}{firebaseUrl}/addresses/{notification.Id}";
            var request = new HttpRequestMessage(HttpMethod.Post, $"{url}");


            var address = new JObject
            {
                { "Date", DateTime.Now },
                { "ClientId", notification.ClientId },
                { "Address", notification.Address },
                { "Name", notification.Name },
                { "City", notification.City },
            };


            var json = JsonConvert.SerializeObject(address);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            request.Content = stringContent;


            var response = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).Result;


            return Task.CompletedTask;
        }
    }
}
