using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LectureTasks {
    internal class Lecture3 : Program {
        public static void SayHello( string name ) {
            Console.WriteLine( $"Hello, {name}!" );
        }
    }

    /*
     * CALCULATOR TASK CLASS
     */
    internal class Calculator : Lecture3 {

        // Addition
        public static int Add( int a, int b ) {
            return a + b;
        }

        // Subtraction
        public static int Subtract( int a, int b ) {
            return a - b;
        }

        // Multiplication
        public static int Multiply( int a, int b ) {
            return a * b;
        }

        // Division
        public static double Divide( int a, int b ) {
            return ( double ) a / b;
        }

        // The run method, for running the calculator
        public static void Run() {

            Console.WriteLine( "Welcome to the calculator!" );
            Console.WriteLine( "Press 1 for addition." );
            Console.WriteLine( "Press 2 for subtraction." );
            Console.WriteLine( "Press 3 for multiplication." );
            Console.WriteLine( "Press 4 for division." );
            Console.Write( "Enter your choice (1-4): " );
            int choice = Helpers.NumberCheck( Console.ReadLine() );

            while( !Regex.IsMatch( choice.ToString(), @"[1-4]") ) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write( "Invalid choice. Please enter a valid choice (1-4): " );
                Console.ResetColor();
                choice = Helpers.NumberCheck( Console.ReadLine() );
            }

            Console.Write( "Enter the first number: " );
            int number1 = Helpers.NumberCheck( Console.ReadLine() );

            Console.Write( "Enter the second number: " );
            int number2 = Helpers.NumberCheck( Console.ReadLine() );

            switch ( choice ) {
                case 1:
                    Console.WriteLine( Add( number1, number2 ) );
                    break;

                case 2:
                    Console.WriteLine( Subtract( number1, number2 ) );
                    break;

                case 3:
                    Console.WriteLine( Multiply( number1, number2 ) );
                    break;

                case 4:
                    while ( number2 == 0 ) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write( "Can't divide by zero (0). Pick another number: " );
                        Console.ResetColor();
                        number2 = Helpers.NumberCheck( Console.ReadLine() );
                    }

                    Console.WriteLine( Divide( number1, number2 ) );
                    break;

                default:
                    Console.WriteLine( "Invalid option." );
                    break;
            }
        }
    }

    internal class ProductPriceCalculator {
        static double CalculateTotal( string product, double price, int quantity, double tax = 0.25 ) {
            return price * quantity  * ( 1 + tax );
        }

        public static void Run() {
            Console.Write( "How many products do you wanna buy?: " );
            int totalProducts = Helpers.NumberCheck( Console.ReadLine() );

            Console.Write( "How much do you wanna pay for each product?: " );
            int price = Helpers.NumberCheck( Console.ReadLine() );

            Console.Write( "How much is the VAT in procent?: " );
            var vat = double.TryParse( Console.ReadLine(), out double v );

            var totalPrice = CalculateTotal( "Apples", price, totalProducts, v );
            Console.WriteLine( $"You bought {totalProducts} apples, total price (incl. tax): {totalPrice} kr" );
        }
    }

    internal class  BMICalculator {
        static double Calculate( double weight, double height, string unit = "metric" ) {
            switch( unit ) {
                case var value when new Regex( @"^(metric)$", RegexOptions.IgnoreCase ).IsMatch( value ):
                    return weight / ( height * height );

                case var value when new Regex( @"^(imperial)$", RegexOptions .IgnoreCase ).IsMatch( value ):
                    return 703 * ( weight / ( height * height ) );

                default:
                    Console.WriteLine( "Unknown unit, returning 0" );
                    return 0;
            }
        }
    }
}
