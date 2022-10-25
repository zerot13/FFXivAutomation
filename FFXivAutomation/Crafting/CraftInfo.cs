using System.Collections.Generic;

namespace FFXivAutomation.Crafting
{
    public static class CraftInfoList
    {
        public static List<CraftInfo> GetCraftList()
        {
            return new List<CraftInfo>()
            {
                //new CraftInfo(CraftingClass.Culinarian, CraftType.Gelatin, 98, KeyboardInput.ScanCodeShort.KEY_4, null),
                //new CraftInfo(CraftingClass.Culinarian, CraftType.PalmSugar, 99, KeyboardInput.ScanCodeShort.KEY_5, null),
                new CraftInfo(CraftingClass.Culinarian, CraftType.RSykonBav, 30, KeyboardInput.ScanCodeShort.KEY_6,
                    new List<HqMaterial> { new HqMaterial(2,1), new HqMaterial(4,3) }),
                //new CraftInfo(CraftingClass.Alchemist, CraftType.CommandingDraught, 36, KeyboardInput.ScanCodeShort.KEY_1, null),
                //new CraftInfo(CraftingClass.Culinarian, CraftType.GoldenHoney, 33, KeyboardInput.ScanCodeShort.KEY_1, null),
                //new CraftInfo(CraftingClass.Culinarian, CraftType.UplandWheatFlour, 7422, KeyboardInput.ScanCodeShort.KEY_2, null),
                //new CraftInfo(CraftingClass.Culinarian, CraftType.GiantPopoto, 36, KeyboardInput.ScanCodeShort.KEY_3,
                //    new List<HqMaterial> { new HqMaterial(2,1), new HqMaterial(3,2) }),
            };
        }
    }

    public class CraftInfo
    {
        public CraftInfo(CraftingClass crafter, CraftType craft, int runs, KeyboardInput.ScanCodeShort key, List<HqMaterial> hqMaterials)
        {
            CraftClass = crafter;
            Craft = craft;
            Runs = runs;
            CraftKey = key;
            HqMaterials = hqMaterials;
        }

        public CraftingClass CraftClass { get; set; }
        public CraftType Craft { get; }
        public int Runs { get; }
        public KeyboardInput.ScanCodeShort CraftKey { get; }
        public List<HqMaterial> HqMaterials { get; }
    }
}
