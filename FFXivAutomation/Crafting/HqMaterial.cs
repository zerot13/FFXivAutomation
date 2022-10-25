namespace FFXivAutomation.Crafting;

public class HqMaterial
{
    public HqMaterial(int row, int count)
    {
        Row = row;
        Count = count;
    }

    public int Row { get; }
    public int Count { get; }
}
