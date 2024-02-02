using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureToCsvConverter
{
    public class Config
    {
        IniFile INI;

        //App
        public string mode;

        public string outputFormat;


        //Paths
        public string inputPath;

        public string outputPath;

        public string outputFilename;

        public string frameworkInputPath;

        public string frameworkOutputPath;


        //Conversion
        public string qaseParentSuiteName;

        public string qaseParentSuiteId;


        public Config()
        {
            INI = new IniFile("config.ini");

            //App

            mode = INI.Read("mode", "App").ToLower().Trim();

            if(mode.Length == 0)
            {
                mode = "b";
            }
            else
            {
                mode = mode.Substring(0);
            }

            outputFormat = INI.Read("outputFormat", "App").ToLower().Trim();

            if (outputFormat.Length == 0)
            {
                outputFormat = "q";
            }
            else
            {
                outputFormat = outputFormat.Substring(0);
            }

            //Paths

            inputPath = INI.Read("inputPath", "Paths").Trim();

            outputPath = INI.Read("outputPath", "Paths").Trim();

            outputFilename = INI.Read("outputFilename", "Paths").Trim();

            frameworkInputPath = INI.Read("frameworkInputPath", "Paths").Trim();

            frameworkOutputPath = INI.Read("frameworkOutputPath", "Paths").Trim();

            if (mode == "s")
            {
                inputPath = frameworkInputPath;

                outputPath = frameworkOutputPath;
            }

            //Conversion

            qaseParentSuiteId = INI.Read("qaseParentSuiteId", "Conversion").Trim();

            qaseParentSuiteName = INI.Read("qaseParentSuiteName", "Conversion").Trim();
        }


        public void save()
        {
            //App


            //Paths

            inputPath = Form1.form1.getAllurePath();

            outputPath = Form1.form1.getCsvPath();

            INI.Write("inputPath", inputPath, "Paths");

            INI.Write("outputPath", outputPath, "Paths");

            INI.Write("outputFilename", outputFilename, "Paths");

            //Conversion

            INI.Write("qaseParentSuiteName", qaseParentSuiteName, "Conversion");

            INI.Write("qaseParentSuiteId", qaseParentSuiteId, "Conversion");
        }
    }
}
