using System.Threading;

namespace FFXivAutomation.Crafting
{
    public class CraftingClasses
    {
        public static void SwitchClass(CraftingClass crafter)
        {
            KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.ESCAPE, 100);
            Thread.Sleep(2000);
            KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.SUBTRACT, 100);
            Thread.Sleep(1000);
            PressClassButton(crafter);
            Thread.Sleep(2000);
        }

        private static void PressClassButton(CraftingClass crafter)
        {
            switch (crafter)
            {
                case CraftingClass.Carpenter:
                    KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_1, 100);
                    break;
                case CraftingClass.Blacksmith:
                    KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_2, 100);
                    break;
                case CraftingClass.Armorer:
                    KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_3, 100);
                    break;
                case CraftingClass.Goldsmith:
                    KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_4, 100);
                    break;
                case CraftingClass.Leatherworker:
                    KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_5, 100);
                    break;
                case CraftingClass.Weaver:
                    KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_6, 100);
                    break;
                case CraftingClass.Alchemist:
                    KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_7, 100);
                    break;
                case CraftingClass.Culinarian:
                    KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_8, 100);
                    break;
            }
        }
    }

    public enum CraftingClass
    {
        Carpenter,
        Blacksmith,
        Armorer,
        Goldsmith,
        Leatherworker,
        Weaver,
        Alchemist,
        Culinarian
    }
}
