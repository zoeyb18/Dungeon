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
            Console.WriteLine("");
            Console.WriteLine(".:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:..:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");
            Console.WriteLine("");
            #endregion

            ICharacter player = CreatePlayer();

            Console.WriteLine($"You have chosen the race: {player.Race}");
            Console.WriteLine($"You have chosen the weapon: {player.Weapon}");
        }
        static ICharacter CreatePlayer()
        {
            // Prompt the user to choose their race
            Console.WriteLine("Choose your race:");
            Console.WriteLine("1. Kitsune");
            Console.WriteLine("2. Tengu");
            Console.WriteLine("3. Nekomata");
            Console.WriteLine("4. Oni");
            Console.WriteLine("5. Kappa");
            Console.WriteLine("6. Komainu");

            int choice;


            do
            {
                Console.Write("Enter the number corresponding to your choice: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6);

            if (choice == 7)
            {
                ShowRaceDesc();
                // Recursive call to let the user choose again after viewing race descriptions
                return CreatePlayer();
            }


            ICharacter player;

            switch (choice)
            {
                case 1:
                    player = new Kitsune();
                    break;

                case 2:
                    player = new Tengu();
                    break;

                case 3:
                    player = new Nekomata();
                    break;

                case 4:
                    player = new Oni();
                    break;

                case 5:
                    player = new Kappa();
                    break;

                case 6:
                    player = new Komainu();
                    break;

                default:
                    // Handle invalid input
                    return null;
            }
            ChooseWeapon(player);

            return player;



        }

        static void ChooseWeapon(ICharacter player)
        {
            Console.WriteLine("Choose your weapon:");
            Console.WriteLine("1. Katana");
            Console.WriteLine("2. Tanto");
            Console.WriteLine("3. Yumi");
            Console.WriteLine("4. Shuriken");
            Console.WriteLine("5. Kanabo");


            int weaponChoice;

            do
            {
                Console.Write("Enter the number corresponding to your choice: ");
            } while (!int.TryParse(Console.ReadLine(), out weaponChoice) || weaponChoice < 1 || weaponChoice > 5);

            switch (weaponChoice)
            {
                case 1:
                    player.Weapon = "Katana";
                    break;
                case 2:
                    player.Weapon = "Tanto";
                    break;
                case 3:
                    player.Weapon = "Yumi";
                    break;
                case 4:
                    player.Weapon = "Shuriken";
                    break;
                case 5:
                    player.Weapon = "Kanabo";
                    break;

                default:
                    // Handle invalid input
                    break;
            }

        }
        static void ShowRaceDesc()
        {
            Console.WriteLine("Race Descriptions:");
            Console.WriteLine("1. Kitsune: Fox-like humanoid creatures. They are often depicted with multiple tails and posess mystical abilities such as shape-shifting and illusion magic.");
            Console.WriteLine("2. Tengu: Humanoid beings with bird-like features, often depicted with wings, beaks, and sometimes with long noses.");
            Console.WriteLine("3.  Nekomata: Cat-like spirits or yokai known for their mystical powers. They often have the ability to shape-shift, possess enhanced agility and senses, and are associated with magic.");
            Console.WriteLine("3. Oni: Powerful and fearsome creatures. They have varying appearances but are often depicted as hulking, horned humanoids with great strength.");
            Console.WriteLine("3.  Kappa: Water-dwelling creatures with reptilian features, typically depicted as child-sized with a shell on their back and a bowl-like depression on their head that holds water.");
            Console.WriteLine("3. Komainu: Mythical guardian creatures typically depicted as lion or dog-like beings.");

        }

        static void ShowWeaponDesc()
        {
            Console.WriteLine("Weapon Descriptions:");
            Console.WriteLine("1. Katana: A versatile melee weapon.");
            Console.WriteLine("2. Bow: A ranged weapon for precision attacks.");
            Console.WriteLine("3. Axe: A powerful melee weapon for heavy hits.");
        }
    }

}

interface IPlayer
{
    // Add properties and methods common to all players here
}

interface ICharacter : IPlayer
{
    string Race { get; }
    string Weapon { get; set; }
}

class Kitsune : ICharacter
{
    public string Race => "Kitsune";
    public string Weapon { get; set; }

}

class Weapon
{
    public string Name { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public int HitChance { get; set; }
    public bool IsOneHanded { get; set; }
}



class Tengu : ICharacter
{
    public string Race => "Tengu";
    public string Weapon { get; set; }
}

class Nekomata : ICharacter
{
    public string Race => "Nekomata";
    public string Weapon { get; set; }
}
class Oni : ICharacter
{
    public string Race => "Oni";
    public string Weapon { get; set; }
}
class Kappa : ICharacter
{
    public string Race => "Kappa";
    public string Weapon { get; set; }
}
class Komainu : ICharacter
{
    public string Race => "Komainu";
    public string Weapon { get; set; }

}
}


//        #region Player Creation
//        //Player Creation, after we've learned how to create custom Datatypes.
//        //Reference the notes in the TestHarness for some ideas of how to expand player creation.

//        //Potential expansion - Let the user choose from a list of pre-made weapons.
//        Weapon sword = new("Katana", 15, 30, 10, true, WeaponType.Sword);
//            Weapon dagger = new("Tanto", 1, 8, 10, false, WeaponType.Dagger);
//            Weapon bow = new("Yumi", 2, 10, 10, true, WeaponType.Bow);
//            Weapon projectile = new("Shuriken", 1, 8, 10, false, WeaponType.Projectile);
//            Weapon club = new("Kanabo", 2, 10, 10, true, WeaponType.Club);

