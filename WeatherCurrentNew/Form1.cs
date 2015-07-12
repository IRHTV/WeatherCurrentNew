using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
namespace WeatherCurrent
{
    public partial class Form1 : Form
    {
        int _TimeOffsetMin = 0;
        string DateTimeStr = "";
        string _XmlFile = "";
        string _XmlFileName = "";
        public Form1()
        {
            InitializeComponent();
        }
        protected bool XmlDownloaderLan()
        {
            try
            {
                string fileDest = System.Configuration.ConfigurationSettings.AppSettings["XmlPath"].Trim();
                if (!Directory.Exists(System.Configuration.ConfigurationSettings.AppSettings["XmlLogDirectory"].Trim()))
                {
                    Directory.CreateDirectory(System.Configuration.ConfigurationSettings.AppSettings["XmlLogDirectory"].Trim());
                }

                try
                {
                    File.Delete(fileDest);
                    richTextBox1.Text += " FILE DELETED:" + fileDest + " \n";
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                }
                catch
                {

                }
                File.Copy(_XmlFile, fileDest);

                richTextBox1.Text += _XmlFile + " COPY TO" + fileDest + " \n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                return true;
                //string fileLog = System.Configuration.ConfigurationSettings.AppSettings["XmlLogDirectory"].Trim() + _XmlFileName + ".xml";
                //File.Copy(_XmlFile, fileLog);

            }
            catch
            {

                return false;
            }
           
        }
        protected bool XmlDownloader()
        {
            try
            {

                // string FilePath = System.Configuration.ConfigurationSettings.AppSettings["FtpFile"].Trim();
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(_XmlFile);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["FtpUserName"].Trim(),
                    System.Configuration.ConfigurationSettings.AppSettings["FtpPassWord"].Trim());

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                FileStream file = File.Create(System.Configuration.ConfigurationSettings.AppSettings["XmlPath"].Trim());
                if (!Directory.Exists(System.Configuration.ConfigurationSettings.AppSettings["XmlLogDirectory"].Trim()))
                {
                    Directory.CreateDirectory(System.Configuration.ConfigurationSettings.AppSettings["XmlLogDirectory"].Trim());
                }
                FileStream fileLog = File.Create(System.Configuration.ConfigurationSettings.AppSettings["XmlLogDirectory"].Trim() + _XmlFileName + ".xml");

                byte[] buffer = new byte[32 * 1024];
                int read;
                FtpWebRequest request2 = (FtpWebRequest)FtpWebRequest.Create(new Uri(_XmlFile));
                request2.Method = WebRequestMethods.Ftp.GetFileSize;
                request2.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["FtpUserName"].Trim(),
                      System.Configuration.ConfigurationSettings.AppSettings["FtpPassWord"].Trim());
                FtpWebResponse result2 = (FtpWebResponse)request2.GetResponse();
                long length = result2.ContentLength;
                progressBar1.Maximum = 100;
                long bfr = 0;
                while ((read = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bfr += read;
                    int Pr = (int)Math.Ceiling(double.Parse(((bfr * 100) / length).ToString()));
                    progressBar1.Value = Pr;
                    file.Write(buffer, 0, read);
                    fileLog.Write(buffer, 0, read);
                    label1.Text = Pr.ToString() + "%";
                    Application.DoEvents();
                }

                file.Close();
                fileLog.Close();
                responseStream.Close();
                response.Close();
                return true;
            }
            catch (Exception Exp)
            {
                richTextBox1.Text += "\n Error Download Xml File " + Exp.Message + " \n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                return false;
            }

        }
        protected void XmlDeleter()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(_XmlFile);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["FtpUserName"].Trim(),
                    System.Configuration.ConfigurationSettings.AppSettings["FtpPassWord"].Trim());

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                response.Close();
            }
            catch (Exception Exp)
            {
                richTextBox1.Text += "\n Error Delete Xml File " + Exp.Message + " \n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();

            }
        }
        public void XmlFinder()
        {
            try
            {
                var list = new List<string>();
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(System.Configuration.ConfigurationSettings.AppSettings["FtpServer"].Trim());
                request.Credentials = new NetworkCredential(System.Configuration.ConfigurationSettings.AppSettings["FtpUserName"].Trim(),
                       System.Configuration.ConfigurationSettings.AppSettings["FtpPassWord"].Trim());
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, true))
                        {
                            while (!reader.EndOfStream)
                            {
                                string FName = reader.ReadLine();
                                if (FName.Contains(System.Configuration.ConfigurationSettings.AppSettings["FtpFile"].Trim()))
                                {
                                    _XmlFile = System.Configuration.ConfigurationSettings.AppSettings["FtpServer"].Trim() + FName;
                                    _XmlFileName = FName;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception Exp)
            {
                richTextBox1.Text += "\n Error Find Xml" + Exp.Message + " \n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();

            }

        }
        protected void FindFile()
        {
            try
            {
                List<string> FileLst = Directory.GetFiles(System.Configuration.ConfigurationSettings.AppSettings["FtpServerLanAddress"].Trim(),
                    System.Configuration.ConfigurationSettings.AppSettings["FtpFile"].Trim() + "*.xml",
                    SearchOption.TopDirectoryOnly).OrderByDescending(f => new FileInfo(f).CreationTime).Select(f => f.ToString()).ToList();

                richTextBox1.Text += "\n FindFileCount: " + FileLst.Count + " \n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();

                if (FileLst.Count > 0)
                {

                   

                    //_XmlFile = System.Configuration.ConfigurationSettings.AppSettings["FtpServer"].Trim() + Path.GetFileName(FileLst[0]);
                    //_XmlFileName = Path.GetFileName(FileLst[0]);


                    _XmlFile = System.Configuration.ConfigurationSettings.AppSettings["FtpServerLanAddress"].Trim()+ Path.GetFileName(FileLst[0]);
                    _XmlFileName = Path.GetFileName(FileLst[0]);

                    richTextBox1.Text += "\n _XmlFile: " + _XmlFile + " \n";
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();


                    richTextBox1.Text += "\n _XmlFileName: " + _XmlFileName + " \n";
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();

                }


            }
            catch (Exception Exp)
            {
                richTextBox1.Text += "\n Error Find XMl File " + Exp.Message + " \n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;


            // timer1.Interval = int.Parse(ConfigurationSettings.AppSettings["RenderIntervalMin"].ToString().Trim()) * 60 * 1000;
            DateTimeStr = string.Format("{0:0000}", DateTime.Now.AddMinutes(_TimeOffsetMin).Year) + "-" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Month) + "-" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Day) + "_" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Hour) + "-" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Minute) + "-" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Second);

            button1.ForeColor = Color.White;
            button1.Text = "Started";
            button1.BackColor = Color.Red;

            richTextBox1.Text = "";

            _XmlFile = "";
            FindFile();

            if (_XmlFile.Length > 2)
            {
                if (XmlDownloaderLan())
                {

                    if (LoadData())
                    {
                        StartRender();
                    }
                    else
                    {
                        richTextBox1.Text += "\n Error Loading Xml File  \n";
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        richTextBox1.ScrollToCaret();
                        Application.DoEvents();
                        timer1.Interval = 10000;
                    }
                }
                else
                {
                    timer1.Interval = 10000;
                }
            }
            else
            {
                richTextBox1.Text += "\n There is no Xml File contains: \n" + System.Configuration.ConfigurationSettings.AppSettings["FtpFile"].Trim();
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                Application.DoEvents();
                timer1.Interval = 10000;
            }

            button1.ForeColor = Color.White;
            button1.Text = "Start";
            button1.BackColor = Color.Navy;
            timer1.Enabled = true;
        }
        protected bool LoadData()
        {
            try
            {
                string XmlFilePath = ConfigurationSettings.AppSettings["XmlPath"].ToString().Trim();
                //Check Xml File is exist or not:
                if (File.Exists(XmlFilePath))
                {
                    richTextBox1.Text += "\n Xml : " + XmlFilePath + "\n";
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                    Application.DoEvents();

                    //Parse Xml file:
                    return XmlParser(XmlFilePath);

                }
                else
                {
                    richTextBox1.Text += "\n Xml file not exist : " + XmlFilePath + "\n";
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                    Application.DoEvents();
                    return false;
                }
            }
            catch (Exception Exp)
            {
                richTextBox1.Text += "\nError : " + Exp.Message + "\n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                return false;
            }


        }
        protected bool XmlParser(string DataXmlPath)
        {
            try
            {
                //Load Cities list:
                XmlDocument XCitiesDoc = new XmlDocument();
                string CitiesXmlPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Cities.xml";

                if (File.Exists(CitiesXmlPath))
                {
                    //String Builder for Data Array:
                    StringBuilder Data = new StringBuilder();
                    Data.Append("Celcius = [");


                    XCitiesDoc.Load(CitiesXmlPath);
                    XmlNodeList CitiesLst = XCitiesDoc.GetElementsByTagName("Location");

                    //Load Data From Meteo Xml:
                    XmlDocument XDoc = new XmlDocument();
                    XDoc.Load(DataXmlPath);
                    foreach (XmlNode Nd in CitiesLst)
                    {
                        //Check Data is Exist in Data Xml File:
                        string query = string.Format("//*[@id='{0}']", Nd.Attributes["id"].Value);
                        XmlElement City = (XmlElement)XDoc.SelectSingleNode(query);
                        if (City != null)
                        {
                            Data.Append("\"" + City.ChildNodes.Item(1).InnerText + "\",");
                            string[] Conds = City.ChildNodes.Item(3).InnerText.Split(',');
                            string StrCond = City.ChildNodes.Item(3).InnerText;
                            if (Conds.Length > 0)
                            {
                                StrCond = Conds[0].Trim();
                            }
                            string CondSource = ConditionFinder(StrCond);
                            if (File.Exists(CondSource))
                            {
                                string CondDest = Nd.Attributes["ConditionPath"].Value.ToString();
                                try
                                {
                                    File.Copy(CondSource, CondDest, true);
                                }
                                catch (Exception Exp)
                                {
                                    richTextBox1.Text += "\n Error Copy Condition File : " + CondDest + "  TO:  " + CondDest + "\n";
                                    richTextBox1.Text += Exp.Message + "\n";
                                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                                    richTextBox1.ScrollToCaret();
                                    return false;
                                }

                            }
                            else
                            {
                                richTextBox1.Text += "\n File not found : " + CondSource + " ** " + City.ChildNodes.Item(3).InnerText + "\n";
                                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                                richTextBox1.ScrollToCaret();
                                Application.DoEvents();
                                return false;
                            }
                        }
                        else
                        {
                            richTextBox1.Text += "\n City not found : " + Nd.Attributes["name"].Value + " Id:" + Nd.Attributes["id"].Value + "\n";
                            richTextBox1.SelectionStart = richTextBox1.Text.Length;
                            richTextBox1.ScrollToCaret();
                            Application.DoEvents();
                            return false;
                        }

                    }
                    if (Data.Length > 11)
                    {
                        Data = Data.Remove(Data.Length - 1, 1);
                    }

                    Data.Append("];");


                    //Create Data Txt File:
                    string DataTxtFile = ConfigurationSettings.AppSettings["DataTxtPath"].ToString().Trim();
                    if (!File.Exists(DataTxtFile))
                    {
                        FileStream Fst = File.Create(DataTxtFile);
                        Fst.Close();
                    }
                    StreamWriter Sw = new StreamWriter(DataTxtFile, false, System.Text.Encoding.UTF8);
                    Sw.Write(Data.ToString());
                    Sw.Close();

                    return true;
                }
                else
                {
                    richTextBox1.Text += "\n There is no file : " + CitiesXmlPath + "\n";
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                    Application.DoEvents();
                    return false;
                }
            }
            catch (Exception Exp)
            {
                richTextBox1.Text += "\n Error Xml : " + Exp.Message + "\n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                return false;
            }

        }
        protected string ConditionFinder(string CondStr)
        {
            //Load Conditions list:
            XmlDocument XConditionDoc = new XmlDocument();
            string ConditionXmlPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Conditions.xml";

            if (File.Exists(ConditionXmlPath))
            {
                XConditionDoc.Load(ConditionXmlPath);
                string query = string.Format("//*[@name='{0}']", CondStr);
                XmlElement Cond = (XmlElement)XConditionDoc.SelectSingleNode(query);
                if (Cond != null)
                {
                    return Cond.Attributes["ConditionFilePath"].Value.ToString();
                }
                else
                {
                    query = string.Format("//*[@name='{0}']", "Sunny");
                    Cond = (XmlElement)XConditionDoc.SelectSingleNode(query);

                    richTextBox2.Text += "\n " + DateTime.Now.AddMinutes(_TimeOffsetMin).ToString() + "  \n";
                    richTextBox2.Text += "\n No Condition : " + CondStr + "\n";
                    richTextBox2.SelectionStart = richTextBox2.Text.Length;
                    richTextBox2.ScrollToCaret();

                    return Cond.Attributes["ConditionFilePath"].Value.ToString();
                }

            }
            else
            {
                return null;
            }
        }
        protected void StartRender()
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "\"" + ConfigurationSettings.AppSettings["AeRenderPath"].ToString().Trim() + "\"";
                DateTimeStr = string.Format("{0:0000}", DateTime.Now.AddMinutes(_TimeOffsetMin).Year) + "-" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Month) + "-" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Day) + "_" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Hour) + "-" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Minute) + "-" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Second);


                try
                {
                    string[] Dirsold = Directory.GetDirectories(ConfigurationSettings.AppSettings["OutputPath"].ToString().Trim());
                    foreach (var item in Dirsold)
                    {
                        DirectoryInfo Dd = new DirectoryInfo(item);
                        if (Dd.CreationTime.AddDays(3) < DateTime.Now.AddMinutes(_TimeOffsetMin))
                            Dd.Delete(true);
                    }

                }
                catch
                {

                }

                DirectoryInfo Dir = new DirectoryInfo(ConfigurationSettings.AppSettings["OutputPath"].ToString().Trim() + string.Format("{0:0000}", DateTime.Now.AddMinutes(_TimeOffsetMin).Year) + "-" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Month) + "-" + string.Format("{0:00}", DateTime.Now.AddMinutes(_TimeOffsetMin).Day));

                if (!Dir.Exists)
                {
                    Dir.Create();
                }


                proc.StartInfo.Arguments = " -project " + "\"" + ConfigurationSettings.AppSettings["AeProjectFile"].ToString().Trim() + "\"" + "   -comp   \"" + ConfigurationSettings.AppSettings["Composition"].ToString().Trim() + "\" -output " + "\"" + Dir + "\\" + ConfigurationSettings.AppSettings["OutPutFileName"].ToString().Trim() + "_" + DateTimeStr + ".mp4" + "\"";
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.EnableRaisingEvents = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;

                if (!proc.Start())
                {
                    return;
                }

                proc.PriorityClass = ProcessPriorityClass.Normal;
                StreamReader reader = proc.StandardOutput;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (richTextBox1.Lines.Length > 10)
                    {
                        richTextBox1.Text = "";
                    }
                    richTextBox1.Text += (line) + " \n";
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                    Application.DoEvents();

                }
                proc.Close();
            }
            catch (Exception Exp)
            {
                richTextBox1.Text += " \n" + Exp + " \n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                Application.DoEvents();
            }



        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] Timesvl = ConfigurationSettings.AppSettings["RenderIntervalMin"].ToString().Trim().Split('#');


            foreach (string item in Timesvl)
            {
                if ((DateTime.Now.AddMinutes(_TimeOffsetMin) >= Convert.ToDateTime(item)) && (DateTime.Now.AddMinutes(_TimeOffsetMin) <= Convert.ToDateTime(item).AddMinutes(5)))
                {
                    timer1.Enabled = false;
                    button1_Click(new object(), new EventArgs());
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _TimeOffsetMin = int.Parse(ConfigurationSettings.AppSettings["TimeOffsetMin"].ToString().Trim());
            timer1.Interval = 3000;
            timer1.Enabled = true;
        }
    }
}
