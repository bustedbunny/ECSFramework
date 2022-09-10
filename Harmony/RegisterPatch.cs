using HarmonyLib;
using Verse;

namespace ECSFramework.Harmony
{
    [HarmonyPatch(typeof(ThingWithComps), nameof(ThingWithComps.InitializeComps))]
    public class RegisterPatch
    {
        public static void Postfix(ThingWithComps __instance)
        {
            var bookkeeper = BookKeeper.current;
            var comps = __instance.AllComps;
            foreach (var thingComp in comps)
            {
                bookkeeper.RegisterComp(thingComp);
            }
        }
    }
}