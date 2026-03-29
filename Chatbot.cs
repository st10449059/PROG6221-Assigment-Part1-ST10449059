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
                // If the audio fails, we just log it silently. 
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
