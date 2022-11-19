namespace NanoNEAT;

public class Node
{
    public int Index { get; set; }
    public int Layer { get; set; }
    public float Bias { get; set; }
    public float InputValue { get; set; }
    public bool Active { get; set; } = true;
    public Func<float, float> Squash { get; set; }

    public float OutputValue => Squash(InputValue);
}