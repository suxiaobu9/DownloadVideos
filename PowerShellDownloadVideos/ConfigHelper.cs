using Newtonsoft.Json;
using PowerShellDownloadVideos.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PowerShellDownloadVideos
{
    public class ConfigHelper: IDisposable
    {
        private readonly object thisLock = new object();
        private string ConfigPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.xml");
        private readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();
        private readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings() { DateFormatString = "yyyyMMdd" };

        private static readonly object instanceLock = new object();
        private static ConfigHelper defaultConfig = null;
        public static ConfigHelper DefaultConfig
        {
            get
            {
                lock (instanceLock)
                {
                    if (defaultConfig == null)
                    {
                        defaultConfig = new ConfigHelper();
                    }
                    return defaultConfig;
                }
            }
        }
        ~ConfigHelper()
        {
            Dispose();
        }

        private ConfigHelper()
        {
            XmlDocument xdoc = new XmlDocument
            {
                XmlResolver = null
            };
            if (!File.Exists(ConfigPath))
                SaveXmlConfig();

            xdoc.Load(ConfigPath);
            var json = JsonConvert.SerializeXmlNode(xdoc.DocumentElement, Newtonsoft.Json.Formatting.None, true);

            //空 config 的狀況下 json 為 null, 所以需判斷轉出不為 null 才賦值
            dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(json, jsonSerializerSettings) ??
                        dictionary;

            //給定從 config model 來的預設值
            var defaultProps = typeof(Settings).GetProperties();

            foreach (var prop in defaultProps)
            {
                if (dictionary.ContainsKey(prop.Name))
                    continue;

                var defaultValueAttr = (prop.GetCustomAttributes(typeof(DefaultValueAttribute), false)).FirstOrDefault() as DefaultValueAttribute;

                if (defaultValueAttr != null)
                    dictionary.Add(prop.Name, defaultValueAttr.Value);
                else
                    dictionary.Add(prop.Name, string.Empty);
            }

        }

        public object this[string name]
        {
            get
            {
                lock (thisLock) { return dictionary[name]; }
            }
            set
            {
                lock (thisLock) { dictionary[name] = value; }
            }
        }

        public void Dispose()
        {
            SaveXmlConfig();
        }

        private void SaveXmlConfig()
        {
            var json = JsonConvert.SerializeObject(this.dictionary, jsonSerializerSettings);
            var xdoc = JsonConvert.DeserializeXmlNode(json, "Config");
            xdoc.XmlResolver = null;
            xdoc.CreateXmlDeclaration("1.0", "utf-8", null);
            var xmlSetting = new XmlWriterSettings
            {
                NewLineOnAttributes = true,
                Indent = true
            };
            using (var writer = XmlWriter.Create(ConfigPath, xmlSetting))
            {
                xdoc.Save(writer);
            }
        }

        internal static void SetConfigValue(Expression<Func<Settings,object>>func , object value)
        {
            var memberExpression = func.Body as MemberExpression;
            var memberName = memberExpression.Member.Name;
            SetConfigValue(memberName, value);
        }

        internal static void SetConfigValue(string property , object value)
        {
            DefaultConfig[property] = value;
        }

        internal static bool HasProperty(string propertyName)
        {
            return DefaultConfig.dictionary.ContainsKey(propertyName);
        }

    }
}
