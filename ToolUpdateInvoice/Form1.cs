using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            try
            {
                string newDomain = txNewDomain.Text;
                string newDataBase = txNewDataBase.Text;

                string pathSampleFolder = ConfigurationManager.AppSettings.Get("pathFolderSample").ToString();
                string pathDesFolder = ConfigurationManager.AppSettings.Get("pathFolder").ToString() + newDomain;
                string pathUse = CopyFolder(pathSampleFolder, pathDesFolder);
                bool replaceDomain = ReplaceInFile(pathUse + @"\wwwroot\env.js", "https://localhost:44383", "https://" + newDomain);

                bool replaceDatabase = ReplaceInFile(pathUse + @"\appsettings.json", "<NameDatabase>", newDataBase);

                string connectionString = ConfigurationManager.AppSettings.Get("connectString").ToString();
                string diskBak = ConfigurationManager.AppSettings.Get("pathFileBak").ToString();
                var a = CreateNewDatabase(connectionString, newDataBase, diskBak);
                MessageBox.Show("Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro");
                throw;
            }
            

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

        public string CopyFolder(string SourcePath, string DestinationPath)
        {
            try
            {
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);

                return DestinationPath;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool CreateNewDatabase(string sqlConnection, string nameDatabase, string diskBak)
        {
            String str;
            SqlConnection myConn = new SqlConnection(sqlConnection);
            str = @"RESTORE FILELISTONLY FROM DISK='" + diskBak + "' " +
                  @"RESTORE DATABASE " + nameDatabase + @" FROM DISK='" + diskBak + "' " +
                "WITH " +
                @"MOVE 'TrungNghiaInvoice' TO 'D:\Database\Invoice\" + nameDatabase + ".mdf'," +
                @"MOVE 'TrungNghiaInvoice_log' TO 'D:\Database\Invoice\" + nameDatabase + ".ldf' ";

            SqlCommand myCommand = new SqlCommand(str, myConn);

            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
