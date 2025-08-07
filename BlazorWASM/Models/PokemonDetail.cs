using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazorWASM.Models
{
    public class PokemonDetail
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("types")]
        public List<PokemonTypeSlot> Types { get; set; } = new();

        [JsonPropertyName("sprites")]
        public PokemonSprites? Sprites { get; set; }

        [JsonIgnore]
        public string? ImageUrl => Sprites?.FrontDefault;
    }
}