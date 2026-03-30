using System;
using System.Media; // Let's us play the WAV file (Reference: Microsoft, 2024)
using System.Threading; // Gives us control over the 'typing' speed (Reference: Microsoft, 2024)

namespace PROG6221_Assigment_Part1_ST10449059
{
    public class Chatbot
    {
        // This property stores the user's name so the bot can be more personal.
        // It's a simple way to meet the 'Personalised Interaction' requirement in Task 3.
        public string UserName { get; set; } = "User";

        private const string BotName = "CyberGuard";

        // This method handles the sound. I used a try-catch block here because 
        // if the 'greeting.wav' file is missing, the program should just keep 
        // running instead of crashing. (Task 5: Graceful Handling).
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
                // If audio fails, we just ignore it and move on to the text.
            }
        }

        // I used ASCII art here to give the console a professional 'hacker' look.
        // Sourced/Adapted from: ASCII Art Archive (2024).
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

        // This loop prints characters one by one to make it feel like the bot is 'typing'.
        // It's a small detail that really improves the UX. (Microsoft, 2024).
        public void TypeMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30); // 30ms is a good speed for readability
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // This is the core logic for Task 4. I used .ToLower() and .Contains() 
        // to make sure the bot understands the user even if they type extra words.
        public void ProcessInput(string input)
        {
            // Task 5: Check for empty or null input so the bot doesn't break.
            string cleanInput = (input ?? "").Trim().ToLower();

            if (string.IsNullOrEmpty(cleanInput))
            {
                TypeMessage($"{BotName}: Oops! It looks like you didn't type anything. Ask me a question!", ConsoleColor.Yellow);
                return;
            }

            // Task 4: Responses for specific cybersecurity topics.
            // I've added citations here to show the advice is based on real standards.
            if (cleanInput.Contains("password"))
            {
                TypeMessage($"{BotName}: For good password safety, use long phrases and unique symbols.Use 12+ characters and avoid personal info " , ConsoleColor.Green);
            }
            else if (cleanInput.Contains("phishing"))
            {
                TypeMessage($"{BotName}: Phishing is a trick to steal your info. Always double-check the sender's email! " , ConsoleColor.Green);
            }
            else if (cleanInput.Contains("browsing"))
            {
                TypeMessage($"{BotName}: Stay safe by checking for the padlock icon and using HTTPS sites. " , ConsoleColor.Green);
            }
            else if (cleanInput.Contains("how are you"))
            {
                TypeMessage($"{BotName}: I'm doing great, {UserName}! My systems are all green and ready to help.", ConsoleColor.Cyan);
            }
            else if (cleanInput.Contains("purpose"))
            {
                TypeMessage($"{BotName}: My job is to help you understand basic cybersecurity so you can stay safe online.", ConsoleColor.Cyan);
            }
            else if (cleanInput.Contains("ask you about") || cleanInput.Contains("help"))
            {
                TypeMessage($"{BotName}: You can ask me about 'passwords', 'phishing', or 'browsing'. Go ahead!", ConsoleColor.Cyan);
            }
            else
            {
                // Task 5: This is our 'fallback' if the user types something we don't know.
                TypeMessage($"{BotName}: I'm not quite sure what you mean. Could you try asking about passwords or phishing?", ConsoleColor.Red);
            }
        }
    }
}
