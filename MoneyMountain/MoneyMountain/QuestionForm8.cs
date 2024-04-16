using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyMountain
{
    public partial class QuestionForm8 : Form
    {
        private int time; //Time in seconds
        private int questionIndex; //Current question index
        private int earnings; //Total prize money earned
        private bool gameOver; //To determine if the game has ended or not
        private List<string> questionList = new List<string>(); //List of questions
        private List<string[]> answerList = new List<string[]>(); //List of answers

        public QuestionForm8()
        {
            InitializeComponent();
            InitializeGame();
            DisplayQuestion();
        }

        private void questionTimer_Tick(object sender, EventArgs e)
        {
            time--; //Counting down by 1 second
            timerLabel.Text = $"Time remaining: {time}"; //Label that displays the timer counting down

            if (time == 0)
            {
                questionTimer.Stop();
                earnings = 0;
                MessageBox.Show($"Game Over! You have been disqualified for failing to answer the question within the time limit! \nYour Prize Money: {earnings}", "Time Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gameOver = true;
                Dispose();
                Application.Exit();
            }
        }

        private void DisplayQuestion()
        {
            questionList = new List<string> {
                "What is the tallest building in the world?"
            };

            answerList = new List<string[]>
            {
                new string[] { "A: CN Tower", "B: Empire State Building", "C: Burj Khalifa", "D: Eiffel Tower" }
            };

            questionLabel.Text = questionList[questionIndex];
            radioButtonOption1.Text = answerList[questionIndex][0];
            radioButtonOption2.Text = answerList[questionIndex][1];
            radioButtonOption3.Text = answerList[questionIndex][2];
            radioButtonOption4.Text = answerList[questionIndex][3];
        }

        private void InitializeGame()
        {
            earnings = 4000; //Carry over value from previous question
            questionTimer.Interval = 1000; //Time interval in milliseconds
            time = 60; //Initializing the timer to 60 seconds
            gameOver = false; //Default initial value
            questionTimer.Tick += questionTimer_Tick;
            questionTimer.Start(); //Start the timer

            buttonConfirm.Enabled = false; //Disabling the confirm and quit buttons at runtime
            buttonQuit.Enabled = false;

            buttonNext.Visible = false; //Hiding the next question button

            groupBoxLifelines.Enabled = true; //Enabling the lifeline buttons inside the groupbox at runtime

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
            if (radioButtonOption3.Checked)
            {
                earnings *= 2;
                MessageBox.Show($"Correct! You've won ${earnings}", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonConfirm.Visible = false;
                buttonQuit.Visible = false;
                buttonNext.Visible = true;
            }

            else
            {
                earnings /= 4;
                MessageBox.Show($"Incorrect! The Correct answer is {radioButtonOption3.Text}", "Wrong Answer", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void FiftyFifty()
        {
            radioButtonOption2.Enabled = false;
            radioButtonOption4.Enabled = false;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
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

        private void buttonQuit_Click(object sender, EventArgs e)
        {
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

        private void buttonLifeline1_Click(object sender, EventArgs e)
        {
            if (!buttonLifeline2.Enabled)
            {
                if (MessageBox.Show("Are you sure you want to activate your last lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gameOver)
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
                    if (gameOver)
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
                    if (gameOver)
                    {
                        return;
                    }

                    else
                    {
                        questionTimer.Stop();
                        listBoxResults.Items.Clear();
                        FiftyFifty();
                        buttonLifeline2.Enabled = false;
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
                if (MessageBox.Show("Are you sure you want to activate the 50/50 lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gameOver)
                    {
                        return;
                    }

                    else
                    {
                        questionTimer.Stop();
                        FiftyFifty();
                        buttonLifeline2.Enabled = false;
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

        private void buttonNext_Click(object sender, EventArgs e)
        {
            QuestionForm9 questionForm9 = new QuestionForm9();

            if (MessageBox.Show("Ready to move onto the next question?", "Next Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Hide();
                questionForm9.Show();
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