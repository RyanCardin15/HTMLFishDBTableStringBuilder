using System;
using System.IO;
using System.Linq;
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

            string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "HTMLBuilt.html")))
            {
                outputFile.WriteLine(htmlStr);
            }
            
        }
    }
}
