using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Hazel;
using UnhollowerBaseLib;
using static BetterAU.BetterAU.CustomRPC;

namespace BetterAU.patches
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.RpcSetInfected))]
    internal class SetInfectedPatch
    {
        public static void Prefix([HarmonyArgument(0)] Il2CppReferenceArray<GameData.PlayerInfo> infected)
        {
            var players = PlayerControl.AllPlayerControls.ToArray().ToList();
            Helper.clearRoles();

            // Jester
            if (players.Count > 0 && BetterAU.NumberOfJesters.GetValue() > 0)
            {
                CLog.Info("Jester Value Found");
                var messageWriter =
                    AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte) SetJester,
                        SendOption.None, -1);

                var selectedPlayers = new List<byte>();

                CLog.Info("Preparing to set Jester Roles");
                for (var i = 0; i < BetterAU.NumberOfJesters.GetValue(); i++)
                {
                    List<PlayerControl> crewmates = players.FindAll(x => !x.infectedSet).ToArray().ToList();

                    foreach (var t in crewmates)
                        CLog.Info("Crewmate: " + t.name);

                    if (crewmates.Count > 0)
                    {
                        Random random = new Random();
                        PlayerControl selectedPlayer = crewmates[random.Next(0, crewmates.Count)];
                        Settings.JesterList.Add(selectedPlayer);
                        players.Remove(selectedPlayer);
                        selectedPlayers.Add(selectedPlayer.PlayerId);
                        CLog.Info("Jester: " + selectedPlayer.name);
                    }
                }
                
                messageWriter.WriteBytesAndSize(selectedPlayers.ToArray());
                AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
                CLog.Info("Jester Roles Set!");
            }
        }
    }
}