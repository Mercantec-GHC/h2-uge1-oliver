using System.Text.Json.Serialization;

namespace BlazorWASM.Models
{
    public class PokemonListItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
