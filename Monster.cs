namespace Monster_fighting_sim
{

    public enum RaceType
    {
        Slime, //0
        Troll, //1
        Orc,   //2
        Goblin //3
    }

    public abstract class Monster
    {

        public int HealthPoints { get; protected set; }
        public int StartHealthPoints { get; private init; }
        public int AttackPoints { get; private init; }
        public int DefensePoints { get; private init; }
        public int SpeedPoints { get; private init; }
        public RaceType Race { get; private init; }



        public Monster(int inHealthPoints, int inAttackPoints, int inDefensePoints, int inSpeedPoints, RaceType inRace)
        {

            HealthPoints = inHealthPoints;
            StartHealthPoints = inHealthPoints;
            AttackPoints = inAttackPoints;
            DefensePoints = inDefensePoints;
            SpeedPoints = inSpeedPoints;
            Race = inRace;
        }
        /// <summary>
        /// Monster Attack method
        /// </summary>
        /// <param name="Target"></param>
        public abstract void Attack(Monster Target);

        /// <summary>
        /// Monster TakeDamage method
        /// </summary>
        /// <param name="damage"></param>
        public abstract void TakeDamage(int damage);

        /// <summary>
        /// Returns RaceType of index
        /// </summary>
        /// <param name="selectedindex"></param>
        /// <returns></returns>
        public static RaceType ReturnRaceTypeIndex(int selectedindex)
        {
            //Index check
            if (selectedindex <= 0 && selectedindex > 3) return default;

            RaceType[] array = (RaceType[])Enum.GetValues(typeof(RaceType));
            return array[selectedindex];
        }
    }
}
