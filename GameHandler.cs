
using System.ComponentModel.Design;

namespace Monster_fighting_sim
{
    public class GameHandler
    {

        private (int x, int y) headerLocation = (1, 1);
        private (int x, int y) attackLocation = (24, 4);

        private (int x, int y) monsterOneLocation = (1, 2);
        private (int x, int y) monsterOneStatsLocation = (1, 12);
        private (int x, int y) monsterOneHpLocation = (2, 14);
        private (int x, int y) monsterOneApLocation = (7, 14);
        private (int x, int y) monsterOneDpLocation = (12, 14);
        private (int x, int y) monsterOneSpLocation = (17, 14);

        private (int x, int y) monsterTwoLocation = (41, 2);
        private (int x, int y) monsterTwoStatsLocation = (41, 12);
        private (int x, int y) monsterTwoHpLocation = (42, 14);
        private (int x, int y) monsterTwoApLocation = (47, 14);
        private (int x, int y) monsterTwoDpLocation = (53, 14);
        private (int x, int y) monsterTwoSpLocation = (57, 14);

        /// <summary>
        /// Initiates the battle phase and handles it
        /// </summary>
        /// <param name="monsterCreator"></param>
        public void BattleHandler(MonsterCreator monsterCreator)
        {
            Console.Clear();

            Monster? monsterOne = monsterCreator.MonsterOne;
            Monster? monsterTwo = monsterCreator.MonsterTwo;
            
            Monster fasterMonster;
            Monster slowerMonster;
            (int x, int y) fasterMonsterHpLocation;
            (int x, int y) slowerMonsterHpLocation;
            int turnCount = 0;
            bool battleOngoing = true;
            bool playerWon;

            DrawBattlefield(monsterOne, monsterTwo);

            //Identifies the faster monster and sets values for the battle loop
            if (monsterOne.SpeedPoints >= monsterTwo.SpeedPoints)
            {
                fasterMonster = monsterOne;
                fasterMonsterHpLocation = monsterOneHpLocation;
                slowerMonster = monsterTwo;
                slowerMonsterHpLocation = monsterTwoHpLocation;
            }
            else
            {
                fasterMonster = monsterTwo;
                fasterMonsterHpLocation = monsterTwoHpLocation;
                slowerMonster = monsterOne;
                slowerMonsterHpLocation = monsterOneHpLocation;
            }

            //battle loop
            while (battleOngoing)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Current Turn: "+turnCount);

                BattleTurn(fasterMonster, slowerMonster, slowerMonsterHpLocation);

                if (slowerMonster.HealthPoints <= 0) break;

                Thread.Sleep(700);

                BattleTurn(slowerMonster, fasterMonster, fasterMonsterHpLocation);

                turnCount++;
                if (fasterMonster.HealthPoints <= 0) break;
            }

            Thread.Sleep(1000);


            //Identiefies if the player has won
            if (slowerMonster.HealthPoints <= 0 && slowerMonster.Race == monsterOne.Race)
            {
                playerWon = false;
            }
            else if (fasterMonster.HealthPoints <= 0 && fasterMonster.Race == monsterOne.Race)
            {
                playerWon = false;
            }
            else
            {
                playerWon = true;
            }

            EndScreen.EndMenu(playerWon);

        }

        /// <summary>
        /// Draws the two fighting monster and their stats
        /// </summary>
        /// <param name="monsterOne"></param>
        /// <param name="monsterTwo"></param>
        private void DrawBattlefield(Monster? monsterOne, Monster? monsterTwo)
        {

            //MonsterOne
            DrawHandler.DrawIllustration(monsterOneLocation.x, monsterOneLocation.y, Illustrations.MonsterCard[monsterOne.Race]);
            DrawHandler.DrawIllustration(monsterOneStatsLocation.x, monsterOneStatsLocation.y, Illustrations.StatContainer);
            DrawHandler.DrawStat(monsterOneHpLocation.x, monsterOneHpLocation.y, monsterOne.HealthPoints);
            DrawHandler.DrawStat(monsterOneApLocation.x, monsterOneApLocation.y, monsterOne.AttackPoints);
            DrawHandler.DrawStat(monsterOneDpLocation.x, monsterOneDpLocation.y, monsterOne.DefensePoints);
            DrawHandler.DrawStat(monsterOneSpLocation.x, monsterOneSpLocation.y, monsterOne.SpeedPoints);

            //MonsterTwo
            DrawHandler.DrawIllustration(monsterTwoLocation.x, monsterTwoLocation.y, Illustrations.MonsterCard[monsterTwo.Race]);
            DrawHandler.DrawIllustration(monsterTwoStatsLocation.x, monsterTwoStatsLocation.y, Illustrations.StatContainer);
            DrawHandler.DrawStat(monsterTwoHpLocation.x, monsterTwoHpLocation.y, monsterTwo.HealthPoints);
            DrawHandler.DrawStat(monsterTwoApLocation.x, monsterTwoApLocation.y, monsterTwo.AttackPoints);
            DrawHandler.DrawStat(monsterTwoDpLocation.x, monsterTwoDpLocation.y, monsterTwo.DefensePoints);
            DrawHandler.DrawStat(monsterTwoSpLocation.x, monsterTwoSpLocation.y, monsterTwo.SpeedPoints);

        }

        /// <summary>
        /// Exute a battle turn
        /// </summary>
        /// <param name="attackingMonster"></param>
        /// <param name="targetMonster"></param>
        /// <param name="hpLocation"></param>
        private void BattleTurn(Monster attackingMonster, Monster targetMonster, (int x, int y) hpLocation)
        {
            attackingMonster.Attack(targetMonster);
            DrawHandler.DrawIllustration(attackLocation.x, attackLocation.y, Illustrations.Sword);
            Thread.Sleep(700);
            DrawHandler.DrawEmptyStat(hpLocation.x, hpLocation.y);
            Console.ForegroundColor = ConsoleColor.Red;
            DrawHandler.DrawStat(hpLocation.x, hpLocation.y, targetMonster.HealthPoints);
            Thread.Sleep(700);
            Console.ForegroundColor = ConsoleColor.White;
            DrawHandler.DrawStat(hpLocation.x, hpLocation.y, targetMonster.HealthPoints);
            DrawHandler.DrawIllustration(attackLocation.x, attackLocation.y, Illustrations.SwordEmpty);
        }
    }
}
