namespace LegacyRPG.Domain.Models.Enemies
{
    public class Orc : Enemy
    {
        public Orc()
        {
            Id = 1;
            Name = "Orc";
            IsAlive = true;
            Attack = 10;
            Category = "Classic Orc";
            Class = "Warrior";
            Health = 150;
            Defense = 15;
            Description = "A fierce orc warrior.";
            Level = 1;
            RewardExperience = 5;
            RewardGold = 15;
            MaxHealth = 150;
            EnemyBeforeBattleMessage = "Grug'nak, humanaz.";
            EnemyLossBattleMessage = "Zrak'ghar, Grognar krush youz next time.";
            EnemyWinBattleMessage = "Hruugh! Orcz ztrongezt.";
        }
    }
}
