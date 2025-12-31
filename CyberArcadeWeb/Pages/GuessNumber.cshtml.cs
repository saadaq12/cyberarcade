using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http; // Behövs för Session (minne)

namespace CyberArcadeWeb.Pages
{
    public class GuessNumberModel : PageModel
    {
        // Variabel för meddelandet till spelaren
        public string Message { get; set; }

        // Variabel för användarens gissning (kopplad till input-rutan)
        [BindProperty]
        public int UserGuess { get; set; }

        // När sidan laddas första gången
        public void OnGet()
        {
            // Om vi inte har ett hemligt nummer än, skapa ett!
            if (HttpContext.Session.GetInt32("SecretNumber") == null)
            {
                Random rnd = new Random();
                int num = rnd.Next(1, 11); // 1 till 10
                HttpContext.Session.SetInt32("SecretNumber", num);
            }
        }

        // När användaren klickar på "Gissa"-knappen
        public void OnPost()
        {
            // Hämta det hemliga numret från minnet
            int? secretNumber = HttpContext.Session.GetInt32("SecretNumber");

            if (secretNumber != null)
            {
                if (UserGuess == secretNumber)
                {
                    Message = "🎉 RÄTT! Du vann! Jag tänker på ett nytt nummer nu.";
                    // Slumpa ett nytt nummer direkt
                    Random rnd = new Random();
                    HttpContext.Session.SetInt32("SecretNumber", rnd.Next(1, 11));
                }
                else if (UserGuess < secretNumber)
                {
                    Message = "⬆️ För lågt! Försök igen.";
                }
                else
                {
                    Message = "⬇️ För högt! Försök igen.";
                }
            }
        }
    }
}