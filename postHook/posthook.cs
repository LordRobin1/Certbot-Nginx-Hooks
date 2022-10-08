using System.Security.AccessControl;
using System;
using System.Diagnostics;

namespace postHook
{
    class posthook
    {
        static void Main(string[] args)
        {
            Process nginx = new Process();
            nginx.StartInfo.WorkingDirectory = @"C:\nginx-1.23.0";
            nginx.StartInfo.FileName = "nginx.exe";
            nginx.StartInfo.UseShellExecute = true;
            nginx.Start();
        }
    }
}
