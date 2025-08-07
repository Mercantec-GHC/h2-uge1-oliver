using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorWASM.Services
{
    public class HighscoreService
    {
        private readonly IJSRuntime _js;

        public HighscoreService(IJSRuntime js)
        {
            _js = js;
        }

        private const string StorageKey = "pokemonquiz_highscores";

        public async Task<List<HighscoreEntry>> GetHighscoresAsync()
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", StorageKey);
            if (string.IsNullOrEmpty(json))
                return new List<HighscoreEntry>();

            return JsonSerializer.Deserialize<List<HighscoreEntry>>(json);
        }

        public async Task AddHighscoreAsync(HighscoreEntry entry)
        {
            var scores = await GetHighscoresAsync();
            scores.Add(entry);
            scores.Sort((a, b) => b.Score.CompareTo(a.Score));
            if (scores.Count > 10)
                scores = scores.Take(10).ToList(); 

            var json = JsonSerializer.Serialize(scores);
            await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, json);
        }
    }

    public class HighscoreEntry
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public int Total { get; set; }
        public DateTime Date { get; set; }
    }
}
