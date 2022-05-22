using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace kiosk_chrome
{
    class DateTimeHelper
    {
        public static string getTime()
        {
            return DateTime.Now.ToString(ConfigFile.readSettings("timeFormat"));
        }
        public static string getDate()
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            return dateTime.ToString(ConfigFile.readSettings("dateFormat"));
        }
        public static string getDayInYear()
        {
            return DateTime.Now.DayOfYear.ToString("000");
        }
        public static string getDateByDayNumber(string dayNumber)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            return dateTime.AddDays(Convert.ToDouble(dayNumber)).ToString(ConfigFile.readSettings("dateFormat"));
        }
        public static string getDateByDayNumberAndDate(DateTime dateTime,string dayNumber)
        {
            return dateTime.AddDays(Convert.ToDouble(dayNumber)).ToString(ConfigFile.readSettings("dateFormat"));
        }
        public static DateTime getDateTimeFromString(string date)
        {
            return DateTime.ParseExact(date, ConfigFile.readSettings("dateFormat"), CultureInfo.InvariantCulture);
        }
        public static string getTimeStampForFile()
        {
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string hour = DateTime.Now.ToString("HH");
            string minute = DateTime.Now.ToString("mm");
            string second = DateTime.Now.ToString("ss");
            string tmp = $"{day}{month}{year}_{hour}{minute}{second}";
            return tmp;
        }
       public static string getDateTime()
        {
            DateTime myDate = DateTime.Now;
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string hour = DateTime.Now.ToString("HH");
            string minute = DateTime.Now.ToString("mm");
            string second = DateTime.Now.ToString("ss");
            return day + "." + month + "." + year + " " + hour + ":" + minute + ":" + second;
        }

    }
}
