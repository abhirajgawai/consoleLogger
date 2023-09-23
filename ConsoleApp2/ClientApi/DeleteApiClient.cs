using ConsoleApp2.Logger;
using System;
using unirest_net.http;

namespace ConsoleApp2.ClientApi
{
    public class DeleteApiClient : IApiClient
    {
        public void MakeApiCall()
        {
            try
            {
                HttpResponse<string> response = Unirest.delete("https://request-boomerang.p.rapidapi.com/query-json?data=%7BAbhi%20Delete%7D")
               .header("X-RapidAPI-Host", "request-boomerang.p.rapidapi.com")
               .header("X-RapidAPI-Key", "c900a51d29msh0e84cd4df0f6affp12d46cjsnbeab6cc8d64d")
               .field("key1", "Abhi")
               .field("key2", "Delete").asJson<string>();

                Logging log = new Logging();
                log.CreateLogs(response, "DELETE");
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
