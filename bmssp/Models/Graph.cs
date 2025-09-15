namespace Bmssp.Models
{
    /// <summary>
    /// Represents a weighted graph using adjacency list representation.
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// Gets the number of vertices in the graph.
        /// </summary>
        public int VertexCount { get; }
        
        /// <summary>
        /// Gets the adjacency list representation of the graph.
        /// </summary>
        public List<Edge>[] AdjacencyList { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Graph"/> class.
        /// </summary>
        /// <param name="vertexCount">The number of vertices in the graph.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when vertexCount is negative.</exception>
        public Graph(int vertexCount)
        {
            if (vertexCount < 0)
                throw new ArgumentOutOfRangeException(nameof(vertexCount), "Vertex count cannot be negative.");
            
            VertexCount = vertexCount;
            AdjacencyList = new List<Edge>[vertexCount];
            
            for (int i = 0; i < vertexCount; i++)
                AdjacencyList[i] = new List<Edge>();
        }

        /// <summary>
        /// Adds a weighted edge to the graph.
        /// </summary>
        /// <param name="from">The starting vertex of the edge.</param>
        /// <param name="to">The ending vertex of the edge.</param>
        /// <param name="weight">The weight of the edge.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when vertex indices are out of range.</exception>
        public void AddEdge(int from, int to, int weight)
        {
            if (from < 0 || from >= VertexCount)
                throw new ArgumentOutOfRangeException(nameof(from), $"Vertex index {from} is out of range [0, {VertexCount - 1}].");
            
            if (to < 0 || to >= VertexCount)
                throw new ArgumentOutOfRangeException(nameof(to), $"Vertex index {to} is out of range [0, {VertexCount - 1}].");
            
            AdjacencyList[from].Add(new Edge(from, to, weight));
        }
    }
}