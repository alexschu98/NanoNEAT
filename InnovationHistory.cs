namespace NanoNEAT;

public struct Innovation
{
    public int FromNode;
    public int ToNode;
    public int InnovationId;
    public bool NewConnection;
    public int? NodeId;
}

public static class InnovationHistory
{
    public static List<Innovation> History { get; set; } = new List<Innovation>();
    public static int InnovationId { get; private set; } = 0;
    public static int NodeId { get; private set; }

    public static void SetNodeId(int nodeId)
    {
        NodeId = Math.Max(NodeId, nodeId);
    }

    public static Innovation GetInnovation(int fromNode, int toNode, bool newConnection = true)
    {
        foreach (var innovation in History.Where(innovation =>
                     innovation.NewConnection == newConnection &&
                     innovation.FromNode == fromNode &&
                     innovation.ToNode == toNode))
        {
            return innovation;
        }

        return CreateInnovation(fromNode, toNode, newConnection);
    }

    private static Innovation CreateInnovation(int fromNode, int toNode, bool newConnection)
    {
        Innovation innovation;
        if (newConnection)
        {
            innovation = new Innovation
            {
                InnovationId = InnovationId,
                FromNode = fromNode,
                ToNode = toNode,
                NewConnection = newConnection,
                NodeId = null
            };
        }
        else
        {
            innovation = new Innovation
            {
                InnovationId = InnovationId,
                FromNode = fromNode,
                ToNode = toNode,
                NewConnection = newConnection,
                NodeId = NodeId
            };
            NodeId++;
        }

        History.Add(innovation);
        InnovationId++;

        return innovation;
    }
}