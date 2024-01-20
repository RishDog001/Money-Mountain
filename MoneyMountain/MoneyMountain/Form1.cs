using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MoneyMountain
{
    public partial class QuestionForm1 : Form
    {
        private int time; //Time in seconds
        private int questionIndex; //Current question index
        private int earnings; //Total prize money earned
        private bool gameOver; //To determine if the game has ended or not
        private List<string> questionList = new List<string>(); //List of questions
        private List<string[]> answerList = new List<string[]>(); //List of answers

        public QuestionForm1()
        {
            InitializeComponent();
            InitializeGame(); //User-defined method to initailize the game settings
            DisplayQuestion(); //User-defined method to display the question and answers
        }

        private void questionTimer1_Tick(object sender, EventArgs e)
        {
            time--; //Counting down by 1 second
            timerLabel.Text = $"Time remaining: {time}"; //Label that displays the timer counting down

            if (time == 0)
            {
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
                "Which color is commonly associated with perfectly ripe bananas?"
            };

            answerList = new List<string[]>
            {
                new string[] { "A: Yellow", "B: Green", "C: Brown", "D: Black" }
            };

            questionLabel.Text = questionList[questionIndex];
            radioButtonOption1.Text = answerList[questionIndex][0];
            radioButtonOption2.Text = answerList[questionIndex][1];
            radioButtonOption3.Text = answerList[questionIndex][2];
            radioButtonOption4.Text = answerList[questionIndex][3];

            groupBoxLifelines.Enabled = true;

            radioButtonOption1.Checked = false;
            radioButtonOption2.Checked = false;
            radioButtonOption3.Checked = false;
            radioButtonOption4.Checked = false;

            questionIndex = 0;
        }

        private void InitializeGame()
        {
            questionTimer.Interval = 1000; //Time interval in milliseconds
            time = 45; //Initializing the timer to 45 seconds
            gameOver = false; //Default initial value
            earnings = 0; //Default initial value
            questionTimer.Tick += questionTimer1_Tick;
            questionTimer.Start(); //Start the timer

            buttonConfirm.Enabled = false; //Disabling the confirm and quit buttons at the start
            buttonQuit.Enabled = false;

            buttonNext.Visible = false; //Hiding the next question button

            buttonLifeline1.Enabled = true; //Enabling the lifeline buttons at the start
            buttonLifeline2.Enabled = true;

            DisplayQuestion();
        }

        private void CheckAnswer()
        {
            if (radioButtonOption1.Checked)
            {
                earnings += 100;
                MessageBox.Show($"Correct! You've won {earnings}", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonConfirm.Visible = false;
                buttonQuit.Visible = false;
                buttonNext.Visible = true;
            }

            else
            {
                MessageBox.Show($"Incorrect! The Correct answer is {radioButtonOption1.Text}", "Wrong Answer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EndGame();
            }
        }

        private void EndGame()
        {
            gameOver = true;
            MessageBox.Show($"Game over! Your Prize Money: {earnings}.\n Thank you for playing Money Mountain!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private List<int> AudiencePoll()
        {
            //Generate random audience choices
            Random random = new Random();
            List<int> choices = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                int choice = (i == 0) ? 1 : random.Next(1, 5);
                choices.Add(choice);
            }

            return choices;
        }

        private void DisplayChoices(List<int> choices)
        {
            //Display the choices in the listbox
            listBoxChoices.Items.Clear();
            for (int i = 0; i < choices.Count; i++)
            {
                listBoxChoices.Items.Add($"Option: {i + 1}: {choices[i]} votes");
            }
        }

        private void FiftyFifty()
        {
            //Randomize the answer choices
            var choices = answerList.OrderBy(i => Guid.NewGuid()).ToList();

            //Keep only the 1st 2 choices
            choices = choices.Take(2).ToList();

            radioButtonOption3.Enabled = false;
            radioButtonOption4.Enabled = false;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Are you sure you want to lock in your answer?", "Confirm Answer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            //MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MessageBox.Show("Are you sure you want to quit?", "Quit Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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
                //MessageBox.Show("Are you sure you want to activate your last lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                        if (!buttonLifeline1.Enabled || !buttonLifeline2.Enabled)
                        {
                            buttonQuit.Enabled = true;
                        }
                    }
                }

                else
                {
                    return;
                }
            }

            else
            {
                //MessageBox.Show("Are you sure you want to activate the audience poll lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                        if (!buttonLifeline1.Enabled || !buttonLifeline2.Enabled)
                        {
                            buttonQuit.Enabled = true;
                        }
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
                //MessageBox.Show("Are you sure you want to activate your last lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (MessageBox.Show("Are you sure you want to activate your last lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gameOver)
                    {
                        return;
                    }

                    else
                    {
                        questionTimer.Stop();
                        listBoxChoices.Items.Clear();
                        FiftyFifty();
                        buttonLifeline2.Enabled = false;
                        questionTimer.Start();

                        if (!buttonLifeline1.Enabled || !buttonLifeline2.Enabled)
                        {
                            buttonQuit.Enabled = true;
                        }
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

                        if (!buttonLifeline1.Enabled || !buttonLifeline2.Enabled)
                        {
                            buttonQuit.Enabled = true;
                        }
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
            QuestionForm2 questionForm2 = new QuestionForm2();
            //MessageBox.Show("Ready to move onto the next question?", "Next Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (MessageBox.Show("Ready to move onto the next question?", "Next Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
                Close();
                questionForm2.Show();
            }

            else
            {
                return;
            }
        }

        private void radioButtonOption1_CheckedChanged(object sender, EventArgs e)
        {
            buttonConfirm.Enabled = true;
        }

        private void radioButtonOption2_CheckedChanged(object sender, EventArgs e)
        {
            buttonConfirm.Enabled = true;
        }

        private void radioButtonOption3_CheckedChanged(object sender, EventArgs e)
        {
            buttonConfirm.Enabled = true;
        }

        private void radioButtonOption4_CheckedChanged(object sender, EventArgs e)
        {
            buttonConfirm.Enabled = true;
        }
    }
}