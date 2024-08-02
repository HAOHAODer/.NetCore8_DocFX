using System;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;

using System.Web;

namespace MyApi.Helpers
{


    /// <summary>
    /// Summary description for Utilities
    /// </summary>
    public class Utilities
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Utilities(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static string ConvertUTF8toBIG5(string strInput)
        {
            byte[] strut8 = System.Text.Encoding.Unicode.GetBytes(strInput);
            byte[] strbig5 = System.Text.Encoding.Convert(System.Text.Encoding.Unicode, System.Text.Encoding.Default, strut8);
            return System.Text.Encoding.Default.GetString(strbig5);
        }

        /// <summary>
        /// bmk日期格式轉換(20081008-->2008年10月8日)
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns></returns>
        public static string GetDayHtmlSelect(string inputstring)
        {
            if (inputstring.Length != 8)
                return "";
            StringBuilder sb = new StringBuilder();
            sb.Append(inputstring.Substring(0, 4));
            sb.Append("年");
            sb.Append(inputstring.Substring(4, 2));
            sb.Append("月");
            sb.Append(inputstring.Substring(6, 2));
            sb.Append("日");
            return sb.ToString();
        }

        /// <summary>
        /// bmk日期格式轉換(20170118-->2017/01/18)
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns></returns>
        public static string TransString2Date_all(string inputstring)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(inputstring.Substring(0, 4));
            sb.Append("/");
            sb.Append(inputstring.Substring(4, 2));
            sb.Append("/");
            sb.Append(inputstring.Substring(6, 2));

            return sb.ToString();
        }

        /// <summary>
        /// bmk日期格式轉換(20170118-->2017/01/18)
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns></returns>
        public static string TransString2Date(string inputstring)
        {
            if (inputstring.Length != 8)
                return "";
            StringBuilder sb = new StringBuilder();
            sb.Append(inputstring.Substring(0, 4));
            sb.Append("/");
            sb.Append(inputstring.Substring(4, 2));
            sb.Append("/");
            sb.Append(inputstring.Substring(6, 2));

            return sb.ToString();
        }

        /// <summary>
        /// bmk時間格式轉換(1230-->12點30分)
        /// </summary>
        /// <param name="inputstring"></param>
        /// <returns></returns>
        public static string GetTimeHtmlSelect(string inputstring)
        {
            if (inputstring.Length == 3)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(inputstring.Substring(0, 1));
                sb.Append("點");
                sb.Append(inputstring.Substring(1, 2));
                sb.Append("分");
                return sb.ToString();
            }
            else if (inputstring.Length <= 2) { return ""; }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(inputstring.Substring(0, 2));
                sb.Append("點");
                sb.Append(inputstring.Substring(2, 2));
                sb.Append("分");
                return sb.ToString();
            }
        }

        /// <summary>
        /// bmk將時間字串-->數字型態(0830-->8.5)
        /// </summary>
        /// <param name="timestring"></param>
        /// <returns></returns>
        public static double TransTimeString2Double(string timestring)
        {
            if (timestring == null || timestring.Length != 4)
                return 0.0;
            string timeStringHr = timestring.Substring(0, 2);
            string timeStringMin = timestring.Substring(2, 2);
            double doubleHr = double.Parse(timeStringHr);
            double doubleMin = double.Parse(timeStringMin);
            if (doubleHr >= 24.0 || doubleHr < 0.0)
                return 0.0;
            if (doubleMin >= 59.0 || doubleMin < 0.0)
                return 0.0;
            double newdoubleMin = doubleMin / 60;
            double newTimeDouble = doubleHr + newdoubleMin;

            return newTimeDouble;

        }

        public static Boolean IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }




        /// <summary>
        /// 將數字週數轉中文
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static string TransNumWeekToString(int week)
        {
            string returnString = "";
            switch (week)
            {
                case 0:
                    returnString = "日";
                    break;
                case 1:
                    returnString = "一";
                    break;
                case 2:
                    returnString = "二";
                    break;
                case 3:
                    returnString = "三";
                    break;
                case 4:
                    returnString = "四";
                    break;
                case 5:
                    returnString = "五";
                    break;
                case 6:
                    returnString = "六";
                    break;
            }
            return returnString;
        }

        /// <summary>
        /// 將數字週數轉中文
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static string TransNumToChinese(int num)
        {
            string returnString = "";
            switch (num)
            {
                case 0:
                    returnString = "零";
                    break;
                case 1:
                    returnString = "一";
                    break;
                case 2:
                    returnString = "二";
                    break;
                case 3:
                    returnString = "三";
                    break;
                case 4:
                    returnString = "四";
                    break;
                case 5:
                    returnString = "五";
                    break;
                case 6:
                    returnString = "六";
                    break;
                case 7:
                    returnString = "七";
                    break;
                case 8:
                    returnString = "八";
                    break;
                case 9:
                    returnString = "九";
                    break;
                case 10:
                    returnString = "十";
                    break;
                case 11:
                    returnString = "十一";
                    break;
                case 12:
                    returnString = "十二";
                    break;
            }
            return returnString;
        }

        //將數字時間轉換成字串時間
        public static string TimeConvertString(int time)
        {
            int hours = time / 100;
            int minutes = time % 100;
            return hours.ToString("D2") + ":" + minutes.ToString("D2");
        }

        /// <summary>
        /// bmk將時間字串-->數字型態(830-->0830)
        /// </summary>
        /// <param name="timestring"></param>
        /// <returns></returns>
        public static string TimeFormat(string time)
        {
            string timeString = "";

            if (time == null || time == "") {
                timeString = "0000";
            }

            timeString = String.Format("{0:0000}",Convert.ToInt16(time));

            return timeString;
        }

        /// <summary>
        /// 取得用戶端 IP
        /// </summary>
        /// <returns></returns>
        public string GetClientIpAddress()
        {
            // 確保 HttpContext 和 Request 不為 null
            var context = _httpContextAccessor.HttpContext;
            if (context == null || context.Request == null)
                return null;

            // 使用 X-Forwarded-For 標頭以處理代理伺服器的情況
            var ipAddress = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            // 如果 X-Forwarded-For 標頭不存在，則使用 RemoteIpAddress 屬性
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = context.Connection.RemoteIpAddress?.ToString();
            }

            // 返回 IP 地址，若未獲取到則返回 null
            return ipAddress;
        }
    }
}