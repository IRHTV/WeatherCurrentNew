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


                    _XmlFile = System.Configuration.ConfigurationSettings.AppSettings["FtpServerLanAddress"].Trim() + Path.GetFileName(FileLst[0]);
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

                //Check Xml File is exist or not:
                if (File.Exists(_XmlFile))
                {
                    richTextBox1.Text += "\n Xml : " + _XmlFile + "\n";
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                    Application.DoEvents();

                    //Parse Xml file:
                    return XmlParser(_XmlFile);

                }
                else
                {
                    richTextBox1.Text += "\n Xml file not exist : " + _XmlFile + "\n";
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

            //TODO:
            try
            {
                //Load Cities list:
                XmlDocument XCitiesDoc = new XmlDocument();
                string CitiesXmlPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Cities.xml";

                if (File.Exists(CitiesXmlPath))
                {
                    //String Builder for Data Array:
                    StringBuilder Data = new StringBuilder();
                    //Data.Append("Celcius = [");


                    XCitiesDoc.Load(CitiesXmlPath);
                    XmlNodeList CitiesLst = XCitiesDoc.GetElementsByTagName("Location");

                    //Load Data From Meteo Xml:
                    XmlDocument XDoc = new XmlDocument();
                    XDoc.Load(DataXmlPath);
                    int cityIndex = 1;
                    foreach (XmlNode Nd in CitiesLst)
                    {
                        //Check Data is Exist in Data Xml File:
                        string query = string.Format("//*[@id='{0}']", Nd.Attributes["id"].Value);
                        XmlElement City = (XmlElement)XDoc.SelectSingleNode(query);
                        if (City != null)
                        {
                            Data.Append("City" + cityIndex + " = [");
                            Data.Append("\"" + City.Attributes["name"].Value + "\",");
                            Data.Append("\"" + City.ChildNodes.Item(1).InnerText + "\",");
                            string[] Conds = City.ChildNodes.Item(3).InnerText.Split(',');
                            string StrCond = City.ChildNodes.Item(3).InnerText;
                            //if (Conds.Length > 0)
                            //{
                            //    StrCond = Conds[0].Trim();
                            //}

                            Data.Append(ConditionFinder(StrCond));
                        }
                        else
                        {
                            richTextBox1.Text += "\n City not found : " + Nd.Attributes["name"].Value + " Id:" + Nd.Attributes["id"].Value + "\n";
                            richTextBox1.SelectionStart = richTextBox1.Text.Length;
                            richTextBox1.ScrollToCaret();
                            Application.DoEvents();
                            return false;
                        }
                        Data.Append("]\r\n");
                        cityIndex++;
                    }
                    if (Data.Length > 11)
                    {
                        Data = Data.Remove(Data.Length - 1, 1);
                    }




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
            string retCondition = "'0','100','0','0','0','0','0'";

            if(CondStr.ToLower().Contains("sun"))
            {
                return "'0','100','0','0','0','0','0'";
            }
            if (CondStr.ToLower().Contains("cloud"))
            {
                return "'0','0','0','100','0','0','0'";
            }
            if (CondStr.ToLower().Contains("show"))
            {
                return "'0','0','100','0','0','0','0'";
            }
            if (CondStr.ToLower().Contains("fog"))
            {
                return "'0','0','0','0','0','0','100'";
            }
            if (CondStr.ToLower().Contains("rain"))
            {
                return "'0','0','100','0','0','0','0'";
            }
            if (CondStr.ToLower().Contains("clear"))
            {
                return "'0','100','0','0','0','0','0'";
            }
            if (CondStr.ToLower().Contains("thunder"))
            {
                return "'0','0','0','0','0','0','100'";
            }
            if (CondStr.ToLower().Contains("snow"))
            {
                return "'0','0','0','0','100','0','0'";
            }
            if (CondStr.ToLower().Contains("snow"))
            {
                return "'0','0','0','0','100','0','0'";
            }
            if (CondStr.ToLower().Contains("snow"))
            {
                return "'0','0','0','0','100','0','0'";
            }
            if (CondStr.ToLower().Contains("snow"))
            {
                return "'0','0','0','0','100','0','0'";
            }
            if (CondStr.ToLower().Contains("snow"))
            {
                return "'0','0','0','0','100','0','0'";
            }


            //switch (CondStr)
            //{
            //    case "partly cloudy":
            //        retCondition = "'0','0','0','100','0','0','0'";
            //        break;
            //    case "cloudy":
            //        retCondition = "'0','0','0','0','0','0','100'";
            //        break;
            //    case "light showers":
            //        retCondition = "'0','0','100','0','0','0','0'";
            //        break;
            //    case "fog":
            //        retCondition = "'0','0','0','0','0','0','100'";
            //        break;
            //    case "overcast":
            //        retCondition = "'0','0','100','0','0','0','0'";
            //        break;
            //    case "fair weather":
            //        retCondition = "'0','0','0','100','0','0','0'";
            //        break;
            //    case "heavy rain":
            //        retCondition = "'0','0','100','0','0','0','0'";
            //        break;
            //    case "clear sky":
            //        retCondition = "'0','100','0','0','0','0','0'";
            //        break;
            //    case "sunny":
            //        retCondition = "'0','100','0','0','0','0','0'";
            //        break;
            //    case "light rain":
            //        retCondition = "'0','0','100','0','0','0','0'";
            //        break;
            //    case "rain":
            //        retCondition = "'0','0','100','0','0','0','0'";
            //        break;
            //    case "heavy showers":
            //        retCondition = "'0','0','100','0','0','0','0'";
            //        break;
            //    case "thunderstorms possible":
            //        retCondition = "'0','0','0','0','0','0','100'";
            //        break;
            //    case "snowfall":
            //        retCondition = "'0','0','0','0','100','0','0'";
            //        break;
            //    case "some snow":
            //        retCondition = "'0','0','0','0','100','0','0'";
            //        break;
            //    case "snow flakes":
            //        retCondition = "'0','0','0','0','100','0','0'";
            //        break;
            //    case "light snowfall":
            //        retCondition = "'0','0','0','0','100','0','0'";
            //        break;
            //    case "light sleet":
            //        retCondition = "'0','0','0','100','0','0','0'";
            //        break;
            //    default:
            //        retCondition = "'0','100','0','0','0','0','0'";
            //        break;
            //}
            return retCondition;
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
