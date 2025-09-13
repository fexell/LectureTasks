using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LectureTasks {
    internal class Helpers {

        /*
         * NUMBER CHECK METHOD
         * Checks if the input is a number and returns the number
         */
        public static int NumberCheck( string n ) {
            while ( true ) {

                // If the input is a number, return it
                if ( int.TryParse( n, out int number ) ) {
                    return number;

                // Else if the input is not a number, ask for a new number again
                } else {
                    Console.WriteLine();
                    Console.Write( "Invalid input. Please enter a valid number: " );
                    n = Console.ReadLine();
                    Console.WriteLine();
                }
            }
        }

        /*
         * NAME CHECK METHOD
         * Checks if the input is a name and returns the name
         */
        public static string NameCheck( string name ) {
            while( true ) {

                // If the input is NOT a "word", ask for a new name again
                if ( !Regex.IsMatch( name, @"([a-z]+)", RegexOptions.IgnoreCase ) ) {

                    Console.WriteLine();
                    Console.Write( "Invalid name. Please enter a valid name: " );
                    name = Console.ReadLine();
                    Console.WriteLine();

                // Else if the input IS a "word", return it
                } else {
                    return name;
                }
            }
        }
    }
}
