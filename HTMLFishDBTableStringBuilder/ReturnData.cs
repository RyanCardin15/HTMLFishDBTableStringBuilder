using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HTMLFishDBTableStringBuilder
{
    public class ReturnData
    {
        private readonly string database = "fishdbtest";
        public List<string> Data { get; set; }
        public bool initilized = false;
        public ReturnData()
        {
            Data = Init();
            initilized = true;
        }

        public new List<string> Init()
        {
            MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder();

            connBuilder.Add("Database", database);
            connBuilder.Add("Data Source", "localhost");
            connBuilder.Add("User Id", "root");
            connBuilder.Add("Password", "Rhino1515");

            MySqlConnection connection = new MySqlConnection(connBuilder.ConnectionString);

            MySqlCommand cmd = connection.CreateCommand();

            connection.Open();

            cmd.CommandText = "SELECT * FROM fish";
            cmd.CommandType = CommandType.Text;

            MySqlDataReader reader = cmd.ExecuteReader();
            var elegetter = new BuildTable();

            var Elements = elegetter.GetElements();

            var list = new List<string>();
            while (reader.Read())
            {
                var temp = new StringBuilder();
                for (int i = 0; i < 25; i++)
                {
                    temp.Append(reader[Elements[i]]).Append(",");
                }
                list.Add(temp.ToString());
            }
            connection.Close();
            return list;
        }

    }
}
