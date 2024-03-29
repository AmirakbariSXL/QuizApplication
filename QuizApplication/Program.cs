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
        public string Text { get; }
        public string Answer { get; }

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
        new Question("What is the capital of France?", "Paris"),
                new Question("Who wrote 'Hamlet'?", "Shakespeare"),
                new Question("What is the chemical symbol for water?", "H2O"),
                new Question ("Who wrote the book Chitty-Chitty-Bang-Bang: The Magical Car?","Ian Fleming"),
                new Question("In which part of your body would you find the cruciate ligament?","Knee"),
                new Question("What is the name of the main antagonist in the Shakespeare play Othello?","Iago"),
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Quiz Application!");
            Console.WriteLine("Please register or login to continue.");

            while (true)

                break
            {
                Console.WriteLine("Choose an option: [1] Register [2] Login");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter username:");
                        string newUsername = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        string newPassword = Console.ReadLine();

                        var newUser = new User { Username = newUsername, Password = newPassword };
                        bool registrationSuccess = UserDatabase.Register(newUser);

                        if (registrationSuccess)
                        {
                            Console.WriteLine("Registration successful!");
                            StartQuiz();
                        }
                        else
                        {
                            Console.WriteLine("Username already exists. Please try a different username.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Enter username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        string password = Console.ReadLine();

                        bool loginSuccess = UserDatabase.Login(username, password);

                        if (loginSuccess)
                        {
                            Console.WriteLine("Login successful!");
                            StartQuiz();
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password.");
                        }
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
                /*
     Text: A public property that holds the text of the quiz question.
     Answer: A public property that holds the answer to the quiz question.
     */
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
    }
}

