using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AddressBookProblem.ADONET
{
    public class AddressRepo
    {
        public static string connectionString = @"Data Source=.;Initial Catalog=AddressBookADONET;Integrated Security=True";
        SqlConnection connection;
        public void RetrieveContactsFromDataBase()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                AddressBookModel addressBookModel = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"select * from AddressBookTable;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            addressBookModel.FirstName = dr.GetString(0);
                            addressBookModel.LastName = dr.GetString(1);
                            addressBookModel.Address= dr.GetString(2);
                            addressBookModel.City= dr.GetString(3);
                            addressBookModel.State= dr.GetString(4);
                            addressBookModel.ZipCode= dr.GetString(5);
                            addressBookModel.PhoneNumber= dr.GetString(6);
                            addressBookModel.EmailId= dr.GetString(7);
                            addressBookModel.BookName= dr.GetString(8);
                            addressBookModel.BookType= dr.GetString(9);
                            Console.WriteLine(addressBookModel.FirstName+"\t"+addressBookModel.LastName+"\t"+addressBookModel.Address+"\t"+addressBookModel.City+"\t"+addressBookModel.State+"\t"+addressBookModel.ZipCode+"\t"+addressBookModel.PhoneNumber+"\t"+addressBookModel.EmailId+"\t"+addressBookModel.BookName+"\t"+addressBookModel.BookType);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                        System.Console.WriteLine("No data found");
                }
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool UpdateContact()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (this.connection)
                {
                    string query = @"update AddressBookTable set address='Newark' where firstName='Kirk';";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                        return true;
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
    }
}
