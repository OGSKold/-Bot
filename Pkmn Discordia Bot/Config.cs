using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Pkmn_Discordia_Bot
{
    class Config
    {
        private const string configfolder = "Resources";
        private const string configfile = "config.json";

        public static BotConfig bot;
        static Config()
        {
            if (!Directory.Exists(configfolder)) Directory.CreateDirectory(configfolder);

            if (!File.Exists(configfolder + "/" + configfile))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot,Formatting.Indented);
                File.WriteAllText(configfolder + "/" + configfile, json);
            }
            else
            {
                string json = File.ReadAllText(configfolder + "/" + configfile);
                var data = JsonConvert.DeserializeObject<BotConfig>(json);
            }
        }
    }
   public struct BotConfig
    {
        public string token;
        public string cmdPrefix;
    }
}
