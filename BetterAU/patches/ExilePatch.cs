using UnityEngine;
using HarmonyLib;

namespace BetterAU.patches
{
    class ExilePatch
    {
        [HarmonyPatch(nameof(ExileController.Begin))]
        public static void Prefix(ExileController __instance)
        {
            if (__instance.exiled != null)
            {
                if (Helper.isJester(__instance.exiled.PlayerId))
                {
                    CLog.Info("Jester Voted Out");
                    __instance.completeString = __instance.exiled.PlayerName + " was the Jester";
                    ShipStatus.RpcEndGame(GameOverReason.HumansByVote, false);
                }
            }
        }
    }
}