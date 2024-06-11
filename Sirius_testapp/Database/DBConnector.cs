using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sirius_testapp.Database
{
    public class DBConnector
    {
        private string _connectionString { get; set; }

        //string tmp = "Server = localhost\\SQLEXPRESS;" +
        //                                            "Database=employee;" +
        //                                            "Trusted_Connection=True;";

        public DBConnector(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            }
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public void TestConnection()
        {
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Connection Succesful");

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
