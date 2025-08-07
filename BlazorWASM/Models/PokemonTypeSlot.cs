using System.Text.Json.Serialization;

namespace BlazorWASM.Models
{
    public class PokemonTypeSlot
    {
        [JsonPropertyName("slot")]
        public int Slot { get; set; }

        [JsonPropertyName("type")]
        public NamedApiResource Type { get; set; } = new();
    }
}