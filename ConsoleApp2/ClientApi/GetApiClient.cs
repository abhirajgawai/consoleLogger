
using ConsoleApp2.Logger;
using unirest_net.http;

namespace ConsoleApp2.ClientApi
{
    public class GetApiClient : IApiClient
    {
        public void MakeApiCall()
        {
            try
            {
                HttpResponse<string> response =
                        Unirest.get("https://request-boomerang.p.rapidapi.com/query-json?data=%7BAbhiraj%7D")
                       .header("X-RapidAPI-Host", "request-boomerang.p.rapidapi.com")
                       .header("X-RapidAPI-Key", "c900a51d29msh0e84cd4df0f6affp12d46cjsnbeab6cc8d64d")
                       .asJson<string>();

                Logging log = new Logging();
                log.CreateLogs(response, "GET");
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
