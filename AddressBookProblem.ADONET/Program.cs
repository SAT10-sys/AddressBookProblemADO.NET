using System;

namespace AddressBookProblem.ADONET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Problem using .ADONET ");
            AddressRepo addressRepo = new AddressRepo();
            //addressRepo.RetrieveContactsFromDataBase();
            addressRepo.UpdateContact();
            Console.WriteLine("Contact Updated");
        }
    }
}
