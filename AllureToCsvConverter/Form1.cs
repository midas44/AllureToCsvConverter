using System.Diagnostics;
using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace AllureToCsvConverter
{
    public partial class Form1 : Form
    {
        public static Form1 form1 = null;

        public delegate void EnableDelegate(bool enable);

        Processor proc;

        Config config;


        public Form1()
        {
            InitializeComponent();

            form1 = this;

            config = new();

            proc = new(config);

            setMode();

            textBoxParentSuiteName.Text = config.qaseParentSuiteName;

            textBoxParentSuiteId.Text = config.qaseParentSuiteId;

            string workDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath);


            if (!System.IO.Path.Exists(config.inputPath))
            {
                textBoxAllurePath.Text = workDir + "\\input";
                System.IO.Directory.CreateDirectory(textBoxAllurePath.Text.Trim());

                string s = textBoxAllurePath.Text + "\\allure-report";

                if (System.IO.Path.Exists(s))
                {
                    textBoxAllurePath.Text = s;
                }
            }
            else
            {
                textBoxAllurePath.Text = config.inputPath;
            }


            if (!System.IO.Path.Exists(config.outputPath))
            {
                textBoxCsvPath.Text = workDir + "\\output";
                System.IO.Directory.CreateDirectory(textBoxCsvPath.Text.Trim());
            }
            else
            {
                textBoxCsvPath.Text = config.outputPath;
            }

            textBoxCsvFilename.Text = config.outputFilename;

            addLog(" * * * Allure To CSV Converter * * *");

            if (config.mode == "s")
            {
                process(config.outputFormat);

                System.Environment.Exit(1);
            }
        }

        public string getQaseParentSuiteName()
        {
            return textBoxParentSuiteName.Text.Trim();
        }

        public string getQaseParentSuiteId()
        {
            return textBoxParentSuiteId.Text.Trim();
        }


        private void buttonQaseProcess_Click(object sender, EventArgs e)
        {
            process("q");
        }

        private void buttonGDocProcess_Click(object sender, EventArgs e)
        {
            process("g");
        }


        private void process(string format)
        {
            load();

            if (format == "q")
            {
                setQase();
            }

            if (format == "g")
            {
                setGDoc();
            }

            convert();

            string dir = textBoxCsvPath.Text.Trim();
            System.IO.Directory.CreateDirectory(dir);

            string path = dir + "\\" + textBoxCsvFilename.Text.Trim();

            saveFile(path);
        }


        private void buttonLoad_Click(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            if (!textBoxAllurePath.Text.Contains("allure-report"))
            {
                addLog("Select allure-report dir");
                return;
            }

            proc.loadAllureData(textBoxAllurePath.Text.Trim());

            if (proc.allureData.Count == 0)
            {
                addLog("No json files found! Check Allure directory");
            }
            else
            {
                addLog(proc.allureData.Count.ToString() + " testcases (json files) loaded");
            }
        }


        public void addLog(string s)
        {
            if (config.mode == "s")
            {
                return;
            }

            if (config.mode == "a")
            {
                textBoxLog.AppendText(s + Environment.NewLine);
            }

            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(s);
        }


        public void clearLog()
        {
            textBoxLog.Clear();
            statusStrip1.Items.Clear();
        }


        private void setGDoc()
        {
            addLog("GDoc format is set");
            proc.arrangeFieldsForGDoc();
            outputFields();
            config.outputFormat = "g";
        }


        private void setQase()
        {
            addLog("Qase format is set");
            proc.arrangeFieldsForQase();
            outputFields();
            config.outputFormat = "q";
        }


        private void buttonSetGDoc_Click(object sender, EventArgs e)
        {
            setGDoc();
        }


        private void buttonSetQase_Click(object sender, EventArgs e)
        {
            setQase();
        }


        private void outputFields()
        {
            textBoxSource.Lines = proc.sourceFields.ToArray();
            textBoxTarget.Lines = proc.targetFields.ToArray();
        }


        public List<string> getInputFields()
        {
            List<string> fields = new();

            string[] sourceFields = textBoxSource.Lines;

            foreach (string field in sourceFields)
            {
                fields.Add(field.Trim());
            }

            return fields;
        }


        public List<string> getOutputFields()
        {
            List<string> fields = new();

            string[] targetFields = textBoxTarget.Lines;

            foreach (string field in targetFields)
            {
                fields.Add(field.Trim());
            }

            return fields;
        }


        private void convert()
        {
            proc.parseAllureData();
            proc.convert();
        }


        private void buttonConvert_Click(object sender, EventArgs e)
        {
            convert();
        }


        private void buttonHelp_Click(object sender, EventArgs e)
        {
            addLog("Help");
            addLog("Use buttons from left to right :)");
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = textBoxCsvPath.Text.Trim();

            saveFileDialog1.FileName = textBoxCsvFilename.Text.Trim();

            saveFileDialog1.RestoreDirectory = false;

            saveFileDialog1.Title = "Save CSV File";

            saveFileDialog1.DefaultExt = "csv";

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";

            saveFileDialog1.FilterIndex = 0;

            saveFileDialog1.CheckFileExists = false;

            saveFileDialog1.CheckPathExists = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFile(saveFileDialog1.FileName);
            }
        }


        private void saveFile(string path)
        {


            using (TextWriter fileTW = new StreamWriter(path))
            {
                fileTW.NewLine = "\n";

                foreach (string line in proc.exportData)
                {
                    string line1 = line.Remove(line.Length - 1);

                    fileTW.WriteLine(line1);
                }
            }
            addLog("Saved to file: " + path);
        }


        private void mode_button_Click(object sender, EventArgs e)
        {
            toggleMode();
        }


        private void toggleMode()
        {
            if (config.mode == "b")
            {
                config.mode = "a";
            }
            else
            {
                config.mode = "b";
            }

            setMode();
        }


        private void setMode()
        {
            switch (config.mode)
            {
                case "s":
                    setStealthMode();
                    break;
                case "a":
                    setAdvancedMode();
                    break;
                default:
                    setBaseMode();
                    break;
            }
        }


        private void setBaseMode()
        {
            mode_button.Text = "Advanced Mode";

            panelC.Visible = false;
            panelB.Visible = false;
            panelA.Visible = true;
            buttonQaseProcess.Visible = true;
            buttonGDocProcess.Visible = true;

            addLog("Base Mode");

            form1.Height = panelA.Height + statusStrip1.Height + 80;
        }


        private void setAdvancedMode()
        {
            mode_button.Text = "Base Mode";

            panelC.Visible = true;
            panelB.Visible = true;
            panelA.Visible = true;
            buttonQaseProcess.Visible = false;
            buttonGDocProcess.Visible = false;

            addLog("Advanced Mode");

            form1.Height = panelA.Height + panelB.Height + panelC.Height + statusStrip1.Height + 80;
        }


        private void setStealthMode()
        {
            panelC.Visible = false;
            panelB.Visible = false;
            panelA.Visible = false;

            form1.Opacity = 0;
            form1.Width = 10; form1.Height = 10;
            form1.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (config.mode != "s")
            {
                config.qaseParentSuiteName = textBoxParentSuiteName.Text;

                config.qaseParentSuiteId = textBoxParentSuiteId.Text;

                config.save();
            }
        }


        public string getAllurePath()
        {
            return textBoxAllurePath.Text.Trim();
        }


        public string getCsvPath()
        {
            return textBoxCsvPath.Text.Trim();
        }


        private void outputPathButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.SelectedPath = textBoxCsvPath.Text.Trim();

            folderBrowserDialog2.ShowNewFolderButton = true;

            DialogResult result = folderBrowserDialog2.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxCsvPath.Text = folderBrowserDialog2.SelectedPath;
            }
        }


        private void inputPathButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = textBoxAllurePath.Text.Trim();

            folderBrowserDialog1.ShowNewFolderButton = true;

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxAllurePath.Text = folderBrowserDialog1.SelectedPath;
            }

            if (textBoxAllurePath.Text.EndsWith("allure-report") || textBoxAllurePath.Text.EndsWith("allure-report/"))
            {
                addLog("allure-report dir is selected");
            }
            else
            {
                addLog("incorrect dir is selected!");
            }
        }


    }
}
