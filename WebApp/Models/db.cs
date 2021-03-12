using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApp.Models;

namespace WebApp.Models
{
    public class db
    {
        SqlConnection conn = new SqlConnection("Server=SE140800\\SQLEXPRESS;Database=BikeStores;Trusted_Connection=True;MultipleActiveResultSets=true");
        public int checkLogin(CustomerIdentity cusIden)
        {
            SqlCommand com = new SqlCommand("sp_Login", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserId", cusIden.UserId);
            com.Parameters.AddWithValue("@Pass", cusIden.Password);
            SqlParameter login = new SqlParameter();
            login.ParameterName = "@isValid";
            login.SqlDbType = SqlDbType.Bit;
            login.Direction = ParameterDirection.Output;
            com.Parameters.Add(login);
            conn.Open();
            com.ExecuteNonQuery();
            int result = Convert.ToInt32(login.Value);
            conn.Close();
            return result;
        }
    }
}
