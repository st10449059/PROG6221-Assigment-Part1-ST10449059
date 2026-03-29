namespace PROG6221_Assigment_Part1_ST10449059
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // This keeps our Main method nice and clean—very professional!
            Chatbot myBot = new Chatbot();

            // Kick things off with the audio and the logo
            myBot.PlayVoiceGreeting();
            myBot.DisplayLogo();

            // Let's get on a first-name basis with the user
            myBot.TypeMessage("SYSTEM: Security link established...");
            myBot.TypeMessage("Who am I speaking with today? ", ConsoleColor.Gray);

            // We use the null-coalescing operator (??) here to avoid any null-pointer headaches.
            string nameInput = Console.ReadLine() ?? "";

            // If they leave the name blank, we'll just call them 'Guest'.
            myBot.UserName = string.IsNullOrWhiteSpace(nameInput) ? "Guest" : nameInput.Trim();

            // Clear the console and reprint the logo for a professional 'app' feel.
            Console.Clear();
            myBot.DisplayLogo();

            myBot.TypeMessage($"\nWelcome to the command line, {myBot.UserName}. How can I assist with your security today?", ConsoleColor.Cyan);
            myBot.TypeMessage("(Type 'exit' whenever you're ready to sign off.)\n");

            // This loop keeps the conversation going until the user says 'exit'.
            bool active = true;
            while (active)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{myBot.UserName} > ");

                string userQuery = Console.ReadLine() ?? "";

                // Checking for the exit command specifically
                if (userQuery.ToLower().Trim() == "exit")
                {
                    active = false;
                    myBot.TypeMessage("\n[SYSTEM]: Connection severed. Stay safe out there!", ConsoleColor.Red);
                }
                else
                {
                    // Hand the question over to the Chatbot class to deal with
                    myBot.ProcessInput(userQuery);
                }
            }

            // Keeps the window open so they can see the final message.
            myBot.TypeMessage("\nPress any key to exit the terminal...");
            Console.ReadKey();
        }
    }
}

