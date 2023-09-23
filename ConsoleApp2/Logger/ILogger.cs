using unirest_net.http;

namespace ConsoleApp2.Logger
{
    public interface ILogger
    {
        void CreateLogs(HttpResponse<string> apiResponse, string Method);
    }
}
