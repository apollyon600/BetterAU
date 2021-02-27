using HarmonyLib;
using UnityEngine;

namespace BetterAU.patches {
    public static class MeetingHudPatch 
    {
        public static void UpdateHUD(MeetingHud __instance)
        {
            foreach (PlayerVoteArea area in __instance.playerStates)
            {
                if (PlayerControl.LocalPlayer.Data.PlayerName == area.NameText.Text &&
                    Helper.isJester(PlayerControl.LocalPlayer.PlayerId))
                {
                    area.NameText.Color = new Color(0.99f, 0.37f, 1f);
                }
            }
        }
        
        [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
        public static class HudUpdatePatch {

            public static void Postfix(HudManager __instance) {
                if (MeetingHud.Instance != null)
                    UpdateHUD(MeetingHud.Instance);

                if (PlayerControl.LocalPlayer != null)
                {
                    if (PlayerControl.AllPlayerControls.Count > 1 && Settings.JesterList != null && Helper.isJester(PlayerControl.LocalPlayer.PlayerId))
                        PlayerControl.LocalPlayer.nameText.Color = new Color(0.99f, 0.37f, 1f);
                }

            }
        }
    }
}