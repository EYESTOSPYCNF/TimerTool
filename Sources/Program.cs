using System;
using System.Diagnostics;

namespace TimerTool
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!IsRunAsAdmin())
            {
                RunAsAdmin();
                return;
            }

            // Your existing code here...

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static bool IsRunAsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        static void RunAsAdmin()
        {
            var exeName = Process.GetCurrentProcess().MainModule.FileName;
            var startInfo = new ProcessStartInfo(exeName);
            startInfo.Verb = "runas";
            Process.Start(startInfo);
        }
    }
}
