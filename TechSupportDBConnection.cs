using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsProDataAccessClassLibrary
{
    public static class TechSupportDBConnection
    {
        public static SqlConnection GetTechSupportDBConnection()
        {
            SqlConnection dataBaseConnection = new SqlConnection();
            dataBaseConnection.ConnectionString = "Data Source = CISSQL.MATRIX.TXSTATE.EDU\\CIS3325;" +
                " Initial Catalog = TechSupport; " +
                "Integrated Security = true";
            return dataBaseConnection;
        }
    }
}
