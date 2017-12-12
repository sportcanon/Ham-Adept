namespace HamAdept
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.problematicToolButton = new System.Windows.Forms.ToolStripButton();
            this.sampleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiokomunikačníPředpisyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radiokomunikačníProvozToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elektrotechnikaARadiotechnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionOrderingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.sequenceToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.richTextBox1);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.textBox2);
            this.splitContainer2.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBox1);
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.trainingToolStripMenuItem,
            this.sampleTestToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.otherToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDataToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            resources.ApplyResources(this.importDataToolStripMenuItem, "importDataToolStripMenuItem");
            this.importDataToolStripMenuItem.Click += new System.EventHandler(this.ImportQuestionsMenuItemClick);
            // 
            // trainingToolStripMenuItem
            // 
            this.trainingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripButton,
            this.problematicToolButton});
            this.trainingToolStripMenuItem.Name = "trainingToolStripMenuItem";
            resources.ApplyResources(this.trainingToolStripMenuItem, "trainingToolStripMenuItem");
            // 
            // allToolStripButton
            // 
            this.allToolStripButton.CheckOnClick = true;
            this.allToolStripButton.Name = "allToolStripButton";
            resources.ApplyResources(this.allToolStripButton, "allToolStripButton");
            this.allToolStripButton.Tag = "BTN_ALL";
            // 
            // problematicToolButton
            // 
            this.problematicToolButton.Name = "problematicToolButton";
            resources.ApplyResources(this.problematicToolButton, "problematicToolButton");
            this.problematicToolButton.Tag = "BTN_PROBLEMATIC";
            // 
            // sampleTestToolStripMenuItem
            // 
            this.sampleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.radiokomunikačníPředpisyToolStripMenuItem,
            this.radiokomunikačníProvozToolStripMenuItem,
            this.elektrotechnikaARadiotechnikaToolStripMenuItem});
            resources.ApplyResources(this.sampleTestToolStripMenuItem, "sampleTestToolStripMenuItem");
            this.sampleTestToolStripMenuItem.Name = "sampleTestToolStripMenuItem";
            // 
            // radiokomunikačníPředpisyToolStripMenuItem
            // 
            this.radiokomunikačníPředpisyToolStripMenuItem.Name = "radiokomunikačníPředpisyToolStripMenuItem";
            resources.ApplyResources(this.radiokomunikačníPředpisyToolStripMenuItem, "radiokomunikačníPředpisyToolStripMenuItem");
            // 
            // radiokomunikačníProvozToolStripMenuItem
            // 
            this.radiokomunikačníProvozToolStripMenuItem.Name = "radiokomunikačníProvozToolStripMenuItem";
            resources.ApplyResources(this.radiokomunikačníProvozToolStripMenuItem, "radiokomunikačníProvozToolStripMenuItem");
            // 
            // elektrotechnikaARadiotechnikaToolStripMenuItem
            // 
            this.elektrotechnikaARadiotechnikaToolStripMenuItem.Name = "elektrotechnikaARadiotechnikaToolStripMenuItem";
            resources.ApplyResources(this.elektrotechnikaARadiotechnikaToolStripMenuItem, "elektrotechnikaARadiotechnikaToolStripMenuItem");
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.questionOrderingToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            resources.ApplyResources(this.configurationToolStripMenuItem, "configurationToolStripMenuItem");
            // 
            // questionOrderingToolStripMenuItem
            // 
            this.questionOrderingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomToolStripMenuItem,
            this.sequenceToolStripMenuItem});
            this.questionOrderingToolStripMenuItem.Name = "questionOrderingToolStripMenuItem";
            resources.ApplyResources(this.questionOrderingToolStripMenuItem, "questionOrderingToolStripMenuItem");
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Checked = true;
            this.randomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            resources.ApplyResources(this.randomToolStripMenuItem, "randomToolStripMenuItem");
            this.randomToolStripMenuItem.Tag = "BTN_RANDOM";
            // 
            // sequenceToolStripMenuItem
            // 
            this.sequenceToolStripMenuItem.Name = "sequenceToolStripMenuItem";
            resources.ApplyResources(this.sequenceToolStripMenuItem, "sequenceToolStripMenuItem");
            this.sequenceToolStripMenuItem.Tag = "BTN_SEQUENCE";
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.deleteStatisticsToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            resources.ApplyResources(this.otherToolStripMenuItem, "otherToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
            // 
            // deleteStatisticsToolStripMenuItem
            // 
            this.deleteStatisticsToolStripMenuItem.Name = "deleteStatisticsToolStripMenuItem";
            resources.ApplyResources(this.deleteStatisticsToolStripMenuItem, "deleteStatisticsToolStripMenuItem");
            this.deleteStatisticsToolStripMenuItem.Click += new System.EventHandler(this.OnDeleteStatisticsToolStripMenuItemClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.ShowReadOnly = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.OnForm1Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainingToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton allToolStripButton;
        private System.Windows.Forms.ToolStripButton problematicToolButton;
        private System.Windows.Forms.ToolStripMenuItem sampleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiokomunikačníPředpisyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radiokomunikačníProvozToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elektrotechnikaARadiotechnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem deleteStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionOrderingToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton sequenceToolStripMenuItem;
    }
}

