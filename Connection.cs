namespace NanoNEAT;

public class Connection
{
    public int FromNode { get; set; }
    public int ToNode { get; set; }
    public float Weight { get; set; }
    public bool Active { get; set; }
}