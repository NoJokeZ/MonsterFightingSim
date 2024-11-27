namespace Monster_fighting_sim
{
    public class Troll : Monster
    {
        private float beserkTreshold = 0.50f;
        private float beserkAttackBoost = 1.5f;
        private float beserkDefenseBoost = 1.2f;

        public Troll(int inHealthPoints, int inAttackPoints, int inDefensePoints, int inSpeedPoints, RaceType inRace)
            : base(inHealthPoints, inAttackPoints, inDefensePoints, inSpeedPoints, inRace)
        {

        }

        /// <summary>
        /// Troll Attack / Troll goes Berserk from when under certain percentage health and gets damage boost
        /// </summary>
        /// <param name="target"></param>
        public override void Attack(Monster target)
        {
            float selfPercentageHealth = float.Round(this.HealthPoints / this.StartHealthPoints, 2); //Current Troll percentage health
            int beserkAttackPoint = (int)Math.Round(this.AttackPoints * beserkAttackBoost); //Boosted attack points

            if (selfPercentageHealth <= beserkTreshold)  //Boosted/Beserk attack
            {
                target.TakeDamage(beserkAttackPoint);
            }
            else //Normal attack
            {
                target.TakeDamage(this.AttackPoints);
            }
        }
        /// <summary>
        /// Troll TakeDamage / Troll goes Beserk from when under certain percentage health and gets less damage
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            float selfPercentageHealth = float.Round(this.HealthPoints / this.StartHealthPoints, 2); //Current Troll percentage health
            int beserkDefensePoints = ((int)Math.Round(this.DefensePoints * beserkDefenseBoost, 0)); //Boosted defense points

            if (selfPercentageHealth <= beserkTreshold) //Boosted/Bersek defense
            {
                if (damage - beserkDefensePoints < 1)
                {
                    this.HealthPoints--;
                }
                else
                {
                    this.HealthPoints -= (damage - beserkDefensePoints);
                }
            }
            else //Normal defense
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
