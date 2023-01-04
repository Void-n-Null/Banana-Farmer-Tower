using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using static BananaFarmer.Helper;
using MainTower = BananaFarmer.MainMod.MainTower;
using Il2Cpp;

namespace BananaFarmer.Tower.Upgrades
{
    public class ParagonUpgrade
    {
        public class Paragon : ModParagonUpgrade<MainTower>
        {
            //public override string Name => "PotassiumSupreme";
            public override string DisplayName => "Potassium Supreme";
            public override int Cost => 700000;
            public override string Description => "The embodiment of the monkey economy itself.";

            public override string Icon => "Paragon-Icon";
            public override string Portrait => "Paragon-Portrait";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                //Set Display
                towerModel.ApplyDisplay<Displays.TowerDisplays.ParagonDisplay>();

                //Remove Original Attack Model
                towerModel.RemoveBehaviors<AttackModel>();

                //Create Banana Gun
                var bananaGun = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().Duplicate();
                var bananaGunWeapon = bananaGun.weapons[0];
                var bananaGunProj = bananaGun.weapons[0].projectile;

                //Edit Banana Gun Attack Model
                bananaGun.RemoveBehavior<TargetTrackModel>();
                bananaGun.AddBehavior(new TargetFirstModel("TargetFirstModel_", true, false));
                bananaGun.AddBehavior(new TargetStrongModel("TargetStrongModel_", true, false));
                bananaGun.AddBehavior(new TargetCloseModel("TargetCloseModel_", true, false));
                bananaGun.AddBehavior(new TargetLastModel("TargetLastModel_", true, false));
                bananaGun.AddBehavior(new RotateToTargetModel("RotateToTargetModel_", true, true, true, 0, true, true));
                bananaGun.attackThroughWalls = true;

                //Edit Banana Gun Weapon Model
                bananaGunWeapon.fireWithoutTarget = false;
                bananaGunWeapon.rate = .175f;
                bananaGunProj.RemoveBehavior<DamageModel>();
                bananaGunProj.RemoveBehavior<SetSpriteFromPierceModel>();
                bananaGunProj.AddBehavior(new DamageModel("DamageModel_", 6, 10, true, true, true, BloonProperties.None,BloonProperties.None));
                bananaGunProj.AddBehavior(new WindModel("WindModel_", 0, 200, 100, true, null, 0));
                bananaGunProj.GetBehavior<ArriveAtTargetModel>().timeToTake = 0.075f;
                bananaGunProj.pierce = 9;
                bananaGunProj.ApplyDisplay<Displays.ProjectileDisplays.GoldenBananaProjectileDisplay>();


                var BananaFarmAttackModel = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
                BananaFarmAttackModel.name = "BananaFarm_";
                BananaFarmAttackModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = 40;
                BananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum = 140;
                BananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum = 140;
                towerModel.range = 114;
                bananaGun.range = towerModel.range;
                towerModel.isGlobalRange = true;
                towerModel.GetBehavior<CollectCashZoneModel>().useTowerRange = false;
                towerModel.GetBehavior<CollectCashZoneModel>().attractRange = float.MaxValue;
                towerModel.AddBehavior(bananaGun);
                towerModel.AddBehavior(BananaFarmAttackModel);
                towerModel.AddBehavior(new MonkeyCityIncomeSupportModel("_MonkeyCityIncomeSupport", true, 3.1f, null, "MonkeyCityBuff", "BuffIconVillagexx4"));
                towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                UpdateAttackModelRange(towerModel);
            }
        }
    }
}