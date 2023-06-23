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
                    "Temple of the Gods: \"You step into a grand chamber adorned with intricate carvings depicting mythological tales." +
                    " The air crackles with divine energy as statues of mighty gods line the walls, their stern gazes watching over you.\"",
                 
                    "Labyrinthine Corridor: \"You find yourself in a twisting maze of narrow corridors." +
                    " The walls are adorned with ancient symbols, hinting at hidden secrets and ancient challenges. " +
                    "The air is heavy with mystery and echoes of lost footsteps.\"",

                    "Enchanted Forest: \"You enter a lush forest bathed in ethereal light. " +
                    "Towering trees seem to whisper secrets as mythical creatures dart among the foliage. " +
                    "The air is thick with enchantment, and the ground shimmers with magical energy.\" ",

                    "Underworld Abyss: \"You descend into a chilling abyss where darkness reigns. " +
                    "Eerie whispers and distant cries fill the air as skeletal remnants lie scattered on the floor. " +
                    "The oppressive atmosphere is punctuated by flickering flames and ominous shadows.",

                    "Celestial Observatory:  \"You step into a celestial observatory perched high above the mortal realm. " +
                    "The walls are adorned with intricate star charts, and telescopes point towards distant constellations." +
                    " The air crackles with cosmic energy and the whisper of distant worlds.\"",
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