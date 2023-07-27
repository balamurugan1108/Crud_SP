using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataLayers : IDataLayer
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;


        public DataLayers(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("SP_Database");
        }
        public object getPlayers()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetPlayers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<SPModel> data = new List<SPModel>();
                        while (reader.Read())
                        {
                            SPModel employee = new SPModel()
                            {
                                PlayerID = reader.GetInt32("PlayerID"),
                                PlayerName = reader.GetString("PlayerName"),
                                PlayerAge = reader.GetInt32("PlayerAge"),
                                JerseyNo = reader.GetInt32("JerseyNo"),
                                Address = reader.GetString("Address"),
                            };
                            data.Add(employee);
                        }
                        connection.Close();
                        return data;
                    }
                }
            }
        }

        public object addPlayers(SP_PostModel postDatas)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("AddPlayers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", postDatas.PlayerName);
                    command.Parameters.AddWithValue("@Age", postDatas.PlayerAge);
                    command.Parameters.AddWithValue("@jerseyNo", postDatas.JerseyNo);
                    command.Parameters.AddWithValue("@address", postDatas.Address);
                    command.ExecuteNonQuery();
                    return "Data Successfully Inserted";

                }
            }
        }

        public object updatePlayers(SPModel updateDatas)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdatePlayers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PlayerID", updateDatas.PlayerID);
                    command.Parameters.AddWithValue("@PlayerName", updateDatas.PlayerName);
                    command.Parameters.AddWithValue("@PlayerAge", updateDatas.PlayerAge);
                    command.Parameters.AddWithValue("@JerseyNo", updateDatas.JerseyNo);
                    command.Parameters.AddWithValue("@Address", updateDatas.Address);
                    command.ExecuteNonQuery();
                    return "Data Updated Successfully";
                }
            }
        }

        public object deletePlayers(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DeletePlayers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PlayerID",id);
                    command.ExecuteNonQuery();
                    return "Data Deleted Successfully";
                }
            }
        }
    }
}
