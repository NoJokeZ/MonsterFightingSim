namespace Monster_fighting_sim
{
    public class Goblin : Monster
    {
        private float ignoreArmorChance = 0.2f;
        private float dodgeChance = 0.2f;

        public Goblin(int inHealthPoints, int inAttackPoints, int inDefensePoints, int inSpeedPoints, RaceType inRace)
            : base(inHealthPoints, inAttackPoints, inDefensePoints, inSpeedPoints, inRace)
        {

        }
        /// <summary>
        /// Goblin Attack / Goblin can ignor armor on attack
        /// </summary>
        /// <param name="target"></param>
        public override void Attack(Monster target)
        {
            Random ignoreArmorRandom = new Random();
            float randomIgnoreArmorChance = (float)ignoreArmorRandom.NextDouble();
            int attackIgnoreArmor = this.AttackPoints + target.DefensePoints;

            if (ignoreArmorChance >= randomIgnoreArmorChance) //Attack with ignore armor
            {
                target.TakeDamage(attackIgnoreArmor);
            }
            else //Normal attack
            {
                target.TakeDamage(AttackPoints);
            }
        }
        /// <summary>
        /// Goblin TakeDamage / Goblin got chance to dodge attack
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            Random dodgeRandom = new Random();
            float randomDodgeChane = (float)dodgeRandom.NextDouble();


            if (dodgeChance >= randomDodgeChane) //Dodge attack
            {
                return;
            }
            else //No dodge -> normal defense
            {
                if (damage - this.DefensePoints < 1)
                {
                    this.HealthPoints--;
                }
                else
                {
                    this.HealthPoints -= (damage - this.DefensePoints);
                }
            }
        }
    }
}
