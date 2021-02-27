using BetterAU;
using HarmonyLib;
using UnityEngine;
using Reactor; 


namespace BetterAU.patches
{
    [HarmonyPatch(typeof(IntroCutscene.CoBegin__d), nameof(IntroCutscene.CoBegin__d.MoveNext))]
    public static class IntroCutscenePatch
    {
        
        static bool Prefix(IntroCutscene.CoBegin__d __instance)
        {
            if (Helper.isJester(PlayerControl.LocalPlayer.PlayerId))
            {
                var jesterTeam = new Il2CppSystem.Collections.Generic.List<PlayerControl>();
                jesterTeam.Add(PlayerControl.LocalPlayer);
                __instance.yourTeam = jesterTeam;
            }

            return true;
        }
        
        public static void Postfix(IntroCutscene.CoBegin__d __instance)
        {
            byte localPlayerId = PlayerControl.LocalPlayer.PlayerId;
            bool isImpostor = __instance.isImpostor;

            if (!isImpostor && Helper.isJester(localPlayerId))
            {
                __instance.__this.Title.Text = "Jester";
                __instance.__this.Title.scale /= 1.4f;
                __instance.__this.Title.Color = new Color(0.99f, 0.37f, 1f);
                __instance.__this.ImpostorText.Text = "Get voted out to win!";
                __instance.__this.BackgroundBar.material.color = new Color(0.99f, 0.37f, 1f);
            }
        } 
    }
}