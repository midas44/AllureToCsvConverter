using System;

namespace AllureToCsvConverter
{
    public class Processor
    {

        public List<string> allureData;

        public List<string> sourceFields;

        public List<string> targetFields;

        public List<List<string>> parsedAllureData;

        public List<string> parsedHeader;

        public string divider;

        public string lineDivider;

        public List<string> exportData;


        public Processor()
        {
            sourceFields = new();

            targetFields = new();

            allureData = new();

            parsedAllureData = new();

            parsedHeader = new();

            exportData = new();

            divider = ",";

            const char LF = '\n';
            lineDivider = " ";
            lineDivider.Append(LF);
        }


        public void loadAllureData(string path)
        {
            path = path + "/data/test-cases";

            allureData.Clear();

            string[] files = System.IO.Directory.GetFiles(path, "*.json");

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    allureData.Add(loadFile(file));
                    Form1.form1.addLog(file);
                }
            }
        }


        private string loadFile(string path)
        {
            return File.ReadAllText(path);
        }


        public void parseAllureData()
        {
            parsedAllureData.Clear();
            parsedHeader.Clear();

            bool header = false;
            foreach (string json in allureData)
            {
                var parsedJsonData = parseJson(json);

                if (!header)
                {
                    parsedHeader = parsedJsonData[0];
                    parsedAllureData.Add(parsedHeader);
                    header = true;
                }

                parsedAllureData.Add(parsedJsonData[1]);
            }
        }


        private List<string>[] parseJson(string jsonString)
        {
            List<string>[] result = new List<string>[2];

            List<string> headerRow = new();
            List<string> contentRow = new();

            JsonData jsonData = new(jsonString);

            List<string> source = getAllureFields();

            foreach (string field in source)
            {

                if (field == "name")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getName());
                }

                if (field == "fullName")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getFullName());
                }

                if (field == "status")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getStatus());
                }

                if (field == "description")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getDescription());
                }

                if (field == "epic")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getEpic());
                }

                if (field == "severity")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getSeverity());
                }

                if (field == "tags")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getTags());
                }

                if (field == "story")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getStory());
                }

                if (field == "links")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getLinks());
                }

                if (field == "feature")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getFeature());
                }

                if (field == "suite")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getSuite());
                }

                if (field == "testMethod")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getTestMethod());
                }

                if (field == "steps")
                {
                    headerRow.Add(field);
                    contentRow.Add(jsonData.getSteps());
                }
            }

            result[0] = headerRow;
            result[1] = contentRow;

            return result;
        }



        public void convert()
        {
            exportData = new();

            string line = "";
            foreach (string field1 in targetFields) //header
            {
                line += field1 + divider;               
            }
            exportData.Add(line);

            int n = sourceFields.Count;

            int[] indexes = new int[n];

            bool header = false;

            foreach (var data in parsedAllureData) //testcases
            {
                if (!header)
                {
                    line = "";

                    for (int i = 0; i < n; i++)
                    {
                        indexes[i] = -1;
                        int j = 0;
                        foreach (var field in data)
                        {
                            if (field == sourceFields[i])
                            {
                                indexes[i] = j;
                            }
                            j++;
                        }
                    }                   
                }

                if (header)
                {
                    int nn = data.Count;
                    line = "";

                    for (int i = 0; i < n; i++)
                    {
                        bool key = false;
                        for (int j = 0; j < nn; j++)
                        {
                            if (indexes[i] == j)
                            {
                                line += data[j] + divider;
                                key = true;
                            }
                        }

                        if (!key)
                        {
                            line += "" + divider;
                        }
                    }
                        exportData.Add(line);                                      
                }
                header = true;
            }
        }


        public void megreForGDoc()
        {

        }


        public void megreForQase()
        {

        }


        private void mergeColumns(string prefix)
        {

        }



        public List<string> getQaseFields()
        {
            List<string> fields = new List<string> {
            "id",
            "title",
            "description",
            "description_autotest",
            "description_spec",
            "preconditions",
            "postconditions",
            "tags",
            "priority",
            "severity",
            "type",
            "behavior",
            "automation",
            "status",
            "is_flaky",
            "layer",
            "steps_type",
            "steps_actions",
            "steps_result",
            "steps_data",
            "milestone_id",
            "milestone",
            "suite_id",
            "suite_parent_id",
            "suite",
            "suite_without_cases",
            "parameters",
        };

            return fields;
        }


        public List<string> getGDocFields()
        {
            List<string> fields = new List<string> {
            "epic",
            "suite",
            "title",
            "description",
            "autotest",
            "behavior",
            "steps",
            "data",
            "expected result",
            "severity",
            "tags",
            "links",
            "status",
            "comment",
        };

            return fields;
        }


        public List<string> getAllureFields()
        {
            List<string> fields = new List<string> {

            "name",
            "fullName",
            "status",
            "description",
            "epic",
            "severity",
            "tags",
            "story",
            "links",
            "feature",
            "suite",
            "testMethod",
            "steps",
        };

            return fields;
        }

        private void resetFields()
        {
            sourceFields.Clear();
            targetFields.Clear();
        }


        public void arrangeFieldsForQase()
        {
            resetFields();

            List<string> target = getQaseFields();
            List<string> source = getAllureFields();

            int index2 = 0;
            foreach (string field2 in target)
            {
                bool k = false;

                int index1 = 0;

                foreach (string field1 in source)
                {

                    k = compareFields(field1, field2, "title", "name");
                    if (k) break;


                    k = compareFields(field1, field2, "description", "description"); //TODO: merge with description section, add subtitle
                    if (k) break;


                    k = compareFields(field1, field2, "description_autotest", "fullName"); //TODO: merge with description section, add subtitle
                    if (k) break;


                    k = compareFields(field1, field2, "description_spec", "links");
                    if (k) break;

                    k = compareFields(field1, field2, "tags", "tags");
                    if (k) break;

                    //k = compareFields(field1, field2, "priority", "???");
                    //if (k) break;

                    k = compareFields(field1, field2, "severity", "severity");
                    if (k) break;

                    k = compareFields(field1, field2, "behavior", "story");
                    if (k) break;

                    k = compareFields(field1, field2, "status", "status"); //TODO: replce status value:
                    if (k) break;

                    //k = compareFields(field1, field2,  "steps_type", "???");
                    //if (k) break;

                    k = compareFields(field1, field2, "steps_actions", "steps");
                    if (k) break;

                    //k = compareFields(field1, field2, "steps_result", "???");
                    //if (k) break;

                    //k = compareFields(field1, field2,  "steps_data", "???");
                    //if (k) break;

                    k = compareFields(field1, field2, "suite", "suite");
                    if (k) break;

                    index1++;
                }


                if (!k)
                {
                    sourceFields.Add("--");
                    targetFields.Add(field2);
                }

                index2++;
            }

        }


        public void arrangeFieldsForGDoc()
        {
            resetFields();

            List<string> target = getGDocFields();
            List<string> source = getAllureFields();

            int index2 = 0;
            foreach (string field2 in target)
            {
                bool k = false;

                int index1 = 0;

                foreach (string field1 in source)
                {
                    k = compareFields(field1, field2, "epic", "epic");
                    if (k) break;

                    k = compareFields(field1, field2, "suite", "suite");
                    if (k) break;

                    k = compareFields(field1, field2, "title", "name");
                    if (k) break;

                    k = compareFields(field1, field2, "autotest", "fullName");
                    if (k) break;

                    k = compareFields(field1, field2, "description", "description");
                    if (k) break;

                    k = compareFields(field1, field2, "behavior", "story");
                    if (k) break;

                    k = compareFields(field1, field2, "steps", "steps");
                    if (k) break;

                    // k = compareFields(field1, field2,  "data", "???");
                    //if (k) break;

                    k = compareFields(field1, field2, "expected result", "???");
                    if (k) break;

                    k = compareFields(field1, field2, "severity", "severity");
                    if (k) break;

                    k = compareFields(field1, field2, "tags", "tags");
                    if (k) break;

                    k = compareFields(field1, field2, "links", "links");
                    if (k) break;

                    k = compareFields(field1, field2, "status", "status");
                    if (k) break;

                    //k = compareFields(field1, field2, "comment", "???");
                    //if (k) break;

                    index1++;
                }

                if (!k)
                {
                    sourceFields.Add("--");
                    targetFields.Add(field2);
                }

                index2++;
            }

        }


        private bool compareFields(string s1, string s2, string e2, string e1)
        {
            if (s1.ToLower() == e1.ToLower() && s2.ToLower() == e2.ToLower())
            {
                sourceFields.Add(s1);
                targetFields.Add(s2);
                return true;
            }
            else
            {
                return false;
            }

        }



    }




    
}
