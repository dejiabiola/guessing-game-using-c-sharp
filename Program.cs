using System;

namespace guessing_game
{
    class Program
    {



        static void checkLevel(string level)
        {
          //Check level the user wants and call the appropriate function
            if (level == "easy") 
            {
              gameFunction(10, 6, level);
            }
            else if (level == "medium")
            {
              gameFunction(20, 4, level);
            }
            else if (level == "hard")
            {
              gameFunction(50, 3, level);
            }
            else 
            {
              Console.WriteLine("You have entered an invalid input.");
            }
        }

        static void gameFunction(int guess_max, int guess_limit, string difficulty)
        {
          // Prompt the user for a number from 1 to guess_max and validate. Prompt again if validation fails.
          Console.WriteLine("You chose {0} level. Can you guess the magic number?", difficulty);
          Console.WriteLine("Please enter a number between 1 and {0}:", guess_max);
          int guess = Convert.ToInt32(Console.ReadLine());

          while(guess > guess_max || guess < 1) {
            Console.WriteLine("You need to enter a number between 1 and {0}:", guess_max);
            guess = Convert.ToInt32(Console.ReadLine());
          }

          // Declare necessary variables
          int guess_count = 1;

          Random rnd = new Random();
          int random_number = rnd.Next(1, (guess_max + 1));
          bool out_of_guesses = false;

          while (guess != random_number && !out_of_guesses) {
            // check if the user guesses correctly the random number and if out of guesses

            if (guess_count < guess_limit) {
              // Ask the user to guess again and run validation on user prompt
              Console.WriteLine("That was wrong.");
              Console.WriteLine("You have " + (guess_limit - guess_count) + " guesses left. Guess again:");
              guess = Convert.ToInt32(Console.ReadLine());
              while(guess > guess_max || guess < 1) {
                Console.WriteLine("You need to enter a number between 1 and {0}:", guess_max);
                guess = Convert.ToInt32(Console.ReadLine());
              }
              guess_count += 1;
            } else {
              out_of_guesses = true;
            }
          }
          // pass out of guesses value to function
          checkForWin(out_of_guesses);

        }

        static void checkForWin(bool out_of_guesses)
        {
          // If out of gueses is true, then user lost otherwise user won
          if (out_of_guesses) 
          {
            Console.WriteLine("Game over!");
          }
          else 
          {
            Console.WriteLine("You got it right!");
          }
        }

        static void Main(string[] args)
        {
          Console.WriteLine("Welcome to the number guessing game!");
          Console.WriteLine("There are 3 levels. These are easy, medium and hard.");
          Console.WriteLine("Enter a level to continue: ");
          string level = Console.ReadLine().ToLower();
          checkLevel(level);
        }
    }
}
