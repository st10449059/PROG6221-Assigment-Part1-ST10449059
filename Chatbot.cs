using System;
using System.Media; // Let's us play the WAV file (Reference: Microsoft, 2024)
using System.Threading; // Gives us control over the 'typing' speed (Reference: Microsoft, 2024)

namespace PROG6221_Assigment_Part1_ST10449059
{
    public class Chatbot
    {
        // We use an Automatic Property here to keep track of the user's name. 
        // It's much cleaner than using a manual getter and setter!
        public string UserName { get; set; } = "User";

        private const string BotName = "CyberGuard";

        /// <summary>
        /// This method handles the audio greeting. 
        /// I've wrapped it in a try-catch block because if the file is missing, 
        /// we want the app to keep running instead of crashing.
        /// </summary>
        public void PlayVoiceGreeting()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer("greeting.wav"))
                {
                    player.Play();
                }
            }
            catch (Exception)
            {
                // If the audio fails, the user just logs it silently. 
                // This keeps the user experience smooth.
            }
        }

        /// <summary>
        /// Just a bit of flair! Using ASCII art makes the console feel like 
        /// a real security terminal from a movie.
        /// </summary>
        public void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
      ___________________________________________________
     [      ____      _              ____                ]
     [     / ___|   _| |__   ___ _ _| ___| _   _  __ _ _ __ __| | ]
     [    | |  | | | | '_ \ / _ \ '__| |  _| | | |/ _` | '__/ _` | ]
     [    | |__| |_| | |_) |  __/ |  | |_| | |_| | (_| | | | (_| | ]
     [     \____\__, |_.__/ \___|_|   \____|\__,_|\__,_|_|  \__,_| ]
     [          |___/  AWARENESS BOT v1.0                ]
     [___________________________________________________]
            ");
            Console.ResetColor();
        }
        /// <summary>
        /// This creates the 'typing' effect. By looping through each character 
        /// and adding a tiny delay, it feels like the bot is actually talking to you.
        /// </summary>
        public void TypeMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30); // 30ms is the best for readability
            }
            Console.WriteLine();
            Console.ResetColor();
        }
        /// <summary>
        /// This is the 'brain' of the bot. 
        /// i use string manipulation to make sure the bot isn't picky about 
        /// how the user types (caps, spaces, etc.).
        /// </summary>
        public void ProcessInput(string input)
        {
             
            // .Trim() kills extra spaces, and .ToLower() means 'PHISHING' works just as well as 'phishing'.
            string cleanInput = (input ?? "").Trim().ToLower();

            // If they just hit 'Enter' without typing, we give them a gentle nudge.
            if (string.IsNullOrEmpty(cleanInput))
            {
                TypeMessage($"{BotName}: Don't be shy! Go ahead and ask me a security question.", ConsoleColor.Yellow);
                return;
            }

            // Here we check for keywords. 
            // to make the advice more valuable for the user.
            if (cleanInput.Contains("password"))
            {
                TypeMessage($"{BotName}: Pro-tip: Passwords should be long (12+ characters) and unique. " +
                            "Think of a 'Passphrase' like 'Correct-Battery-Horse-Staple'—it's easy for humans, " +
                            "but a nightmare for hackers. (Reference: NIST, 2024).", ConsoleColor.Green);
            }
            else if (cleanInput.Contains("phishing"))
            {
                TypeMessage($"{BotName}: Phishing is all about trickery. If an email feels urgent or 'too good to be true', " +
                            "it usually is. Always double-check the sender's email address for typos like 'g00gle.com'.", ConsoleColor.Green);
            }
            else if (cleanInput.Contains("browsing"))
            {
                TypeMessage($"{BotName}: When browsing, look for the 'Padlock' icon in the URL bar. " +
                            "This means the site uses HTTPS, which encrypts the path between you and the server.", ConsoleColor.Green);
            }
            else if (cleanInput.Contains("how are you"))
            {
                TypeMessage($"{BotName}: I'm doing great! My antivirus is up to date and my logic circuits are humming.", ConsoleColor.Cyan);
            }
            else if (cleanInput.Contains("purpose"))
            {
                TypeMessage($"{BotName}: I'm here to help you understand that YOU are the most important firewall in any system.", ConsoleColor.Cyan);
            }
            else
            {
                // The 'catch-all' response for when the bot gets confused.
                TypeMessage($"{BotName}: I'm not quite sure I follow. Try asking about 'passwords' or 'browsing'!", ConsoleColor.Red);
            }
        }
    }
}