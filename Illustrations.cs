namespace Monster_fighting_sim
{
    public static class Illustrations
    {

        public static Dictionary<RaceType, string> MonsterDescription = new Dictionary<RaceType, string>();
        public static Dictionary<RaceType, string[]> MonsterCard = new Dictionary<RaceType, string[]>();


        static Illustrations()
        {
            MonsterDescription.Add(RaceType.Slime, "Slime: Eats low health targets but gets sliced in half when hit.");
            MonsterCard[RaceType.Slime] = new[]
            {
            @"▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄",
            @"▌                   ▐",
            @"▌ ░░░░░░░░░░░░░░░░░ ▐",
            @"▌ ░░███░░░░░░░███░░ ▐",
            @"▌ ░░███░░░░░░░███░░ ▐",
            @"▌ ░░░░░░░░░░░░░░░░░ ▐",
            @"▌ ░░░░░░░░░░░░░░░░░ ▐",
            @"▌ ░░░░░░░░███░░░░░░ ▐",
            @"▌ ░░░░░░░░░░░░░░░░░ ▐",
            @"▌ ░░░░░░░░░░░░░░░░░ ▐",
            @"▌                   ▐",
            @"▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            };

            MonsterDescription[RaceType.Troll] = "Troll: Goes Beserk when angry which boosts attack and defense.";
            MonsterCard[RaceType.Troll] = new[]
            {
            @"▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄",
            @"▌                   ▐",
            @"▌   ░░░░░░░░░░░░░   ▐",
            @"▌  ░░ Ö       Ö ░░  ▐",
            @"▌  ░░           ░░  ▐",
            @"▌   ░    ▐█▌    ░   ▐",
            @"▌   ░    ▐█▌    ░   ▐",
            @"▌   ░           ░   ▐",
            @"▌   ░░░░░░░░░░░░░   ▐",
            @"▌                   ▐",
            @"▌                   ▐",
            @"▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            };

            MonsterDescription[RaceType.Orc] = "Orc: Has a chance to crit but also miss. Survies a deathblow.";
            MonsterCard[RaceType.Orc] = new[]
            {
            @"▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄",
            @"▌                   ▐",
            @"▌  ░░           ░░  ▐",
            @"▌  ░░░░░░░░░░░░░░░  ▐",
            @"▌   ░  \      / ░   ▐",
            @"▌   ░           ░   ▐",
            @"▌   ░           ░   ▐",
            @"▌   ░  ▄█▄▄▄▄█▄ ░   ▐",
            @"▌   ░           ░   ▐",
            @"▌   ░░░░░░░░░░░░░   ▐",
            @"▌                   ▐",
            @"▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            };

            MonsterDescription[RaceType.Goblin] = "Goblin: Has a chance to ignore defense and to dodge.";
            MonsterCard[RaceType.Goblin] = new[]
            {
            @"▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄",
            @"▌                   ▐",
            @"▌ ░░             ░░ ▐",
            @"▌  ░░░ ░░░░░░░ ░░░  ▐",
            @"▌    ░░ $   $ ░░    ▐",
            @"▌     ░   ▄   ░     ▐",
            @"▌     ░       ░     ▐",
            @"▌     ░  ▄▄▄  ░     ▐",
            @"▌     ░       ░     ▐",
            @"▌      ░░░░░░░      ▐",
            @"▌                   ▐",
            @"▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            };
        }

        public static string[] Sword { get; } =
        {
            @"▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄",
            @"▌      _      ▐",
            @"▌     / \     ▐",
            @"▌     | |     ▐",
            @"▌     | |     ▐",
            @"▌     | |     ▐",
            @"▌    <XXX>    ▐",
            @"▌      I      ▐",
            @"▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
        };
        public static string[] SwordEmpty { get; } =
        {
            @"               ",
            @"               ",
            @"               ",
            @"               ",
            @"               ",
            @"               ",
            @"               ",
            @"               ",
            @"               "
        };

        public static string[] StatContainer { get; } =
        {
            @"█████████████████████",
            @"▌HP: ▌AP: ▌DP: ▌SP: ▐",
            @"▌    ▌    ▌    ▌    ▐",
            @"▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
        };

    }
}
