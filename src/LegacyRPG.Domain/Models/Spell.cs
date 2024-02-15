namespace LegacyRPG.Domain.Models
{
    public class Spell
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public string Type { get; set; }
        public int ManaCost { get; set; }
        public string Description { get; set; }
    }
}
