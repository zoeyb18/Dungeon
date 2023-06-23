using DungeonLibrary;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Intro
            //TODO intro
            #endregion


            #region PLayer
            // create player

            //reference the notes in the test harness for some ideas of how to expand player creation.

            //Potential expansion - Let the user choose from a list of premade weapons
            Weapon sword = new("Lightsaber", 1, 8, 10, true, WeaponType.Sword);

            //potential expansion - let the user choose their name and Race
            Player player = new("Leeroy Jenkins", Race.Human, sword);

            player.Score = 0;

            #endregion


            //Outer Loop
          
            bool quit = false;
            do
            {

                #region Monster and room generation
                // create monster
                //TODO create room - 
                Console.WriteLine(GetRoom());//Room is temporary until you add room descriptions

                Monster monster = Monster.GetMonster();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nIn this is a " + monster.Name);
                Console.ResetColor();
                #endregion

                #region Encounter Loop          

                bool reload = false;//set to true to "reload" the monster & the room
               
                    do
                    {
                        #region Menu
                        Console.WriteLine("\nPlease choose an action:\n" +
                            "1) Attack\n" +
                            "2) Run away\n" +
                            "3) Player Info\n" +
                            "4) Monster Info\n" +
                            "5) Exit\n");

                        char action = Console.ReadKey(true).KeyChar;
                        Console.Clear();
                        switch (action)
                        {
                            case '1':
                                Console.WriteLine("Attack!");
                                //TODO Combat functionality
                                break;
                            case '2':
                                Console.WriteLine("Run Away!!");
                                //TODO Give the monster a free attack chance

                                //Leave the inner loop (reload the room) and get a new room & monster.
                                reload = true;
                                break;
                            case '3':
                                Console.WriteLine("Player info: ");
                            // print player details to the screen
                            Console.WriteLine(player);
                            break;

                            case '4':
                                Console.WriteLine("Monster info: ");
                            // print monster details to the screen
                            Console.WriteLine(monster);
                            break;

                            case '5':
                                //quit the whole game. "reload = true;" gives us a new room and monster, "quit = true" quits the game, leaving both the inner AND outer loops.
                                Console.WriteLine("No one likes a quitter!");
                                quit = true;
                                break;

                            default:
                                Console.WriteLine("Do you think this is a game?? Quit playing around!");
                                break;
                        }//end switch
                        #endregion
                        //TODO Check Player Life. If they are dead, quit the game and show them their score.

                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Dude... You died!\a");
                        quit = true; //leave both loops.
                    }


                    } while (!reload && !quit);
                Console.WriteLine("You defeated " + player.Score +
                    " monster" + (player.Score == 1 ? "." : "s. "));
                #endregion
            } while (!quit);





        }


        private static string GetRoom()
        {
                string[] rooms =
                {
                  "Kitchen:\r\nThe kitchen is a chaotic and grime-covered space, with greasy countertops, sticky floors, and flickering fluorescent lights that cast a sickly yellow hue." +
                  " Dilapidated equipment clatters and clangs as the overworked and sweat-drenched cooks hustle to churn out greasy bar food." +
                  " The air is thick with the scent of frying oil, burnt onions, and a faint hint of desperation.",
                 
                  "Server Alley:\r\nThe server alley is a narrow, dimly lit corridor that connects the kitchen to the dining area. " +
                  "Its cracked and stained walls are lined with shelves stacked haphazardly with dirty dishes and broken glassware. " +
                  "An overflowing trash can emits an unpleasant odor that lingers in the air. " +
                  "Weary servers maneuver through the clutter, occasionally slipping on spilled liquids, and exchanging tired glances.",

                  "Dining Room:\r\nThe dining room exudes a worn-down charm, with peeling wallpaper, scratched tables, and torn vinyl seats." +
                  " Dim, flickering neon signs advertise cheap drinks and daily specials." +
                  " The air is filled with a mixture of stale beer, cigarette smoke, and the distinct aroma of years of accumulated grime. " +
                  "Patrons, a colorful cast of characters, engage in animated conversations, their voices punctuated by occasional slurred words and rowdy outbursts.",

                  "Walk-in Freezer:\r\nThe walk-in freezer is a cramped and dingy chamber, its walls lined with rusted metal shelves and cracked tiles." +
                  " Flickering, dim lights barely illuminate the room, casting eerie shadows. " +
                  "The shelves are disorganized, stacked with boxes of frozen food covered in frost and icy residue." +
                  " A musty odor permeates the air, hinting at years of neglect and poor maintenance.",

                  "Patio:\r\nThe patio is a weathered outdoor space, with rickety tables and chairs that wobble on uneven ground." +
                  " Faded and peeling paint reveals years of neglect, and the cracked concrete floor is stained with mysterious splotches." +
                  " Dim string lights, swaying in the breeze, cast a faint glow on chipped and graffiti-covered walls. " +
                  "The sounds of nearby alleyways and passing traffic mingle with the lively conversations of patrons seeking solace from the griminess of the indoors."
                };

                //Random rand = new Random();
                ////rooms.length
                //int index = rand.Next(rooms.Length);
                //string room = rooms[index];
                //return room;

                //Refactor:
                return rooms[new Random().Next(rooms.Length)]; //does same code as above but more efficient

        }
          
            
            


            


    }
}