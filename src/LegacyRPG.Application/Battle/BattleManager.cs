using LegacyRPG.Domain.Models;

namespace LegacyRPG.Application.Battle
{
    public class BattleManager
    {
        private const double SuccessPercentage = 0.5;
        private const int MaxInvalidChoices = 3;

        public void StartBattle(Player player, Enemy enemy)
        {
            Console.WriteLine($"You found a/an {enemy.Name}. The battle begins! {player.Name} vs {enemy.Name}. Good Luck!");

            while (player.IsAlive && enemy.IsAlive)
            {
                Console.WriteLine($"{player.Name} (HP: {player.Health})");
                Console.WriteLine($"What do you want to do? (A)ttack or (R)un?");
                string choice = GetValidChoice();

                if (choice.ToUpper() == "A")
                    AttackEnemy(player, enemy);
                else if (choice.ToUpper() == "R")
                    AttemptToRun(player, enemy);

                if (!enemy.IsAlive)
                    HandleVictory(player, enemy);
                else if (!player.IsAlive)
                    HandleDefeat(enemy, player);
            }
        }

        private string GetValidChoice()
        {
            int invalidChoiceCount = 0;
            string choice;
            do
            {
                Console.WriteLine("Invalid choice! Please choose either 'A' to attack or 'R' to run.");
                Console.WriteLine($"What do you want to do? (A)ttack or (R)un?");
                choice = Console.ReadLine();
            } while ((choice.ToUpper() != "A" && choice.ToUpper() != "R") && invalidChoiceCount++ < MaxInvalidChoices);

            return invalidChoiceCount >= MaxInvalidChoices ? "A" : choice;
        }

        private void AttackEnemy(Player player, Enemy enemy)
        {
            int damageDealt = player.Attack - enemy.Defense;
            if (damageDealt < 0)
                damageDealt = 0;

            enemy.Health -= damageDealt;
            Console.WriteLine($"{player.Name} attacks {enemy.Name} and deals {damageDealt} damage!");
        }

        private void AttemptToRun(Player player, Enemy enemy)
        {
            Random rand = new Random();
            if (rand.NextDouble() < SuccessPercentage)
            {
                Console.WriteLine($"{player.Name} successfully runs away from {enemy.Name}!");
                return;
            }

            Console.WriteLine($"{player.Name} failed to run away from {enemy.Name}!");
            int damageReceived = enemy.Attack - player.Defense;
            if (damageReceived < 0)
                damageReceived = 0;

            player.Health -= damageReceived;
            Console.WriteLine($"{enemy.Name} attacks {player.Name} and deals {damageReceived} damage!");
        }

        private void HandleVictory(Player player, Enemy enemy)
        {
            int expReward = enemy.RewardExperience;
            int goldReward = enemy.RewardGold;

            if (enemy.Level > player.Level)
            {
                int levelDifference = enemy.Level - player.Level;
                expReward *= (1 + levelDifference / 10);
                goldReward *= (1 + levelDifference / 10);
            }

            player.Experience += expReward;
            player.Gold += goldReward;

            Console.WriteLine($"You gained {expReward} experience and {goldReward} gold!");
        }

        private void HandleDefeat(Enemy enemy, Player player)
        {
            Console.WriteLine($"{enemy.Name} wins the battle!");
            player.Reset();
        }
    }
}
