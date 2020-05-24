namespace StudentManagement
{
    public class WelcomeService : IWelcomeService
    {
        public string GetMessage()
        {
            return "Hello from IWelcome service";
        }
    }
}