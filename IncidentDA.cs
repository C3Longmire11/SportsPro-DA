using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace SportsProDataAccessClassLibrary
{
    public class IncidentDA
    {
        SqlConnection dataBaseConnection = TechSupportDBConnection.GetTechSupportDBConnection();
        public ArrayList RetriveIncidentsWithNoTech()
        {
            ArrayList IncidentsRecords = new ArrayList();

            try
            {
                SqlCommand commandIncidentsNoTech = new SqlCommand();
                commandIncidentsNoTech.CommandText = "SELECT * From[dbo].[vwCAL198_IncidentsNoTech] ";
                commandIncidentsNoTech.CommandType = CommandType.Text;
                commandIncidentsNoTech.Connection = dataBaseConnection;
                dataBaseConnection.Open();

                SqlDataReader objectDataReader = commandIncidentsNoTech.ExecuteReader();
                if (objectDataReader.HasRows)
                {
                    while (objectDataReader.Read())
                    {
                        object[] record = new object[objectDataReader.FieldCount];
                        objectDataReader.GetValues(record);
                        IncidentsRecords.Add(record);
                    }
                    return IncidentsRecords;

                }
                else
                {
                    return null;
                }

            }
            catch(Exception sqlex)
            {
                throw sqlex;
            }
            finally
            {
                dataBaseConnection.Close();
            }
        }

        public ArrayList RetriveOpenIncidents()
        {
            ArrayList IncidentsOpenRecords = new ArrayList();

            try
            {
                SqlCommand commandOpenIncidents = new SqlCommand();
                commandOpenIncidents.CommandText = "SELECT * From [dbo].[vwCAL198_OpenedIncidents] ";
                commandOpenIncidents.CommandType = CommandType.Text;
                commandOpenIncidents.Connection = dataBaseConnection;
                dataBaseConnection.Open();

                SqlDataReader objectDataReader = commandOpenIncidents.ExecuteReader();
                if (objectDataReader.HasRows)
                {
                    while (objectDataReader.Read())
                    {
                        object[] record = new object[objectDataReader.FieldCount];
                        objectDataReader.GetValues(record);
                        IncidentsOpenRecords.Add(record);
                    }
                    return IncidentsOpenRecords;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception sqlex)
            {
                throw sqlex;
            }
            finally
            {
                dataBaseConnection.Close();
            }
        }

        public ArrayList RetriveClosedIncidents()
        {
            ArrayList IncidentsClosedRecords = new ArrayList();

            try
            {
                SqlCommand commandClosedIncidents = new SqlCommand();
                commandClosedIncidents.CommandText = "SELECT * From dbo.vwCAL198_ClosedIncidents ";

                commandClosedIncidents.CommandType = CommandType.Text;
                commandClosedIncidents.Connection = dataBaseConnection;
                dataBaseConnection.Open();

                SqlDataReader objectDataReader = commandClosedIncidents.ExecuteReader();
                if (objectDataReader.HasRows)
                {
                    while (objectDataReader.Read())
                    {
                        object[] record = new object[objectDataReader.FieldCount];

                        objectDataReader.GetValues(record);
                        IncidentsClosedRecords.Add(record);
                    }
                    objectDataReader.Close();
                    return IncidentsClosedRecords;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception sqlex)
            {
                throw sqlex;
            }
        
            finally
            {
                dataBaseConnection.Close();
            }
        }

    }
}
