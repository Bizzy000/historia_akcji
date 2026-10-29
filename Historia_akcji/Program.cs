using System;
using System.Data.Common;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> Plecak = new List<string>();
        List<string> historia_akcji = new List<string>();
        bool menu = true;
        Console.WriteLine("Podaj swoje imie:");
        string imie = Console.ReadLine()!;
        Console.WriteLine("ile masz hp?:");
        int hp = int.Parse(Console.ReadLine()!);
        Console.WriteLine("liczba mikstur:");
        int mikstury = int.Parse(Console.ReadLine()!);
        Console.WriteLine("ile masz zlota?");
        int zloto = int.Parse(Console.ReadLine()!);
        int numerTury = 1;
        int maxhp = 100;
        while (menu)

        {
            Console.WriteLine("                       ");
            Console.WriteLine("                       ");
            Console.WriteLine("===Witaj Podrozniku===");
            Console.WriteLine($"TURA: {numerTury}");
            Console.WriteLine($"Bohater: {imie}");
            Console.WriteLine($"HP: {hp}/{maxhp} | ZLOTO: {zloto} | MIKSTURY: {mikstury} ");
            Console.WriteLine("                      ");
            Console.WriteLine("                      ");
            Console.WriteLine("1 - Eksploruj");
            Console.WriteLine("2 - Pokaz plecak");
            Console.WriteLine("3 - Uzyj przedmiotu");
            Console.WriteLine("4 - Dodaj znalezisko");
            Console.WriteLine("5 - Wyrzuc przedmiot");
            Console.WriteLine("6 - Pokaz historie");
            Console.WriteLine("7 - Pokaz statystyki wyprawy");
            Console.WriteLine("8 - Zakoncz");

            string wybor = Console.ReadLine()!;

            switch (wybor)
            {
                case "1":
                    historia_akcji.Add("Eksploracja");
                    Console.WriteLine("Eksploracja zakonczona");
                    numerTury++;
                    break;

                case "2":
                    if (Plecak.Count == 0)
                    {
                        Console.WriteLine("Plecak jest pusty");
                    }
                    else
                    {
                        Console.WriteLine("+++++++++TWOJ PLECAK+++++++++");
                        for (int i = 0; i < Plecak.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {Plecak[i]}");
                        }
                    }

                    break;

                case "3":
                    if (Plecak.Count == 0)
                    {
                        Console.WriteLine("Plecak jest pusty, nie ma czego użyć.");
                    }
                    else
                    {
                        Console.WriteLine("\n--- Wybierz przedmiot do użycia ---");
                        for (int i = 0; i < Plecak.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {Plecak[i]}");
                        }
                        Console.Write("Podaj numer przedmiotu: ");
                        if (int.TryParse(Console.ReadLine(), out int numer) && numer >= 1 && numer <= Plecak.Count)
                        {
                            int indeks = numer - 1; // Zamiana numeru na indeks listy
                            string przedmiot = Plecak[indeks];

                            Console.WriteLine($"Użyto przedmiotu: {przedmiot}");
                            Plecak.RemoveAt(indeks);
                            historia_akcji.Add($"Użyto przedmiotu: {przedmiot}");
                            numerTury++;
                        }
                        else
                        {
                            Console.WriteLine("Nieprawidłowy numer przedmiotu.");
                        }
                    }
                    break;


                case "4":
                    if (Plecak.Count >= 6)
                    {
                        Console.WriteLine("Plecak jest pełny! (max 6 elementów). Nie można dodać przedmiotu.");
                    }
                    else
                    {
                        Console.WriteLine("Co znalazles? Mikstura, Klucz, Pochodnia, Zwoj");
                        string znalezisko = Console.ReadLine()!;

                        if (!string.IsNullOrWhiteSpace(znalezisko))
                        {
                            Plecak.Add(znalezisko);
                            Console.WriteLine($"Dodano do plecaka: {znalezisko}");
                            historia_akcji.Add($"Znaleziono i dodano: {znalezisko}");
                            numerTury++;
                        }
                        else
                        {
                            Console.WriteLine("Nazwa przedmiotu nie może być pusta.");
                        }
                    }
                    break;
                case "5":

                    if (historia_akcji.Count == 0)
                    {
                        Console.WriteLine("Nie ma zapisanej historii");
                    }
                    else
                    {
                        Console.WriteLine("To twoje ostatnie trzy wpisy");
                        int trzywpisy = historia_akcji.Count > 3 ? historia_akcji.Count - 3 : 0;
                        for (int i = trzywpisy; i < historia_akcji.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} {historia_akcji[i]}");
                        }
                    }
                    break;

                case "6":
                    Console.WriteLine("Co mam zliczyc? (Eksploracja, Odpoczynek, Przedmioty)");
                    string ktoraakcja = Console.ReadLine()!;

                    int ilosc = 0;
                    foreach (string wpis in historia_akcji)
                    {
                        if (wpis.Equals(ktoraakcja))
                        {
                            ilosc++;
                        }
                    }
                    Console.WriteLine($"Wybor {ktoraakcja} wybrales {ilosc} raz/razy");
                    break;

                case "7":
                    Console.WriteLine("Chcesz wyczyscic historie? (t/n)");
                    string potwierdzenie = Console.ReadLine()!.ToLower()!;
                    if (potwierdzenie == "t")
                    {
                        historia_akcji.Clear();
                        Console.WriteLine("HISTORIA WYCZYSZCZONA");
                    }
                    else
                    {
                        Console.WriteLine("HISTORIA NIE JEST USUWANA");
                    }
                    break;

                case "8":
                    menu = false;
                    Console.WriteLine("PROGRAM ZAKONCZONY");
                    break;

                default:
                    Console.WriteLine("zla opcja, sprobuj jeszcze raz");
                    break;
            }
        }
    }
}