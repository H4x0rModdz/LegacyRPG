namespace LegacyRPG.Domain.Models
{
    public class Enemy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public string Category { get; set; }
        public string Class { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int RewardExperience { get; set; }
        public int RewardGold { get; set; }
        public int MaxHealth { get; set; }
        public string EnemyBeforeBattleMessage { get; set; }
        public string EnemyLossBattleMessage { get; set; }
        public string EnemyWinBattleMessage { get; set; }
    }
}
