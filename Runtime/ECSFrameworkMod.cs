using Verse;

namespace ECSFramework
{
    public class ECSFrameworkMod : Mod
    {
        public ECSFrameworkMod(ModContentPack content) : base(content)
        {
            var harmony = new HarmonyLib.Harmony("ECSFramework");
            harmony.PatchAll();
        }
    }
}