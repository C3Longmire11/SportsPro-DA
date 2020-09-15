using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsProDataAccessClassLibrary
{
    public class CustomerDA
    {
        SqlConnection dataBaseConnection = TechSupportDBConnection.GetTechSupportDBConnection();
        public CustomerDA() { }

        public ArrayList RetrieveAllCustomers()
        {
            
            ArrayList dataBaseRecords = new ArrayList();

            try
            {
                SqlCommand commandAllCustomers = new SqlCommand();
                commandAllCustomers.CommandText = "Select [CustomerID], [Name], [Address], [City], [State], [ZipCode], [Phone], [EMail]" +
                    "from [dbo].[Customers]";
                commandAllCustomers.CommandType = CommandType.Text;
                commandAllCustomers.Connection = dataBaseConnection;
                dataBaseConnection.Open();

                SqlDataReader objectDataReader = commandAllCustomers.ExecuteReader();
                if (objectDataReader.HasRows)
                {
                    while(objectDataReader.Read())
                    {
                        object[] record = new object[objectDataReader.FieldCount];
                        objectDataReader.GetValues(record);
                        dataBaseRecords.Add(record);
                    }
                    return dataBaseRecords;
                    
                }
                else
                {
                    return null;
                }

            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataBaseConnection.Close();
            }
        }

        public object[] RetrieveCustomerByID(Int32 customerID)
        {
            
            Object objCustomer = new Object();


            try
            {
                SqlCommand commandCustomerID = new SqlCommand();
                commandCustomerID.CommandText = "Select [CustomerID], [Name], [Address], [City], [State], [ZipCode], [Phone], [EMail]" +
                    "from [dbo].[Customers] where [CustomerID] = @custID ";
                commandCustomerID.CommandType = CommandType.Text;
                commandCustomerID.Parameters.AddWithValue("@custID", customerID);
                commandCustomerID.Connection = dataBaseConnection;
                dataBaseConnection.Open();

                SqlDataReader objectDataReader = commandCustomerID.ExecuteReader(CommandBehavior.SingleRow);
                if (objectDataReader.HasRows)
                {
                    objectDataReader.Read();
                    object[] record = new object[objectDataReader.FieldCount];
                    objectDataReader.GetValues(record);


                    return record;

                }
                else
                {
                    return null;
                }

            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataBaseConnection.Close();
            }
        }

        public Int32 DeleteCustomer(Int32 customerID)
        {
            try
            {
                SqlCommand comandDeleteCustomer = new SqlCommand();

                comandDeleteCustomer.CommandText = "Delete from [dbo].[customers] where CustomerID = @custID";
                comandDeleteCustomer.CommandType = CommandType.Text;
                comandDeleteCustomer.Parameters.AddWithValue("@custID", customerID);
                comandDeleteCustomer.Connection = dataBaseConnection;
                dataBaseConnection.Open();

                Int32 numberOfRecordsDeleted = comandDeleteCustomer.ExecuteNonQuery();
                return numberOfRecordsDeleted;

            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataBaseConnection.Close();
            }
        }

        public Int32 InsertCustomer(Object[] aCustomer)
        {
            try
            {
                SqlCommand commandAddCustomer = new SqlCommand();

                commandAddCustomer.CommandText = "Insert Into [dbo].[customers] ([Name], [Address], [City], [State], [ZipCode], [Phone], [EMail]) values (@name, @address, @city, @state, @zipCode, @phone, @email)";
                commandAddCustomer.CommandType = CommandType.Text;
                commandAddCustomer.Parameters.AddWithValue("@name", Convert.ToString(aCustomer[0]));
                commandAddCustomer.Parameters.AddWithValue("@address", Convert.ToString(aCustomer[1]));
                commandAddCustomer.Parameters.AddWithValue("@city", Convert.ToString(aCustomer[2]));
                commandAddCustomer.Parameters.AddWithValue("@state", Convert.ToString(aCustomer[3]));
                commandAddCustomer.Parameters.AddWithValue("@zipCode", Convert.ToString(aCustomer[4]));
                commandAddCustomer.Parameters.AddWithValue("@phone", Convert.ToString(aCustomer[5]));
                commandAddCustomer.Parameters.AddWithValue("@email", Convert.ToString(aCustomer[6]));

                commandAddCustomer.Connection = dataBaseConnection;
                dataBaseConnection.Open();


                Int32 numberOfRecordsAdded = commandAddCustomer.ExecuteNonQuery();
                if (numberOfRecordsAdded != 0)
                {
                    SqlCommand commandNewCustomerID = new SqlCommand();
                    commandNewCustomerID.CommandText = "SELECT IDENT_CURRENT ('customers') FROM dbo.customers";
                    commandNewCustomerID.CommandType = CommandType.Text;
                    commandNewCustomerID.Connection = dataBaseConnection;
                    

                    Int32 newCustomerID = Convert.ToInt32(commandNewCustomerID.ExecuteScalar());
                    return newCustomerID;

                }
                else
                {
                    return 0;
                }

            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dataBaseConnection.Close();
            }

        }
    }
}
