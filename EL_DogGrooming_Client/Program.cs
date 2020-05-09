using EL_DogGrooming_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EL_DogGrooming_Client
{
    class Program
    {
        static async Task GetsClientsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53841/api/Client/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));

                //GET api/ Client / 
                HttpResponseMessage response = await client.GetAsync("all");
                if (response.IsSuccessStatusCode)
                {
                    var returnedClients = await response.Content.ReadAsAsync<IEnumerable<Client>>();
                    Console.WriteLine("*** Complete Client List ****");
                    foreach (Client clnt in returnedClients)
                    {
                        Console.WriteLine(clnt);
                    }
                }

                //GET api/ Client /{ id}
                response = await client.GetAsync("1");
                if (response.IsSuccessStatusCode)
                {
                    var returnedClients = await response.Content.ReadAsAsync<Client>();
                    Console.WriteLine("\nClient with id 1: " + returnedClients);
                }

                //GET api/ Client /names
                response = await client.GetAsync("names");
                if (response.IsSuccessStatusCode)
                {
                    var returnedClients = await response.Content.ReadAsAsync<IEnumerable<String>>();
                    Console.WriteLine("\n* Returned Names *");
                    foreach (var item in returnedClients)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }


                //POST api/ Client / AddClient
                Client c1 = new Client() { Id = 4, Name = "Mary Rose", DogName = "Finn", Phone = "0869876543", Email = "maryrose@rathfarnham.ie"};
                response = client.PostAsJsonAsync("AddClient", c1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nClient added: " + c1.Name);
                }

                //PUT api/ Client / UpdateClient
                Client c2 = new Client() { Id = 4, Name = "Mary Rose", DogName = "Polly", Phone = "0869876543", Email = "maryrose@rathfarnham.ie"};
                response = client.PutAsJsonAsync("UpdateClient", c2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated client: " + c2.Name + " dog name changed to " + c2.DogName);
                }

                //DELETE api/ Client / DeleteClient
                response = client.DeleteAsync("DeleteClient/2").Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nClient deleted");
                }
                else
                {
                    Console.WriteLine("\nDelete - " + response.StatusCode + " " + response.ReasonPhrase);
                }

            }
        }

        /********************     SERVICES     ************************/

        static async Task GetsServicesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53841/api/Service/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));

                //GET api/ Service / 
                HttpResponseMessage response = await client.GetAsync("all");
                if (response.IsSuccessStatusCode)
                {
                    var returnedServices = await response.Content.ReadAsAsync<IEnumerable<Service>>();
                    Console.WriteLine("\n*** Complete Service List ****");
                    foreach (Service srv in returnedServices)
                    {
                        Console.WriteLine(srv);
                    }
                }

                //GET api/ Service / { id}
                response = await client.GetAsync("101");
                if (response.IsSuccessStatusCode)
                {
                    var returnedServices = await response.Content.ReadAsAsync<Service>();
                    Console.WriteLine("\nService with Code 101: " + returnedServices);
                }

                //GET api/ Service / descriptions
                response = await client.GetAsync("descriptions");
                if (response.IsSuccessStatusCode)
                {
                    var returnedServices = await response.Content.ReadAsAsync<IEnumerable<String>>();
                    Console.WriteLine("\n* Returned Descriptions *");
                    foreach (var item in returnedServices)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }


                //POST api/ Service / AddService
                Service s1 = new Service() { Code = 104, Description = "Tail Braiding", Price = 5 };
                response = client.PostAsJsonAsync("AddService", s1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nService added: " + s1.Description);
                }

                //PUT api/ Service / UpdateService
                Service s2 = new Service() { Code = 104, Description = "Tail Braiding", Price = 15 };
                response = client.PutAsJsonAsync("UpdateService", s2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nService updated: " + s2.Description + " increasing price to E" + s2.Price);
                }

            }
        }

        //Run program
        static void Main()
        {
            GetsClientsAsync().Wait();
            GetsServicesAsync().Wait();
            Console.ReadLine();
        }
    }
}