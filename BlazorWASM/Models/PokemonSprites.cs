using System.Text.Json.Serialization;

namespace BlazorWASM.Models
{
    public class PokemonSprites
    {
        [JsonPropertyName("front_default")]
        public string? FrontDefault { get; set; }
    }
}
