using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnlimitedJetpack.Patches;

namespace UnlimitedJetpack
{
    [BepInPlugin(ModInfo.modGUID, ModInfo.modName, ModInfo.modVersion)]
    public class JetpackFuelPatchBase : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(ModInfo.modGUID);
        private static JetpackFuelPatchBase instance;

        internal ManualLogSource logSource;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            logSource = BepInEx.Logging.Logger.CreateLogSource(ModInfo.modGUID);

            harmony.PatchAll(typeof(JetpackFuelPatchBase));
            harmony.PatchAll(typeof(JetpackUnlimitedFuelPatch));
            harmony.PatchAll(typeof(NetworkPatch));

            logSource.LogInfo(ModInfo.modName + " (version - " + ModInfo.modVersion + ")" + ": patches applied successfully");
        }
    }
}
