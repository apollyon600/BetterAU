using HarmonyLib;

namespace BetterAU.patches
{
    class VersionPatch
    {
        [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
        public static class VersionShowerPatch {
            public static void Postfix(VersionShower __instance) {
                __instance.text.Text = "\n \n \n \n \n[]> [ffffffff]Better[ff0000ff]AU <\n[ffffffff]Made by Apollo#6000\n[6e88e3ff]Discord: [a7b4e0ff]discord.gg/gbXcMta";
            }
        }
    }
}