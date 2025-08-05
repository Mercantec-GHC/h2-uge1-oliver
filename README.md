### Valgfrit API Projekt ###

Vores projekt benytter Open Trivia DB (https://opentdb.com/) og uddeler dem som en interaktiv quiz.

# Funktioner
- Henter 5 spørgsmål via HTTP GET
- Viser et spørgsmål af gangen, og giver 4 svar muligheder (1 knap til hver mulighed)
- Når brugeren svarer på et spørgsmål, får brugeren feedback med det samme: rigtigt/forkert
- Tæller point. Efter femte spørgsmål, kan man se hvordan man har klaret sig
- Mulighed for at tage quizzen om efter femte spørgsmål og quizzen er slut

# Teknologi
- Blazor WebAssembly
- Trivia API
- HttpClient + GetFromJsonAsync

# Sådan virker det
- APIService (APIService.cs) kalder trivia API'et
- UI (QuizPage.razor) viser spørgsmål og svar
- Model (TriviaQuestion.cs) matcher API-data

# Kørsel
1) Clone Projektet
2) Kør projektet og tilføj '/quiz` til URL'en i din browser, og quizz'en vil starte automatisk
