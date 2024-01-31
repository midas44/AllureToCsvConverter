namespace AllureToCsvConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelB = new Panel();
            buttonHelp = new Button();
            buttonSave = new Button();
            buttonConvert = new Button();
            buttonSetQase = new Button();
            buttonSetGDoc = new Button();
            buttonLoad = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            saveFileDialog1 = new SaveFileDialog();
            panelA = new Panel();
            label3 = new Label();
            textBoxCsvFilename = new TextBox();
            outputPathButton = new Button();
            inputPathButton = new Button();
            mode_button = new Button();
            processButton = new Button();
            label2 = new Label();
            textBoxCsvPath = new TextBox();
            label1 = new Label();
            textBoxAllurePath = new TextBox();
            statusStrip1 = new StatusStrip();
            folderBrowserDialog2 = new FolderBrowserDialog();
            panelC = new Panel();
            textBoxTarget = new TextBox();
            textBoxSource = new TextBox();
            textBoxLog = new TextBox();
            panelB.SuspendLayout();
            panelA.SuspendLayout();
            panelC.SuspendLayout();
            SuspendLayout();
            // 
            // panelB
            // 
            panelB.Controls.Add(buttonHelp);
            panelB.Controls.Add(buttonSave);
            panelB.Controls.Add(buttonConvert);
            panelB.Controls.Add(buttonSetQase);
            panelB.Controls.Add(buttonSetGDoc);
            panelB.Controls.Add(buttonLoad);
            panelB.Location = new Point(12, 347);
            panelB.Name = "panelB";
            panelB.Size = new Size(1322, 137);
            panelB.TabIndex = 0;
            // 
            // buttonHelp
            // 
            buttonHelp.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonHelp.Location = new Point(1265, 90);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(40, 34);
            buttonHelp.TabIndex = 9;
            buttonHelp.Text = "?";
            buttonHelp.UseVisualStyleBackColor = true;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSave.Location = new Point(990, 38);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(189, 34);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Save to file";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonConvert
            // 
            buttonConvert.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonConvert.Location = new Point(719, 38);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(189, 34);
            buttonConvert.TabIndex = 7;
            buttonConvert.Text = "Convert to CSV";
            buttonConvert.UseVisualStyleBackColor = true;
            buttonConvert.Click += buttonConvert_Click;
            // 
            // buttonSetQase
            // 
            buttonSetQase.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSetQase.Location = new Point(295, 56);
            buttonSetQase.Name = "buttonSetQase";
            buttonSetQase.Size = new Size(315, 34);
            buttonSetQase.TabIndex = 5;
            buttonSetQase.Text = "Set Qase import format";
            buttonSetQase.UseVisualStyleBackColor = true;
            buttonSetQase.Click += buttonSetQase_Click;
            // 
            // buttonSetGDoc
            // 
            buttonSetGDoc.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonSetGDoc.Location = new Point(295, 16);
            buttonSetGDoc.Name = "buttonSetGDoc";
            buttonSetGDoc.Size = new Size(315, 34);
            buttonSetGDoc.TabIndex = 4;
            buttonSetGDoc.Text = "Set G.Doc spreadsheet format";
            buttonSetGDoc.UseVisualStyleBackColor = true;
            buttonSetGDoc.Click += buttonSetGDoc_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLoad.Location = new Point(18, 38);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(189, 34);
            buttonLoad.TabIndex = 3;
            buttonLoad.Text = "Load Allure testcases";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // panelA
            // 
            panelA.Controls.Add(label3);
            panelA.Controls.Add(textBoxCsvFilename);
            panelA.Controls.Add(outputPathButton);
            panelA.Controls.Add(inputPathButton);
            panelA.Controls.Add(mode_button);
            panelA.Controls.Add(processButton);
            panelA.Controls.Add(label2);
            panelA.Controls.Add(textBoxCsvPath);
            panelA.Controls.Add(label1);
            panelA.Controls.Add(textBoxAllurePath);
            panelA.Location = new Point(12, 12);
            panelA.Name = "panelA";
            panelA.Size = new Size(1322, 329);
            panelA.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 171);
            label3.Name = "label3";
            label3.Size = new Size(187, 23);
            label3.TabIndex = 21;
            label3.Text = "Output Filename (*.csv)";
            // 
            // textBoxCsvFilename
            // 
            textBoxCsvFilename.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCsvFilename.Location = new Point(18, 207);
            textBoxCsvFilename.Name = "textBoxCsvFilename";
            textBoxCsvFilename.Size = new Size(627, 30);
            textBoxCsvFilename.TabIndex = 20;
            // 
            // outputPathButton
            // 
            outputPathButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            outputPathButton.Location = new Point(1216, 121);
            outputPathButton.Name = "outputPathButton";
            outputPathButton.Size = new Size(79, 34);
            outputPathButton.TabIndex = 19;
            outputPathButton.Text = ". . .";
            outputPathButton.UseVisualStyleBackColor = true;
            outputPathButton.Click += outputPathButton_Click;
            // 
            // inputPathButton
            // 
            inputPathButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inputPathButton.Location = new Point(1216, 33);
            inputPathButton.Name = "inputPathButton";
            inputPathButton.Size = new Size(79, 34);
            inputPathButton.TabIndex = 18;
            inputPathButton.Text = ". . .";
            inputPathButton.UseVisualStyleBackColor = true;
            inputPathButton.Click += inputPathButton_Click;
            // 
            // mode_button
            // 
            mode_button.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mode_button.Location = new Point(15, 275);
            mode_button.Name = "mode_button";
            mode_button.Size = new Size(189, 34);
            mode_button.TabIndex = 17;
            mode_button.Text = "Advanced Mode";
            mode_button.UseVisualStyleBackColor = true;
            mode_button.Click += mode_button_Click;
            // 
            // processButton
            // 
            processButton.Location = new Point(867, 275);
            processButton.Name = "processButton";
            processButton.Size = new Size(428, 34);
            processButton.TabIndex = 16;
            processButton.Text = "Convert Allure -> Qase CSV";
            processButton.UseVisualStyleBackColor = true;
            processButton.Click += processButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 85);
            label2.Name = "label2";
            label2.Size = new Size(140, 23);
            label2.TabIndex = 15;
            label2.Text = "Output CSV Path";
            // 
            // textBoxCsvPath
            // 
            textBoxCsvPath.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxCsvPath.Location = new Point(18, 121);
            textBoxCsvPath.Name = "textBoxCsvPath";
            textBoxCsvPath.Size = new Size(1192, 30);
            textBoxCsvPath.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 0);
            label1.Name = "label1";
            label1.Size = new Size(260, 23);
            label1.TabIndex = 13;
            label1.Text = "Allure Report Path (allure-report)";
            // 
            // textBoxAllurePath
            // 
            textBoxAllurePath.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxAllurePath.Location = new Point(18, 36);
            textBoxAllurePath.Name = "textBoxAllurePath";
            textBoxAllurePath.Size = new Size(1192, 30);
            textBoxAllurePath.TabIndex = 12;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 1500);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1341, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // panelC
            // 
            panelC.Controls.Add(textBoxTarget);
            panelC.Controls.Add(textBoxSource);
            panelC.Controls.Add(textBoxLog);
            panelC.Location = new Point(12, 490);
            panelC.Name = "panelC";
            panelC.Size = new Size(1323, 1004);
            panelC.TabIndex = 8;
            // 
            // textBoxTarget
            // 
            textBoxTarget.BackColor = SystemColors.Window;
            textBoxTarget.BorderStyle = BorderStyle.FixedSingle;
            textBoxTarget.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxTarget.ForeColor = SystemColors.WindowText;
            textBoxTarget.Location = new Point(990, 3);
            textBoxTarget.Multiline = true;
            textBoxTarget.Name = "textBoxTarget";
            textBoxTarget.ScrollBars = ScrollBars.Both;
            textBoxTarget.Size = new Size(330, 987);
            textBoxTarget.TabIndex = 14;
            textBoxTarget.WordWrap = false;
            // 
            // textBoxSource
            // 
            textBoxSource.BackColor = SystemColors.Window;
            textBoxSource.BorderStyle = BorderStyle.FixedSingle;
            textBoxSource.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSource.ForeColor = SystemColors.WindowText;
            textBoxSource.Location = new Point(652, 3);
            textBoxSource.Multiline = true;
            textBoxSource.Name = "textBoxSource";
            textBoxSource.ScrollBars = ScrollBars.Both;
            textBoxSource.Size = new Size(335, 987);
            textBoxSource.TabIndex = 13;
            textBoxSource.WordWrap = false;
            // 
            // textBoxLog
            // 
            textBoxLog.BackColor = Color.Black;
            textBoxLog.BorderStyle = BorderStyle.FixedSingle;
            textBoxLog.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxLog.ForeColor = Color.FromArgb(224, 224, 224);
            textBoxLog.Location = new Point(3, 3);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ScrollBars = ScrollBars.Both;
            textBoxLog.Size = new Size(643, 987);
            textBoxLog.TabIndex = 12;
            textBoxLog.WordWrap = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1341, 1522);
            Controls.Add(panelC);
            Controls.Add(statusStrip1);
            Controls.Add(panelA);
            Controls.Add(panelB);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Location = new Point(1000, 500);
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "AllureToCsvConverter";
            FormClosing += Form1_FormClosing;
            panelB.ResumeLayout(false);
            panelA.ResumeLayout(false);
            panelA.PerformLayout();
            panelC.ResumeLayout(false);
            panelC.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelB;
        private FolderBrowserDialog folderBrowserDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button buttonLoad;
        private Button buttonSetGDoc;
        private Button buttonSetQase;
        private Button buttonConvert;
        private Button buttonSave;
        private Button buttonHelp;
        private Panel panelA;
        private Label label2;
        private TextBox textBoxCsvPath;
        private Label label1;
        private TextBox textBoxAllurePath;
        private Button processButton;
        private Button mode_button;
        private StatusStrip statusStrip1;
        private Button inputPathButton;
        private Button outputPathButton;
        private FolderBrowserDialog folderBrowserDialog2;
        private Label label3;
        private TextBox textBoxCsvFilename;
        private Panel panelC;
        private TextBox textBoxTarget;
        private TextBox textBoxSource;
        private TextBox textBoxLog;
    }
}
