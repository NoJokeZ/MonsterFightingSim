namespace Monster_fighting_sim
{
    public class Slime : Monster
    {
        private float killTreshold = 0.20f; //Percentage from when the target is killed instantly
        private float deathTreshold = 0.20f; //Percentage from when slime is killed

        public Slime(int inHealthPoints, int inAttackPoints, int inDefensePoints, int inSpeedPoints, RaceType inRace)
            : base(inHealthPoints, inAttackPoints, inDefensePoints, inSpeedPoints, inRace)
        {

        }
        /// <summary>
        /// Slime Attack / Slime "eats" enemy if they're below a certain health percentage
        /// </summary>
        /// <param name="target"></param>
        public override void Attack(Monster target)
        {
            int targetHealthAfterAttack = target.HealthPoints; // = (target.HealthPoints - (this.AttackPoints - target.DefensePoints)); //Estimated Target health after attack
            if (this.AttackPoints - target.DefensePoints <= 0)
            {
                targetHealthAfterAttack -= 1;
            }
            else
            {
                targetHealthAfterAttack = (target.HealthPoints - (this.AttackPoints - target.DefensePoints));
            }

            float targetPercentageHealth = float.Round(targetHealthAfterAttack / target.StartHealthPoints, 2); //Current target percentage health

            if (targetPercentageHealth <= killTreshold) //kill if target under treshold
            {
                target.TakeDamage(999);
            }
            else //normal attack
            {
                target.TakeDamage(this.AttackPoints);
            }
        }
        /// <summary>
        /// Slime TakeDamage / Slime get health halfed everytime instead of taking normal damgage and dies if below certain treshold
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            float selfPercentageHealth = float.Round(this.HealthPoints / this.StartHealthPoints, 2); //Current slime percentage health

            if (selfPercentageHealth <= deathTreshold) //Die if under treshold
            {
                //this.Die();
            }
            else //Health halfed on attack logic
            {
                float tempHealthPoints = this.HealthPoints / 2;
                int newHealthPoints = (int)Math.Round(tempHealthPoints, 0);
                this.HealthPoints = newHealthPoints;
            }
        }
    }
}
