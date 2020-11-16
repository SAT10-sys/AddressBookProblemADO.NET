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
            Console.WriteLine("Enter the following information one by one");
            Console.WriteLine("FIRST NAME\nLAST NAME\nADDRESS\nCITY\nSTATE\nZIPCODE\nPHONE NUMBER\nEMAIL ID\nTYPE OF CONTACT\nDATE ADDED");
            addressBookModel.FirstName = Console.ReadLine();
            addressBookModel.LastName = Console.ReadLine();
            addressBookModel.Address= Console.ReadLine();
            addressBookModel.City= Console.ReadLine();
            addressBookModel.State= Console.ReadLine();
            addressBookModel.ZipCode= Console.ReadLine();
            addressBookModel.PhoneNumber= Console.ReadLine();
            addressBookModel.EmailId= Console.ReadLine();
            addressBookModel.BookType= Console.ReadLine();
            addressBookModel.DateAdded = Convert.ToDateTime(Console.ReadLine());
            addressRepo.AddContact(addressBookModel);
            Console.WriteLine("Contact added");

        }
    }
}
