using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.DTO;

namespace platformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDto plat)
        {
            var httpClient = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json" 
            );

            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpClient);

            if (response.IsSuccessStatusCode) {
                Console.WriteLine("--> sync post to commandservice is OK");
            }
            else{
                Console.WriteLine("--> Sync Post to commandService was Not OK");
            }

        }
    }
}