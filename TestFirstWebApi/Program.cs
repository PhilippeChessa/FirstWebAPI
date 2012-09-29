using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using FirstWebApiDAL;


namespace TestFirstWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();


            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("http://localhost:59130/api/customer").Result;

            if (response.IsSuccessStatusCode)
            {

                var Customers = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                foreach (var c in Customers)
                {
                    Console.WriteLine("{0}\t{1}\t{2}", c.FirstName, c.LastName, c.EMail);

                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.ReadLine();
        }
    }
}
