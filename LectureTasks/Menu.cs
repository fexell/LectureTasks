using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTasks {

    /*
     * MENU ITEM CLASS
     */
    internal class MenuItem {

        // The title of the menu item
        public string Title { get; }

        // The action of the menu item
        public Action Action { get; }

        // Whether or not to add a separator after the menu item (defaults to false)
        public bool AddSeparatorAfter { get; } = false;

        // Constructor
        public MenuItem( string title, Action action, bool addSeparatorAfter = false, bool autoReturn = true ) {
            Title = title;
            AddSeparatorAfter = addSeparatorAfter;

            // Automatically prompt the user to return to the menu, if autoReturn is true,
            // instead of executing the action in every method
            if ( autoReturn )
                Action = () => {
                    action();
                    Menu.ReturnToMenu();
                };

            else
                Action = action;
        }
    }

    /*
     * MENU CLASS
     */
    internal class Menu {

        // All the menu options
        static Dictionary<int, MenuItem> MenuOptions = new() {
            { 1, new MenuItem( "FizzBuzz", Lecture2.FizzBuzz ) },
            { 2, new MenuItem( "Age Task", Lecture2.AgeTask ) },
            { 3, new MenuItem( "Grade Task", Lecture2.GradeTask ) },
            { 4, new MenuItem( "Add Number Task", Lecture2.AddNumberTask ) },
            { 5, new MenuItem( "Loop Numbers Task", Lecture2.LoopNumbersTask ) },
            { 6, new MenuItem( "Foreach Task", Lecture2.ForeachTask, addSeparatorAfter: true ) },
            { 0, new MenuItem( "Exit", Exit, true ) }
        };

        // Exit the program
        static void Exit() {
            Environment.Exit( 0 );
        }

        // Display the menu
        static void DisplayMenu() {
            foreach( var item in MenuOptions ) {
                Console.WriteLine( $"{item.Key}: {item.Value.Title}" );

                if ( item.Value.AddSeparatorAfter )
                    Console.WriteLine();
            }
        }

        // Show the menu, and handles the running of the method/function
        public static void Show() {
            while( true ) {
                Console.Clear();

                DisplayMenu();

                Console.Write( "> " );
                var input = Console.ReadLine();

                Console.WriteLine();

                if( int.TryParse( input, out int choice ) && MenuOptions.ContainsKey( choice ) ) {
                    MenuOptions[ choice ].Action.Invoke();
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine( "Invalid option. Press any key to try again." );
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        // For DRY, to be used for returning to the menu
        public static void ReturnToMenu() {
            Console.WriteLine();
            Console.WriteLine( "Press a key to continue to the menu." );
            Console.ReadKey();
        }
    }
}
