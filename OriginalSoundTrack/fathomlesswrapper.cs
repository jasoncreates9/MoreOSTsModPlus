using EntityStates.AffixVoid;
using EntityStates.Huntress.HuntressWeapon;
using HarmonyLib;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace OriginalSoundTrack
{
    internal static class fathomlesswrapper
    {
        private static OriginalSoundTrack ostpluginfathomless;

        private static bool? _Present2 = null;

        public static bool Present2
        {
            get
            {
                if (_Present2 == null)
                {
                    _Present2 = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("Nuxlar.FathomlessVoidling");
                }
                return (bool)_Present2;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static void Init2(OriginalSoundTrack instance2)
        {
            Debug.Log("hey i loaded correctly as well uwu");

            ostpluginfathomless = instance2;

            Harmony weareinharmony2 = new Harmony("com.jasoncreatesblep.moreostsmodplus");
            weareinharmony2.PatchAll(typeof(fathomlesswrapper));
        }

        [HarmonyPatch(typeof(FathomlessVoidling.EntityStates.BetterSpawnState), "OnEnter")]
        [HarmonyPostfix]
        static void PatchOnEnter()
        {
            Debug.Log("====================== FATHOMLESS VOIDLING BOSS START ======================");
            ostpluginfathomless.extratracksfrfr = false;
            ostpluginfathomless.bossActive = true;
            ostpluginfathomless.afterBossPhase = false;
            ostpluginfathomless.hasshuffled = false;
            ostpluginfathomless.listtracker = 0;
            ostpluginfathomless.PickOutMusic(true);

        }
    }
}
