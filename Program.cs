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


