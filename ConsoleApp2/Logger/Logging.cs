using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.IO;
using unirest_net.http;

namespace ConsoleApp2.Logger
{
    public class Logging : ILogger
    {
        public void CreateLogs(HttpResponse<string> response, string Method)
        {
            // Create a folder to store the log files
            string logFolderPath = "Logs";
            Directory.CreateDirectory(logFolderPath);

            // Initialize Serilog logger
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(logFolderPath, "app.log"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            if (response.Code == 200)
            {
                var result = response.Body;

                JObject parsedString = JObject.Parse(result);
                Log.Information($"{Method} API RESPONSE---> ", parsedString.ToString());
                Console.WriteLine($"Request sent to:{Method}");
                Console.WriteLine($"Response received:\n{parsedString}");
                Console.ReadLine();
            }
            else
            {
                Log.Error("API Request Failed: {StatusCode}", response.Code);
            }
        }
    }
}
