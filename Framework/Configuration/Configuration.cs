namespace Framework.Configuration
{
    public static class TestConfig
    {
        public static ConfigurationReader reader = new ConfigurationReader("FrameworkConfiguration.config");

        public static string Browser()
        {
            return reader.ReadValue("Browser");
        }
        public static string LocalDriverPath()
        {
            return reader.ReadValue("LocalDriverPath");
        }
    }
}