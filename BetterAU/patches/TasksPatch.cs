using UnityEngine;
using HarmonyLib;

namespace BetterAU.patches
{
    class TasksPatch
    {
        [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.SetTasks))]
        public static void Prefix(PlayerControl __instance)
        {
            __instance.killTimer = 0;
            if (PlayerControl.LocalPlayer != null)
            {
                if (Helper.isJester(PlayerControl.LocalPlayer.PlayerId))
                {
                    ImportantTextTask importantTasks =
                        new GameObject("JesterTasks").AddComponent<ImportantTextTask>();
                    importantTasks.transform.SetParent(__instance.transform, false);
                    importantTasks.Text = "[d72df2ff]You are the jester! Get voted out to win!";
                    __instance.myTasks.Insert(0, importantTasks);
                }
            }
        }
    }
}