namespace Snapp.Tests.Core.Services
{
    public class RequestService<TIn, TOut> : IRequestService<TIn, TOut>
    {
        public TOut Execute(HttpClient client, string url, TIn requestObj)
        {
            throw new NotImplementedException();
        }
    }
}