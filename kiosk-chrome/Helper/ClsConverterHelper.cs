using System;
using System.Globalization;
using System.Text.RegularExpressions;
namespace kiosk_chrome
{
    class ConverterHelper
    {
        public static bool isStringWithNumeric(string value)
        {
            int n;
            return int.TryParse(value, out n);
        }
        public static bool isStringWithDate(string value)
        {
            DateTime dateValue;
            if (DateTime.TryParseExact(value, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dateValue))//hardcoded
                return true;
            else
                return false;
        }
        public static bool isStringWithWeight(string value)
        {
            if (value.Contains("."))//hardcoded
                return true;
            else
                return false;
        }
        public static bool isStringWithTwoDate(string value)
        {
            return false;
        }
        public static string getOnlyNumber(string value)
        {
            return Regex.Replace(value, "[^0-9 _]", "");
        }
    }
}
