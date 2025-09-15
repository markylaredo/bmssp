namespace Bmssp.Models
{
    /// <summary>
    /// Represents a weighted edge in a graph.
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Gets the starting vertex of the edge.
        /// </summary>
        public int From { get; }
        
        /// <summary>
        /// Gets the ending vertex of the edge.
        /// </summary>
        public int To { get; }
        
        /// <summary>
        /// Gets the weight of the edge.
        /// </summary>
        public int Weight { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Edge"/> class.
        /// </summary>
        /// <param name="from">The starting vertex of the edge.</param>
        /// <param name="to">The ending vertex of the edge.</param>
        /// <param name="weight">The weight of the edge.</param>
        public Edge(int from, int to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }
}