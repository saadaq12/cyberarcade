using System;
using System.Threading;
using System.Diagnostics;

namespace CyberArcade
{
    class Program
    {
        // Huvudprogrammet startar här
        static void Main(string[] args)
        {
            // Ställ in titeln på fönstret
            Console.Title = "CYBER ARCADE V1.0";
            
            // Kör en cool intro-effekt ("Bakgrunden")
            MatrixIntro();

            bool isRunning = true;

            while (isRunning)
            {
                // Rita menyn
                DrawMenu();

                // Läs användarens val
                Console.Write("\n[SYSTEM] Välj ett alternativ: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlayGuessTheNumber();
                        break;
                    case "2":
                        PlayReactionTest();
                        break;
                    case "3":
                        ShowSystemInfo();
                        break;
                    case "4":
                        Console.WriteLine("Stänger ner systemet...");
                        isRunning = false;
                        break;
                        case "5":
                     Process.Start("open", "https://www.google.com"); // "open" kommandot fungerar på Mac
                        break;
                    default:
                        ErrorMessage("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        // --- MENY OCH GRAFIK ---

        static void DrawMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  ______   __     __  _______   ______   _______  
 /      \ /  \   /  |/       \ /      \ /       \ 
/$$$$$$  |$$  \ /$$/ $$$$$$$  /$$$$$$  |$$$$$$$  |
$$ |  $$/  $$  /$$/  $$ |__$$ |$$    $$ |$$ |__$$ |
$$ |        $$ $$/   $$    $$< $$$$$$$$ |$$    $$< 
$$ |   __    $$$/    $$$$$$$  |$$       |$$$$$$$  |
$$ \__/  |    $$ |   $$ |__$$ |$$$$$$$$/ $$ |  $$ |
$$    $$/     $$ |   $$    $$/ $$ |      $$ |  $$ |
 $$$$$$/      $$/    $$$$$$$/  $$/       $$/   $$/ 
            ");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Välkommen till huvudhubben.");
            Console.WriteLine("------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. [SPEL] Gissa Numret (Matematik)");
            Console.WriteLine("2. [SPEL] Reflex Test (Action)");
            Console.WriteLine("3. [INFO] Om Datorn");
            Console.WriteLine("4. [AVSLUTA] Logga ut");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------");
        }

        static void MatrixIntro()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.WriteLine("Initierar systemet...");
            
            // En enkel loop för att simulera laddning/hackerkänsla
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                Console.Write((char)rnd.Next(33, 126) + " ");
                Thread.Sleep(20); // Pausar i 20 millisekunder
            }
            Console.Clear();
            Console.ResetColor();
        }

        static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"FEL: {message}");
            Console.ResetColor();
            Console.WriteLine("Tryck på Enter för att fortsätta...");
            Console.ReadLine();
        }

        // --- SPEL OCH FUNKTIONER ---

        static void PlayGuessTheNumber()
        {
            Console.Clear();
            Console.WriteLine("=== GISSA NUMRET ===");
            Console.WriteLine("Jag tänker på ett tal mellan 1 och 100.");
            
            Random random = new Random();
            int numberToGuess = random.Next(1, 101);
            int attempts = 0;
            bool won = false;

            while (!won)
            {
                Console.Write("Din gissning: ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out int guess))
                {
                    attempts++;
                    if (guess < numberToGuess) Console.WriteLine("För lågt!");
                    else if (guess > numberToGuess) Console.WriteLine("För högt!");
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nGRATTIS! Du klarade det på {attempts} försök.");
                        won = true;
                    }
                }
                else
                {
                    Console.WriteLine("Skriv en siffra tack.");
                }
            }
            Console.ResetColor();
            Console.WriteLine("\nTryck Enter för att återgå till menyn.");
            Console.ReadLine();
        }

        static void PlayReactionTest()
        {
            Console.Clear();
            Console.WriteLine("=== REFLEX TEST ===");
            Console.WriteLine("När texten säger 'NU!', tryck Enter så snabbt du kan.");
            Console.WriteLine("Tryck Enter för att starta...");
            Console.ReadLine();

            Console.WriteLine("Vänta...");
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(2000, 5000)); // Vänta slumpmässig tid 2-5 sek

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red; // Byt bakgrundsfärg
            Console.WriteLine("\n   NU!!!!!   \n");
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.ReadLine(); // Väntar på att användaren trycker Enter
            stopwatch.Stop();

            Console.ResetColor(); // Återställ färger
            Console.WriteLine($"Din tid: {stopwatch.ElapsedMilliseconds} ms");
            
            if (stopwatch.ElapsedMilliseconds < 250) Console.WriteLine("Oj! Supersnabbt!");
            else Console.WriteLine("Ganska bra, men du kan snabbare!");

            Console.WriteLine("\nTryck Enter för menyn.");
            Console.ReadLine();
        }

        static void ShowSystemInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== SYSTEM INFORMATION ===");
            Console.WriteLine($"OS Version: {Environment.OSVersion}");
            Console.WriteLine($"Datornamn: {Environment.MachineName}");
            Console.WriteLine($"Processorer: {Environment.ProcessorCount}");
            Console.WriteLine($"Nuvarande tid: {DateTime.Now}");
            Console.ResetColor();
            Console.WriteLine("\nTryck Enter för att återgå.");
            Console.ReadLine();
        }
    }
}