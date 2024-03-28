using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MoneyMountain
{
    public partial class QuestionForm16 : Form
    {
        private int questionIndex; //Current question index
        private int earnings; //Total prize money earned
        private bool gameOver; //To determine if the game has ended or not
        private List<string> questionList = new List<string>(); //List of questions
        private List<string[]> answerList = new List<string[]>(); //List of answers

        public QuestionForm16()
        {
            InitializeComponent();
            InitializeGame();
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            questionList = new List<string> {
                "According to the Population Reference Bureau,\nwhat is the approximate number of people who\nhave ever lived on earth?"
            };

            answerList = new List<string[]>
            {
                new string[] { "A: 50 billion", "B: 100 billion", "C: 1 trillion", "D: 5 trillion" }
            };

            questionLabel.Text = questionList[questionIndex];
            radioButtonOption1.Text = answerList[questionIndex][0];
            radioButtonOption2.Text = answerList[questionIndex][1];
            radioButtonOption3.Text = answerList[questionIndex][2];
            radioButtonOption4.Text = answerList[questionIndex][3];
        }

        private void InitializeGame()
        {
            earnings = 1000000; //Carry over value from previous question
            gameOver = false; //Default initial value

            buttonConfirm.Enabled = false; //Disabling the confirm button at runtime

            groupBoxLifelines.Enabled = false; //Disabling the lifeline buttons inside the groupbox at runtime since the user won't be able to use them for the final question
            listBoxResults.Enabled = false; //Disabling the listbox at runtime

            radioButtonOption1.Checked = false; //Unchecking the radio buttons at runtime
            radioButtonOption2.Checked = false;
            radioButtonOption3.Checked = false;
            radioButtonOption4.Checked = false;

            radioButtonOption1.AutoCheck = true;

            questionIndex = 0;
            DisplayQuestion();
        }

        private void CheckAnswer()
        {
            if (radioButtonOption2.Checked)
            {
                earnings *= 7;
                MessageBox.Show($"Congratulations! You've just won the jackpot, which is worth ${earnings}!", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonConfirm.Visible = false;
                buttonQuit.Visible = false;
                EndGame();
            }

            else
            {
                earnings -= 968000;
                MessageBox.Show($"Incorrect! The Correct answer is {radioButtonOption2.Text}", "Wrong Answer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EndGame();
            }
        }

        private void EndGame()
        {
            LoginForm loginForm = new LoginForm();
            gameOver = true;
            MessageBox.Show($"Game over! Your Prize Money: ${earnings}.\nThank you for playing Money Mountain!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
            loginForm.Show();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to lock in your answer?", "Confirm Answer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                groupBoxOptions.Enabled = false;
                buttonQuit.Enabled = false;
                CheckAnswer();
            }

            else
            {
                return;
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EndGame();
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