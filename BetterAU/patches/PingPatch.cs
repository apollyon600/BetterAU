using HarmonyLib;
using System.Drawing;

namespace BetterAU.patches
{
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingPatch
    {
        public static void Postfix(PingTracker __instance)
        {
            __instance.text.Text =
                string.Format(
                    "Ping: {0}\n \n[]> [ffffffff]Better[ff0000ff]AU <\n[ffffffff]Made by Apollo#6000\n[6e88e3ff]Discord: [a7b4e0ff]discord.gg/gbXcMta",
                    AmongUsClient.Instance.Ping);
        }
    }
}