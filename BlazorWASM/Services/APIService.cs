// Services/APIService.cs
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using BlazorWASM.Components;
using System.Text.Json.Serialization;
using BlazorWASM.Models;


namespace BlazorWASM.Services
{
    public class APIService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://opgaver.mercantec.tech/apiq";
        private const string PokeApiBaseUrl = "https://pokeapi.co/api/v2";

        public APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BackendStatus?> GetBackendStatusAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/Status/all");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<BackendStatus>(jsonString, options);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl ved tjek af backend status: {ex.Message}");
                return null;
            }
        }

        public async Task<List<TriviaQuestion>> GetTriviaQuestionsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<TriviaResponse>(
                "https://opentdb.com/api.php?amount=5&difficulty=easy&type=multiple");

            foreach (var question in response.Results)
            {
                var allAnswers = question.Incorrect_Answers.Append(question.Correct_Answer).ToList();
                question.Incorrect_Answers = allAnswers.OrderBy(_ => Guid.NewGuid()).ToList();
            }

            return response.Results;
        }

   
        public async Task<PokemonListResponse?> GetPokemonListAsync(int limit = 20, int offset = 0)
        {
            try
            {
                var url = $"{PokeApiBaseUrl}/pokemon?limit={limit}&offset={offset}";
                return await _httpClient.GetFromJsonAsync<PokemonListResponse>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Pokemon list: {ex.Message}");
                return null;
            }
        }

        public async Task<PokemonDetail?> GetPokemonDetailAsync(string nameOrId)
        {
            try
            {
                var url = $"{PokeApiBaseUrl}/pokemon/{nameOrId.ToLower()}";
                return await _httpClient.GetFromJsonAsync<PokemonDetail>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Pokemon detail for '{nameOrId}': {ex.Message}");
                return null;
            }
        }
    }

    



       
    

    public class BackendStatus
    {
        public ServerStatus? Server { get; set; }
        public DatabaseStatus? MongoDB { get; set; }
        public DatabaseStatus? PostgreSQL { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class ServerStatus
    {
        public string Status { get; set; } = string.Empty;
    }

    public class DatabaseStatus
    {
        public string Status { get; set; } = string.Empty;
        public string? Database { get; set; }
        public string? Error { get; set; }
        public bool IsError { get; set; }
    }




}

