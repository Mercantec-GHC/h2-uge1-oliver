using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazorWASM.Models
{
    public class PokemonListResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }

        [JsonPropertyName("previous")]
        public string? Previous { get; set; }

        [JsonPropertyName("results")]
        public List<PokemonListItem> Results { get; set; } = new();
    }
}
