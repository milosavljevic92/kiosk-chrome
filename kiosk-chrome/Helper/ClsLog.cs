using System;
namespace kiosk_chrome
{
    class Log
    {
        public static void New(string logType, string logMessage)
        {
            try
            {
                string lines = DateTime.Now.ToString() + " # logType: " + logType + " # " + "msg: " + logMessage;
                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "_app.log", "\r\n" + lines);
            }
            catch { }
        }
    }
}
