using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Server.Interfaces;
using Server.Models;

namespace Server.Interface
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private readonly HttpClient _httpClient;

        public ExchangeRatesService(HttpClient httpclient)
        {
            _httpClient = httpclient;
        }
        public async Task<Currencies> GetCurrencyCodes()
        {
            return await Task.Run(() => GetLastestCurrencyCodes());
        }

        public async Task<Currencies> GetLastestCurrencyCodes()
        {
            var apiData = await JsonSerializer.DeserializeAsync<Currencies>
                (await _httpClient.GetStreamAsync($"https://blockchain.info/ticker"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return apiData;
        }

    }
}
