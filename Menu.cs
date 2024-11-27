namespace Monster_fighting_sim
{
    public static class Menu
    {
        /// <summary>
        /// Shows the main menu
        /// </summary>
        public static void MainMenu()
        {
            Console.Clear();

            MonsterCreator monsterCreator = new MonsterCreator();
            GameHandler gameHandler = new GameHandler();

            bool menuSelected = false;

            string menu = @"
Menu

 1: Game start
 2: Exit
 3: Credits";

            Console.WriteLine(menu);


            while (!menuSelected)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        menuSelected = true;
                        Console.Clear();
                        monsterCreator.ChooseMonster();
                        monsterCreator.MonsterWithRandomStats();
                        gameHandler.BattleHandler(monsterCreator);

                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        menuSelected = true;
                        Environment.Exit(0);

                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        menuSelected = true;
                        Console.Clear();
                        //Credits();
                        ;

                        break;
                    default:
                        break;
                }
            }
        }

    }
}
