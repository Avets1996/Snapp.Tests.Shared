using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Tests.Core.Services
{
    public interface IRequestService<TIn, TOut> 
    {
        TOut Execute(HttpClient client, string url, TIn requestObj);
    }
}
