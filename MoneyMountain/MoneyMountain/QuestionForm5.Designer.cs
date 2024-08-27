namespace MoneyMountain
{
    partial class QuestionForm5
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
            this.questionLabel = new System.Windows.Forms.Label();
            this.questionTimer = new System.Windows.Forms.Timer(this.components);
            this.timerLabel = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.radioButtonOption4 = new System.Windows.Forms.RadioButton();
            this.radioButtonOption3 = new System.Windows.Forms.RadioButton();
            this.radioButtonOption2 = new System.Windows.Forms.RadioButton();
            this.radioButtonOption1 = new System.Windows.Forms.RadioButton();
            this.groupBoxLifelines = new System.Windows.Forms.GroupBox();
            this.buttonLifeline2 = new System.Windows.Forms.Button();
            this.buttonLifeline1 = new System.Windows.Forms.Button();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonStartTimer = new System.Windows.Forms.Button();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxLifelines.SuspendLayout();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.Location = new System.Drawing.Point(32, 27);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(53, 20);
            this.questionLabel.TabIndex = 0;
            this.questionLabel.Text = "label1";
            // 
            // questionTimer
            // 
            this.questionTimer.Interval = 1000;
            this.questionTimer.Tick += new System.EventHandler(this.questionTimer_Tick);
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.Red;
            this.timerLabel.Location = new System.Drawing.Point(549, 27);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(158, 20);
            this.timerLabel.TabIndex = 1;
            this.timerLabel.Text = "Time Remaining: 45";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.radioButtonOption4);
            this.groupBoxOptions.Controls.Add(this.radioButtonOption3);
            this.groupBoxOptions.Controls.Add(this.radioButtonOption2);
            this.groupBoxOptions.Controls.Add(this.radioButtonOption1);
            this.groupBoxOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxOptions.Location = new System.Drawing.Point(36, 151);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(432, 188);
            this.groupBoxOptions.TabIndex = 2;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // radioButtonOption4
            // 
            this.radioButtonOption4.AutoSize = true;
            this.radioButtonOption4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonOption4.Location = new System.Drawing.Point(247, 132);
            this.radioButtonOption4.Name = "radioButtonOption4";
            this.radioButtonOption4.Size = new System.Drawing.Size(112, 21);
            this.radioButtonOption4.TabIndex = 3;
            this.radioButtonOption4.Text = "radioButton1";
            this.radioButtonOption4.UseVisualStyleBackColor = true;
            this.radioButtonOption4.CheckedChanged += new System.EventHandler(this.radioButtonOption4_CheckedChanged);
            // 
            // radioButtonOption3
            // 
            this.radioButtonOption3.AutoSize = true;
            this.radioButtonOption3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonOption3.Location = new System.Drawing.Point(7, 132);
            this.radioButtonOption3.Name = "radioButtonOption3";
            this.radioButtonOption3.Size = new System.Drawing.Size(112, 21);
            this.radioButtonOption3.TabIndex = 2;
            this.radioButtonOption3.Text = "radioButton1";
            this.radioButtonOption3.UseVisualStyleBackColor = true;
            this.radioButtonOption3.CheckedChanged += new System.EventHandler(this.radioButtonOption3_CheckedChanged);
            // 
            // radioButtonOption2
            // 
            this.radioButtonOption2.AutoSize = true;
            this.radioButtonOption2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonOption2.Location = new System.Drawing.Point(247, 39);
            this.radioButtonOption2.Name = "radioButtonOption2";
            this.radioButtonOption2.Size = new System.Drawing.Size(112, 21);
            this.radioButtonOption2.TabIndex = 1;
            this.radioButtonOption2.Text = "radioButton1";
            this.radioButtonOption2.UseVisualStyleBackColor = true;
            this.radioButtonOption2.CheckedChanged += new System.EventHandler(this.radioButtonOption2_CheckedChanged);
            // 
            // radioButtonOption1
            // 
            this.radioButtonOption1.AutoCheck = false;
            this.radioButtonOption1.AutoSize = true;
            this.radioButtonOption1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButtonOption1.Location = new System.Drawing.Point(7, 39);
            this.radioButtonOption1.Name = "radioButtonOption1";
            this.radioButtonOption1.Size = new System.Drawing.Size(112, 21);
            this.radioButtonOption1.TabIndex = 0;
            this.radioButtonOption1.Text = "radioButton1";
            this.radioButtonOption1.UseVisualStyleBackColor = true;
            this.radioButtonOption1.CheckedChanged += new System.EventHandler(this.radioButtonOption1_CheckedChanged);
            // 
            // groupBoxLifelines
            // 
            this.groupBoxLifelines.Controls.Add(this.buttonLifeline2);
            this.groupBoxLifelines.Controls.Add(this.buttonLifeline1);
            this.groupBoxLifelines.Location = new System.Drawing.Point(547, 99);
            this.groupBoxLifelines.Name = "groupBoxLifelines";
            this.groupBoxLifelines.Size = new System.Drawing.Size(241, 96);
            this.groupBoxLifelines.TabIndex = 3;
            this.groupBoxLifelines.TabStop = false;
            this.groupBoxLifelines.Text = "Lifelines";
            // 
            // buttonLifeline2
            // 
            this.buttonLifeline2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLifeline2.Location = new System.Drawing.Point(134, 39);
            this.buttonLifeline2.Name = "buttonLifeline2";
            this.buttonLifeline2.Size = new System.Drawing.Size(98, 32);
            this.buttonLifeline2.TabIndex = 1;
            this.buttonLifeline2.Text = "Double Dip";
            this.buttonLifeline2.UseVisualStyleBackColor = true;
            this.buttonLifeline2.Click += new System.EventHandler(this.buttonLifeline2_Click);
            // 
            // buttonLifeline1
            // 
            this.buttonLifeline1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLifeline1.Location = new System.Drawing.Point(6, 39);
            this.buttonLifeline1.Name = "buttonLifeline1";
            this.buttonLifeline1.Size = new System.Drawing.Size(105, 32);
            this.buttonLifeline1.TabIndex = 0;
            this.buttonLifeline1.Text = "Audience Poll";
            this.buttonLifeline1.UseVisualStyleBackColor = true;
            this.buttonLifeline1.Click += new System.EventHandler(this.buttonLifeline1_Click);
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.ItemHeight = 16;
            this.listBoxResults.Location = new System.Drawing.Point(547, 223);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(241, 116);
            this.listBoxResults.TabIndex = 4;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonConfirm.Location = new System.Drawing.Point(547, 345);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(107, 26);
            this.buttonConfirm.TabIndex = 5;
            this.buttonConfirm.Text = "Lock Answer";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonQuit.Location = new System.Drawing.Point(681, 345);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(98, 26);
            this.buttonQuit.TabIndex = 6;
            this.buttonQuit.Text = "Quit Game";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonNext.Location = new System.Drawing.Point(547, 387);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(107, 25);
            this.buttonNext.TabIndex = 7;
            this.buttonNext.Text = "Next Question";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonStartTimer
            // 
            this.buttonStartTimer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonStartTimer.Location = new System.Drawing.Point(681, 387);
            this.buttonStartTimer.Name = "buttonStartTimer";
            this.buttonStartTimer.Size = new System.Drawing.Size(98, 23);
            this.buttonStartTimer.TabIndex = 8;
            this.buttonStartTimer.Text = "Start Timer";
            this.buttonStartTimer.UseVisualStyleBackColor = true;
            this.buttonStartTimer.Click += new System.EventHandler(this.buttonStartTimer_Click);
            // 
            // QuestionForm5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 433);
            this.Controls.Add(this.buttonStartTimer);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.groupBoxLifelines);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.questionLabel);
            this.Name = "QuestionForm5";
            this.Text = "Question 5 - Worth $1000";
            this.Load += new System.EventHandler(this.QuestionForm5_Load);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxLifelines.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Timer questionTimer;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.GroupBox groupBoxLifelines;
        private System.Windows.Forms.Button buttonLifeline2;
        private System.Windows.Forms.Button buttonLifeline1;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.RadioButton radioButtonOption4;
        private System.Windows.Forms.RadioButton radioButtonOption3;
        private System.Windows.Forms.RadioButton radioButtonOption2;
        private System.Windows.Forms.RadioButton radioButtonOption1;
        private System.Windows.Forms.Button buttonStartTimer;
    }
}