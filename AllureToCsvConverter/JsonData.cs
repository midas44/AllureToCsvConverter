using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureToCsvConverter
{
    public class JsonData
    {
        dynamic data;

        string divider;

        string altDivider;

        string lineDivider;


        public JsonData(string jsonString) {

            divider = ",";

            altDivider = ";";

            //lineDivider = "\n";

            lineDivider = " | "; //debug


            data = JsonConvert.DeserializeObject(jsonString);
        }


        private string replaceDiveder(string s)
        {
            return s.Replace(divider, altDivider);
        }


        public string getName()
        {
            string result = data.name;

            Form1.form1.addLog("parsed: name = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getFullName()
        {
            string result = data.fullName;

            Form1.form1.addLog("parsed: fullName = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getDescription()
        {
            string result = data.description;

            Form1.form1.addLog("parsed: description = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getStatus()
        {
            string result = data.status;

            Form1.form1.addLog("parsed: status = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getEpic()
        {
            string result = "";

            foreach (var label in data.labels) 
            {
                if(label.name == "epic")
                {
                    result = label.value;
                }
            }

            Form1.form1.addLog("parsed: epic = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getStory()
        {
            string result = "";

            foreach (var label in data.labels)
            {
                if (label.name == "story")
                {
                    result = label.value;
                }
            }

            Form1.form1.addLog("parsed: story = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getFeature()
        {
            string result = "";

            foreach (var label in data.labels)
            {
                if (label.name == "feature")
                {
                    result = label.value;
                }
            }

            Form1.form1.addLog("parsed: feature = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getTestMethod()
        {
            string result = "";

            foreach (var label in data.labels)
            {
                if (label.name == "testMethod")
                {
                    result = label.value;
                }
            }

            Form1.form1.addLog("parsed: testMethod = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getSuite()
        {
            string result = "";

            foreach (var label in data.labels)
            {
                if (label.name == "suite")
                {
                    result = label.value;
                }
            }

            Form1.form1.addLog("parsed: suite = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getTags()
        {
            string result = "";

            foreach (var label in data.labels)
            {
                if (label.name == "tag")
                {
                    result += label.value + "; ";
                }
            }

            Form1.form1.addLog("parsed: epic = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getLinks()
        {
            string result = "";

            foreach (var link in data.links)
            {
                result += link.name + lineDivider;
            }

            Form1.form1.addLog("parsed: links = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getSeverity()
        {

            string result = data.extra.severity;

            Form1.form1.addLog("parsed: severity = " + result);

            result = replaceDiveder(result);

            return result;
        }


        public string getSteps()
        {
            string result = "";

            if (data.ContainsKey("testStage"))
            {
                if (data.testStage.ContainsKey("steps"))
                {
                    foreach (var step in data.testStage.steps)
                    {                      
                        result += step.name + lineDivider;
                    }
                }
            }

            if(result.ToLower().Contains("selenide prop"))
            {
                return "";
            }

            Form1.form1.addLog("parsed: steps = " + result);

            result = replaceDiveder(result);

            return result;
        }



    }
}
