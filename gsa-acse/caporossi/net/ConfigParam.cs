using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using System.IO;
using IniParser.Model;

namespace gsa_acse.caporossi.net
{
    public static class ConfigParam
    {
        public static String GetDBPath()
        {
            return getParsedData()["GeneralConfiguration"]["sqlitedb"];
        }
        public static String GetAllegatiPath()
        {
            return getParsedData()["GeneralConfiguration"]["allegatiPath"];
        }
        public static String GetFotoPath()
        {
            return getParsedData()["GeneralConfiguration"]["fotoPath"];
        }

        private static IniData getParsedData()
        {
            // Create an instance of a ini file parser
             FileIniDataParser fileIniData = new FileIniDataParser();
            // This is a special ini file where we use the '#' character for comment lines
            // instead of ';' so we need to change the configuration of the parser:
            fileIniData.Parser.Configuration.CommentString = "#";
            //Parse the ini file
#if DEBUG
            IniData parsedData = fileIniData.ReadFile(@"..\..\Config\gsa-acse.ini");
#else
            IniData parsedData = fileIniData.ReadFile(@".\Config\gsa-acse.ini");
#endif


            Log.Instance.Debug("Recuperato file configurazione");
            Log.Instance.Debug(parsedData);
            return parsedData;
        }

    }
}
