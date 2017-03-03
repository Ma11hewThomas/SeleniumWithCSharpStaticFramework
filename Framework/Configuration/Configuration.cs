namespace Framework.Configuration
{
    public static class TestConfig
    {
        public static ConfigurationReader reader = new ConfigurationReader("WebAutomationConfiguration.config");

        public static string Browser()
        {
            return reader.ReadValue("Browser");
        }
    }
}