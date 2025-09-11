using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuBoilerplate {
    internal class Menu {
        static Dictionary<int, ( string, Action )> MenuOptions = new Dictionary<int, ( string, Action )> {
            { 1, ( "FizzBuzz", Program.FizzBuzz ) },
            { 2, ( "Age Check", Program.AgeCheck ) },
            { 3, ( "Grade Check", Program.GradeCheck ) },
            { 4, ( "Number adder", Program.NumberAdder ) },
            { 5, ( "Number Looper", Program.NumberLooper ) },
            { 0, ( "Exit", Exit ) }
        };

        public Menu() {
            Show();
        }

        static void Exit() {
            Environment.Exit( 0 );
        }

        static void DisplayMenu() {
            foreach( var item in MenuOptions ) {
                Console.WriteLine( $"{ item.Key }: { item.Value.Item1 }" );
            }
        }

        public static void Show() {
            while( true ) {
                Console.Clear();

                DisplayMenu();

                Console.Write( "> " );
                var input = Console.ReadLine();

                if( int.TryParse( input, out int choice ) && MenuOptions.ContainsKey( choice ) ) {
                    MenuOptions[ choice ].Item2.Invoke();
                } else {
                    Console.WriteLine( "Invalid option. Press any key to try again." );
                    Console.ReadKey();
                }
            }
        }
    }
}
