using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLFishDBTableStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new BuildTable();
            var data = new ReturnData();

            var Elements = table.GetElements();
            var GetData = new ReturnData();
            var list = GetData.Init();
            var htmlStr = table.HtmlDisplayBuilder(Elements, list);

            Console.WriteLine(htmlStr);
        }
    }

    class BuildTable
    {
        public string[] GetElements()
        {
            var elements = new string[25];

            elements[0] = "Fish_Name";
            elements[1] = "Fish_Size";
            elements[2] = "Fish_Amount";
            elements[3] = "Fish_Location";
            elements[4] = "Wind_Speed";
            elements[5] = "Water_Pressure";
            elements[6] = "Month";
            elements[7] = "Moon_Cycle";
            elements[8] = "Medium";
            elements[9] = "Wind_Direction";
            elements[10] = "Air_Temperature";
            elements[11] = "Time";
            elements[12] = "Visibility";
            elements[13] = "Water_Temperature";
            elements[14] = "Water_Clarity";
            elements[15] = "Humidity";
            elements[16] = "4hr_air_change";
            elements[17] = "4hr_water_change";
            elements[18] = "4hr_pressure_change";
            elements[19] = "8hr_air_change";
            elements[20] = "8hr_water_change";
            elements[21] = "8hr_pressure_change";
            elements[22] = "24hr_air_change";
            elements[23] = "24hr_water_change";
            elements[24] = "24hr_pressure_change";

            return elements;
        }

        public StringBuilder HtmlDisplayBuilder(string[] Elements, List<string> list)
        {
            var htmlStr = new StringBuilder();
            htmlStr.Append("<table border = '1'>");
            htmlStr.Append("<tr>");
            foreach (var item in Elements)
            {
                htmlStr.Append("<th>");
                htmlStr.Append(item);
                htmlStr.Append(@"</th>");
            }
            htmlStr.Append(@"</tr>");

            foreach (var item in list)
            {
                var temp = item.Split(',');
                foreach (var e in temp)
                {
                    htmlStr.Append("<td>");
                    htmlStr.Append(e);
                    htmlStr.Append(@"</td>");
                }
                htmlStr.Append(@"</tr>");
            }
            htmlStr.Append(@"</table>");

            return htmlStr;
        }
    }

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
            var Elements = new string[25];

            Elements[0] = "Fish_Name";
            Elements[1] = "Fish_Size";
            Elements[2] = "Fish_Amount";
            Elements[3] = "Fish_Location";
            Elements[4] = "Wind_Speed";
            Elements[5] = "Water_Pressure";
            Elements[6] = "Month";
            Elements[7] = "Moon_Cycle";
            Elements[8] = "Medium";
            Elements[9] = "Wind_Direction";
            Elements[10] = "Air_Temperature";
            Elements[11] = "Time";
            Elements[12] = "Visibility";
            Elements[13] = "Water_Temperature";
            Elements[14] = "Water_Clarity";
            Elements[15] = "Humidity";
            Elements[16] = "4hr_air_change";
            Elements[17] = "4hr_water_change";
            Elements[18] = "4hr_pressure_change";
            Elements[19] = "8hr_air_change";
            Elements[20] = "8hr_water_change";
            Elements[21] = "8hr_pressure_change";
            Elements[22] = "24hr_air_change";
            Elements[23] = "24hr_water_change";
            Elements[24] = "24hr_pressure_change";
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
