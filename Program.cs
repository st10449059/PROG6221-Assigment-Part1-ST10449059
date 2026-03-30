namespace PROG6221_Assigment_Part1_ST10449059
{
    /// <summary>
    /// Entry point for the application. Handles user session and program flow.
    /// Citation: Microsoft (2024) 'Main() and command-line arguments'.
    /// </summary>
   
        internal class Program
        {
            static void Main(string[] args)
            {
                // Creating the bot object
                Chatbot myBot = new Chatbot();

                // Task 3: Start the multimedia and branding
                myBot.PlayVoiceGreeting();
                myBot.DisplayLogo();

                // Task 3: Asking for the user's name to personalize the chat
                myBot.TypeMessage("SYSTEM: Booting up security module...");
                myBot.TypeMessage("Hi! Before we start, what is your name? ", ConsoleColor.Gray);

                // Using the null-coalescing operator (??) to prevent errors if input is null.
                string userInput = Console.ReadLine() ?? "";

                // Setting the name. If they left it blank, we just use 'Guest'.
                myBot.UserName = string.IsNullOrWhiteSpace(userInput) ? "Guest" : userInput.Trim();

                // Clear the screen so it looks like a fresh interface after they join.
                Console.Clear();
                myBot.DisplayLogo();

                myBot.TypeMessage($"\nWelcome, {myBot.UserName}. I'm here to answer your security questions.", ConsoleColor.Cyan);
                myBot.TypeMessage("Type 'exit' to quit or ask me anything.\n");

                // This while loop keeps the bot running until the user says 'exit'.
                bool keepRunning = true;
                while (keepRunning)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{myBot.UserName} > ");

                    string query = Console.ReadLine() ?? "";

                    // Checking for the exit command specifically.
                    if (query.ToLower().Trim() == "exit")
                    {
                        keepRunning = false;
                        myBot.TypeMessage("\n[SYSTEM]: Session ended. Stay safe out there!", ConsoleColor.Red);
                    }
                    else
                    {
                        // Pass the input to the chatbot class to figure out the answer.
                        myBot.ProcessInput(query);
                    }
                }

                // Standard way to keep the console window from closing instantly.
                myBot.TypeMessage("\nPress any key to close the window...");
                Console.ReadKey();
            }
        }
    }
