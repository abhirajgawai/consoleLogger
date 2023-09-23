using ConsoleApp2.Logger;
using unirest_net.http;

namespace ConsoleApp2.ClientApi
{
    public class PutApiClient : IApiClient
    {
        public void MakeApiCall()
        {
            try
            {
                HttpResponse<string> response = Unirest.put("https://request-boomerang.p.rapidapi.com/query-json?data=%7BAbhi%20PUT%7D")
               .header("X-RapidAPI-Host", "request-boomerang.p.rapidapi.com")
               .header("X-RapidAPI-Key", "c900a51d29msh0e84cd4df0f6affp12d46cjsnbeab6cc8d64d")
               .field("key1", "Abhi")
               .field("key2", "Put").asJson<string>();

                Logging log = new Logging();
                log.CreateLogs(response, "PUT");
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
