using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public static class HttpContentExtensions
    {
        public static async Task<Pokemon> ReadAsPokemonAsync(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            var pokemon = JsonSerializer.Deserialize<Pokemon>(json);
            if (pokemon != null)
            {
                pokemon.Types = new List<PokemonType>();
                var jsonObject = JsonDocument.Parse(json).RootElement;
                var types = jsonObject.GetProperty("types");
                foreach (var type in types.EnumerateArray())
                {
                    var typeName = type.GetProperty("type").GetProperty("name").GetString();
                    pokemon.Types.Add(new PokemonType { Name = typeName });
                }
            }
            return pokemon;
        }
    }
}



