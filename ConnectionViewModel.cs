using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    public class ConnectionViewModel
    {

        string ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Name;Data Source=LAPTOP-PJRIF9P6;encrypt = False";
        public string ProQuery { get; set; }
        public int Query()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(ProQuery, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            int q = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return q;
        }
        public SqlDataAdapter dataset()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = ProQuery;
            object q = sqlCommand.ExecuteScalar();
            SqlDataAdapter data = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            data.Fill(dataSet);
            sqlConnection.Close();
            return data;

        }
    }
}
