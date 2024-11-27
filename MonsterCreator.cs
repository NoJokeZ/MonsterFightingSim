namespace Monster_fighting_sim
{
    public class MonsterCreator
    {
        private (int x, int y) monsterCardLocation = (1, 5);
        private (int x, int y) monsterDescriptionLocation = (1, 4);
        private (int x, int y) monsterStatContainerLocation = (1, 16);
        private (int x, int y) hpLocation = (2, 18);
        private (int x, int y) apLocation = (7, 18);
        private (int x, int y) dpLocation = (12, 18);
        private (int x, int y) spLocation = (17, 18);


        private RaceType inputRaceType;
        private int inputHealthPoints;
        private int inputAttackPoints;
        private int inputDefensePoints;
        private int inputSpeedPoints;

        private int distributablePoints = 30; //Will be changeble by player in the future

        private int[] stats = new int[4];

        public Monster? MonsterOne { get; private set; }
        public Monster? MonsterTwo { get; private set; }

        /// <summary>
        /// Lets the player choose favoured monster race
        /// </summary>
        public void ChooseMonster()
        {
            bool isMonsterChosen = false;
            inputRaceType = RaceType.Slime; //Default is slime
            Console.WriteLine("Choose your Monster:");
            Console.WriteLine("/← | /→");

            while (!isMonsterChosen)
            {

                DrawHandler.ClearLine(monsterDescriptionLocation.x, monsterDescriptionLocation.y);
                DrawHandler.DrawDescription(monsterDescriptionLocation.x, monsterDescriptionLocation.y, Illustrations.MonsterDescription[inputRaceType]);
                DrawHandler.DrawIllustration(monsterCardLocation.x, monsterCardLocation.y, Illustrations.MonsterCard[inputRaceType]);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        PreviousRaceType(inputRaceType); //Identfies the previous raceType
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        NextRaceType(inputRaceType); //Identfies the next raceType
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        isMonsterChosen = true;
                        ChooseStats(distributablePoints); //Initiates the stat distribution trough the player
                        break;
                    default:
                        break;
                }
            }

        }
        /// <summary>
        /// Lets the player select stats for monster
        /// </summary>
        /// <param name="distributablePoints"></param>
        private void ChooseStats(int distributablePoints)
        {
            bool statsSelected = false;
            int indexStats = 0; //An index to cycle trough the diffrent stats the player can modify

            while (!statsSelected)
            {
                Console.WriteLine();
                Console.Clear();
                Console.WriteLine("You chose: " + inputRaceType.ToString());
                DrawHandler.DrawDescription(monsterDescriptionLocation.x, monsterDescriptionLocation.y, Illustrations.MonsterDescription[inputRaceType]);
                DrawHandler.DrawIllustration(monsterCardLocation.x, monsterCardLocation.y, Illustrations.MonsterCard[inputRaceType]);
                DrawHandler.DrawIllustration(monsterStatContainerLocation.x, monsterStatContainerLocation.y, Illustrations.StatContainer);
                RedrawStats();
                Console.WriteLine();
                Console.WriteLine("/← | /→ & /↑ | /↓");
                Console.WriteLine("Select your stats! You have " + distributablePoints + " points left to distribute.");

                switch (Console.ReadKey(true).Key) //left and right to cycle trough stats / up and down to raise or lower stats
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        indexStats--;
                        if (indexStats < 0) indexStats = 3;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        indexStats++;
                        if (indexStats > 3) indexStats = 0;
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (distributablePoints == 0)
                        {
                            Console.Beep(300, 10);
                        }
                        else
                        {
                            distributablePoints--;
                            stats[indexStats]++;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (stats[indexStats] == 0)
                        {
                            Console.Beep(300, 10);
                        }
                        else
                        {
                            distributablePoints++;
                            stats[indexStats]--;
                        }
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (distributablePoints != 0)
                        {
                            Console.Beep(300, 10);
                        }
                        else
                        {
                            statsSelected = true;
                            CreateMonster(stats[0], stats[1], stats[2], stats[3], inputRaceType);
                        }
                        break;
                    default:
                        break;
                }

            }
        }

        /// <summary>
        /// Identifies the previous raceType
        /// </summary>
        /// <param name="inRaceType"></param>
        private void PreviousRaceType(RaceType inRaceType)
        {
            int temp = (int)inRaceType;
            if (temp == 0) temp = 3;
            else temp--;
            inputRaceType = Monster.ReturnRaceTypeIndex(temp);
        }
        /// <summary>
        /// Identifies the next raceType
        /// </summary>
        /// <param name="inRaceType"></param>
        private void NextRaceType(RaceType inRaceType)
        {
            int temp = (int)inRaceType;
            if (temp == 3) temp = 0;
            else temp++;
            inputRaceType = Monster.ReturnRaceTypeIndex(temp);
        }

        /// <summary>
        /// Creates a Monster with given stats and race into monsterOne or monsterTwo if one is already filled
        /// </summary>
        /// <param name="healtPoints"></param>
        /// <param name="attackPoints"></param>
        /// <param name="defensePoints"></param>
        /// <param name="speedPoints"></param>
        /// <param name="race"></param>
        public void CreateMonster(int healtPoints, int attackPoints, int defensePoints, int speedPoints, RaceType race)
        {
            Monster? newMonster;

            switch (race)
            {

                case RaceType.Slime:
                    newMonster = new Slime(healtPoints, attackPoints, defensePoints, speedPoints, RaceType.Slime);
                    break;
                case RaceType.Troll:
                    newMonster = new Troll(healtPoints, attackPoints, defensePoints, speedPoints, RaceType.Troll);
                    break;
                case RaceType.Orc:
                    newMonster = new Orc(healtPoints, attackPoints, defensePoints, speedPoints, RaceType.Orc);
                    break;
                case RaceType.Goblin:
                    newMonster = new Goblin(healtPoints, attackPoints, defensePoints, speedPoints, RaceType.Goblin);
                    break;
                default:
                    newMonster = null;
                    break;
            }

            if (newMonster != null) 
            {
                if (MonsterOne == null) //First monsterOne
                    MonsterOne = newMonster;

                else if (MonsterTwo == null) //Then monsterTwo
                    MonsterTwo = newMonster;

                else //Error is smth went wrong
                    Console.Error.WriteLine("No more Monsters!");
            }
            else //Error is smth went wrong
            {
                Console.Error.WriteLine("No empty Monsters!");
            }
        }

        /// <summary>
        /// Redraws the stats after they haven beed changed in the select screen
        /// </summary>
        private void RedrawStats()
        {
            DrawHandler.DrawEmptyStat(hpLocation.x, hpLocation.y);
            DrawHandler.DrawStat(hpLocation.x, hpLocation.y, stats[0]);

            DrawHandler.DrawEmptyStat(apLocation.x, apLocation.y);
            DrawHandler.DrawStat(apLocation.x, apLocation.y, stats[1]);

            DrawHandler.DrawEmptyStat(dpLocation.x, dpLocation.y);
            DrawHandler.DrawStat(dpLocation.x, dpLocation.y, stats[2]);

            DrawHandler.DrawEmptyStat(spLocation.x, spLocation.y);
            DrawHandler.DrawStat(spLocation.x, spLocation.y, stats[3]);
        }

        /// <summary>
        /// Determines random stats and a race that is not the players race and creates monster with it
        /// </summary>
        public void MonsterWithRandomStats()
        {
            int pointRange = 5; //Random monsters can have more or less points then available for players

            Random rndDistPoints = new Random();

            int randomDistributablePoints = rndDistPoints.Next(distributablePoints - pointRange, distributablePoints + pointRange);

            int[] stats = new int[4]; //Array for 4 random stats

            while (randomDistributablePoints > 0) //Takes a random stat out of the 4 and raises it by one until there a no points left to distribute
            {
                Random rndStats = new Random();
                int rndIndex = rndStats.Next(0, 4);
                stats[rndIndex]++;
                randomDistributablePoints--;
            }

            //Give the health Stat a + 1 in case its 0 so the enemy is not instant death if rng hits bad
            if (stats[0] == 0) stats[0]++;

            Random rndRace = new Random(); 
            int playerRaceIndex = (int)inputRaceType;
            int randomRaceIndex = 0;

            do //Determines a random inter for a random race and makes sure it isnt same as player
            {
                randomRaceIndex = rndRace.Next(0, 4);
            }
            while (randomRaceIndex == playerRaceIndex);

            RaceType randomRace = Monster.ReturnRaceTypeIndex(randomRaceIndex);

            CreateMonster(stats[0], stats[1], stats[2], stats[3], randomRace);

        }
    }
}
