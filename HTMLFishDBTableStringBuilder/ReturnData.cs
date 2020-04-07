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

            //Elements[0] = "Fish_Name";
            //Elements[1] = "Fish_Size";
            //Elements[2] = "Fish_Amount";
            //Elements[3] = "Fish_Location";
            //Elements[4] = "Wind_Speed";
            //Elements[5] = "Water_Pressure";
            //Elements[6] = "Month";
            //Elements[7] = "Moon_Cycle";
            //Elements[8] = "Medium";
            //Elements[9] = "Wind_Direction";
            //Elements[10] = "Air_Temperature";
            //Elements[11] = "Time";
            //Elements[12] = "Visibility";
            //Elements[13] = "Water_Temperature";
            //Elements[14] = "Water_Clarity";
            //Elements[15] = "Humidity";
            //Elements[16] = "4hr_air_change";
            //Elements[17] = "4hr_water_change";
            //Elements[18] = "4hr_pressure_change";
            //Elements[19] = "8hr_air_change";
            //Elements[20] = "8hr_water_change";
            //Elements[21] = "8hr_pressure_change";
            //Elements[22] = "24hr_air_change";
            //Elements[23] = "24hr_water_change";
            //Elements[24] = "24hr_pressure_change";
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
