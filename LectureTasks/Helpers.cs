using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MenuBoilerplate {
    internal class Helpers {
        public static int NumberCheck( string n ) {
            while ( true ) {
                if ( int.TryParse( n, out int number ) ) {

                    return number;

                } else {

                    Console.WriteLine();
                    Console.Write( "Invalid input. Please enter a valid number: " );
                    n = Console.ReadLine();
                    Console.WriteLine();

                }
            }
        }

        public static string NameCheck( string name ) {
            while( true ) {
                if ( !Regex.IsMatch( name, @"([a-z]+)", RegexOptions.IgnoreCase ) ) {

                    Console.WriteLine();
                    Console.Write( "Invalid name. Please enter a valid name: " );
                    name = Console.ReadLine();
                    Console.WriteLine();

                } else {
                    return name;
                }
            }
        }
    }
}
