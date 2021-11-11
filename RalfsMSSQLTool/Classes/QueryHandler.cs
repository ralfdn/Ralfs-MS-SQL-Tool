using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RalfsMSSQLTool.Classes
{
    public class QueryHandler
    {
        #region Constructors
        public QueryHandler()
        {

        }
        #endregion Constructors

        #region Methods
        public DataTable ExecuteQuery(string query, SqlConnection connection)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand($"{query}", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            data.Load(reader);
            reader.Close();
            connection.Close();
            return data;
        }
        #endregion Methods
    }
}
