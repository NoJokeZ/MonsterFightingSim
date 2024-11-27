namespace Monster_fighting_sim
{
    public class Orc : Monster
    {
        private float critChance = 0.2f;
        private float critMultiplyer = 1.5f;
        private float missChance = 0.2f;
        private int lastChances = 1;

        public Orc(int inHealthPoints, int inAttackPoints, int inDefensePoints, int inSpeedPoints, RaceType inRace)
            : base(inHealthPoints, inAttackPoints, inDefensePoints, inSpeedPoints, inRace)
        {

        }
        /// <summary>
        /// Orc Attack / Orc can crit and miss attacks
        /// </summary>
        /// <param name="target"></param>
        public override void Attack(Monster target)
        {
            Random randomMiss = new Random();
            float randomMissChance = (float)randomMiss.NextDouble();
            Random randomCrit = new Random();
            float randomCritChance = (float)randomCrit.NextDouble();

            if (missChance >= randomMissChance) //If miss then 0 damage
            {
                target.TakeDamage(0);
            }
            else if (critChance >= randomCritChance) //If crit then crit damage
            {
                int critAttackPoints = ((int)Math.Round(this.AttackPoints * critMultiplyer, 0)); //Crit damage calculation

                target.TakeDamage(critAttackPoints);
            }
            else //Normal damage
            {
                target.TakeDamage(AttackPoints);
            }
        }
        /// <summary>
        /// Orc TakeDamage / Orc got last chances if dies
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {

            if (damage - this.DefensePoints < 1)
            {
                this.HealthPoints--;
            }
            else
            {
                this.HealthPoints -= (damage - this.DefensePoints);
            }


            if (this.HealthPoints <= 0 && lastChances > 0) //If any last chances left then surviv with one hp
            {
                this.HealthPoints = 1;
                lastChances--;
            }
        }
    }
}
