using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;
using Essentials.CustomOptions;

namespace BetterAU
{
    [BepInPlugin(Id)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public class BetterAU : BasePlugin {
        public const string Id = "xyz.apollo30.betterau";
        
        // Jester(s)
        public static readonly CustomNumberOption
            NumberOfJesters = CustomOption.AddNumber("Jesters", 0f, 0f, 9f, 1f);

        // Leader(s)
        public static readonly CustomNumberOption
            NumberOfLeaders = CustomOption.AddNumber("Leaders", 0f, 0f, 9f, 1f);
        
        // Trolls(s)
        public static readonly CustomNumberOption
            NumberOfTrolls = CustomOption.AddNumber("Trolls", 0f, 0f, 9f, 1f);

        // Mayor(s)
        public static readonly CustomNumberOption
            NumberOfMayors = CustomOption.AddNumber("Mayors", 0f, 0f, 9f, 1f);

        public enum CustomRPC
        {
            SetJester = 43,
            SetLeader = 44,
            SetTroll = 45,
            SetMayor = 46
        }
        
        public Harmony Harmony { get; } = new Harmony(Id);
        
        public override void Load()
        {
            RegisterInIl2CppAttribute.Register();
            Harmony.PatchAll();
        }
    }
}
