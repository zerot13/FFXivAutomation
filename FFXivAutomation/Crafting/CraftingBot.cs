using System;
using System.Collections.Generic;
using System.Threading;

namespace FFXivAutomation.Crafting;

public class CraftingBot
{
    public CraftingBot()
    {
        _random = new Random();
        _craftSteps = new CraftSteps();
    }
    
    public void Run()
    {
        Thread.Sleep(5000);
        SwitchToMacroHotbar();
        foreach (CraftInfo craftInfo in CraftInfoList.GetCraftList())
        {
            int index = 0;
            SetUpCraft(craftInfo);
            while (index < craftInfo.Runs)
            {
                Thread.Sleep(3000);
                MoveToSynthButton();
                Console.WriteLine("Crafting " + craftInfo.Craft + ": " + craftInfo.Runs);
                RunCraft(craftInfo.Craft);
                Console.WriteLine("Finished " + (index + 1));
                index++;
            }
        }
    }

    private void SetUpCraft(CraftInfo craftInfo)
    {
        CraftingClasses.SwitchClass(craftInfo.CraftClass);
        SwitchToMacroHotbar();
        SwitchToCraftHotbar();
        KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.ESCAPE, 100);
        Thread.Sleep(2000);
        KeyboardInput.PressKey(craftInfo.CraftKey, 100);
        Thread.Sleep(1000);
        SwitchToMacroHotbar();
        AddHqMaterials(craftInfo.HqMaterials);
    }

    private void AddHqMaterials(List<HqMaterial> hqMaterials)
    {
        if(hqMaterials == null || hqMaterials.Count == 0)
        {
            return;
        }

        foreach(HqMaterial material in hqMaterials)
        {
            MouseInput.MoveMouseAbsolute(745, 375 + (46 * (material.Row - 1)));
            Thread.Sleep(1000);
            for(int clicks = 0; clicks < material.Count; clicks++)
            {
                MouseInput.ClickLeftMouseButton(0, 0);
                Thread.Sleep(1000);
            }
        }
    }

    private void MoveToSynthButton()
    {
        MouseInput.MoveMouseAbsolute(870, 680);
        Thread.Sleep(1000);
    }

    private void RunCraft(CraftType craft)
    {
        MouseInput.ClickLeftMouseButton(0, 0);
        Thread.Sleep(2000);
        foreach (CraftStep step in _craftSteps.Steps[craft])
        {
            KeyboardInput.PressKey(step.Key, 100);
            Thread.Sleep(step.Delay);
        }
    }

    private void SwitchToMacroHotbar()
    {
        KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_Quote, 100);
        Thread.Sleep(1000);
    }

    private void SwitchToCraftHotbar()
    {
        KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_DASH, 100);
        Thread.Sleep(1000);
    }

    private Random _random;
    private CraftSteps _craftSteps;
}
