﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MoneyMountain
{
    public partial class QuestionForm3 : Form
    {
        private int time; //Time in seconds
        private int questionIndex; //Current question index
        private int earnings; //Total prize money earned
        private string correctAnswer; //Variable to store the correct answer in
        private bool isDoubleDipActive = false; //2 boolean variables to control the double dip lifeline
        private bool isFirstGuess = true;
        private bool isGameOver; //To determine if the game has ended or not
        private List<string> questionList = new List<string>(); //List of questions
        private List<string[]> answerList = new List<string[]>(); //List of answers

        public QuestionForm3()
        {
            InitializeComponent();
            InitializeGame(); //User-defined method to initailize the game settings
            DisplayQuestion(); //User-defined method to display the question and answers
        }

        private void QuestionForm3_Load(object sender, EventArgs e)
        {
            if (LifelineManager.Lifeline1Used)
            {
                buttonLifeline1.Enabled = false;
            }

            if (LifelineManager.Lifeline2Used)
            {
                buttonLifeline2.Enabled = false;
            }
        }

        private void questionTimer_Tick(object sender, EventArgs e)
        {
            time--; //Counting down by 1 second
            timerLabel.Text = $"Time Remaining: {time}"; //Label that displays the timer counting down

            if (time == 0)
            {
                questionTimer.Stop();
                earnings = 0;
                MessageBox.Show($"Game Over! You have been disqualified for failing to answer the question within the time limit! \nYour Prize Money: {earnings}", "Time Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isGameOver = true;
                Dispose();
                Application.Exit();
            }
        }

        private void DisplayQuestion()
        {
            questionList = new List<string> {
                "Where is the highest mountain located?"
            };

            answerList = new List<string[]>
            {
                new string[] { "A: Andes Mountain Range", "B: Mount Everest", "C: Swiss Alps", "D: Mount Kilimanjaro" }
            };

            correctAnswer = "B: Mount Everest";

            questionLabel.Text = questionList[questionIndex];
            radioButtonOption1.Text = answerList[questionIndex][0];
            radioButtonOption2.Text = answerList[questionIndex][1];
            radioButtonOption3.Text = answerList[questionIndex][2];
            radioButtonOption4.Text = answerList[questionIndex][3];
        }

        private void InitializeGame()
        {
            earnings = 200; //Carry over value from previous question

            questionTimer.Interval = 1000; //Time interval in milliseconds
            time = 45; //Initializing the timer to 45 seconds
            isGameOver = false; //Default initial value
            questionTimer.Tick -= questionTimer_Tick;
            questionTimer.Tick += questionTimer_Tick;

            buttonConfirm.Enabled = false; //Disabling the confirm and quit buttons at runtime
            buttonQuit.Enabled = false;

            buttonNext.Visible = false; //Hiding the next question button

            groupBoxLifelines.Enabled = false; //Disabling the lifeline buttons inside the groupbox at runtime
            groupBoxOptions.Enabled = false; //Disabling the radiobuttons at runtime until after the timer starts

            radioButtonOption1.Checked = false; //Unchecking the radio buttons at runtime
            radioButtonOption2.Checked = false;
            radioButtonOption3.Checked = false;
            radioButtonOption4.Checked = false;

            questionIndex = 0;
            DisplayQuestion();
        }

        private void buttonStartTimer_Click(object sender, EventArgs e)
        {
            questionTimer.Start(); //Start the timer
            buttonStartTimer.Enabled = false;
            groupBoxOptions.Enabled = true; //Enabling the radiobuttons when the timer starts
            groupBoxLifelines.Enabled = true; //Enabling the lifeline buttons when the timer starts
        }

        private void CheckAnswer()
        {
            if (radioButtonOption2.Checked)
            {
                earnings += 100;
                MessageBox.Show($"Correct! You've won ${earnings}", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonConfirm.Visible = false;
                buttonQuit.Visible = false;
                buttonNext.Visible = true;
            }

            else
            {
                earnings = 0;
                MessageBox.Show($"Incorrect! The Correct answer is {correctAnswer}", "Wrong Answer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EndGame();
            }
        }

        private void EndGame()
        {
            isGameOver = true;
            MessageBox.Show($"Game over! Your Prize Money: {earnings}.\nThank you for playing Money Mountain!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private List<int> AudiencePoll()
        {
            //Generate random audience choices
            Random random = new Random();
            List<int> choices = new List<int>();

            if (buttonLifeline2.Enabled)
            {
                for (int i = 0; i < 4; i++)
                {
                    int choice = (i == 0) ? 1 : random.Next(1, 5);
                    choices.Add(choice);
                }
            }

            else
            {
                for (int i = 0; i < 2; i++)
                {
                    int choice = (i == 0) ? 1 : random.Next(1, 5);
                    choices.Add(choice);
                }
            }

            return choices;
        }

        private void DisplayChoices(List<int> choices)
        {
            //Display the choices in the listbox
            listBoxResults.Items.Clear();
            
            for (int i = 0; i < choices.Count; i++)
            {
                listBoxResults.Items.Add($"Option: {i + 1}: {choices[i]} votes");
            }
        }

        private void DoubleDip()
        {
            isDoubleDipActive = true;
            buttonQuit.Enabled = false;
            MessageBox.Show("Double Dip lifeline activated! You have two chances to guess the correct answer.", "Double Dip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CheckDoubleDipAnswer()
        {
            if (!isDoubleDipActive)
            {
                CheckAnswer();
                return;
            }

            if (isFirstGuess)
            {
                isFirstGuess = false;
                if (IsAnswerCorrect())
                {
                    earnings += 100;
                    MessageBox.Show($"Correct! You've won ${earnings}", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetDoubleDip();
                }

                else
                {
                    MessageBox.Show($"Incorrect! You have 1 more guess remaining.", "Wrong Answer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    questionTimer.Start();
                    ResetOptions();
                }
            }

            else
            {
                if (IsAnswerCorrect())
                {
                    earnings += 100;
                    MessageBox.Show($"Correct! You've won ${earnings}", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetDoubleDip();
                }

                else
                {
                    earnings = 0;
                    MessageBox.Show($"Incorrect! The Correct answer is {correctAnswer}", "Wrong Answer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EndGame();
                }
            }
        }

        private bool IsAnswerCorrect() //Method to support the double dip lifeline
        {
            RadioButton selectedRadioButton = null;

            if (radioButtonOption1.Checked)
            {
                selectedRadioButton = radioButtonOption1;
            }

            else if (radioButtonOption2.Checked)
            {
                selectedRadioButton = radioButtonOption2;
            }

            else if (radioButtonOption3.Checked)
            {
                selectedRadioButton = radioButtonOption3;
            }

            else if (radioButtonOption4.Checked)
            {
                selectedRadioButton = radioButtonOption4;
            }

            if (selectedRadioButton != null && selectedRadioButton.Text == correctAnswer)
            {
                return true;
            }

            return false;
        }

        private void ResetDoubleDip()
        {
            isDoubleDipActive = false;
            buttonConfirm.Visible = false;
            buttonQuit.Visible = false;
            buttonNext.Visible = true;
            ResetOptions();
        }

        private void ResetOptions()
        {
            radioButtonOption1.Checked = false;
            radioButtonOption2.Checked = false;
            radioButtonOption3.Checked = false;
            radioButtonOption4.Checked = false;
        }

        private void buttonLifeline1_Click(object sender, EventArgs e)
        {
            if (!buttonLifeline2.Enabled)
            {
                if (MessageBox.Show("Are you sure you want to activate your last lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (isGameOver)
                    {
                        return;
                    }

                    else
                    {
                        questionTimer.Stop();

                        //Generate random choices
                        List<int> choices = AudiencePoll();

                        //Display the choices in the listbox
                        DisplayChoices(choices);

                        LifelineManager.UseLifeline(1); //Disables the lifeline buttons in each form as they get used up
                        buttonLifeline1.Enabled = false;
                        questionTimer.Start();
                        buttonQuit.Enabled = true;
                    }
                }

                else
                {
                    return;
                }
            }

            else
            {
                if (MessageBox.Show("Are you sure you want to activate the audience poll lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (isGameOver)
                    {
                        return;
                    }

                    else
                    {
                        questionTimer.Stop();

                        //Generate random choices
                        List<int> choices = AudiencePoll();

                        //Display the choices in the listbox
                        DisplayChoices(choices);

                        LifelineManager.UseLifeline(1); //Disables the lifeline buttons in each form as they get used up
                        buttonLifeline1.Enabled = false;
                        questionTimer.Start();
                        buttonQuit.Enabled = true;
                    }
                }

                else
                {
                    return;
                }
            }
        }

        private void buttonLifeline2_Click(object sender, EventArgs e)
        {
            if (!buttonLifeline1.Enabled)
            {
                if (MessageBox.Show("Are you sure you want to activate your last lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (isGameOver)
                    {
                        return;
                    }

                    else
                    {
                        questionTimer.Stop();
                        listBoxResults.Items.Clear();
                        DoubleDip();
                        buttonLifeline2.Enabled = false;
                        LifelineManager.UseLifeline(2); //Disables the lifeline buttons in each form as they get used up
                    }
                }

                else
                {
                    return;
                }
            }

            else
            {
                if (MessageBox.Show("Are you sure you want to activate the Double Dip lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (isGameOver)
                    {
                        return;
                    }

                    else
                    {
                        questionTimer.Stop();
                        DoubleDip();
                        buttonLifeline2.Enabled = false;
                        LifelineManager.UseLifeline(2); //Disables the lifeline buttons in each form as they get used up
                    }
                }

                else
                {
                    return;
                }
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (!isDoubleDipActive)
            {
                if (MessageBox.Show("Are you sure you want to lock in your answer?", "Confirm Answer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    questionTimer.Stop();
                    groupBoxOptions.Enabled = false;
                    groupBoxLifelines.Enabled = false;
                    buttonQuit.Enabled = false;
                    CheckAnswer();
                }

                else
                {
                    return;
                }
            }

            else
            {
                CheckDoubleDipAnswer();
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                questionTimer.Stop();
                EndGame();
            }

            else
            {
                return;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            QuestionForm4 questionForm4 = new QuestionForm4();

            if (MessageBox.Show("Ready to move onto the next question?", "Next Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetDoubleDip();
                Close();
                questionForm4.Show();
            }

            else
            {
                return;
            }
        }

        private void radioButtonOption1_CheckedChanged(object sender, EventArgs e)
        {
            buttonConfirm.Enabled = radioButtonOption1.Checked;
        }

        private void radioButtonOption2_CheckedChanged(object sender, EventArgs e)
        {
            buttonConfirm.Enabled = radioButtonOption2.Checked;
        }

        private void radioButtonOption3_CheckedChanged(object sender, EventArgs e)
        {
            buttonConfirm.Enabled = radioButtonOption3.Checked;
        }

        private void radioButtonOption4_CheckedChanged(object sender, EventArgs e)
        {
            buttonConfirm.Enabled = radioButtonOption4.Checked;
        }
    }
}