using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HL7.FHIR_GettingStarted
{
    internal class Program
    {
        private static FhirClient client = new FhirClient("https://stu3.test.pyrohealth.net/fhir");

        static void Main(string[] args)
        {
            Console.WriteLine("This is my first FHIR Client");

            var patient = new Patient()
            {
                Name = new List<HumanName>()
                {
                    new HumanName()
                    {
                        Given = new List<string>{"John","James" },
                        Family = "Doe"
                    }
                },
                Gender = AdministrativeGender.Male,
                BirthDate = "1990-01-01",
                Identifier = new List<Identifier>()
                {
                    new Identifier()
                    {
                        Value = "123456790"
                    }
                }
            };

            client.Create(patient);

            var searchResult = client.Search("Patient", new string[] { "family=Fhirmanaaaa" });

            foreach (var result in searchResult.Entry)
            {
                var pat = result.Resource as Patient;
                Console.WriteLine($"Received patient with {pat.Name[0].Given.FirstOrDefault()}  {pat.Name[0].Family}");
            }


            Console.ReadLine();
        }
    }
}
