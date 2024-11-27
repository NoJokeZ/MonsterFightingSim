namespace Monster_fighting_sim
{
    public static class EndScreen
    {
        /// <summary>
        /// Shows the end screen and its menu
        /// </summary>
        /// <param name="playerWon"></param>
        public static void EndMenu(bool playerWon)
        {
            
            Console.Clear();
            bool menuSelected = false;

            string battleOutcomeWin = @"
 __     __         _                                 _ _ _  __     __                   __  
 \ \   / /        ( )                               | | | | \ \   / /           ______  \ \ 
  \ \_/ /__  _   _|/__   _____  __      _____  _ __ | | | |  \ \_/ /_ _ _   _  |______|  | |
   \   / _ \| | | | \ \ / / _ \ \ \ /\ / / _ \| '_ \| | | |   \   / _` | | | |  ______   | |
    | | (_) | |_| |  \ V /  __/  \ V  V / (_) | | | |_|_|_|    | | (_| | |_| | |______|  | |
    |_|\___/ \__,_|   \_/ \___|   \_/\_/ \___/|_| |_(_|_|_)    |_|\__,_|\__, |           | |
                                                                         __/ |          /_/ 
                                                                        |___/               ";

            string battleOutcomeLoose = @"
 __     __           _           _   _             __ 
 \ \   / /          | |         | | | |  ______   / / 
  \ \_/ /__  _   _  | | ___  ___| |_| | |______| | |  
   \   / _ \| | | | | |/ _ \/ __| __| |  ______  | |  
    | | (_) | |_| | | | (_) \__ \ |_|_| |______| | |  
    |_|\___/ \__,_| |_|\___/|___/\__(_)          | |  
                                                  \_\ 
                                                      ";

            string menu = @"
Menu

 1: Restart
 2: Exit";


            if (playerWon) 
            {
                Console.WriteLine(battleOutcomeWin);
            }
            else
            {
                Console.WriteLine(battleOutcomeLoose);
            }

            Console.WriteLine(menu);


            while (!menuSelected)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        menuSelected = true;
                        Console.Clear();
                        //GameReset();
                        Menu.MainMenu();

                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        menuSelected = true;
                        Environment.Exit(0);

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
