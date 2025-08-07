using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWASM.Services // ← Tilføjet dette
{
    public class PokemonService
    {
        private readonly HttpClient _http;

        public PokemonService(HttpClient http)
        {
            _http = http;
        }

        public async Task<(string name, string imageUrl)> GetRandomPokemonAsync()
        {
            var random = new Random();
            int id = random.Next(1, 151); // De første 150 Pokémoner
            var response = await _http.GetFromJsonAsync<PokemonResponse>($"https://pokeapi.co/api/v2/pokemon/{id}");

            return (response.name, response.sprites.front_default);
        }

        public async Task<string> GetPokemonNameByIdAsync(int id)
        {
            var response = await _http.GetFromJsonAsync<PokemonResponse>($"https://pokeapi.co/api/v2/pokemon/{id}");
            return response.name;
        }

        private class PokemonResponse
        {
            public string name { get; set; }
            public Sprites sprites { get; set; }

            public class Sprites
            {
                public string front_default { get; set; }
            }
        }
    }
}
