using System;
using System.IO;
using System.Text.Json;

public static class Settings
{
    public static bool UseAzureOpenAI{get;set;}

    public static string AzureEndpoint { get; set; }

    public static string OpenAIApiKey { get; set; }

    public static string OrgId { get; set; }

    public static string BingApiKey { get; set; }
}

public static class SettingsHelper
{
    private const string DefaultConfigFile = "../config/settings.json";

    // Load settings from file
    public static void LoadFromFile(string configFile = DefaultConfigFile)
    {
        if (!File.Exists(DefaultConfigFile))
        {
            Console.WriteLine("Configuration not found: " + DefaultConfigFile);
            throw new Exception("Configuration not found");
        }

        try
        {
            var config = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(DefaultConfigFile));
            
            Settings.UseAzureOpenAI = config["type"] == "azure";
            Settings.AzureEndpoint = config["endpoint"];
            Settings.OpenAIApiKey = config["oaiApiKey"];
            Settings.OrgId = config["orgId"];
            Settings.BingApiKey = config["bingApiKey"];
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong: " + e.Message);
        }
    }
}