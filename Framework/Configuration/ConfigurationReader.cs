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
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Framework\\Configuration\\";
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