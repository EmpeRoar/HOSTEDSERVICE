using DB;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SERVICEPROVIDER
{
    public class RandumNumberProviderService : IRandumNumberProviderService
    {


        public RandumNumberProviderService()
        {
            
        }

       
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string GetRandomString()
        {
            return RandomString(10);
        }


        

        
    }
}
