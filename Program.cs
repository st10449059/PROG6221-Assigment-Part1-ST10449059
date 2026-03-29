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

