using System;
using System.Collections; // For ArrayList Type
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data; // For CommandType Property

// Oracle needed statements:
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace OracleDotNetProjectwithWebService
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        public ArrayList sqlList { get; set; }

        public WebService()
        {
            sqlList = new ArrayList();
        }

        public void populateSQLLIST()
        {
            // Create a connection to Oracle			
            string conString = "User Id=bms;Password=abc;" +
            "Data Source=localhost:1521;";

            using (OracleConnection con = new OracleConnection(conString))
            {

                /*
                    // Test to see if connection is open:
                    if (con.State == ConnectionState.Open) { 
                        // Display Version Number
                        // Console.WriteLine("Connected to Oracle " + con.ServerVersion); 
                    }
                */

                string queryString = "SELECT FIRST_NAME FROM employees";
                OracleCommand cmd = new OracleCommand(queryString, con);
                // cmd.BindByName = true;
                cmd.CommandType = CommandType.Text;

                // Connect with the database, get the data, then close the connection.
                con.Open();

                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sqlList.Add(reader.GetString(0));
                }
                reader.Dispose();
                con.Close();
            }
        } // end of populateSQLLIST method function

        [WebMethod]
        public ArrayList getSQLList()
        {
            populateSQLLIST();
            return sqlList;
        }

        public void insertIntoSQLLIST(string fname)
        {
            // Create a connection to Oracle			
            string conString = "User Id=bms;Password=abc;" +
            "Data Source=localhost:1521;";

            using (OracleConnection con = new OracleConnection(conString))
            {
                // Test to see if connections open:
                /*
                    if (con.State == ConnectionState.Open) { 
                        // Display Version Number
                        // Console.WriteLine("Connected to Oracle " + con.ServerVersion); 
                    }
                */

                // addFirstName is the name of the stored procedure.
                string queryString = "addFirstName";
                OracleCommand cmd = new OracleCommand(queryString, con);
                // cmd.BindByName = true;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("param", fname);

                // Connect with the database, execute the stored procedure, and close the connection
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        } // end of insertIntoSQLLIST method function
    }
}
