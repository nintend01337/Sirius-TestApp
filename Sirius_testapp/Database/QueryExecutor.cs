using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sirius_testapp.Database
{
    public class QueryExecutor
    {
        private DBConnector _connector;
        public QueryExecutor(DBConnector conn)
        {
            _connector = conn;
        }
        public DataSet GetDataSetFromStoredProcedure(string storedProcedureName)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = _connector.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataSet);
                }
            }
            return dataSet;
        }

        public Dictionary<int, string> GetStatusList()
        {
            string querry = "SELECT id, name FROM dbo.status";

            using (SqlConnection connection = _connector.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(querry, connection);
                SqlDataReader reader = command.ExecuteReader();

                Dictionary<int, string> statusList = new Dictionary<int, string>();
                while (reader.Read())
                {
                    statusList.Add(reader.GetInt32(0), reader.GetString(1));
                }

                return statusList;

            }

        }

        public DataTable GetEmployeeStatistics(int statusId, DateTime startDate, DateTime endDate, bool isEmployed)
        {
            string connectionString = _connector.GetConnectionString();
            string procedureName = "GetEmployeeStatistics";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(procedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@status_id", statusId);
                command.Parameters.AddWithValue("@start_date", startDate);
                command.Parameters.AddWithValue("@end_date", endDate);
                command.Parameters.AddWithValue("@is_employed", isEmployed);

                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }

        }
    }
}