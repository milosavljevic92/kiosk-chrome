using System.Runtime.InteropServices;
using System.Text;
using System;
using System.IO;
namespace kiosk_chrome
{
    class ConfigFile
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        private static string path = AppDomain.CurrentDomain.BaseDirectory + "config.ini";
        private static void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }
        private static string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, path);
            return temp.ToString();
        }
        public static string readSettings(string key)
        {
            return IniReadValue("config", key);
        }
        public static void setSettings(string key, string value)
        {
            IniWriteValue("config", key, value);
        }
        public static void deleteConfigFile()
        {
            try
            {
                File.Delete(path);
            }
            catch { }
        }
        public static void generateIfNotExist()
        {
            Console.WriteLine(path);
            if (File.Exists(path)) return;
            using (StreamWriter _file = File.AppendText(path))
            {
                _file.Flush();
                _file.WriteLine("[config]");
                _file.WriteLine("dbServer=127.0.0.1");
                _file.WriteLine("dbUser=root");
                _file.WriteLine("dbPort=3306");
                _file.WriteLine("dbBase=dbweightlabel");
                _file.WriteLine("dbPassword=root");
                _file.WriteLine(" ");
                _file.WriteLine("CompanyName=Tecomatic.rs");
                _file.WriteLine("CompanyAddress=Novi Sad");
                _file.WriteLine(" ");                
                _file.WriteLine("ean13start_1=27");
                _file.WriteLine("ean13start_2=28");
                _file.WriteLine("ean13start_3=29");
                _file.WriteLine("ean13start_4=30");
                _file.WriteLine(" ");
                _file.WriteLine("ean128_1=01");
                _file.WriteLine("ean128_2=3103");
                _file.WriteLine("ean128_3=17");
                _file.WriteLine("ean128_4=10");
                _file.WriteLine(" ");
                _file.WriteLine("pluEan13StaticLen=12");
                _file.WriteLine("pluEan13DynamicLen=5");
                _file.WriteLine("gtinEan128Len=14");
                _file.WriteLine(" ");
                _file.WriteLine("productDescriptionFont=1");
                _file.WriteLine(" ");              
                _file.WriteLine("scaleValueOffset=0.050");
                _file.WriteLine(" ");
                _file.WriteLine("scalePort=COM1");
                _file.WriteLine("scaleSpeed=9600");
                _file.WriteLine("scaleModel=default");
                _file.WriteLine("scaleWeightStart=7");
                _file.WriteLine("scaleWeightLen=6");
                _file.WriteLine("scaleSignStart=5");
                _file.WriteLine("scaleSignLen=1");
                _file.WriteLine("scaleGrossStart=3");
                _file.WriteLine("scaleGrossLen=1");
                _file.WriteLine(" ");
                _file.WriteLine("weightUnit=kg");
                _file.WriteLine(" ");
                _file.WriteLine("weightFormatString=00.000");
                _file.WriteLine("total1FormatString=00.000");
                _file.WriteLine("total2FormatString=000.000");
                _file.WriteLine(" ");
                _file.WriteLine("dateFormat=dd.MM.yyyy");
                _file.WriteLine("timeFormat=HH:mm:ss");
                _file.WriteLine(" ");
                _file.WriteLine("printerModel=HD100");
                _file.WriteLine(" ");
                _file.WriteLine("productionBox=5");
                _file.WriteLine("productionPalete=3");
                _file.WriteLine(" ");
                _file.WriteLine("startWithWin=0");
                _file.WriteLine(" ");
                _file.WriteLine("isServerSetup=1");
                _file.WriteLine(" ");
                _file.WriteLine("defaultLabelDir=C:\\ProductionPackageManager");
                _file.Close();
            }
        }
        public static void writeConfigIntoIni(string config)
        {
            System.IO.File.Delete(path);
            System.IO.File.WriteAllText(path, config);
        }
    }
}
