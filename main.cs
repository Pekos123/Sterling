using System;
using System.Windows;
using System.IO;

// https://www.szyfry.matw.pl/

// nie diala mi rekord pointsow linia 190

// Przestrzeń nazw
namespace NumberGuesser 
{
    // Klasa główna
    class Program
    {
        // Metoda główna, czyli punkt wejścia programu 
        static void Main(string[] args)
        {
            // Wyświetl informacje o aplikacji
            GetAppInfo();

            // Zapytaj o imię i zainicjalizuj zmienną typu tesktowego
            string userName = GetUserName();

            // Przywitaj użytkownika
            GreetUser(userName);

            // Wylosuj liczbę z przedziału od 1 do 10
            Random random = new Random();
            // Zainicjalizuj zmienną typu całkowtego

            //rekord
            int numbersCountRekord = 0;

            //file("olnitr.txt", userName, numbersCount, true);
            //zeby ciagle pytano cie o liczby
            while (true){
            // Wyświetl komunikat
            int correctNumber =  random.Next(1, 101);

            // Zainicjalizuj zmienną typu logicznego
            bool correctAnswer = false;

            int numbersCount = 0;

            Console.WriteLine("\nZgadnij wylosowaną liczbę z przedziału od 1 do 100.");

            // Powtarzaj operacje w pętli dopóki wartość zmiennej correctAnswer jest równa false
            while (!correctAnswer)
            {
                // Pobierz i zainicjalizuj zmienną typu tesktowego
                string input = Console.ReadLine();

                // Zadeklaruj zmienną typu liczbowego
                int guess;

                // Konwertuj typ tesktowy na typ liczbowy
                bool isNumber = int.TryParse(input, out guess);
                
                // Sprawdź czy użytkownik wprowadził liczbę
                if (!isNumber)
                {
                    // Wyświetl komunikat 
                    PrintColorMessage(ConsoleColor.Yellow, "Proszę wprowadzić liczbę.");
                    // Przejdź do kolejnej iteracji pętli
                    continue;
                }

                // Sprawdź czy użytkownik wprowadził liczbę z przediału od 1 do 10
                if (guess < 1 || guess > 100)
                {
                    // Wyświetl komunikat
                    PrintColorMessage(ConsoleColor.Yellow, "Proszę wprowadzić liczbę z przedziału od 1 do 100.");
                    // Przejdź do kolejnej iteracji pętli
                    continue;
                }

                // Sprawdź czy użytkownik wprowadził liczbę mniejszą od wylosowanej liczby
                if (guess < correctNumber)
                {
					// Wyświetl komunikat
                    PrintColorMessage(ConsoleColor.Red, "Błędna odpowiedź. Wylosowana liczba jest większa.");
                    numbersCount += 1;
                }
				// Sprawdź czy użytkownik wprowadził liczbę większą od wylosowanej liczby
                else if (guess > correctNumber)
                {
					// Wyświetl komunikat
                    PrintColorMessage(ConsoleColor.Red, "Błędna odpowiedź. Wylosowana liczba jest mniejsza.");
                    numbersCount += 1;
                }
                else
                {
					 // Przypisz do zmiennej correctAnswer wartość true
                    correctAnswer = true;
					// Wyświetl komunikat
                    PrintColorMessage(ConsoleColor.Green, "Brawo! Prawidłowa odpowiedź!");
                    numbersCount += 1;
                    
                    //czy rekord jest aktualny
                    if(numbersCount < numbersCountRekord || numbersCountRekord == 0){
                      numbersCountRekord = numbersCount;

                      //fileWrite("olnitr.txt", numbersCountRekord);
                    }

                    //pokazuje liczbe prob
                    PrintColorMessage(ConsoleColor.Magenta, $"Liczba prób: {numbersCount}");

                    //fileOpen("olnitr.txt");

                    //pokazuje twój rekord
                    PrintColorMessage(ConsoleColor.Magenta, $"Rekord: {numbersCountRekord}");
                }
            }
            }

        }

        // Wyświetl informacje o aplikacji
        static void GetAppInfo()
        {
            // Zainicjalizuj informacje o aplikacji
            string appName = "Zgadywanie liczby";
            string appVersion = "0.0.1";
            string appAuthor = "Patryk Sładek";
            string appModsCreator = "Paweł Wojas";
            string modVersion = "0.1";

            // Przygotuj tekst informacji
            string info = $"[{appName}] Wersja: {appVersion}, Autor: {appAuthor} | Modyfikacja Sterling Wersja: {modVersion}, Autor: {appModsCreator}";

            // Wyświetl komunikat w fioletowym kolorze
            PrintColorMessage(ConsoleColor.Magenta, info);

        }

        // Zapytaj o imię i zwróć wartość typu tesktowego
        static string GetUserName()
        {
            // Zapytaj o imię
            Console.WriteLine("Jak masz na imię?");

            // Pobierz odpowiedź użytkownika
            string inputUserName = Console.ReadLine();

            // Zwróć odpowiedź
            return inputUserName;
        }

        // Przywitaj użytkownika
        static void GreetUser(string userName) // Parametrem wejściowym metody jest imię użytkownika 
        {
            // Przygotuj tekst przywitania
            string greet = $"Powodzenia {userName}, odgadnij liczbę...";

            // Wyświetl komunikat w niebieskim kolorze
            PrintColorMessage(ConsoleColor.Blue, greet);

            // Wyświetl pustą linię na konsoli
            Console.WriteLine();
        }


        // Wyświetl komunikat w odpowiednim kolorze
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            // Zmień kolor tekstu konsoli
            Console.ForegroundColor = color;

            // Wyświetl komunikat na konsoli
            Console.WriteLine(message);

            // Zresetuj kolor tekstu konsoli
            Console.ResetColor();
        }
    }

    /*class files 
    {
      bool isntFile = false;

        public void fileWrite(string path, float nc){

          StreamWriter sw;
          if(!File.Exists(path)){
            sw = File.CreateText(path);
          }
          else{
            sw = new StreamWriter(path, true);
          }
          
          if(nc != null){
            sw.WriteLine(nc);
          }
          else if(nc != null && isntFile == true){
            isntFile = false;
          }
          else{
            PrintColorMessage(ConsoleColor.Red, "Bląd nr. 001");
            sw.Close();
          }

        }
        public int points = 0;
        public void fileOpen(string path){
          StreamReader sr = File.OpenText(path);
          if(!File.Exists(path)){
            fileWrite("olnitr.txt", null);
            isntFile = true;
          }
          string line = sr.ReadLine();
          int points = Int16.Parse(line);        
        }
    }*/
}