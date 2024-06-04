using System.IO;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Extensions;
using UnityEngine;

namespace VoidBananaFarmer
{
    public static class Helper  
    {
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        public static TowerModel BaseBananaFarmer => Game.instance.model.GetTowerFromId("BananaFarmer");
        public static string BananaFarmerDisplay => BaseBananaFarmer.display.guidRef;

        public static void UpdateHatTexture(UnityDisplayNode node, Texture tex)
        {
            node.genericRenderers[0].materials[1].SetTexture(MainTex, tex);
        }

        public static void UpdateAttackModelRange(TowerModel spainico)
        {
            if (spainico.HasBehavior<AttackModel>())
            {
                foreach (var attackModel in spainico.GetAttackModels())
                {
                    attackModel.range = spainico.range;
                }
            }
        }
    }
}

