using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MainTower = BananaFarmer.MainMod.MainTower;
namespace BananaFarmer.Tower.Upgrades
{
    public class BottomPathUpgrades
    {
        public class Tier1 : ModUpgrade<MainTower>
        {
            public override int Path => BOTTOM; 
            public override int Tier => 1;
            public override string Name => "HelpinHand";
            public override string DisplayName => "Helpin' Hand";
            public override int Cost => 650;
            public override string Description => "Farmer can now generate bananas.";
            public override string Icon => "HelpingHand-Icon";
            public override string Portrait => "BananaFarmer-Portrait";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var bananaFarmAttackModel = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
                bananaFarmAttackModel.name = "BananaFarm_";
                bananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum = 26;
                bananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum = 26;
                towerModel.AddBehavior(bananaFarmAttackModel);
            }


        }
        public class Tier2 : ModUpgrade<MainTower>
        {
            public override int Path => BOTTOM;
            public override int Tier => 2;
            public override string Name => "BananaDealer";
            public override string DisplayName => "Banana Dealer";
            public override int Cost => 900;
            public override string Description => "Farmer produces double the bananas.";
            public override string Icon => "BananaDealer-Icon";
            public override string Portrait => "BananaFarmer-002-Portrait";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<Displays.TowerDisplays.BananaDealerDisplay>();
                AttackModel bananaFarmAttackModel = default;
                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    if (!attackModel.name.Equals("BananaFarm_"))
                        continue;
                    bananaFarmAttackModel = attackModel;
                }
                bananaFarmAttackModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = 12;
            }



        }
        public class Tier3 : ModUpgrade<MainTower>
        {
            public override int Path => BOTTOM;
            public override int Tier => 3;
            public override string Name => "BananaBanker";
            public override string DisplayName => "Banana Banker";
            public override int Cost => 2700;
            public override string Description => "All farms and farmers in range get 15% more income.";
            public override string Icon => "BananaBanker-Icon";
            public override string Portrait => "BananaFarmer-003-Portrait";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.AddBehavior(new MonkeyCityIncomeSupportModel("_MonkeyCityIncomeSupport", true, 1.15f, null, "MonkeyCityBuff", "BuffIconVillagexx4"));
                towerModel.ApplyDisplay<Displays.TowerDisplays.BananaBankerDisplay>();
                AttackModel bananaFarmAttackModel = default;
                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    if (!attackModel.name.Equals("BananaFarm_"))
                        continue;
                    bananaFarmAttackModel = attackModel;
                        break;
                }
                bananaFarmAttackModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = 10;
                bananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum = 40;
                bananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum = 40;

            }


        }
        public class Tier4 : ModUpgrade<MainMod.MainTower>
        {
            public override int Path => BOTTOM;
            public override int Tier => 4;
            public override string Name => "BananaStockTrader";
            public override string DisplayName => "Banana Stonks";
            public override int Cost => 6700;
            public override string Description => "Increases farm and farmer income in range by 50%";
            public override string Icon => "BananaStonks-Icon";
            public override string Portrait => "BananaFarmer-004-Portrait";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.GetBehavior<MonkeyCityIncomeSupportModel>().incomeModifier = 1.5f;
                towerModel.ApplyDisplay<Displays.TowerDisplays.BananaStonksDisplay>();
                AttackModel BananaFarmAttackModel = default;
                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    if (!attackModel.name.Equals("BananaFarm_"))
                        continue;
                    BananaFarmAttackModel = attackModel;
                }
                BananaFarmAttackModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = 15;
                BananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum = 70;
                BananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum = 70;
                
            }


        }
        public class Tier5 : ModUpgrade<MainTower>
        {
            public override int Path => BOTTOM;
            public override int Tier => 5;
            public override string Name => "WolfOfMonkeyWallstreet";
            public override string DisplayName => "The Wolf of Monkey Wall Street";
            public override int Cost => 65000;
            public override string Description => "Tripples worth of bananas in range!";
            public override string Icon => "MonkeyWallStreet-Icon";
            public override string Portrait => "BananaFarmer-005-Portrait";
            public override void ApplyUpgrade(TowerModel towerModel)
            {
                towerModel.GetBehavior<MonkeyCityIncomeSupportModel>().incomeModifier = 3f;
                towerModel.ApplyDisplay<Displays.TowerDisplays.MonkeyWallStreetDisplay>();
                AttackModel BananaFarmAttackModel = default;
                foreach (var attackModel in towerModel.GetAttackModels())
                {
                    if (!attackModel.name.Equals("BananaFarm_"))
                        continue;
                    BananaFarmAttackModel = attackModel;
                }
                BananaFarmAttackModel.weapons[0].GetBehavior<EmissionsPerRoundFilterModel>().count = 30;
                BananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().maximum = 70;
                BananaFarmAttackModel.weapons[0].projectile.GetBehavior<CashModel>().minimum = 70;
                towerModel.AddBehavior(Game.instance.model.GetTowerFromId("MonkeyVillage-005").GetAttackModel().Duplicate());
            }
        }
    }
}
