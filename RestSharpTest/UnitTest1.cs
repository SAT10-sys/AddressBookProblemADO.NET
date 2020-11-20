using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestSharpTest
{
    [TestClass]
    public class UnitTest1
    {
        RestClient client;
        [TestInitialize]
        public void SetUp()
        {
            client = new RestClient("http://localhost:3000");
        }
        private IRestResponse GetContactList()
        {
            RestRequest request = new RestRequest("/contacts/list", Method.GET);
            RestSharp.IRestResponse response = client.Execute(request);
            return response;
        }
        [TestMethod]
        public void TestMethod1()
        {
            IRestResponse response = GetContactList();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            List<Contacts> employeeList = JsonConvert.DeserializeObject<List<Contacts>>(response.Content);
            Assert.AreEqual(4, employeeList.Count);
            Console.Write("\nID".PadRight(4) + "FirstName".PadRight(12) + "LastName".PadRight(12) + "Address".PadRight(20));
            Console.Write("City".PadRight(18) + "State".PadRight(12) + "Zip".PadRight(10) + "Phone No.".PadRight(15) + "Email".PadRight(12));
            Console.Write("\n");
            foreach (Contacts contact in employeeList)
            {
                Console.Write(contact.ID.ToString().PadRight(4) + contact.FirstName.PadRight(12) + contact.LastName.PadRight(12));
                Console.Write(contact.Address.PadRight(20) + contact.City.PadRight(18) + contact.State.PadRight(12));
                Console.Write(contact.Zip.PadRight(10) + contact.PhoneNo.PadRight(15) + contact.Email.PadRight(12));
                Console.Write("\n");
            }
        }
    }
}