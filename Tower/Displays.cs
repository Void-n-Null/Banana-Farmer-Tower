using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using UnityEngine;
using static BananaFarmer.Helper;
using MainTower = BananaFarmer.MainMod.MainTower;

//DISPLAYSSSSSSs

namespace BananaFarmer.Tower
{
    public class Displays
    {
        public class ProjectileDisplays
        {
            public class BaseBananaProjectileDisplay : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "BananaPeel");
                }
            }

            public class RottenBananaProjectileDisplay : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "RottenBananaPeel");
                }
            }

            public class GoldenBananaProjectileDisplay : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "GoldenBananaPeel");
                }
            }
        }

        public class TowerDisplays
        {

            public class BaseFarmerDisplay : ModDisplay
            {
                public override string BaseDisplay => BananaFarmerDisplay;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {

                }
            }

            public class ParagonDisplay : ModTowerDisplay<MainTower>
            {
                public override string BaseDisplay => Game.instance.model.GetTowerFromId("SuperMonkey-130").display.guidRef;

                public override bool UseForTower(int[] paratier) => IsParagon(paratier);

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (Renderer genericRenderer in node.genericRenderers)
                        genericRenderer.material.mainTexture = GetTexture("Paragon_Texture");
                }
            }

            public  class BananaGunDisplay : ModDisplay
            {
                public override string BaseDisplay => BananaFarmerDisplay;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    UpdateHatTexture(node, GetTexture("RedHat_Texture"));
                }
            }

            public  class SlipperyBananaDisplay : ModDisplay
            {
                public override string BaseDisplay => BananaFarmerDisplay;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    UpdateHatTexture(node, GetTexture("RedHatYellowRim_Texture"));
                }
            }

            public  class BananaDealerDisplay : ModDisplay
            {
                public override string BaseDisplay => BananaFarmerDisplay;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    UpdateHatTexture(node, GetTexture("BananaDealerHat_Texture"));

                }
            }

            public  class BananaBankerDisplay : ModDisplay
            {
                public override string BaseDisplay => BananaFarmerDisplay;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (Renderer genericRenderer in node.genericRenderers)
                        genericRenderer.material.mainTexture = GetTexture("Suit_Texture");
                    UpdateHatTexture(node, GetTexture("BananaBankerHat_Texture"));
                }
            }

            public  class BananaStonksDisplay : ModDisplay
            {
                public override string BaseDisplay => BananaFarmerDisplay;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (Renderer genericRenderer in node.genericRenderers)
                        genericRenderer.material.mainTexture = GetTexture("Suit_Texture");
                    UpdateHatTexture(node, GetTexture("BananaStonksHat_Texture"));
                }
            }

            public  class MonkeyWallStreetDisplay : ModDisplay
            {
                public override string BaseDisplay => BananaFarmerDisplay;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (var genericRenderer in node.genericRenderers)
                        genericRenderer.material.mainTexture = GetTexture("Suit_Texture");
                    UpdateHatTexture(node, GetTexture("MonkeyWallStreetHat_Texture"));
                }
            }
        }
    }
}
