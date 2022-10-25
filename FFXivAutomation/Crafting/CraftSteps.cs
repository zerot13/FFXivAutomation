using System.Collections.Generic;

namespace FFXivAutomation.Crafting;

public class CraftSteps
{
    public CraftSteps()
    {
        Steps = new Dictionary<CraftType, List<CraftStep>>
        {
            { CraftType.GiantPopoto, new List<CraftStep> { new CraftStep(38000, KeyboardInput.ScanCodeShort.KEY_1) } },
            { CraftType.PerillaOil, new List<CraftStep> { new CraftStep(45000, KeyboardInput.ScanCodeShort.KEY_2) } },
            { CraftType.ScallopSalad, new List<CraftStep> { 
                new CraftStep(40000, KeyboardInput.ScanCodeShort.KEY_3),
                new CraftStep(12000, KeyboardInput.ScanCodeShort.KEY_4)
                } },
            { CraftType.Gelatin, new List<CraftStep> { new CraftStep(8000, KeyboardInput.ScanCodeShort.KEY_5) } },
            { CraftType.PalmSugar, new List<CraftStep> { new CraftStep(45000, KeyboardInput.ScanCodeShort.KEY_2) } },
            { CraftType.RSykonBav, new List<CraftStep> {
                new CraftStep(45000, KeyboardInput.ScanCodeShort.KEY_2),
                new CraftStep(17000, KeyboardInput.ScanCodeShort.KEY_6)
                } },
            { CraftType.CommandingDraught, new List<CraftStep> {
                new CraftStep(45000, KeyboardInput.ScanCodeShort.KEY_1),
                new CraftStep(17000, KeyboardInput.ScanCodeShort.KEY_2)
                } },
            { CraftType.GoldenHoney, new List<CraftStep> { new CraftStep(8000, KeyboardInput.ScanCodeShort.KEY_5) } },
            { CraftType.UplandWheatFlour, new List<CraftStep> { new CraftStep(8000, KeyboardInput.ScanCodeShort.KEY_5) } }
        };
    }
    public Dictionary<CraftType, List<CraftStep>> Steps;
}

public class CraftStep
{
    public CraftStep(int delay, KeyboardInput.ScanCodeShort key)
    {
        Delay = delay;
        Key = key;
    }
    public int Delay { get; set; }
    public KeyboardInput.ScanCodeShort Key { get; set; }
}
