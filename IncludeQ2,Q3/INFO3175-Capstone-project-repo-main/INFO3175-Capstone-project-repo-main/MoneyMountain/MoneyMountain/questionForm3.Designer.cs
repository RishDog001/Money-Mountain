namespace MoneyMountain
{
    partial class questionForm3
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
            this.components = new System.ComponentModel.Container();
            this.timerLabel = new System.Windows.Forms.Label();
            this.questionLabel = new System.Windows.Forms.Label();
            this.listBoxChoices = new System.Windows.Forms.ListBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.radioButtonOption4 = new System.Windows.Forms.RadioButton();
            this.radioButtonOption3 = new System.Windows.Forms.RadioButton();
            this.radioButtonOption2 = new System.Windows.Forms.RadioButton();
            this.radioButtonOption1 = new System.Windows.Forms.RadioButton();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.groupBoxLifelines = new System.Windows.Forms.GroupBox();
            this.buttonLifeline1 = new System.Windows.Forms.Button();
            this.buttonLifeline2 = new System.Windows.Forms.Button();
            this.questionTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxLifelines.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.Red;
            this.timerLabel.Location = new System.Drawing.Point(618, 51);
            this.timerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(64, 25);
            this.timerLabel.TabIndex = 27;
            this.timerLabel.Text = "label1";
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.Location = new System.Drawing.Point(13, 51);
            this.questionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(64, 25);
            this.questionLabel.TabIndex = 26;
            this.questionLabel.Text = "label1";
            // 
            // listBoxChoices
            // 
            this.listBoxChoices.FormattingEnabled = true;
            this.listBoxChoices.ItemHeight = 18;
            this.listBoxChoices.Location = new System.Drawing.Point(623, 199);
            this.listBoxChoices.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBoxChoices.Name = "listBoxChoices";
            this.listBoxChoices.Size = new System.Drawing.Size(308, 94);
            this.listBoxChoices.TabIndex = 25;
            // 
            // buttonNext
            // 
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonNext.Location = new System.Drawing.Point(513, 348);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(149, 43);
            this.buttonNext.TabIndex = 24;
            this.buttonNext.Text = "Next Question";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.radioButtonOption4);
            this.groupBoxOptions.Controls.Add(this.radioButtonOption3);
            this.groupBoxOptions.Controls.Add(this.radioButtonOption2);
            this.groupBoxOptions.Controls.Add(this.radioButtonOption1);
            this.groupBoxOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 163);
            this.groupBoxOptions.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBoxOptions.Size = new System.Drawing.Size(401, 179);
            this.groupBoxOptions.TabIndex = 23;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // radioButtonOption4
            // 
            this.radioButtonOption4.AutoSize = true;
            this.radioButtonOption4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonOption4.Location = new System.Drawing.Point(215, 112);
            this.radioButtonOption4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.radioButtonOption4.Name = "radioButtonOption4";
            this.radioButtonOption4.Size = new System.Drawing.Size(146, 23);
            this.radioButtonOption4.TabIndex = 3;
            this.radioButtonOption4.TabStop = true;
            this.radioButtonOption4.Text = "radioButton4";
            this.radioButtonOption4.UseVisualStyleBackColor = true;
            this.radioButtonOption4.CheckedChanged += new System.EventHandler(this.radioButtonOption4_CheckedChanged);
            // 
            // radioButtonOption3
            // 
            this.radioButtonOption3.AutoSize = true;
            this.radioButtonOption3.Location = new System.Drawing.Point(6, 112);
            this.radioButtonOption3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.radioButtonOption3.Name = "radioButtonOption3";
            this.radioButtonOption3.Size = new System.Drawing.Size(135, 22);
            this.radioButtonOption3.TabIndex = 2;
            this.radioButtonOption3.TabStop = true;
            this.radioButtonOption3.Text = "radioButton3";
            this.radioButtonOption3.UseVisualStyleBackColor = true;
            this.radioButtonOption3.CheckedChanged += new System.EventHandler(this.radioButtonOption3_CheckedChanged);
            // 
            // radioButtonOption2
            // 
            this.radioButtonOption2.AutoSize = true;
            this.radioButtonOption2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonOption2.Location = new System.Drawing.Point(215, 47);
            this.radioButtonOption2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.radioButtonOption2.Name = "radioButtonOption2";
            this.radioButtonOption2.Size = new System.Drawing.Size(146, 23);
            this.radioButtonOption2.TabIndex = 1;
            this.radioButtonOption2.TabStop = true;
            this.radioButtonOption2.Text = "radioButton2";
            this.radioButtonOption2.UseVisualStyleBackColor = true;
            this.radioButtonOption2.CheckedChanged += new System.EventHandler(this.radioButtonOption2_CheckedChanged);
            // 
            // radioButtonOption1
            // 
            this.radioButtonOption1.AutoSize = true;
            this.radioButtonOption1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonOption1.Location = new System.Drawing.Point(6, 47);
            this.radioButtonOption1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.radioButtonOption1.Name = "radioButtonOption1";
            this.radioButtonOption1.Size = new System.Drawing.Size(146, 23);
            this.radioButtonOption1.TabIndex = 0;
            this.radioButtonOption1.TabStop = true;
            this.radioButtonOption1.Text = "radioButton1";
            this.radioButtonOption1.UseVisualStyleBackColor = true;
            this.radioButtonOption1.CheckedChanged += new System.EventHandler(this.radioButtonOption1_CheckedChanged);
            // 
            // buttonQuit
            // 
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonQuit.Location = new System.Drawing.Point(594, 313);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(125, 29);
            this.buttonQuit.TabIndex = 22;
            this.buttonQuit.Text = "Quit Game";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonConfirm.Location = new System.Drawing.Point(463, 313);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(125, 29);
            this.buttonConfirm.TabIndex = 21;
            this.buttonConfirm.Text = "Lock Answer";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // groupBoxLifelines
            // 
            this.groupBoxLifelines.Controls.Add(this.buttonLifeline1);
            this.groupBoxLifelines.Controls.Add(this.buttonLifeline2);
            this.groupBoxLifelines.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxLifelines.Location = new System.Drawing.Point(614, 100);
            this.groupBoxLifelines.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBoxLifelines.Name = "groupBoxLifelines";
            this.groupBoxLifelines.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.groupBoxLifelines.Size = new System.Drawing.Size(325, 71);
            this.groupBoxLifelines.TabIndex = 20;
            this.groupBoxLifelines.TabStop = false;
            this.groupBoxLifelines.Text = "Lifelines";
            // 
            // buttonLifeline1
            // 
            this.buttonLifeline1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLifeline1.Location = new System.Drawing.Point(6, 22);
            this.buttonLifeline1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonLifeline1.Name = "buttonLifeline1";
            this.buttonLifeline1.Size = new System.Drawing.Size(135, 33);
            this.buttonLifeline1.TabIndex = 0;
            this.buttonLifeline1.Text = "Audience Poll";
            this.buttonLifeline1.UseVisualStyleBackColor = true;
            this.buttonLifeline1.Click += new System.EventHandler(this.buttonLifeline1_Click);
            // 
            // buttonLifeline2
            // 
            this.buttonLifeline2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLifeline2.Location = new System.Drawing.Point(182, 22);
            this.buttonLifeline2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonLifeline2.Name = "buttonLifeline2";
            this.buttonLifeline2.Size = new System.Drawing.Size(135, 33);
            this.buttonLifeline2.TabIndex = 1;
            this.buttonLifeline2.Text = "50/50";
            this.buttonLifeline2.UseVisualStyleBackColor = true;
            this.buttonLifeline2.Click += new System.EventHandler(this.buttonLifeline2_Click);
            // 
            // questionForm3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 495);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.listBoxChoices);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.groupBoxLifelines);
            this.Name = "questionForm3";
            this.Text = "questionForm3";
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxLifelines.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.ListBox listBoxChoices;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.RadioButton radioButtonOption4;
        private System.Windows.Forms.RadioButton radioButtonOption3;
        private System.Windows.Forms.RadioButton radioButtonOption2;
        private System.Windows.Forms.RadioButton radioButtonOption1;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.GroupBox groupBoxLifelines;
        private System.Windows.Forms.Button buttonLifeline1;
        private System.Windows.Forms.Button buttonLifeline2;
        private System.Windows.Forms.Timer questionTimer;
    }
}