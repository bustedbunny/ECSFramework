using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Verse;

namespace ECSFramework
{
    public class ECSMod : Mod
    {
        public unsafe ECSMod(ModContentPack content) : base(content)
        {
            var list = new List<int>(500);
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = i;
            }
        }
    }
}