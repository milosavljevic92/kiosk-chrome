using System;
using Microsoft.Win32;
namespace kiosk_chrome
{  
    class AppAutorun
    {     
        public static void setAppInAutoRun()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rkApp.SetValue("Tecomatic", AppDomain.CurrentDomain.BaseDirectory + "\\" + System.AppDomain.CurrentDomain.FriendlyName);
        }
        public static void removeAppFromAutoRun()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rkApp.DeleteValue("Tecomatic", false);
        }
    }
}
