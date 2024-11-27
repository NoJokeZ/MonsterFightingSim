namespace Monster_fighting_sim
{
    /// <summary>
    /// Shows the Intro Header and checks for correct window size
    /// </summary>
    public static class Intro
    {
        public static void IntroSequenz()
        {
            int windowWidth = 130;
            int windowHeight = 30;
            string welcome = @"
    __  __                 _              ______ _       _     _   _                _____ _                 _       _            
   |  \/  |               | |            |  ____(_)     | |   | | (_)              / ____(_)               | |     | |           
   | \  / | ___  _ __  ___| |_ ___ _ __  | |__   _  __ _| |__ | |_ _ _ __   __ _  | (___  _ _ __ ___  _   _| | __ _| |_ ___ _ __ 
   | |\/| |/ _ \| '_ \/ __| __/ _ \ '__| |  __| | |/ _` | '_ \| __| | '_ \ / _` |  \___ \| | '_ ` _ \| | | | |/ _` | __/ _ \ '__|
   | |  | | (_) | | | \__ \ ||  __/ |    | |    | | (_| | | | | |_| | | | | (_| |  ____) | | | | | | | |_| | | (_| | ||  __/ |   
   |_|  |_|\___/|_| |_|___/\__\___|_|    |_|    |_|\__, |_| |_|\__|_|_| |_|\__, | |_____/|_|_| |_| |_|\__,_|_|\__,_|\__\___|_|   
                                                  __/ |                     __/ |                                                
                                                 |___/                     |___/                                                 ";
            Console.CursorVisible = false;
            Console.WindowWidth = windowWidth;
            Console.WindowHeight = windowHeight;

            while (Console.WindowWidth < windowWidth)
            {
                Console.WriteLine("Please make your console window a bit bigger. Thank you ^-^");
                Thread.Sleep(1000);
                Console.Clear();
            }

            Console.WriteLine(welcome);

            Thread.Sleep(3000);

            Console.Clear();

            Menu.MainMenu();

        }
    }
}
