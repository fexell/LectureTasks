

using System.Text.RegularExpressions;

namespace MenuBoilerplate {
    public class  Program {
        static int NumberCheck( string n ) {
            while( true ) {
                if( int.TryParse( n, out int number ) ) {

                    return number;

                } else {

                    Console.WriteLine();
                    Console.Write( "Invalid input. Please enter a valid number: " );
                    n = Console.ReadLine();
                    Console.WriteLine();

                }
            }
        }

        public static void FizzBuzz() {
            int number;

            Console.Write( "Enter a number: " );
            number = NumberCheck( Console.ReadLine() );

            for( int i = 1; i <= number; i++ ) {
                if( i % 3 == 0 && i % 5 == 0 ) {
                    Console.WriteLine( "FizzBuzz" );
                } else if( i % 3 == 0 ) {
                    Console.WriteLine( "Fizz" );
                } else if( i % 5 == 0 ) {
                    Console.WriteLine( "Buzz" );
                } else {
                    Console.WriteLine( i );
                }
            }
            Console.WriteLine( "Press any key to return to the menu." );
            Console.ReadKey();
        }

        public static void AgeCheck() {
            string name;
            int age;

            Console.Write( "What is your name?: " );
            name = Console.ReadLine();

            Console.Write( "How old are you?: " );
            age = NumberCheck( Console.ReadLine() );

            if( age < 18 ) {
                Console.WriteLine( $"Hello { name }, you are a minor." );
            } else if( age >= 18 && age <= 64 ) {
                Console.WriteLine( $"Hello { name }, you are an adult." );
            } else {
                Console.WriteLine( $"Hello { name }, you are a senior." );
            }

            Console.WriteLine( "Press any key to return to the menu." );
            Console.ReadKey();
        }

        /*
         * GRADE CHECK METHOD
         * Asks for the user to input a grade (1-6 or A-F)
         * 
         * Hur jag tänkte:
         * - Be användaren mata in en betyg
         * - Kolla om input är giltig (1-6 eller A-F) -- ifall inte, be om input igen
         * - Använd switch-case för att matcha input med rätt meddelande
         * - Be användaren om att trycka på en knapp för att gå vidare till menyn igen
         */
        public static void GradeCheck() {

            // Initiate variables
            string input;

            // Ask the user for a grade
            Console.Write( "Enter your grade: " );
            input = Console.ReadLine();

            // If the input is not valid, ask again
            while ( !Regex.IsMatch( input, @"^[1-6]$|^[a-f]$" ) ) {
                Console.Write( "Invalid input. Please enter a valid grade (1-6 or A-F): " );
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
                case "6":
                case "f":
                case "F":
                    Console.WriteLine( "You got an F!" );
                    break;

                // Default case for invalid input
                default:
                    Console.WriteLine( "You did not enter a correct grade." );
                    break;
            }

            // Wait for user input before returning to the menu
            Console.WriteLine( "Press any key to return to the menu." );
            Console.ReadKey();
        }

        public static void NumberAdder() {

            // Initiate/set the variables
            int number;
            int sum = 0;

            // Start the do while loop
            do {
                Console.Write( "Enter a number (exit with 0): " );
                number = NumberCheck( Console.ReadLine() );

                // Add the number to the current sum
                sum = sum + number;

            // Continue the loop, until the user inputs a 0
            } while ( number != 0 );

            // Print the sum
            Console.WriteLine( $"The sum is: {sum}." );
            Console.WriteLine();

            // Prompt the user to press any key to go back to menu
            Console.WriteLine( "Press any key to go back to menu." );
            Console.ReadKey();
        }

        public static void NumberLooper() {

            Console.WriteLine( "1-10" );
            for( int i = 1; i <= 10; i++ ) {
                Console.WriteLine( i );
            }

            Console.WriteLine();

            Console.WriteLine( "2-20" );
            for( int i = 2; i <= 20; i += 2 ) {
                Console.WriteLine( i );
            }

            Console.WriteLine();
            Console.WriteLine( "Press any key to return to the menu." );
            Console.ReadKey();
        }

        static void Main( string[] args ) {
            Menu.Show();
        }
    }
}