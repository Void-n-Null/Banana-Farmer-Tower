using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using UnityEngine;
using static BananaFarmer.Helper;
using MainTower = BananaFarmer.MainMod.MainTower;

namespace BananaFarmer.Tower.Upgrades
{
    public class TopPathUpgrades
    {
        public class Tier1 : ModUpgrade<MainTower>
        {
            public override int Path => TOP;
            public override int Tier => 1;
            public override string Name => "10 ft Pitch Fork";
            public override string DisplayName => "10 ft Pitch Fork";
            public override int Cost => 350;
            public override string Description => "Increase Farmer's range slightly.";
            public override string Icon => "10FtPitchfork-Icon";
            public override string Portrait => "BananaFarmer-Portrait";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.range = 51f;
                UpdateAttackModelRange(towerModel);
            }
        }

        public class Tier2 : ModUpgrade<MainTower>
        {
            public override int Path => TOP;
            public override int Tier => 2;
            public override string Name => "BananOcculars";
            public override string DisplayName => "Banan-Occulars";
            public override int Cost => 600;
            public override string Description => "Increase Farmer's range greatly. Allows banana gun to see camo.";
            public override string Icon => "BananOculars-Icon";
            public override string Portrait => "BananaFarmer-Portrait";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.range = 67f;
                towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
                UpdateAttackModelRange(towerModel);
            }
        }

        public class Tier3 : ModUpgrade<MainTower>
        {
            public override int Path => TOP;
            public override int Tier => 3;
            public override string Name => "BananaPhone";
            public override string DisplayName => "Banana Phone";
            public override int Cost => 1500;
            public override string Description => "Increase farmers range. Allows banana gun to shoot over obstacles.";
            public override string Icon => "BananPhone-Icon";
            public override string Portrait => "BananaFarmer-Portrait";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                if (towerModel.HasBehavior<AttackModel>())
                {
                    towerModel.GetAttackModel().attackThroughWalls = true;
                }
                towerModel.range = 87;
                UpdateAttackModelRange(towerModel);
            }
        }

        public class Tier4 : ModUpgrade<MainTower>
        {
            public override int Path => TOP;
            public override int Tier => 4;
            public override string Name => "CyborgFarmer";
            public override string DisplayName => "Cyborg Farmer";
            public override int Cost => 4000;
            public override string Description => "Partially robotic farmer. Has even more range.";
            public override string Icon => "CyborgFarmer-Icon";
            public override string Portrait => "CyborgFarmer-Icon";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<CyborgFarmerDisplay>();
                towerModel.range = 104;
                UpdateAttackModelRange(towerModel);
            }
            public class CyborgFarmerDisplay : ModDisplay
            {
                public override string BaseDisplay => BananaFarmerDisplay;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (Renderer genericRenderer in node.genericRenderers)
                        genericRenderer.material.mainTexture = GetTexture("CyborgFarmer_Texture");
                }
            }
        }

        public class Tier5 : ModUpgrade<MainTower>
        {
            public override int Path => TOP;
            public override int Tier => 5;
            public override string Name => "Robo Farmer";
            public override string DisplayName => "Robo Farmer";
            public override int Cost => 22000;
            public override string Description => "Fully mechanical farmer. Has infinite banana collection range (and no arms).";
            public override string Icon => "RoboFarmer-Portrait";
            public override string Portrait => "RoboFarmer-Portrait";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<RoboFarmerDisplay>();
                towerModel.GetBehavior<CollectCashZoneModel>().useTowerRange = false;
                towerModel.GetBehavior<CollectCashZoneModel>().attractRange = float.MaxValue;
                UpdateAttackModelRange(towerModel);
            }
            public class RoboFarmerDisplay : ModDisplay
            {
                public override string BaseDisplay => Game.instance.model.GetTowerFromId("SuperMonkey-130").display.guidRef;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (Renderer genericRenderer in node.genericRenderers)
                        genericRenderer.material.mainTexture = GetTexture("RoboFarmer_Texture");
                }
            }
        }
    }
}
