using System;

namespace AddressBookProblem.ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Problem using .ADONET ");
            AddressRepo addressRepo = new AddressRepo();
            AddressBookModel addressBookModel = new AddressBookModel();
            //addressRepo.RetrieveContactsFromDataBase();
            Console.WriteLine("Enter the following");
            Console.WriteLine("FIRST NAME\nLAST NAME\nPHONE NUMBER\nEMAIL ID");
            addressBookModel.FirstName= Console.ReadLine();
            addressBookModel.LastName = Console.ReadLine();
            addressBookModel.PhoneNumber = Console.ReadLine();
            addressBookModel.EmailId = Console.ReadLine();
            addressRepo.UpdateContact(addressBookModel);
            Console.WriteLine("Contact Updated");
        }
    }
}
