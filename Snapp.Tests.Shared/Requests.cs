using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Snapp.Tests.Shared
{
    public static class Requests
    {
        public static TOut MakeRequest<TIn, TOut>(HttpMethod method, string url, TIn model)
        {
            using (HttpClient client = new HttpClient())
            {
                return HttpCommandFactory.CommandFor<TIn, TOut>(method).Execute(client, url, model);
            }
        }
        public static TOut MakeRequest<TIn, TOut>(HttpClient client, HttpMethod method, string url, TIn model)
        {
            return HttpCommandFactory.CommandFor<TIn, TOut>(method).Execute(client, url, model);
        }
        public static TOut MakeRequest<TOut>(HttpMethod method, string url)
        {
            return MakeRequest<string, TOut>(method, url, null);
        }
        public static TOut MakeRequest<TOut>(HttpClient client, HttpMethod method, string url)
        {
            return MakeRequest<string, TOut>(client, method, url, null);
        }
    }
    //public class TaxRequestHelper
    //{
    //    public string URL;

    //    public TaxRequestHelper(string url)
    //    {
    //        this.URL = url;
    //    }

    //    public async Task<T> HttpPut<T, TV>(string url, TV data, IDictionary<string, string> headers = null)
    //    {
    //        if (String.IsNullOrEmpty(url)) url = this.URL;
    //        using HttpClient client = new HttpClient();
    //        prepareClientHeaders(client, headers);
    //        var response = await client.PutAsJsonAsync(url, data);
    //        string respString = analizeHttpResponse(response);

    //        if (typeof(T) == typeof(string))
    //        {
    //            //return (T)respString;
    //        }

    //        return JsonConvert.DeserializeObject<T>(respString);
    //    }

    //    public async Task<string> HttpPut(string url, IDictionary<string, string> headers = null)
    //    {
    //        if (String.IsNullOrEmpty(url)) url = this.URL;
    //        using HttpClient client = new HttpClient();
    //        prepareClientHeaders(client, headers);
    //        var response = await client.PutAsJsonAsync(url, new Dictionary<string, string>() { });
    //        string respString = analizeHttpResponse(response);

    //        return respString;
    //    }


    //    public async Task<T> HttpPost<T, TV>(string url, TV data, IDictionary<string, string> headers = null)
    //    {
    //        string respString = String.Empty;
    //        if (String.IsNullOrEmpty(url)) url = this.URL;
    //        using HttpClient client = new HttpClient();
    //        prepareClientHeaders(client, headers);

    //        var response = await client.PostAsJsonAsync(url, data);
    //        respString = analizeHttpResponse(response);

    //        return JsonConvert.DeserializeObject<T>(respString);
    //    }




    //    public string prepareRequestUrl(string endPoint, string token = null)
    //    {
    //        string url = new Uri(new Uri(this.URL), endPoint).ToString();
    //        if (!String.IsNullOrEmpty(token))
    //        {
    //            url = String.Format(url, token);
    //        }

    //        return url;
    //    }

    //    /*public void prepareHttpManager(Manager.CallManager manager)
    //    {
    //        manager.AddHeader("Accept", "application/json");
    //        //manager.AddHeader("Content-Type", "application/x-www-form-urlencoded");
    //        manager.AddHeader("X-Token", options.Token);
    //        manager.AddHeader("Host", "localhost");
    //    }*/

    //    public async Task<T> HttpGet<T>(string url, IDictionary<string, string> headers = null)
    //    {
    //        if (String.IsNullOrEmpty(url)) url = this.URL;
    //        using HttpClient client = new HttpClient();
    //        prepareClientHeaders(client, headers);
    //        var resp = await client.GetAsync(url);
    //        string data = analizeHttpResponse(resp);

    //        return JsonConvert.DeserializeObject<T>(data);
    //    }

    //    public async Task<string> HttpGetString(string url, IDictionary<string, string> headers = null)
    //    {
    //        if (String.IsNullOrEmpty(url)) url = this.URL;
    //        using HttpClient client = new HttpClient();
    //        prepareClientHeaders(client, headers);
    //        var resp = await client.GetAsync(url);
    //        return analizeHttpResponse(resp);
    //    }

    //    public void prepareClientHeaders(HttpClient client, IDictionary<string, string> headers)
    //    {
    //        if (headers != null)
    //        {
    //            foreach (var keyValuePair in headers)
    //            {
    //                client.DefaultRequestHeaders.Add(keyValuePair.Key, keyValuePair.Value);
    //            }
    //        }
    //    }

    //    public string analizeHttpResponse(HttpResponseMessage response)
    //    {
    //        string data = String.Empty;
    //        if (response.IsSuccessStatusCode)
    //        {
    //            data = response.Content.ReadAsStringAsync().Result;
    //            return data;
    //        }

    //        data = response.Content.ReadAsStringAsync().Result;
    //        throw new Exception(data);
    //    }
    //}
    //var requestHelper = new TaxRequestHelper("https://prelive.e-community.am/web-service");
    //var resp1 = await requestHelper
    //    .HttpPost<GetTaxesResponseModel<TaxServiceVehicleServiceModel>, GetVehicleTaxesRequestModel>(
    //        string.Empty, request);
    //responseModel = PrepareVehicleResponseModel(resp1);
}
