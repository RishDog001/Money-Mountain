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
    public partial class QuestionForm14 : Form
    {
        private int questionIndex; //Current question index
        private int earnings; //Total prize money earned
        private string correctAnswer; //Variable to store the correct answer in
        private bool isDoubleDipActive = false; //2 boolean variables to control the double dip lifeline
        private bool isFirstGuess = true;
        private bool isGameOver; //To determine if the game has ended or not
        private List<string> questionList = new List<string>(); //List of questions
        private List<string[]> answerList = new List<string[]>(); //List of answers

        public QuestionForm14()
        {
            InitializeComponent();
            InitializeGame();
            DisplayQuestion();
        }

        private void QuestionForm14_Load(object sender, EventArgs e)
        {
            if (LifelineManager.Lifeline1Used)
            {
                LifelineManager.UseLifeline(1);
                buttonQuit.Enabled = true;
            }

            if (LifelineManager.Lifeline2Used)
            {
                LifelineManager.UseLifeline(2);
                buttonQuit.Enabled = true;
            }
        }

        private void DisplayQuestion()
        {
            questionList = new List<string> {
                "What technology company was founded in 1993\nwith the vision that the next wave of\ncomputing would be graphics-based?"
            };

            answerList = new List<string[]>
            {
                new string[] { "A: Amazon", "B: Yahoo!", "C: eBay", "D: Nvidia" }
            };

            correctAnswer = "D: Nvidia";

            questionLabel.Text = questionList[questionIndex];
            radioButtonOption1.Text = answerList[questionIndex][0];
            radioButtonOption2.Text = answerList[questionIndex][1];
            radioButtonOption3.Text = answerList[questionIndex][2];
            radioButtonOption4.Text = answerList[questionIndex][3];
        }

        private void InitializeGame()
        {
            earnings = 250000; //Carry over value from previous question
            isGameOver = false; //Default initial value

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
            if (radioButtonOption4.Checked)
            {
                earnings *= 2;
                MessageBox.Show($"Correct! You've won ${earnings}", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonConfirm.Visible = false;
                buttonQuit.Visible = false;
                buttonNext.Visible = true;
            }

            else
            {
                earnings -= 218000;
                MessageBox.Show($"Incorrect! The Correct answer is {correctAnswer}", "Wrong Answer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EndGame();
            }
        }

        private void EndGame()
        {
            LoginForm loginForm = new LoginForm();
            isGameOver = true;
            MessageBox.Show($"Game over! Your Prize Money: ${earnings}.\nThank you for playing Money Mountain!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            loginForm.Show();
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
                    earnings *= 2;
                    MessageBox.Show($"Correct! You've won ${earnings}.", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetDoubleDip();
                }

                else
                {
                    MessageBox.Show($"Incorrect! You have 1 more guess remaining.", "Wrong Answer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetOptions();
                }
            }

            else
            {
                if (IsAnswerCorrect())
                {
                    earnings *= 2;
                    MessageBox.Show($"Correct! You've won ${earnings}", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetDoubleDip();
                }

                else
                {
                    earnings -= 218000;
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

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (!isDoubleDipActive)
            {
                if (MessageBox.Show("Are you sure you want to lock in your answer?", "Confirm Answer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
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
                if (MessageBox.Show("Are you sure you want to activate your last lifeline?", "Activate Lifeline", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (isGameOver)
                    {
                        return;
                    }

                    else
                    {
                        //Generate random choices
                        List<int> choices = AudiencePoll();

                        //Display the choices in the listbox
                        DisplayChoices(choices);
                        LifelineManager.UseLifeline(1);
                        buttonLifeline1.Enabled = false;
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
                        //Generate random choices
                        List<int> choices = AudiencePoll();

                        //Display the choices in the listbox
                        DisplayChoices(choices);
                        LifelineManager.UseLifeline(1);
                        buttonLifeline1.Enabled = false;
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
                        listBoxResults.Items.Clear();
                        DoubleDip();
                        buttonLifeline2.Enabled = false;
                        LifelineManager.UseLifeline(2);
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
                        listBoxResults.Items.Clear();
                        DoubleDip();
                        buttonLifeline2.Enabled = false;
                        LifelineManager.UseLifeline(2);
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
            QuestionForm15 questionForm15 = new QuestionForm15();

            if (MessageBox.Show("Ready to move onto the next question?", "Next Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetDoubleDip();
                Close();
                questionForm15.Show();
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