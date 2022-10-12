using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace preHook
{
    class prehook
    {
        static void Main(string[] args)
        {
            prehook p = new prehook();
            string path = p.getDirectory();

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            
            cmd.StandardInput.WriteLine($@"cd {path}");
            cmd.StandardInput.Flush();
            cmd.StandardInput.WriteLine("nginx -s stop");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }

        string getDirectory() {    
            string dir = Directory.GetCurrentDirectory();
            string parentDir = Directory.GetParent(dir).FullName;
            string settingsPath = parentDir + @"\appsettings.json";
            IConfigurationRoot settings = new ConfigurationBuilder().AddJsonFile(settingsPath).Build();
            string path = settings.GetSection("AppSettings")["NginxPath"];
            return path;
        }
    }
}
