using System.Security.AccessControl;
using System;
using System.Diagnostics;

namespace preHook
{
    class prehook
    {
        static void Main(string[] args)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            
            cmd.StandardInput.WriteLine(@"cd C:\nginx-1.23.0");
            cmd.StandardInput.Flush();
            cmd.StandardInput.WriteLine("nginx -s stop");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }
    }
}
