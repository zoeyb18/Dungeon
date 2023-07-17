using DungeonLibrary;
using System.Numerics;
using System.Text;

namespace DungeonApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Introduction
            //TODO Intro
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("ようこそ (Yōkoso)! Prepare for an epic adventure through a world of ancient samurai and yokai." +
                " Embrace the challenges, and forge your path to greatness. Your destiny awaits in the depths of the dungeon.");
            #endregion

            #region Player Creation
            //Player Creation, after we've learned how to create custom Datatypes.
            //Reference the notes in the TestHarness for some ideas of how to expand player creation.

            //Potential expansion - Let the user choose from a list of pre-made weapons.
            Weapon sword = new("Katana", 1, 8, 10, true, WeaponType.Sword);
            Weapon dagger = new("Tanto", 1, 8, 10, false, WeaponType.Dagger);
            Weapon bow = new("Yumi", 2, 10, 10, true, WeaponType.Bow);
            Weapon projectile = new("Shuriken", 1, 8, 10, false, WeaponType.Projectile);
            Weapon club = new("Kanabo", 2, 10, 10, true, WeaponType.Club);

            //Potential Expansion - Let the user choose their name and Race
            Player player1 = new("Kitsune", Race.Kitsune, sword);
            //Player player2 = new("Tengu", Race.Tengu, dagger);
            //Player player3 = new("Nekomata", Race.Nekomata, projectile);
            //Player player4 = new("Oni", Race.Oni, club);
            //Player player5 = new("Kappa", Race.Kappa, bow);
            //Player player6 = new("Komianu", Race.Komainu, projectile);

            player1.Score = 0;
            #endregion

            //Outer Loop
            bool quit = false;
            do
            {
                #region Monster and room generation
                //We need to generate a new monster and a new room for each encounter.                
                //TODONE Generate a room - random string description
                Console.WriteLine(GetRoom());
                //Generate a Monster (custom datatype) 
                Monster monster = Monster.GetMonster();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nIn this room is a " + monster.Name);
                Console.ResetColor();
                #endregion

                #region Encounter Loop                
                //This menu repeats until either the monster dies or the player quits, dies, or runs away.
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
                            reload = Combat.DoBattle(player1, monster);
                            break;
                        case '2':
                            Console.WriteLine("Run Away!!");
                            //TODO Give the monster a free attack chance
                            Combat.DoAttack(monster, player1);
                            //Leave the inner loop (reload the room) and get a new room & monster.
                            reload = true;
                            break;
                        case '3':
                            Console.WriteLine("Player info: ");
                            //print player details to the screen
                            Console.WriteLine(player1);
                            break;

                        case '4':
                            Console.WriteLine("Monster info: ");
                            //print monster details to the screen
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
                    //Check Player Life. If they are dead, quit the game and show them their score.
                    if (player1.Life <= 0)
                    {
                        Console.WriteLine("Aw, you died! Better luck next time.\a");
                        quit = true;//leave both loops.
                    }

                } while (!reload && !quit); //While reload and quit are both FALSE (!true), keep looping. If either becomes true, leave the inner loop.
                #endregion

            } while (!quit);//While quit is NOT true, keep looping.

            #region Exit
            Console.WriteLine("You defeated " + player1.Score +
                " monster" + (player1.Score == 1 ? "." : "s."));
            #endregion
        }//End Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "You enter a serene room adorned with delicate shōji paper screens, allowing soft sunlight to filter through." +
                "  A low table with cushions invites you to sit and rest.  ",
                "As you step into the chamber, the warm glow of flickering lanterns illuminates the surroundings. " +
                " A polished stone altar stands in the center, radiating a faint mystical aura. ",
                "The room exudes an otherworldly ambiance. A stone shrine stands against one wall, adorned with offerings of incense and flowers. ",
                "The room is dominated by a wide and deep pit, its bottom lost in darkness." +
                " The stench of dampness and decay fills the air, adding to the unsettling atmosphere. ",
                "A room cluttered with dusty shelves, broken glassware, and faded scrolls greets you. " +
                "An eerie silence hangs in the air, broken only by the occasional creaking of a rusty hinge. ",
                "You find yourself in a room filled with lush bamboo, their tall stalks swaying gently in an unseen breeze. " +
                "The room is bathed in a cool, green hue, creating a serene and peaceful atmosphere.",
                " Unseen whispers echo from the shadows, and a chilling breeze brushes against your skin." +
                " Flickering candles cast dancing shadows on the cracked walls, revealing faded paintings of past inhabitants.",
               
            };

            Random rand = new Random();
            //rooms.Length
            int index = rand.Next(rooms.Length);
            string room = rooms[index];
            return room;

            //Refactor:
            //return rooms[new Random().Next(rooms.Length)];
        }//End GetRoom()








    }
}