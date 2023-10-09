using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_App
{
    public partial class Form1 : Form
    {
        private List<QuizQuestion> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;
        private RadioButton[] radioButtonOptions;
        public Form1()
        {
            InitializeComponent();

            radioButtonOptions = new RadioButton[]
            {
                radioButton1,
                radioButton2,
                radioButton3,
                radioButton4,
            
            };

            questions = new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    QuestionText = "What is the capital of France?",
                    Choices = new List<string> { "Paris", "London", "Berlin", "Madrid" },
                    CorrectAnswerIndex = 0
                },
                new QuizQuestion
                {
                    QuestionText = "Which planet is known as the Red Planet?",
                    Choices = new List<string> { "Earth", "Mars", "Venus", "Jupiter" },
                    CorrectAnswerIndex = 1
                },
                // Add more questions here
            };

            // Initialize the first question
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                QuizQuestion currentQuestion = questions[currentQuestionIndex];
                label2.Text = currentQuestion.QuestionText;

                for (int i = 0; i < currentQuestion.Choices.Count; i++)
                {
                    radioButtonOptions[i].Text = currentQuestion.Choices[i];
                }
            }
            else
            {
                // Quiz finished, display the final score
                label4.Text = "Quiz Finished!";
                MessageBox.Show($"Your Score: {score}/{questions.Count}", "Quiz Finished");
            }
        }

        public class QuizQuestion
        {
            public string QuestionText { get; set; }
            public List<string> Choices { get; set; }
            public int CorrectAnswerIndex { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButtonOptions[currentQuestionIndex].Checked)
            {
                QuizQuestion currentQuestion = questions[currentQuestionIndex];
                if (radioButtonOptions[currentQuestionIndex].Text == currentQuestion.Choices[currentQuestion.CorrectAnswerIndex])
                {
                    score++; // Correct answer
                }
            }

            // Move to the next question
            currentQuestionIndex++;

            // Display the next question or finish the quiz
            DisplayQuestion();
        }
    }
}
