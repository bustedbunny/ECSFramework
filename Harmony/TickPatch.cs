using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using Mono.Unix.Native;
using Verse;

namespace ECSFramework.Harmony
{
    [HarmonyPatch]
    public class TickPatch
    {
        [HarmonyTargetMethod]
        public static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Method(typeof(ThingWithComps), nameof(ThingWithComps.Tick)) ??
                         throw new NullReferenceException("Kek");
            yield return AccessTools.Method(typeof(ThingWithComps), nameof(ThingWithComps.TickRare)) ??
                         throw new NullReferenceException("Kek");
            yield return AccessTools.Method(typeof(ThingWithComps), nameof(ThingWithComps.TickLong)) ??
                         throw new NullReferenceException("Kek");
        }

        public static bool Prefix() { return false; }

        // public static IEnumerable<CodeInstruction> Transpiler() { yield return new CodeInstruction(OpCodes.Ret); }
    }
}