using System;
using System.Net.Http;
using System.Net.Security;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Snapp.Tests.Shared
{

    public enum HttpMethod
    {
        GET,
        POST
    }

    public interface IHttpCommand<TIn, TOut>
    {
        TOut Execute(HttpClient client, string url, TIn requestObj);
    }

    public class HttpGetCommand<TIn, TOut> : IHttpCommand<TIn, TOut>
    {
        public TOut Execute(HttpClient client, string url, TIn requestObj)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            string data = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TOut>(data);
        }
    }

    public class HttpPostCommand<TIn, TOut> : IHttpCommand<TIn, TOut>
    {
        public TOut Execute(HttpClient client, string url, TIn requestObj)
        {
            string json = JsonConvert.SerializeObject(requestObj);

            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            var stringContent = new StringContent(json,
                         UnicodeEncoding.UTF8,
                         "application/json");
            string data = client.PostAsync(new Uri(url), stringContent).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TOut>(data);
        }
    }

    public class HttpCommandFactory
    {
        public static IHttpCommand<TIn, TOut> CommandFor<TIn, TOut>(HttpMethod httpMethod)
        {
            switch (httpMethod)
            {
                case HttpMethod.GET: return new HttpGetCommand<TIn, TOut>();
                case HttpMethod.POST: return new HttpPostCommand<TIn, TOut>();
                default: throw new Exception();
            }
        }
    }
}
