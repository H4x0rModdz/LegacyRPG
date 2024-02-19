using LegacyRPG.Application.Battle;
using LegacyRPG.Domain.Models;
using LegacyRPG.Domain.Models.Enemies;
using System.Text.RegularExpressions;

namespace LegacyRPG.Application.Start
{
    public class Game
    {
        public void StartGame()
        {
            Console.WriteLine("Welcome to LegacyRPG!");
            Player player = CreateCharacter();
            bool continueGame = true;
            while (player.Health > 0)
            {
                StartAdventure(player);

                if (player.Health > 0)
                {
                    Console.WriteLine("Do you want to continue? (Y/N)");
                    string input = Console.ReadLine();
                    continueGame = input.Equals("Y", StringComparison.OrdinalIgnoreCase);
                }
            }
        }

        private Player CreateCharacter()
        {
            string playerName;
            do
            {
                Console.WriteLine("Let's create your character.");
                Console.Write("Enter your character's name: ");
                playerName = Console.ReadLine();
            } while (!IsNameValid(playerName));

            Console.WriteLine($"Ok, {playerName}, Choose your class:");
            Console.WriteLine("1. Warrior");
            Console.WriteLine("2. Healer");
            Console.WriteLine("3. Mage");
            Console.WriteLine("4. Rogue");
            Console.Write("Enter the number corresponding to your chosen class: ");
            int classChoice = Convert.ToInt32(Console.ReadLine());

            Player player = new Player
            {
                Name = playerName,
                Level = 1,
                Experience = 0,
                Gold = 0
            };

            switch (classChoice)
            {
                case 1: // Warrior
                    player.Health = 120;
                    player.MaxHealth = 120;
                    player.Attack = 15;
                    player.Defense = 10;
                    break;
                case 2: // Healer
                    player.Health = 80;
                    player.MaxHealth = 80;
                    player.Attack = 8;
                    player.Defense = 6;
                    break;
                case 3: // Mage
                    player.Health = 100;
                    player.MaxHealth = 100;
                    player.Attack = 20;
                    player.Defense = 4;
                    break;
                case 4: // Rogue
                    player.Health = 100;
                    player.MaxHealth = 100;
                    player.Attack = 12;
                    player.Defense = 8;
                    break;
                default:
                    Console.WriteLine("Invalid choice! Defaulting to Warrior class.");
                    player.Health = 120;
                    player.MaxHealth = 120;
                    player.Attack = 15;
                    player.Defense = 10;
                    break;
            }

            Console.WriteLine($"Welcome, {player.Name}! Your adventure begins now as a {GetClassName(classChoice)}.");
            Console.WriteLine($"Character stats:\nHealth: {player.Health}\nAttack: {player.Attack}\nDefense: {player.Defense}\nLevel: {player.Level}\nExperience: {player.Experience}\nGold: {player.Gold}");
            return player;
        }

        private bool IsNameValid(string name) => !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[a-zA-Z]+$");

        private string GetClassName(int classChoice)
        {
            switch (classChoice)
            {
                case 1:
                    return "Warrior";
                case 2:
                    return "Healer";
                case 3:
                    return "Mage";
                case 4:
                    return "Rogue";
                default:
                    return "Unknown";
            }
        }

        private void StartAdventure(Player player)
        {
            Console.WriteLine("You find yourself in a dense forest...");

            Random random = new Random();
            if (random.Next(1, 11) <= 5)
            {
                Console.WriteLine("You embark on your journey! May fortune favor you.");
                Console.WriteLine("Suddenly, you encounter an enemy!");

                Enemy enemy = GenerateRandomEnemy();

                BattleManager battleManager = new BattleManager();
                battleManager.StartBattle(player, enemy);
            }

            else
                Console.WriteLine("You continue your journey without encountering any enemies.");
        }

        private Enemy GenerateRandomEnemy()
        {
            Random random = new Random();
            int enemyType = random.Next(1, 3);

            switch (enemyType)
            {
                case 1:
                    return new Goblin();
                case 2:
                    return new Orc();
                default:
                    return null;
            }
        }
    }
}
