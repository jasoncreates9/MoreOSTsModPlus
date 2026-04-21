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
    internal static class enemiesreturnswrapper
    {
        private static OriginalSoundTrack ostplugin;

        private static bool? _Present = null;

        public static bool Present
        {
            get
            {
                if (_Present == null)
                {
                    _Present = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.Viliger.EnemiesReturns");
                }
                return (bool) _Present;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static void Init(OriginalSoundTrack instance) 
        {
            Debug.Log("hey i loaded correctly");

            ostplugin = instance;

            Harmony weareinharmony = new Harmony("com.jasoncreatesblep.moreostsmodplus");
            weareinharmony.PatchAll(typeof(enemiesreturnswrapper));
        }

        [HarmonyPatch(typeof(EnemiesReturns.ModdedEntityStates.Judgement.Arraign.Phase1.Spawn), "OnEnter")]
        [HarmonyPostfix]
        static void PatchOnEnter()
        {
                Debug.Log("====================== JUDGEMENT BOSS FIGHT START ======================");
                ostplugin.bossActive = false;
                ostplugin.afterBossPhase = true;
                ostplugin.PickOutMusic(false);

        }

        [HarmonyPatch(typeof(EnemiesReturns.ModdedEntityStates.Judgement.WaveInteractable.StartingUp), "OnEnter")]
        [HarmonyPostfix]
        static void PatchOnEnter2()
        {
            if (!ostplugin.bossActive)
            {
                Debug.Log("====================== JUDGEMENT TRIAl START ======================");
                ostplugin.bossActive = true;
                ostplugin.PickOutMusic(true);
            }

        }



    }
}