//            //Potential Expansion - Let the user choose their name and Race
//            Player player1 = new("Kitsune", Race.Kitsune, sword);
//            //Player player2 = new("Tengu", Race.Tengu, dagger);
//            //Player player3 = new("Nekomata", Race.Nekomata, projectile);
//            //Player player4 = new("Oni", Race.Oni, club);
//            //Player player5 = new("Kappa", Race.Kappa, bow);
//            //Player player6 = new("Komianu", Race.Komainu, projectile);

//            player1.Score = 0;
//            #endregion

//            //Outer Loop
//            bool quit = false;
//            do
//            {
//                #region Monster and room generation
//                //We need to generate a new monster and a new room for each encounter.                
//                //TODONE Generate a room - random string description
//                Console.WriteLine(GetRoom());
//                //Generate a Monster (custom datatype) 
//                Monster monster = Monster.GetMonster();
//                Console.ForegroundColor = ConsoleColor.DarkRed;
//                Console.WriteLine("\nIn this room is a " + monster.Name);
//                Console.ResetColor();
//                #endregion

//                #region Encounter Loop                
//                //This menu repeats until either the monster dies or the player quits, dies, or runs away.
//                bool reload = false;//set to true to "reload" the monster & the room
//                do
//                {
//                    #region Menu
//                    Console.WriteLine("\nPlease choose an action:\n" +
//                        "1) Attack\n" +
//                        "2) Run away\n" +
//                        "3) Player Info\n" +
//                        "4) Monster Info\n" +
//                        "5) Exit\n");

//                    char action = Console.ReadKey(true).KeyChar;
//                    Console.Clear();
//                    switch (action)
//                    {
//                        case '1':
//                            Console.WriteLine("Attack!");
//                            //TODO Combat functionality
//                            reload = Combat.DoBattle(player1, monster);
//                            break;
//                        case '2':
//                            Console.WriteLine("Run Away!!");
//                            //TODO Give the monster a free attack chance
//                            Combat.DoAttack(monster, player1);
//                            //Leave the inner loop (reload the room) and get a new room & monster.
//                            reload = true;
//                            break;
//                        case '3':
//                            Console.WriteLine("Player info: ");
//                            //print player details to the screen
//                            Console.WriteLine(player1);
//                            Console.WriteLine("Monsters killed: " + player1.Score);
//                            break;

//                        case '4':
//                            Console.WriteLine("Monster info: ");
//                            //print monster details to the screen
//                            Console.WriteLine(monster);
//                            break;

//                        case '5':
//                            //quit the whole game. "reload = true;" gives us a new room and monster, "quit = true" quits the game, leaving both the inner AND outer loops.
//                            Console.WriteLine("No one likes a quitter!");
//                            quit = true;
//                            break;

//                        default:
//                            Console.WriteLine("Do you think this is a game?? Quit playing around!");
//                            break;
//                    }//end switch
//                    #endregion
//                    //Check Player Life. If they are dead, quit the game and show them their score.
//                    if (player1.Life <= 0)
//                    {
//                        Console.WriteLine("Aw, you died! Better luck next time.\a");
//                        quit = true;//leave both loops.
//                    }

//                } while (!reload && !quit); //While reload and quit are both FALSE (!true), keep looping. If either becomes true, leave the inner loop.
//                #endregion

//            } while (!quit);//While quit is NOT true, keep looping.

//            #region Exit
//            Console.WriteLine("You defeated " + player1.Score +
//                " monster" + (player1.Score == 1 ? "." : "s."));
//            #endregion
//        }//End Main()

//        private static string GetRoom()
//        {
//            string[] rooms =
//            {
//                "You enter a serene room adorned with delicate shōji paper screens, allowing soft sunlight to filter through." +
//                "  A low table with cushions invites you to sit and rest.  ",
//                "As you step into the chamber, the warm glow of flickering lanterns illuminates the surroundings. " +
//                " A polished stone altar stands in the center, radiating a faint mystical aura. ",
//                "The room exudes an otherworldly ambiance. A stone shrine stands against one wall, adorned with offerings of incense and flowers. ",
//                "The room is dominated by a wide and deep pit, its bottom lost in darkness." +
//                " The stench of dampness and decay fills the air, adding to the unsettling atmosphere. ",
//                "A room cluttered with dusty shelves, broken glassware, and faded scrolls greets you. " +
//                "An eerie silence hangs in the air, broken only by the occasional creaking of a rusty hinge. ",
//                "You find yourself in a room filled with lush bamboo, their tall stalks swaying gently in an unseen breeze. " +
//                "The room is bathed in a cool, green hue, creating a serene and peaceful atmosphere.",
//                " Unseen whispers echo from the shadows, and a chilling breeze brushes against your skin." +
//                " Flickering candles cast dancing shadows on the cracked walls, revealing faded paintings of past inhabitants.",

//            };

//            Random rand = new Random();
//            //rooms.Length
//            int index = rand.Next(rooms.Length);
//            string room = rooms[index];
//            return room;

//    //Refactor:
//    //return rooms[new Random().Next(rooms.Length)];
//}//End GetRoom()







//    }
//}