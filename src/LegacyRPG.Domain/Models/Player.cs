namespace LegacyRPG.Domain.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public string Class { get; set; }
        public int Gold { get; set; }
        public int MaxHealth { get; set; }
        public int MaxMana { get; set; }
        public int Mana { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Spell> Spells { get; set; }

        public void Reset()
        {
            this.Health = this.MaxHealth;
            this.Experience = 0;
            this.Gold = 0;
            this.Level = 1;
            //this.Inventory = new List<Item>(); // ainda sem inventário D:
        }
    }
}
