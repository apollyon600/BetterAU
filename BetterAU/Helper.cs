namespace BetterAU
{
    public static class Helper
    {
        public static bool isJester(byte playerID)
        {
            bool isJester = false;
            if (Settings.JesterList != null)
            {
                for (int i = 0; i < Settings.JesterList.Count; i++)
                {
                    if (playerID == Settings.JesterList[i].PlayerId)
                        isJester = true;
                }
            }

            return isJester;
        }
        
        public static bool isMayor(byte playerID)
        {
            bool isMayor = false;
            if (Settings.MayorList != null)
            {
                for (int i = 0; i < Settings.MayorList.Count; i++)
                {
                    if (playerID == Settings.MayorList[i].PlayerId)
                        isMayor = true;
                }
            }

            return isMayor;
        }
        
        public static bool isTroll(byte playerID)
        {
            bool isTroll = false;
            if (Settings.TrollList != null)
            {
                for (int i = 0; i < Settings.TrollList.Count; i++)
                {
                    if (playerID == Settings.TrollList[i].PlayerId)
                        isTroll = true;
                }
            }

            return isTroll;
        }
        
        public static bool isLeader(byte playerID)
        {
            bool isLeader = false;
            if (Settings.LeaderList != null)
            {
                for (int i = 0; i < Settings.LeaderList.Count; i++)
                {
                    if (playerID == Settings.LeaderList[i].PlayerId)
                        isLeader = true;
                }
            }

            return isLeader;
        }

        public static void clearRoles()
        {
            if (Settings.JesterList != null && Settings.JesterList.Count > 0)
                Settings.JesterList.Clear();
            
            if (Settings.LeaderList != null && Settings.LeaderList.Count > 0)
                Settings.LeaderList.Clear();
            
            if (Settings.TrollList != null && Settings.TrollList.Count > 0)
                Settings.TrollList.Clear();
            
            if (Settings.MayorList != null && Settings.MayorList.Count > 0)
                Settings.MayorList.Clear();
        }
    }
}