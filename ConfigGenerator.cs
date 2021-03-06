﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace SpotiSharp
{
    public class ConfigData
    {
        public string ConfigVersion { get; set; }
        public string ClientID { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string FFmpegPath { get; set; } = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        public string DownloadPath { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "SpotiSharp");

        public bool IsMissingRequiredFields()
        {
            return ClientID == string.Empty && ClientSecret == string.Empty;
        }

        public void EnsurePathsExist()
        {
            Directory.CreateDirectory(FFmpegPath);
            Directory.CreateDirectory(DownloadPath);
        }
    }
    public static class Config
    {

        public static ConfigData Properties;

        private static readonly string configFile = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "config.json");

        public static void Initialize()
        {
            if (File.Exists(configFile))
            {
                var deserialized = JsonSerializer.Deserialize<ConfigData>(File.ReadAllText(configFile));

                if (deserialized.ConfigVersion != Utilities.ApplicationVersion)
                {
                    deserialized.ConfigVersion = Utilities.ApplicationVersion;
                    updateConfig(deserialized);
                }
                if (deserialized.IsMissingRequiredFields())
                {
                    Console.WriteLine("Please fill missing information in the configuration file");
                    Environment.Exit(1);
                }
                Properties = deserialized;
            }
            else
            {
                Properties = new ConfigData();
                Properties.ConfigVersion = Utilities.ApplicationVersion;
                updateConfig(Properties);
                if (Properties.IsMissingRequiredFields())
                {
                    Console.WriteLine("Please fill missing information in the configuration file");
                    Environment.Exit(1);
                }
            }

            Properties.EnsurePathsExist();
        }
        private static void updateConfig(ConfigData data)
        {
            var serialized = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configFile, serialized);
        }        
    }
}
