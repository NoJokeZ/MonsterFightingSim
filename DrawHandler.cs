namespace Monster_fighting_sim
{
    public static class DrawHandler
    {
        /// <summary>
        /// Draws a string array from Illustrations class at transferred coords
        /// </summary>
        /// <param name="IllustrationX"></param>
        /// <param name="illustrationY"></param>
        /// <param name="DrawIllustration"></param>
        public static void DrawIllustration(int IllustrationX, int illustrationY, string[] DrawIllustration)
        {
            Console.SetCursorPosition(IllustrationX, illustrationY);

            for (int i = 0; i < DrawIllustration.Length; i++)
            {
                Console.Write(DrawIllustration[i]);
                Console.SetCursorPosition(IllustrationX, illustrationY + 1 + i);
            }
        }

        /// <summary>
        /// Draws a string at transferred coords (Either from Illustrations or just a some string.)
        /// </summary>
        /// <param name="descriptionX"></param>
        /// <param name="descriptionY"></param>
        /// <param name="drawDescription"></param>
        public static void DrawDescription(int descriptionX, int descriptionY, string drawDescription)
        {
            Console.SetCursorPosition(descriptionX, descriptionY);
            Console.WriteLine(drawDescription);
        }

        /// <summary>
        /// Clears a complete Line at transferred coords
        /// </summary>
        /// <param name="clearLineX"></param>
        /// <param name="clearLineY"></param>
        public static void ClearLine(int clearLineX, int clearLineY)
        {
            Console.SetCursorPosition(clearLineX, clearLineY);
            for (int i = 0; i < 130; i++)
            {
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Draws an integer at transferred coords 
        /// </summary>
        /// <param name="statX"></param>
        /// <param name="statY"></param>
        /// <param name="drawStat"></param>
        public static void DrawStat(int statX, int statY, int drawStat)
        {
            Console.SetCursorPosition(statX, statY);
            Console.WriteLine(drawStat);
        }

        /// <summary>
        /// Draws two blanks at transferred coords to clear stats
        /// </summary>
        /// <param name="statX"></param>
        /// <param name="statY"></param>
        public static void DrawEmptyStat(int statX, int statY)
        {
            Console.SetCursorPosition(statX, statY);
            Console.WriteLine("  ");
        }
    }
}
