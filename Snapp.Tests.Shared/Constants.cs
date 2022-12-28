using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Tests.Shared
{
    internal static class Constants
    {
#if DEBUG
        public static string AdminApiUrl
        {
            get
            {
                return "http://snapp.admin.com/api";
            }
        }


        public static string WebApiUrl
        {
            get
            {
                return "https://snapp.web.com/api";
            }
        }


#else
        public static string AdminApiUrl
        {
            get
            {
                return "http://snapp.staging.admin.com/api";
            }
        }
        public static string WebApiUrl
        {
            get
            {
                return "https://snapp.staging.web.com/api";
            }
        }
#endif
    }
}