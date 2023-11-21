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
            CenterText("ようこそ (Yōkoso)! Prepare for an epic adventure through a world of ancient samurai and yokai.");
            CenterText("Embrace the challenges, and forge your path to greatness. Your destiny awaits in the depths of the dungeon.");
            Console.WriteLine("\n.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:..:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:._.:*~*:.");
            #endregion

           
           

            ICharacter player = CreatePlayer();

            if (player != null)
            {

               

                Console.WriteLine("\n\nDo you want to continue?");
                Console.WriteLine("1. Continue");
                Console.WriteLine("2. Exit");

                int continueChoice;

                do
                {
                    Console.Write("Enter the number corresponding to your choice: ");
                }
                while (!int.TryParse(Console.ReadLine(), out continueChoice) || continueChoice < 1 || continueChoice > 2);

                if (continueChoice == 1)
                {
                    // Continue with the game logic
                    Console.WriteLine("Continue with the game...");
                }
                else
                {
                    // Exit the game
                    Console.WriteLine("Exiting the game. Goodbye!");
                }
            }
            else
            {
                // Player creation failed or the user chose to go back to the menu
                Console.WriteLine("Exiting the game. Goodbye!");
            }
        }




        static ICharacter CreatePlayer()
        {
            ICharacter player = null;

            while (player == null)
            {

                // Prompt the user to choose their race
                Console.WriteLine("Choose your race wisely. You can't go back:");
                Console.WriteLine("1. Kitsune");
                Console.WriteLine("2. Tengu");
                Console.WriteLine("3. Nekomata");
                Console.WriteLine("4. Oni");
                Console.WriteLine("5. Kappa");
                Console.WriteLine("6. Komainu");
                Console.WriteLine("7. See Race Descriptions");


                int choice;


                do
                {
                    Console.Write("Enter the number corresponding to your choice: ");
                } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 8);


                //MENU FOR RACE CHOICE

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

                    case 7:
                        ShowRaceDesc();
                        continue;

                    case 8:
                        return null;

                    default:
                        // Handle invalid input
                        Console.WriteLine("Try Again!");
                        break;
                }

                if (player != null)
                {
                    ChooseWeapon(player);
                }
            }
            return player;



        }

        static void ChooseWeapon(ICharacter player)
        {
            while (true)
            {
                Console.Clear();
                

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
                } 
                while (!int.TryParse(Console.ReadLine(), out weaponChoice) || weaponChoice < 1 || weaponChoice > 5);



                switch (weaponChoice)
                {
                    case 1:
                        player.Weapon = new Katana();
                        break;
                    case 2:
                        player.Weapon = new Tanto();
                        break;
                    case 3:
                        player.Weapon = new Yumi();
                        break;
                    case 4:
                        player.Weapon = new Shuriken();
                        break;
                    case 5:
                        player.Weapon = new Kanabo();
                        break;

                    default:
                        Console.WriteLine("Try Again!");
                        break;
                }
                Console.WriteLine($"You have chosen the race: {player.Race}");
                Console.WriteLine($"You have chosen the weapon: {player.Weapon.Name}");
                Console.WriteLine($"Weapon Properties:");
                Console.WriteLine($"   Min Damage: {player.Weapon.MinDamage}");
                Console.WriteLine($"   Max Damage: {player.Weapon.MaxDamage}");
                Console.WriteLine($"   Hit Chance: {player.Weapon.HitChance}%");
                Console.WriteLine($"   Is One-Handed: {player.Weapon.IsOneHanded}");
                Console.WriteLine($"   Description: {player.Weapon.Description}");
                break;
            }

        }
        static void CenterText(string text)
        {
            int width = Console.WindowWidth;
            int leftPadding = (width - text.Length) / 2;

            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.WriteLine(text);
        }
        static void ShowRaceDesc()
        {
            Console.WriteLine("\n\nRace Descriptions:");
            Console.WriteLine("\n\n1. Kitsune: Fox-like humanoid creatures. They are often depicted with multiple tails and possess mystical abilities such as shape-shifting and illusion magic.");
            Console.WriteLine("\n\n2. Tengu: Humanoid beings with bird-like features, often depicted with wings, beaks, and sometimes with long noses.");
            Console.WriteLine("\n\n3.  Nekomata: Cat-like spirits or yokai known for their mystical powers. They often have the ability to shape-shift, possess enhanced agility and senses, and are associated with magic.");
            Console.WriteLine("\n\n4. Oni: Powerful and fearsome creatures. They have varying appearances but are often depicted as hulking, horned humanoids with great strength.");
            Console.WriteLine("\n\n5.  Kappa: Water-dwelling creatures with reptilian features, typically depicted as child-sized with a shell on their back and a bowl-like depression on their head that holds water.");
            Console.WriteLine("\n\n6. Komainu: Mythical guardian creatures typically depicted as lion or dog-like beings.\n\n");

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
    Weapon Weapon { get; set; }
}

//CLASSES

class Weapon
{
    public string Name { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public int HitChance { get; set; }
    public bool IsOneHanded { get; set; }

    public string Description { get; set; }
}

class Katana : Weapon
{
    public Katana()
    {
        Name = "Katana";
        MinDamage = 5;
        MaxDamage = 10;
        HitChance = 80;
        IsOneHanded = true;
        Description = "Sword";
    }
}

class Tanto : Weapon
{
    public Tanto()
    {
        Name = "Tanto";
        MinDamage = 3;
        MaxDamage = 8;
        HitChance = 90;
        IsOneHanded = true;
        Description = "Dagger";
    }
}
class Yumi : Weapon
{
    public Yumi()
    {
        Name = "Yumi";
        MinDamage = 8;
        MaxDamage = 15;
        HitChance = 70;
        IsOneHanded = false;
        Description = "Bow.";
    }
}
class Shuriken : Weapon
{
    public Shuriken()
    {
        Name = "Shuriken";
        MinDamage = 3;
        MaxDamage = 8;
        HitChance = 90;
        IsOneHanded = true;
        Description = "Projectile";
    }
}
class Kanabo : Weapon
{
    public Kanabo()
    {
        Name = "Kanabo";
        MinDamage = 5;
        MaxDamage = 10;
        HitChance = 80;
        IsOneHanded = false;
        Description = "Spiked Melee";
    }
}


class Kitsune : ICharacter
{
    public string Race => "Kitsune";
    public Weapon Weapon { get; set; }

}

class Tengu : ICharacter
{
    public string Race => "Tengu";
    public Weapon Weapon { get; set; }
}

class Nekomata : ICharacter
{
    public string Race => "Nekomata";
    public Weapon Weapon { get; set; }
}
class Oni : ICharacter
{
    public string Race => "Oni";
    public Weapon Weapon { get; set; }
}
class Kappa : ICharacter
{
    public string Race => "Kappa";
    public Weapon Weapon { get; set; }
}
class Komainu : ICharacter
{
    public string Race => "Komainu";
    public Weapon Weapon { get; set; }

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