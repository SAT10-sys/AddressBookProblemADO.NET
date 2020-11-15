using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookProblem.ADONET;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {               
        [TestMethod]
        public void TestMethod1()
        {
            //given proper name should return true on correct update
            AddressBookModel addressBookModel = new AddressBookModel();
            AddressRepo addressRepo = new AddressRepo();
            addressBookModel.FirstName = "James";
            addressBookModel.LastName = "Hetfield";
            addressBookModel.PhoneNumber = "9999999999";
            addressBookModel.EmailId = "jameshetfielf@yahoo.com";
            bool result = addressRepo.UpdateContact(addressBookModel);
            Assert.AreEqual(result, true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //given improper name should return false on update
            AddressBookModel addressBookModel = new AddressBookModel();
            AddressRepo addressRepo = new AddressRepo();
            addressBookModel.FirstName = "Jame";
            addressBookModel.LastName = "Hetfield";
            addressBookModel.PhoneNumber = "9999999967";
            addressBookModel.EmailId = "jameshetfielf@yahoo.com";
            bool result = addressRepo.UpdateContact(addressBookModel);
            Assert.AreEqual(result, false);
        }        
    }
}
