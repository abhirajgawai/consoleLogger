using System;
using Serilog;
using ConsoleApp2.ClientApi;

namespace ConsoleApp2
{
    internal class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            Console.WriteLine("Choose an API call you want to make:");
            Console.WriteLine("GET");
            Console.WriteLine("PUT");
            Console.WriteLine("POST");
            Console.WriteLine("DELETE");

            var userInput = Console.ReadLine();
            Console.ReadLine();
            try
            {
                IApiClient apiClient;

                switch (userInput.ToUpper())
                {
                    case "GET":
                        apiClient = new GetApiClient();
                        break;
                    case "PUT":
                        apiClient = new PutApiClient();
                        break;
                    case "POST":
                        apiClient = new PostApiClient();
                        break;
                    case "DELETE":
                        apiClient = new DeleteApiClient();
                        break;
                    default:
                        Log.Error("Invalid user input.", userInput);
                        Console.WriteLine($"Please select a Valid User Input number: {userInput}");
                        return;
                }

                apiClient.MakeApiCall();


                //// Create a folder to store the log files
                //string logFolderPath = "Logs";
                //Directory.CreateDirectory(logFolderPath);

                //// Initialize Serilog logger
                //Log.Logger = new LoggerConfiguration()
                //    .WriteTo.File(Path.Combine(logFolderPath, "app.log"), rollingInterval: RollingInterval.Day)
                //    .CreateLogger();

                //HttpResponse<string> response =
                // Unirest.get("https://baseballapi.p.rapidapi.com/api/baseball/team/3633")
                //.header("X-RapidAPI-Host", "baseballapi.p.rapidapi.com")
                //.header("X-RapidAPI-Key", "c900a51d29msh0e84cd4df0f6affp12d46cjsnbeab6cc8d64d")
                //.asJson<string>();

                //if (response.Code == 200)
                //{
                //    var result = response.Body;

                //    JObject parsedString = JObject.Parse(result);
                //    Log.Information("API Response: {ApiResponse}", result);
                //}
                //else
                //{
                //    Log.Error("API Request Failed: {StatusCode}", response.Code);
                //}

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while making the API request.");
            }
            finally
            {
                // Close and flush the log
                Log.CloseAndFlush();
            }
        }
    }
}

