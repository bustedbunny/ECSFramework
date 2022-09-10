using HarmonyLib;
using Mono.Unix.Native;
using Verse;

namespace ECSFramework.Harmony
{
    [HarmonyPatch(typeof(ThingWithComps), nameof(ThingWithComps.Destroy))]
    public class UnregisterPatch
    {
        public static void Postfix(ThingWithComps __instance)
        {
            var bookkeeper = BookKeeper.current;
            var comps = __instance.AllComps;
            foreach (var thingComp in comps)
            {
                bookkeeper.UnregisterComp(thingComp);
            }
        }
    }
}