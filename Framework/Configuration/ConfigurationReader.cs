using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Framework.Configuration
{
    public class ConfigurationReader
    {
        XDocument xdoc;

        public ConfigurationReader(string configurationFileName)
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            xdoc = XDocument.Load(Path.Combine(path, configurationFileName));
        }


        public string ReadValue(string name)
        {
            string value = xdoc.Descendants("setting")
                .Select(x => new
                {
                    key = x.Descendants("key").FirstOrDefault().Value,
                    value = x.Descendants("value").FirstOrDefault().Value
                })
                .Where(x => x.key == name)
                    .FirstOrDefault()
                    .value;

            return value;
        }
    }
}