using System.Collections.Generic;

namespace BetterAU
{
    public static class Settings
    {
        // Roles
        public static List<PlayerControl> JesterList = new List<PlayerControl>(); // The jester must get themselves voted out to win.
        public static List<PlayerControl> MayorList = new List<PlayerControl>(); // The mayor's votes counts as two.
        public static List<PlayerControl> LeaderList = new List<PlayerControl>(); // The leader has the ability to vote anyone they like, the crewmates must convince the leader.
        public static List<PlayerControl> TrollList = new List<PlayerControl>(); // The troll must get themselves killed by an impostor to win.

        // Misc
        public static bool isGameStarted = false;
    }
}