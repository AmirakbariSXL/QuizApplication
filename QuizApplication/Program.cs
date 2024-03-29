
using System;
using System.Collections.Generic;

namespace QuizApplication
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; } // Passwords should be hashed in a real application
    }

    public static class UserDatabase
    {
        private static Dictionary<string, User> users = new Dictionary<string, User>();

        public static bool Register(User newUser)
        {
            if (!users.ContainsKey(newUser.Username))
            {
                users.Add(newUser.Username, newUser);
                return true;
            }
            return false;
        }

        public static bool Login(string username, string password)
        {
            if (users.TryGetValue(username, out User user))
            {
                return user.Password == password; // Use password hashing and comparison in a real application
            }
            return false;
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public string Answer { get; set; }

        public Question(string text, string answer)
        {
            Text = text;
            Answer = answer;
        }
    }

    class Program
    {
        static List<Question> questions = new List<Question>
        {
            // Default questions
                new Question("What is the capital of France?", "Paris"),
                new Question("Who wrote 'Hamlet'?", "Shakespeare"),
                new Question("What is the chemical symbol for water?", "H2O"),
                new Question ("Who wrote the book Chitty-Chitty-Bang-Bang: The Magical Car?","Ian Fleming"),
                new Question("In which part of your body would you find the cruciate ligament?","Knee"),
                new Question("What is the name of the main antagonist in the Shakespeare play Othello?","Iago"),
          };



        class Main_program
        {


            static void Main(string[] args)
            {
                Console.WriteLine("Welcome to the Quiz Application!");
                bool exitApp = false;

                while (!exitApp)
                {
                    Console.WriteLine("Please register or login to continue.");
                    // Registration and login logic...

                    Console.WriteLine("Would you like to [1] Take the quiz, [2] Add your own question, or [3] Exit?");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            StartQuiz();
                            break;
                        case "2":
                            AddQuestion();
                            break;
                        case "3":
                            Console.WriteLine("Thank you for using the Quiz Application. Goodbye!");
                            exitApp = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }

            static void StartQuiz()
            {
                int score = 0;
                foreach (var question in questions)
                {
                    Console.WriteLine(question.Text);
                    string answer = Console.ReadLine();

                    if (answer.Equals(question.Answer, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine($"Wrong! The correct answer is {question.Answer}.");
                    }
                }

                Console.WriteLine($"Quiz completed! Your score: {score}/{questions.Count}");
            }

            static void AddQuestion()
            {
                Console.WriteLine("Enter your question:");
                string userQuestion = Console.ReadLine();
                Console.WriteLine("Enter the answer:");
                string userAnswer = Console.ReadLine();

                questions.Add(new Question(userQuestion, userAnswer));
                Console.WriteLine("Your question has been added. Thank you!");
            }
        }

    }
}
