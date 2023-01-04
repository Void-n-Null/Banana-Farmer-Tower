using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MainTower = BananaFarmer.MainMod.MainTower;
using Il2Cpp;

namespace BananaFarmer.Tower.Upgrades
{


    public static class MiddlePathUpgrades
    {
        public class Tier1 : ModUpgrade<MainTower>
        {
            public override int Path => MIDDLE;
            public override int Tier => 1;
            public override string Name => "BananaGun";
            public override string DisplayName => "Banana Gun";
            public override int Cost => 350;
            public override string Description => "Enables farmer to shoot slippery banana peels.";
            public override string Icon => "BananaGun-Icon";
            public override string Portrait => "RedHat-Portrait";
            public override void ApplyUpgrade(TowerModel towerModel)
            {

                towerModel.ApplyDisplay<Displays.TowerDisplays.BananaGunDisplay>();
                var BananaGun = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().Duplicate();
                WeaponModel GunWeaponModel = BananaGun.weapons[0];
                ProjectileModel projectileModel = BananaGun.weapons[0].projectile;
                BananaGun.range = towerModel.range;
                BananaGun.RemoveBehavior<TargetTrackModel>();
                BananaGun.AddBehavior(new TargetFirstModel("TargetFirstModel_", true, false));
                BananaGun.AddBehavior(new TargetStrongModel("TargetStrongModel_", true, false));
                BananaGun.AddBehavior(new TargetCloseModel("TargetCloseModel_", true, false));
                BananaGun.AddBehavior(new TargetLastModel("TargetLastModel_", true, false));
                BananaGun.AddBehavior(new RotateToTargetModel("RotateToTargetModel_", true, true, true, 0, true, true));
                GunWeaponModel.fireWithoutTarget = false;
                projectileModel.RemoveBehavior<DamageModel>();
                projectileModel.AddBehavior(new WindModel("WindModel_", 0, 200, 100, false, null, 0,null,1));
                projectileModel.RemoveBehavior<SetSpriteFromPierceModel>();
                projectileModel.pierce = 1;
                projectileModel.GetBehavior<ArriveAtTargetModel>().timeToTake = .45f;
                projectileModel.ApplyDisplay<Displays.ProjectileDisplays.BaseBananaProjectileDisplay>();
                towerModel.AddBehavior(BananaGun);
            }




        }
        public class Tier2 : ModUpgrade<MainTower>
        {
            public override int Path => MIDDLE;
            public override int Tier => 2;
            public override string Name => "SubBananaGun";
            public override string DisplayName => "Sub Banana Gun";
            public override int Cost => 650;
            public override string Description => "Doubles banana fire speed.";
            public override string Icon => "BananaPeel";
            public override string Portrait => "RedHat-Portrait";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<Displays.TowerDisplays.BananaGunDisplay>();
                towerModel.GetAttackModel().weapons[0].rate = 0.875f;
                towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<ArriveAtTargetModel>().timeToTake = .25f;
            }
        }
        public class Tier3 : ModUpgrade<MainTower>
        {
            public override int Path => MIDDLE;
            public override int Tier => 3;
            public override string Name => "RottenBananas";
            public override string DisplayName => "Rotten Bananas";
            public override int Cost => 1200;
            public override string Description => "Bananas now do damage on hit.";
            public override string Icon => "RottenBananaPeel";
            public override string Portrait => "RedHat-Portrait";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<Displays.TowerDisplays.BananaGunDisplay>();
                towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<Displays.ProjectileDisplays.RottenBananaProjectileDisplay>();
                towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModel("DamageModel_", 2, 3, true, true, true, BloonProperties.Frozen |
                    BloonProperties.Lead,BloonProperties.Frozen | BloonProperties.Lead));
            }


        }
        public class Tier4 : ModUpgrade<MainTower>
        {
            public override int Path => MIDDLE;
            public override int Tier => 4;
            public override string Name => "PotassiumSpeed";
            public override string DisplayName => "Potassium Speed";
            public override int Cost => 6500;
            public override string Description => "Doubles banana fire speed and makes Bloons travel backwards 2/3 as fast.";
            public override string Icon => "BananaSight-Icon";
            public override string Portrait => "RedHat-Portrait";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<Displays.TowerDisplays.BananaGunDisplay>();
                towerModel.GetAttackModel().weapons[0].rate = 1.75f / 4f;
                towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<ArriveAtTargetModel>().timeToTake = .15f;
                towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().speedMultiplier = 0.75f;
            }
        }
        public class Tier5 : ModUpgrade<MainTower>
        {
            public override int Path => MIDDLE;
            public override int Tier => 5;
            public override string Name => "SuperSlipperyBananas";
            public override string DisplayName => "Super Slippery Bananas";
            public override int Cost => 45000;
            public override string Description => "Bananas can now affect moabs!";
            public override string Icon => "SlipperyBananaPeel";
            public override string Portrait => "RedHatYellowRim-Portrait";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<Displays.TowerDisplays.SlipperyBananaDisplay>();
                towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<ArriveAtTargetModel>().timeToTake = .13f;
                towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().affectMoab = true;
            }
        }
    }
}