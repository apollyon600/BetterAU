using System;
using HarmonyLib;

namespace BetterAU
{
    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.HandleProceed))]
    public class MeetingPatch
    {
        static void Postfix(MeetingHud __instance)
        {
            
        }
    }

    [HarmonyPatch(typeof(ExileController), nameof(ExileController.Begin))]
    class ExileControllerPatch
    {
        static void Postfix(ExileController __instance)
        {
            __instance.Text.Text = __instance.Player.name + " was de pasta";
        }
    }
}