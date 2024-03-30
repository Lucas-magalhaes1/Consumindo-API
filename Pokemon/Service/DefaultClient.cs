using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    public class DefaultClient
    {
        private readonly HttpClient _httpClient;

        public DefaultClient(string baseUri)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUri);
        }

        public async Task<HttpResponseMessage> GetPokemonAsync(string id)
        {
            return await _httpClient.GetAsync($"pokemon/{id}");
        }

        // Implementar outros métodos para as demais operações HTTP (POST, PUT, DELETE, etc.)
    }
}
