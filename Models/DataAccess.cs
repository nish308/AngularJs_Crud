using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AngularJs_Crud.Models
{
    public class DataAccess
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConn"].ConnectionString);

        public void Add_record(Register rs)
        {
            SqlCommand com = new SqlCommand("Sp_register", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Email", rs.Email);
            com.Parameters.AddWithValue("@Password", rs.Password);
            com.Parameters.AddWithValue("@Name", rs.Name);
            com.Parameters.AddWithValue("@Address", rs.Address);
            com.Parameters.AddWithValue("@City", rs.City);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }


        public DataSet get_record()
        {
            SqlCommand com = new SqlCommand("Sp_register_get", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }


        public string update_record(Register rs)
        {
            string result = "";

            try
            {
                SqlCommand com = new SqlCommand("Sp_register_Update", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@Sr_no", rs.Sr_no);
                com.Parameters.AddWithValue("@Email", rs.Email);
                com.Parameters.AddWithValue("@Password", rs.Password);
                com.Parameters.AddWithValue("@Name", rs.Name);
                com.Parameters.AddWithValue("@Address", rs.Address);
                com.Parameters.AddWithValue("@City", rs.City);

                con.Open();
                result = com.ExecuteScalar().ToString();
                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error retrieving customers: " + ex.Message);
                con.Close();
            }
            return result;
        }


        public DataSet get_recordbyid(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_byid", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Sr_no", id);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }


        public void deletedata(int id)
        {
            SqlCommand com = new SqlCommand("Sp_register_delete", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Sr_no", id);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}