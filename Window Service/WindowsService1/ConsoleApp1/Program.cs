using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            { 
            Console.Write("Please Enter MunicipalityName :-");
            string MunicipalityName = Console.ReadLine();
            Console.Write("Please Enter Date :-");
            DateTime dateTime = Convert.ToDateTime(Console.ReadLine());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var response = client.GetAsync("TaxCalculation"+"/"+ MunicipalityName + "/" + dateTime + "/" +"Tax");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {

                    var TaxRate = result.Content.ReadAsStringAsync();
                    TaxRate.Wait();
                    Console.WriteLine("Tax Rate of " + MunicipalityName +" :-"+ TaxRate.Result);                   
                }
            }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
    }
}
