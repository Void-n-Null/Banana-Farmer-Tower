using System.IO;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Extensions;
using UnityEngine;

namespace BananaFarmer
{
    public static class Helper  
    {
        public static TowerModel BaseBananaFarmer => Game.instance.model.GetTowerFromId("BananaFarmer");
        public static string BananaFarmerDisplay => BaseBananaFarmer.display.guidRef;

        public static void UpdateHatTexture(UnityDisplayNode node, Texture tex)
        {
            node.genericRenderers[0].materials[1].SetTexture("_MainTex", tex);
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

        // public static UnityDisplayNode GetNode(string guid)
        // {
        //     UnityDisplayNode udn = null;
        //     Game.instance.GetDisplayFactory().FindAndSetupPrototypeAsync(guid, (Action<UnityDisplayNode>)delegate (UnityDisplayNode node)
        //     {
        //         udn = node;
        //     });
        //     return udn;
        // }

        public static Texture2D Duplicate(this Texture texture, Rect? proj = null)
        {
                if (proj == null) proj = new Rect(0, 0, texture.width, texture.height);
                var rect = (Rect)proj;
                texture.filterMode = FilterMode.Point;
                RenderTexture rt = RenderTexture.GetTemporary(texture.width, texture.height);
                rt.filterMode = FilterMode.Point;
                RenderTexture.active = rt;
                Graphics.Blit(texture, rt);
                Texture2D texture2 = new Texture2D((int)rect.width, (int)rect.height);
                texture2.ReadPixels(new Rect(rect.x, texture.height - rect.height - rect.y, rect.width, rect.height), 0, 0);
                texture2.Apply();
                RenderTexture.active = null;
                return texture2;
        }
        public static void CustomSaveToPng(string Path, Texture tex)
        {
            Texture2D texture = tex.Duplicate();
            File.WriteAllBytes($"{Path}.png", ImageConversion.EncodeToPNG(texture));
        }
    }
}

