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
        public bool RetrieveContactsFromDataBase()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select * from AddressBookTable;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressBookModel addressBookModel = new AddressBookModel();
                            addressBookModel.FirstName = dr.GetString(0);
                            addressBookModel.LastName = dr.GetString(1);
                            addressBookModel.Address = dr.GetString(2);
                            addressBookModel.City = dr.GetString(3);
                            addressBookModel.State = dr.GetString(4);
                            addressBookModel.ZipCode = dr.GetString(5);
                            addressBookModel.PhoneNumber = dr.GetString(6);
                            addressBookModel.EmailId = dr.GetString(7);
                            addressBookModel.BookName = dr.GetString(8);
                            addressBookModel.BookType = dr.GetString(9);
                            Console.WriteLine(addressBookModel.FirstName + "\t" + addressBookModel.LastName + "\t" + addressBookModel.Address + "\t" + addressBookModel.City + "\t" + addressBookModel.State + "\t" + addressBookModel.ZipCode + "\t" + addressBookModel.PhoneNumber + "\t" + addressBookModel.EmailId + "\t" + addressBookModel.BookName + "\t" + addressBookModel.BookType);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                        System.Console.WriteLine("No data found");
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public bool UpdateContact(AddressBookModel addressBookModel)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"update Contact set PhoneNumber='" + addressBookModel.PhoneNumber + "', EmailId= '" + addressBookModel.EmailId + "' where FirstName= '" + addressBookModel.FirstName + "' and LastName= '" + addressBookModel.LastName + "'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                        return true;
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public void GetContactsInDateRange(string startDate)
        {
            AddressBookModel addressBookModel = new AddressBookModel();
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select * from Contact where DateAdded between '" + startDate + "' and GETDATE();";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            addressBookModel.FirstName = dr.GetString(0);
                            addressBookModel.LastName = dr.GetString(1);
                            addressBookModel.Address = dr.GetString(2);
                            addressBookModel.City = dr.GetString(3);
                            addressBookModel.State = dr.GetString(4);
                            addressBookModel.ZipCode = dr.GetString(5);
                            addressBookModel.PhoneNumber = dr.GetString(6);
                            addressBookModel.EmailId = dr.GetString(7);
                            addressBookModel.BookName = dr.GetString(8);
                            addressBookModel.BookType = dr.GetString(9);
                            addressBookModel.DateAdded = Convert.ToDateTime(dr.GetString(10));
                            Console.WriteLine(addressBookModel.FirstName + "\t" + addressBookModel.LastName + "\t" + addressBookModel.Address + "\t" + addressBookModel.City + "\t" + addressBookModel.State + "\t" + addressBookModel.ZipCode + "\t" + addressBookModel.PhoneNumber + "\t" + addressBookModel.EmailId + "\t" + addressBookModel.BookName + "\t" + addressBookModel.BookType + "\t" + addressBookModel.DateAdded);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                        Console.WriteLine("No contacts found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void GetCountByCityOrState()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("GetCountByCityState", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string state = dr.GetString(0);
                            string city = dr.GetString(1);
                            int count = dr.GetInt32(2);
                            Console.WriteLine(state + "\t" + city + "\t" + count);
                        }
                    }
                    else
                        Console.WriteLine("No data");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool AddContact(AddressBookModel addressBookModel)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpAddContactDetails", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", addressBookModel.FirstName);
                    command.Parameters.AddWithValue("@LastName", addressBookModel.LastName);
                    command.Parameters.AddWithValue("@PhoneNumber", addressBookModel.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", addressBookModel.EmailId);
                    command.Parameters.AddWithValue("@DateAdded", addressBookModel.DateAdded);
                    command.Parameters.AddWithValue("@Contact_Type", addressBookModel.BookType);
                    command.Parameters.AddWithValue("@Address", addressBookModel.Address);
                    command.Parameters.AddWithValue("@City", addressBookModel.City);
                    command.Parameters.AddWithValue("@State", addressBookModel.State);
                    command.Parameters.AddWithValue("@Zipcode", addressBookModel.ZipCode);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                        return true;
                    else 
                        return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}           