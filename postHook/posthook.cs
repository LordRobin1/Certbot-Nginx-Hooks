using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace postHook
{
    class posthook
    {
        static void Main(string[] args)
        {
            posthook p = new posthook();
            string path = p.getDirectory();
            
            Process nginx = new Process();
            nginx.StartInfo.WorkingDirectory = $@"{path}";
            Console.WriteLine(path);
            nginx.StartInfo.FileName = "nginx.exe";
            nginx.StartInfo.Verb = "runas";
            nginx.StartInfo.UseShellExecute = true;
            nginx.Start();
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
