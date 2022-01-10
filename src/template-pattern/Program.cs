using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var country = Country.ALL;

            var list = new List<CredentialsValidationsError>();
            
            string password = "Pass12345";
            DateTime dateTime = DateTime.Now;
            string docId = "95470620";
            string alias = "ctevez";

            switch (country)
            {
                case Country.MX:
                    var asd = new Mexico();
                    list = asd.RunValidation(password, dateTime, docId, alias).ToList();
                    break;
                default:
                    var asd2 = new Base();
                    list = asd2.RunValidation(password, dateTime, docId).ToList();
                    break;
            }

            list.ForEach(x => {
                Console.WriteLine($"{x.Rule} {x.Result}");
            });

            Console.ReadLine();
        }
    }
}
