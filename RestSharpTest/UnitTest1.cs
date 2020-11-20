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
        [TestMethod]
        public void TestMethod2()
        {
            List<Contacts> contactList = new List<Contacts>();
            contactList.Add(new Contacts { FirstName = "Stephen", LastName = "Smith", PhoneNo = "6323454579", Address = "Manhattan", City = "New York City", State = "NewYork", Zip = "103431", Email = "ssmith@yahoo.com" });
            contactList.Add(new Contacts { FirstName = "Toby", LastName = "Blair", PhoneNo = "9876546345", Address = "Queens", City = "New York City", State = "New York", Zip = "223400", Email = "tblair@rediffmail.com" });
            //Iterate the loop for each contact
            foreach (var contact in contactList)
            {
                //Initialize the request for POST to add new contact
                RestRequest request = new RestRequest("/contacts/list", Method.POST);
                JsonObject jsonObj = new JsonObject();
                jsonObj.Add("firstname", contact.FirstName);
                jsonObj.Add("lastname", contact.LastName);
                jsonObj.Add("phoneNo", contact.PhoneNo);
                jsonObj.Add("address", contact.Address);
                jsonObj.Add("city", contact.City);
                jsonObj.Add("state", contact.State);
                jsonObj.Add("zip", contact.Zip);
                jsonObj.Add("email", contact.Email);
                //Added parameters to the request object such as the content-type and attaching the jsonObj with the request
                request.AddParameter("application/json", jsonObj, ParameterType.RequestBody);
                //Act
                IRestResponse response = client.Execute(request);
                //Assert
                Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
                Contacts addedContact = JsonConvert.DeserializeObject<Contacts>(response.Content);
                Assert.AreEqual(addedContact.FirstName, contact.FirstName);
                Assert.AreEqual(addedContact.LastName, contact.LastName);
                Assert.AreEqual(addedContact.PhoneNo, contact.PhoneNo);
                Console.WriteLine(response.Content);
            }
        }
    }
}