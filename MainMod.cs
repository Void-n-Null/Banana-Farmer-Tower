#region imports

using System;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using BananaFarmer;
using BananaFarmer.Tower;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using ModHelperData = BananaFarmer.ModHelperData;
using Il2CppAssets.Scripts.Models.TowerSets;

#endregion

/*
Credits
Kosmic#4494 for some great sprite work
1330 Studios discord for help with recommending and explaining certain behaviors (https://discord.gg/BxauzvUUjE)
BTD6 Mods & Discussion discord for great and efficient problem solving and debugging (https://discord.gg/dV682SPepR)
*/

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonColor(255,255,255,255)]
[assembly: MelonAuthorColor(255,0,0,139)]
[assembly: MelonInfo(typeof(MainMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]

namespace BananaFarmer
{

    public class MainMod : BloonsTD6Mod
    {
        public class MainTower : ModTower
        {
            public override string Name => "Banana Farmer";
            public override TowerSet TowerSet => TowerSet.Support;
            public override string BaseTower => TowerType.DartMonkey;
            public override int Cost => 1975;
            public override string Description => "Collects bananas from Banana Farms.";
            public override string DisplayName => "Banana Farmer";
            public override int TopPathUpgrades =>5;
            public override int MiddlePathUpgrades =>5;
            public override int BottomPathUpgrades =>5;
            public override ParagonMode ParagonMode => ParagonMode.Base555;
            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<Displays.TowerDisplays.BaseFarmerDisplay>();
                towerModel.RemoveBehavior<AttackModel>();
                towerModel.GetBehavior<DisplayModel>().display = towerModel.display;
                towerModel.range = 45;
                towerModel.AddBehavior(new CollectCashZoneModel("CollectCashZoneModel_",45,19,3,"",true,true,true,true));
            }

            public override bool IsValidCrosspath(int[] tiers) => ModHelper.HasMod("Ultimate Crosspathing") ? true : base.IsValidCrosspath(tiers);
        }
    }
}
