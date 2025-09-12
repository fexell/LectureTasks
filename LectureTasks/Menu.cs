using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuBoilerplate {
    internal class Menu {
        static Dictionary<int, ( string, Action )> MenuOptions = new Dictionary<int, ( string, Action )> {
            { 1, ( "FizzBuzz", Lecture2.FizzBuzz ) },
            { 2, ( "Age Task", Lecture2.AgeTask ) },
            { 3, ( "Grade Task", Lecture2.GradeTask ) },
            { 4, ( "Add Number(s) Task", Lecture2.AddNumberTask ) },
            { 5, ( "Loop Numbers Task", Lecture2.LoopNumbersTask ) },
            { 6, ( "Foreach Task", Lecture2.ForeachTask ) },
            { 0, ( "Exit", Exit ) }
        };

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

                Console.WriteLine();

                if( int.TryParse( input, out int choice ) && MenuOptions.ContainsKey( choice ) ) {
                    MenuOptions[ choice ].Item2.Invoke();
                } else {
                    Console.WriteLine( "Invalid option. Press any key to try again." );
                    Console.ReadKey();
                }
            }
        }

        public static void ReturnToMenu() {
            Console.WriteLine();
            Console.WriteLine( "Press a key to continue to the menu." );
            Console.ReadKey();
        }
    }
}
