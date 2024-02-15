namespace LegacyRPG.Domain.Models.Enemies
{
    public class Goblin : Enemy
    {
        public Goblin()
        {
            Id = 2;
            Name = "Goblin";
            IsAlive = true;
            Attack = 10;
            Category = "Classic Goblin";
            Class = "Warrior";
            Health = 150;
            Defense = 15;
            Description = "A mischievous goblin.";
            Level = 1;
            RewardExperience = 5;
            RewardGold = 15;
            MaxHealth = 125;
            EnemyBeforeBattleMessage = "Snik-snik, me eat youz";
            EnemyLossBattleMessage = "Zak-zak, youz lucky diz time, human";
            EnemyWinBattleMessage = "Hehe! Goblins rulez";
        }
    }
}
