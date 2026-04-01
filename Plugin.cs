using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnlimitedJetpack.Patches;

namespace UnlimitedJetpack
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class JetpackFuelPatchBase : BaseUnityPlugin
    {
        private const string modGUID = "PixelIndieDev_UnlimitedJetpack";
        private const string modName = "Unlimited Jetpack";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        private static JetpackFuelPatchBase instance;

        internal ManualLogSource logSource;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            logSource = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            harmony.PatchAll(typeof(JetpackFuelPatchBase));
            harmony.PatchAll(typeof(JetpackUnlimitedFuelPatch));

            logSource.LogInfo(modName + ": patch applied successfully");
        }
    }
}
