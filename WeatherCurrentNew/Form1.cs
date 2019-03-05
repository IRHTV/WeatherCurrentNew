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
        public Form1()
        {
            InitializeComponent();
        }
        public Cities getData(Cities ct)
        {

            try
            {
                Logger(ct.Name);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://artgroup.feeds.meteonews.net/forecasts/geonames/" + ct.Code.Replace("G", "") + ".xml?cumulation=3h&begin=" + DateTime.Now.AddHours(-8).ToString("yyyy-MM-dd HH:mm") + @"&end=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "&lang=en");
                request.Credentials = new System.Net.NetworkCredential("artgroup", "Ar+HIspGr0p");
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader readerResult = new StreamReader(stream);

                var result = readerResult.ReadToEnd();
                stream.Dispose();
                readerResult.Dispose();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(result);


                XmlNodeList elemListMin = xmlDoc.GetElementsByTagName("temp_min");
                if (elemListMin.Count > 0)
                {
                    ct.Min = elemListMin[0].InnerText;
                    Logger("Min1:" + ct.Min);
                }

                XmlNodeList elemListMax = xmlDoc.GetElementsByTagName("temp_max");
                if (elemListMax.Count > 0)
                {
                    ct.Max = elemListMax[0].InnerText;
                    Logger("Max1:" + ct.Max);
                }

                XmlNodeList elemListavg = xmlDoc.GetElementsByTagName("temp_avg");
                if (elemListavg.Count > 0)
                {
                    ct.Avg = elemListavg[elemListavg.Count - 1].InnerText;
                    Logger("Avg: " + ct.Avg);
                }
                XmlNodeList elemListWind = xmlDoc.GetElementsByTagName("windforce");
                if (elemListWind.Count > 0)
                {
                    ct.Wind = elemListWind[elemListWind.Count - 1].InnerText;
                    Logger("Wind: " + ct.Wind);
                }
                XmlNodeList elemListHum = xmlDoc.GetElementsByTagName("hum");
                if (elemListHum.Count > 0)
                {
                    ct.Hum = elemListHum[elemListHum.Count - 1].InnerText;
                    Logger("Hum: " + ct.Hum);
                }
                XmlNodeList elemListState = xmlDoc.GetElementsByTagName("txt");
                if (elemListState.Count > 0)
                {
                    ct.State = elemListState[elemListavg.Count - 1].InnerText;
                    Logger("State:" + ct.State);
                }

            }
            catch (Exception Exp)
            {
                ct.Max = "0";
                ct.Max2 = "0";
                ct.Min = "0";
                ct.Min2 = "0";
                ct.State = "0";
                ct.State2 = "0";
                ct.Avg = "0"; ;
                richTextBox1.Text += Exp.Message + "  \n";
            }


            return ct;
        }
        protected void Logger(string log)
        {
            try
            {
                if (richTextBox1.Lines.Length > 400)
                {
                    richTextBox1.Text = "";
                }
                richTextBox1.Text += "[" + DateTime.Now.ToString() + "] " + (log) + " \n ======================= \n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                Application.DoEvents();
            }
            catch { }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1.ForeColor = Color.White;
            button1.Text = "Started";
            button1.BackColor = Color.Red;

            List<Cities> Cts = new List<Cities>();
            Cts.Add(new Cities { Name = "Asunción", Code = "G8873978" });
            Cts.Add(new Cities { Name = "Beirut", Code = "G276781" });
            Cts.Add(new Cities { Name = "Berlín", Code = "G2950159" });
            Cts.Add(new Cities { Name = "Bogotá", Code = "G3688689" });
            Cts.Add(new Cities { Name = "Brasilia", Code = "G3469058" });
            Cts.Add(new Cities { Name = "BUENOS AIRES", Code = "G3435910" });
            Cts.Add(new Cities { Name = "Caracas", Code = "G3660401" });
            Cts.Add(new Cities { Name = "Damasco", Code = "G170654" });
            Cts.Add(new Cities { Name = "EL Cairo", Code = "G8869792" });
            Cts.Add(new Cities { Name = "Guatemala", Code = "G3557556" });
            Cts.Add(new Cities { Name = "La Habana", Code = "G3553478" });
            Cts.Add(new Cities { Name = "La Paz", Code = "G4000900" });
            Cts.Add(new Cities { Name = "Lima", Code = "G3437846" });
            Cts.Add(new Cities { Name = "Londres", Code = "G8893550" });
            Cts.Add(new Cities { Name = "Los Ángeles", Code = "G5368361" });
            Cts.Add(new Cities { Name = "Madrid", Code = "G3117735" });
            Cts.Add(new Cities { Name = "Managua", Code = "G3617763" });
            Cts.Add(new Cities { Name = "México D.F", Code = "G3530597" });
            Cts.Add(new Cities { Name = "Miami", Code = "G4164138" });
            Cts.Add(new Cities { Name = "Montevideo", Code = "G3441575" });
            Cts.Add(new Cities { Name = "Moscú", Code = "G524901" });
            Cts.Add(new Cities { Name = "Panamá (ciudad)", Code = "G3703443" });
            Cts.Add(new Cities { Name = "Puerto Príncipe", Code = "G3718426" });
            Cts.Add(new Cities { Name = "Quito", Code = "G3652462" });
            Cts.Add(new Cities { Name = "San José", Code = "G3621841" });
            Cts.Add(new Cities { Name = "San Juan", Code = "G4568127" });
            Cts.Add(new Cities { Name = "San Salvador", Code = "G3583361" });
            Cts.Add(new Cities { Name = "Santiago", Code = "G3871336" });
            Cts.Add(new Cities { Name = "Santo Domingo", Code = "G3492908" });
            Cts.Add(new Cities { Name = "Tegucigalpa", Code = "G3600949" });
            Cts.Add(new Cities { Name = "Teherán", Code = "G112931" });
            Cts.Add(new Cities { Name = "Washington", Code = "G4140963" });

            List<Cities> CtsFinal = new List<Cities>();
            foreach (var item in Cts)
            {
                CtsFinal.Add(getData(item));
            }

            StringBuilder Data = new StringBuilder();           
            int cityIndex = 1;
            foreach (Cities Nd in CtsFinal)
            {
                Data.Append("City" + cityIndex + " = [");
                Data.Append("\"" + Nd.Name + "\",");
                Data.Append("\"" + Nd.Min + "\",");
                Data.Append(ConditionFinder(Nd.State));               
                Data.Append("]\r\n");
                cityIndex++;
            }
            if (Data.Length > 11)
            {
                Data = Data.Remove(Data.Length - 1, 1);
            }
            string DataTxtFile = ConfigurationSettings.AppSettings["DataTxtPath"].ToString().Trim();
            if (!File.Exists(DataTxtFile))
            {
                FileStream Fst = File.Create(DataTxtFile);
                Fst.Close();
            }
            StreamWriter Sw = new StreamWriter(DataTxtFile, false, System.Text.Encoding.UTF8);
            Sw.Write(Data.ToString());
            Sw.Close();

            Logger("Start Job");
            render();
            Convert();

            button1.ForeColor = Color.White;
            button1.Text = "Start";
            button1.BackColor = Color.Navy;
            timer1.Interval = 120000;
            timer1.Enabled = true;
        }
       
        protected string ConditionFinder(string CondStr)
        {
            string retCondition = "'0','0','0','0','0','0','0'";

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
            if (CondStr.ToLower().Contains("fair"))
            {
                return "'0','100','0','0','0','0','0'";
            }
            if (CondStr.ToLower().Contains("overcast"))
            {
                return "'0','0','0','100','0','0','0'";
            }
            if (CondStr.ToLower().Contains("-"))
            {
                return "'0','100','0','0','0','0','0'";
            }

            return retCondition;
        }
        public void Convert()
        {
            string DateTimeStr = string.Format("{0:0000}", DateTime.Now.Year) + "-" + string.Format("{0:00}", DateTime.Now.Month) + "-" + string.Format("{0:00}", DateTime.Now.Day) + "_" + string.Format("{0:00}", DateTime.Now.Hour) + "-" + string.Format("{0:00}", DateTime.Now.Minute) + "-" + string.Format("{0:00}", DateTime.Now.Second);
            DirectoryInfo Dir = new DirectoryInfo(ConfigurationSettings.AppSettings["OutputPath"].ToString().Trim());
            Dir.Create();
            string DestFile = ConfigurationSettings.AppSettings["OutputPath"].ToString().Trim() + ConfigurationSettings.AppSettings["OutPutFileName"].ToString().Trim() + "_" + DateTimeStr + ".mp4";
            string SourceFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + ConfigurationSettings.AppSettings["OutPutFileName"].ToString().Trim() + ".mov";

            Process proc = new Process();
            proc.StartInfo.FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\ffmpeg";
            proc.StartInfo.Arguments = "-y -i " + SourceFile + "   -vcodec h264 -acodec aac   \"" + DestFile + "\"";
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.EnableRaisingEvents = true;
            proc.Start();
            StreamReader reader = proc.StandardError;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Logger(line);
            }
            try
            {
                string StaticDestFileName = ConfigurationSettings.AppSettings["ScheduleDestFileName"].ToString().Trim();
                // File.Delete(StaticDestFileName);
                File.Copy(ConfigurationSettings.AppSettings["OutputPath"].ToString().Trim() + ConfigurationSettings.AppSettings["OutPutFileName"].ToString().Trim() + "_" + DateTimeStr + ".mp4", StaticDestFileName, true);
                Logger("COPY FINAL:" + StaticDestFileName);

            }
            catch (Exception Ex)
            {
                Logger(Ex.Message);
            }
        }
        protected void render()
        {
            Logger("Start Render:");
            Process proc = new Process();
            proc.StartInfo.FileName = "\"" + ConfigurationSettings.AppSettings["AeRenderPath"].ToString().Trim() + "\"";

            // string DateTimeStr = string.Format("{0:0000}", DateTime.Now.Year) + "-" + string.Format("{0:00}", DateTime.Now.Month) + "-" + string.Format("{0:00}", DateTime.Now.Day) + "_" + string.Format("{0:00}", DateTime.Now.Hour) + "-" + string.Format("{0:00}", DateTime.Now.Minute) + "-" + string.Format("{0:00}", DateTime.Now.Second);

            DirectoryInfo Dir = new DirectoryInfo(ConfigurationSettings.AppSettings["OutputPath"].ToString().Trim());

            if (!Dir.Exists)
            {
                Dir.Create();
            }
            try
            {
                File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + ConfigurationSettings.AppSettings["OutPutFileName"].ToString().Trim() + ".mov");
            }
            catch { }

            proc.StartInfo.Arguments = " -project " + "\"" + ConfigurationSettings.AppSettings["AeProjectFile"].ToString().Trim() + "\"" + "   -comp   \"" + ConfigurationSettings.AppSettings["Composition"].ToString().Trim() + "\" -output " + "\"" + Path.GetDirectoryName(Application.ExecutablePath) + "\\" + ConfigurationSettings.AppSettings["OutPutFileName"].ToString().Trim() + ".mov" + "\"";
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
                if (richTextBox1.Lines.Length > 3)
                {
                    richTextBox1.Text = "";
                }
                richTextBox1.Text += (line) + " \n";
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                Application.DoEvents();
            }
            proc.Close();

            //try
            //{
            //    string StaticDestFileName = ConfigurationSettings.AppSettings["ScheduleDestFileName"].ToString().Trim();
            //    // File.Delete(StaticDestFileName);
            //    File.Copy(ConfigurationSettings.AppSettings["OutputPath"].ToString().Trim() + ConfigurationSettings.AppSettings["OutPutFileName"].ToString().Trim() + "_" + DateTimeStr + ".mp4", StaticDestFileName, true);
            //    richTextBox1.Text += "COPY FINAL:" + StaticDestFileName + " \n";
            //    richTextBox1.SelectionStart = richTextBox1.Text.Length;
            //    richTextBox1.ScrollToCaret();
            //    Application.DoEvents();
            //}
            //catch (Exception Ex)
            //{
            //    richTextBox1.Text += Ex.Message + " \n";
            //    richTextBox1.SelectionStart = richTextBox1.Text.Length;
            //    richTextBox1.ScrollToCaret();
            //    Application.DoEvents();
            //}
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button1_Click(new object(), new EventArgs());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 3000;
            timer1.Enabled = true;
        }
    }
}
