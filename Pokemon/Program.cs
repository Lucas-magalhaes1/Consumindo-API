using System;
using System.Threading.Tasks;
using Client;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Digite o ID do Pokémon: ");
        string pokemonId = Console.ReadLine();

        var client = new DefaultClient("https://pokeapi.co/api/v2/");
        var response = await client.GetPokemonAsync(pokemonId);

        if (response.IsSuccessStatusCode)
        {
            var pokemon = await response.Content.ReadAsPokemonAsync();

            Console.Write("Digite a altura do Pokémon: ");
            pokemon.Height = int.Parse(Console.ReadLine());

            Console.Write("Digite o peso do Pokémon: ");
            pokemon.Weight = int.Parse(Console.ReadLine());

            Console.WriteLine("Tipos:");
            foreach (var type in pokemon.Types)
            {
                Console.WriteLine($"- {type.Name}");
            }
        }
        else
        {
            Console.WriteLine($"Erro ao obter o Pokémon. Código de status: {response.StatusCode}");
        }

        Console.ReadLine(); // Aguarda o usuário pressionar Enter antes de encerrar o programa
    }
}







