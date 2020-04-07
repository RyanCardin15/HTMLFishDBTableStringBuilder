using System.Collections.Generic;
using System.Text;

namespace HTMLFishDBTableStringBuilder
{
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
}
