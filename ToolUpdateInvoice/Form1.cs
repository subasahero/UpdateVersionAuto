using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolUpdateInvoice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string path = txPath.Text;
            string newDomain = txNewDomain.Text;
            string newDataBase = txNewDataBase.Text;
            System.IO.DirectoryInfo di = new DirectoryInfo(@"" + path);

            foreach (FileInfo file in di.GetFiles())
            {
                string fileName = file.Name;
                if (file.Name != "appsettings.json" && file.Name != "web.config")
                {
                    file.Delete();
                }
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                string folderName = dir.Name;
                if(folderName != "Assets")
                {
                    dir.Delete(true);
                }
            }

            ZipFile.ExtractToDirectory(@"D:\PublicForDemo\PublicForDemo.zip", path);

            bool replaceDomain = ReplaceInFile(path + @"\wwwroot\env.js", "https://localhost:44383", "https://" + newDomain);

            bool replaceDatabase = ReplaceInFile(path + @"\appsettings.json", "BaoAnInvoice", newDataBase);

            MessageBox.Show("update success");
        }

        public bool ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            try
            {
                StreamReader reader = new StreamReader(filePath);
                string content = reader.ReadToEnd();
                reader.Close();
                content = Regex.Replace(content, searchText, replaceText);
                StreamWriter writer = new StreamWriter(filePath);
                writer.Write(content);
                writer.Close();
                return true;



            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
