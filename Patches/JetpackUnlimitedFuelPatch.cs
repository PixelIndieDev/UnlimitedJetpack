using HarmonyLib;

namespace UnlimitedJetpack.Patches
{
    [HarmonyPatch(typeof(GrabbableObject))]
    internal class JetpackUnlimitedFuelPatch
    {
        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        static void PatchJetpack(GrabbableObject __instance)
        {
            if (__instance is JetpackItem && __instance.IsOwner)
            {
                __instance.insertedBattery.charge = 1f;
            }
        }
    }
}
