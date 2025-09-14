using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace LectureTasks {
    internal class Lecture2 : Program {

        public static void FizzBuzz() {
            int number;

            Console.Write( "Enter a number: " );
            number = Helpers.NumberCheck( Console.ReadLine() );

            for ( int i = 1; i <= number; i++ ) {
                if ( i % 3 == 0 && i % 5 == 0 ) {
                    Console.WriteLine( "FizzBuzz" );
                } else if ( i % 3 == 0 ) {
                    Console.WriteLine( "Fizz" );
                } else if ( i % 5 == 0 ) {
                    Console.WriteLine( "Buzz" );
                } else {
                    Console.WriteLine( i );
                }
            }
        }

        /*
         * AGE CHECK TASK METHOD
         * Asks for name, and age, and prints a message to let the user know they are a minor, adult, or senior
         */
        public static void AgeTask() {

            // Initiate the variables
            string name;
            int age;

            // Get the name
            Console.Write( "What is your name?: " );
            name = Helpers.NameCheck( Console.ReadLine() );

            // Title case the name, so the first letter starts with a capital, and the rest are lowercase
            name = Helpers.Capitalize( name );

            // Get the age
            Console.Write( "How old are you?: " );
            age = Helpers.NumberCheck( Console.ReadLine() );

            // If the age entered is less than 18
            if ( age < 18 ) {
                Console.WriteLine( $"Hello {name}, you are a minor." );

            // Else if the age entered is between 18 and 64
            } else if ( age >= 18 && age <= 64 ) {
                Console.WriteLine( $"Hello {name}, you are an adult." );

            // Else if the age entered is greater than 64 (65 or higher)
            } else {
                Console.WriteLine( $"Hello {name}, you are a senior." );
            }
        }

        /*
         * GRADE CHECK METHOD
         * Asks for the user to input a grade (0-5 or A-F)
         * 
         * Jag valde att använda regex först o främst, för att kolla om inputen var giltig, och loopa om och om igen, tills inputen är giltig.
         * Sedan använde jag switch-case, som man skulle göra, och kollar flera cases, som till exempel:
         * case "1": case "a": case "A":
         * Egentligen behöver jag inte ett default case, eftersom regex-checken ser till att inputen är giltig innan den används i switch-casen.
         * 
         * Hur jag tänkte:
         * - Be användaren mata in en betyg
         * - Kolla om input är giltig (0-5 eller A-F) -- ifall inte, be om input igen
         * - Använd switch-case för att matcha input med rätt meddelande
         * - Be användaren om att trycka på en knapp för att gå vidare till menyn igen
         */
        public static void GradeTask() {

            // Initiate variables
            string input;

            // Ask the user for a grade
            Console.Write( "Enter your grade: " );
            input = Console.ReadLine();

            // If the input is not valid, ask again
            while ( !Regex.IsMatch( input, @"^[0-5]$|^[a-f]$", RegexOptions.IgnoreCase ) ) {
                Console.WriteLine();
                Console.Write( "Invalid input. Please enter a valid grade (0-5 or A-F): " );
                input = Console.ReadLine();
            }

            // Check the grade and print the corresponding message
            switch ( input ) {

                // Cases for "1", "a", or "A"
                case "1":
                case "a":
                case "A":
                    Console.WriteLine( "You got an A!" );
                    break;

                // Cases for "2", "b", or "B"
                case "2":
                case "b":
                case "B":
                    Console.WriteLine( "You got a B!" );
                    break;

                // Cases for "3", "c", or "C"
                case "3":
                case "c":
                case "C":
                    Console.WriteLine( "You got a C!" );
                    break;

                // Cases for "4", "d", or "D"
                case "4":
                case "d":
                case "D":
                    Console.WriteLine( "You got a D!" );
                    break;

                // Cases for "5", "e", or "E"
                case "5":
                case "e":
                case "E":
                    Console.WriteLine( "You got an E!" );
                    break;

                // Cases for "6", "f", or "F"
                case "0":
                case "f":
                case "F":
                    Console.WriteLine( "You got an F!" );
                    break;

                // Default case for invalid input
                default:
                    Console.WriteLine( "You did not enter a correct grade." );
                    break;
            }
        }

        /*
         * ADD NUMBER(s) TASK METHOD
         * Add as many numbers as the user wants
         * - Asks for a number, and adds it to the current sum
         * - If the number is 0, break the loop, and print the sum
         */
        public static void AddNumberTask() {

            // Initiate/set the variables
            int number;
            int sum = 0;

            // Start the do while loop
            do {
                Console.Write( "Enter a number (exit with 0): " );
                number = Helpers.NumberCheck( Console.ReadLine() );

                // Add the number to the current sum
                sum = sum + number;

            // Continue the loop, until the user inputs a 0
            } while ( number != 0 );

            // Print the sum
            Console.WriteLine( $"The sum is: {sum}." );
            Console.WriteLine();
        }

        /*
         * LOOP NUMBERS TASK METHOD
         * First, loop from 1 to 10; lastly, loop from 2 to 20, but only each number
         */
        public static void LoopNumbersTask() {

            // Loop from 1 to 10
            Console.WriteLine( "1-10" );
            for ( int i = 1; i <= 10; i++ ) {
                Console.WriteLine( i );
            }

            // Write a line to separate
            Console.WriteLine();

            // Loop from 2 to 20, +2 for each iteration
            Console.WriteLine( "2-20" );
            for ( int i = 2; i <= 20; i += 2 ) {
                Console.WriteLine( i );
            }
        }

        /*
         * FOREACH TASK METHOD
         * Print each fruit (in the array/list) -- once in "original mode" and once where the fruit names are uppercased -- and count
         * the letter a
         */
        public static void ForeachTask() {

            // Initiate the number-of-a variable
            int numberOfA = 0;

            // The fruits array/list
            List<string> fruits = new List<string> { "Apple", "Banana", "Pear", "Orange", "Kiwi" };

            // For each fruit...
            foreach ( var ( fruit, index ) in fruits.Zip( Enumerable.Range( 0, fruits.Count() ) ) ) {

                // ...increase the number of a letter count...
                numberOfA += fruit.Count( x => Regex.IsMatch( x.ToString(), @"[a]{1}", RegexOptions.IgnoreCase ) );

                // ...and print the fruit's number (starting at 1 (0+1)), with the fruit's name
                Console.WriteLine( $"Original - Fruit nr. {index + 1}: {fruit}" );
            }

            // A new line for some separation
            Console.WriteLine();

            // For each fruit (again)...
            foreach( var ( fruit, index ) in fruits.Zip( Enumerable.Range( 0, fruits.Count() ) ) ) {

                // ...uppercase the fruit's name/text...
                string fruitToUppercase = fruit.ToUpper();

                // ...and print the fruit's number, with the fruit's name
                Console.WriteLine( $"Uppercase - Fruit nr. {index + 1}: {fruitToUppercase}" );
            }

            // Print the number of A(s) found
            Console.WriteLine( $"\nNumber of A: {numberOfA}" );
        }
    }
}
