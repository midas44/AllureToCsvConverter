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

            lineDivider = "<br/>";

            data = JsonConvert.DeserializeObject(jsonString);
        }


        private string replaceDivider(string s)
        {
            return s.Replace(divider, altDivider);
        }


        public string getName()
        {
            string result = data.name;

            Form1.form1.addLog("parsed: name = " + result);

            result = replaceDivider(result);

            return result;
        }


        public string getFullName()
        {
            string result = data.fullName;

            Form1.form1.addLog("parsed: fullName = " + result);

            result = replaceDivider(result);

            return result;
        }


        public string getDescription()
        {
            string result = data.description;

            Form1.form1.addLog("parsed: description = " + result);

            result = replaceDivider(result);

            return result;
        }


        public string getAutomationStatus(string format)
        {
            string result = data.status;

            Form1.form1.addLog("parsed: status = " + result);

            result = replaceDivider(result);

            if (format == "q")
            {

                if (result != "skipped")
                {
                    result = "automated";
                }
                else
                {
                    result = "is-not-automated";
                }
            }
           
            return result;
        }


        public string getStatus(string format)
        {
            string result = data.status;

            Form1.form1.addLog("parsed: status = " + result);

            result = replaceDivider(result);

            if(format == "q")
            {
                if (result != "skipped")
                {
                    result = "actual";
                }
                else
                {
                    result = "draft";
                }
            }

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

            result = replaceDivider(result);

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

            result = replaceDivider(result);

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

            result = replaceDivider(result);

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

            result = replaceDivider(result);

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

            result = replaceDivider(result);

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

            result = replaceDivider(result);

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

            result = replaceDivider(result);

            return result;
        }


        public string getSeverity()
        {

            string result = data.extra.severity;

            Form1.form1.addLog("parsed: severity = " + result);

            result = replaceDivider(result);

            return result;
        }


        public string getSteps()
        {
            string result = "";

            if (data.ContainsKey("testStage"))
            {
                if (data.testStage.ContainsKey("steps"))
                {
                    int stepNumber = 0;
                    foreach (var step in data.testStage.steps)
                    {
                        string stepName = step.name;

                        if (!stepName.ToLower().Contains("selenide") && !stepName.ToLower().Contains("open logout"))
                        {
                            stepNumber++;
                            result += stepNumber.ToString() + ". " + step.name + lineDivider;
                        } 
                    }
                }
            }

            Form1.form1.addLog("parsed: steps = " + result);

            result = replaceDivider(result);

            return result;
        }

    }
}
