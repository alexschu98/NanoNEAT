namespace NanoNEAT;

public class Genotype
{
    public Genotype(List<Node> nodeGenes, List<Connection> connectionGenes)
    {
        NodeGenes = nodeGenes;
        ConnectionGenes = connectionGenes;
    }

    public List<Node> NodeGenes;
    public List<Connection> ConnectionGenes;

    public float[] FeedForward(float[] inputs)
    {
        // Order the nodes in Layers and skip input layer because it does not require any calculations
        var layers = NodeGenes
            .Where(n => n.Active)
            .GroupBy(n => n.Layer)
            .OrderBy(g => g.Key)
            .Select(g => g.Select(n => n).ToList())
            .Skip(1)
            .ToList();

        foreach (var layer in layers)
        {
            foreach (var node in layer)
            {
                // get all relevant ingoing connections for this node
                var connections = ConnectionGenes
                    .Where(con => con.Active)
                    .Where(con => con.ToNode == node.Index)
                    .ToList();

                var inputSum = connections.Sum(con =>
                    NodeGenes.Single(n => n.Index == con.FromNode).OutputValue * con.Weight);
                node.InputValue = node.Bias + inputSum;
            }
        }

        return layers.Last().Select(n => n.OutputValue).ToArray();
    }
}