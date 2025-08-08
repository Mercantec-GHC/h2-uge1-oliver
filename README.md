# WHO IS THAT POKEMON!? – Pokémon Quiz i Blazor WebAssembly

Et valgfrit API-projekt, der tester din Pokémon-viden ved hjælp af [PokeAPI](https://pokeapi.co).  
Quizzen henter et billede af en tilfældig Pokémon og genererer 4 svarmuligheder – og du skal gætte den rigtige.

---

## ✨ Funktioner
- Vælg spillets længde: **5, 20, 50 eller 100 Pokémoner**
- Ét spørgsmål ad gangen med **4 svarmuligheder** (1 korrekt + 3 forkerte)
- Øjeblikkelig feedback på hvert svar – **"Korrekt!"** eller **"Forkert!"**
- Resultatvisning efter det sidste spørgsmål
- Mulighed for at starte quizzen forfra

---

## 🛠 Teknologi
- **Blazor WebAssembly**
- **[PokeAPI](https://pokeapi.co)**
- `HttpClient` + `GetFromJsonAsync` til API-kald
- Lokal highscore-håndtering (ingen database nødvendig)

---

## 🚀 Sådan virker det
- Når siden `/pokemonquiz` åbnes, vælger brugeren antal Pokémoner, der skal gættes  
- Systemet henter en tilfældig Pokémon fra API’et samt tre forkerte svarmuligheder  
- Brugeren vælger et svar og får straks feedback (rigtigt/forkert)  
- Spillet fortsætter, indtil det valgte antal spørgsmål er besvaret  
- Til sidst vises resultat, antal rigtige/forkerte og highscore  

### 📂 Filoversigt
- **PokemonQuiz.razor** – Hovedkomponenten, der styrer quiz-flowet og viser UI  
- **PokemonService.cs** – Henter Pokémon-data fra PokeAPI  
- **HighscoreService.cs** – Holder styr på og opdaterer highscore lokalt  
- **PokemonQuiz.css** – Styling til quiz-siden  

---

## ▶️ Kørsel
1. **Clone** projektet 
2. Kør projektet via din IDE eller - Kør **Dotnet run** i din terminal
3. Åbn din browser og **tilføj /pokemonquiz til din url**
4. Quizzen er klar – Gotta catch 'em all!

🙌 Credits

Projektet er lavet som en del af et valgfrit API-projekt, med data fra det fantastiske PokeAPI.
Ingen Pokémon blev skadet under udviklingen 🐾
