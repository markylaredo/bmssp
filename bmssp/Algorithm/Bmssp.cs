using Bmssp.DataStructures;
using Bmssp.Models;

namespace Bmssp.Algorithm
{
    /// <summary>
    /// Implements the Bounded Multi-source Shortest Path algorithm.
    /// </summary>
    public class BmsspAlgorithm
    {
        private readonly Graph _graph;
        private readonly int[] _distances;

        /// <summary>
        /// Initializes a new instance of the <see cref="BmsspAlgorithm"/> class.
        /// </summary>
        /// <param name="graph">The graph to run the algorithm on.</param>
        public BmsspAlgorithm(Graph graph)
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));
            _distances = Enumerable.Repeat(int.MaxValue, graph.VertexCount).ToArray();
        }

        /// <summary>
        /// Runs the BMSSP algorithm.
        /// </summary>
        /// <param name="recursionLevel">The recursion level (l).</param>
        /// <param name="boundary">The distance boundary (B).</param>
        /// <param name="sources">The set of source vertices (S).</param>
        /// <returns>A tuple containing the boundary value and the set of reached vertices.</returns>
        public (int boundaryPrime, HashSet<int> reachedVertices) Run(
            int recursionLevel, 
            int boundary, 
            HashSet<int> sources)
        {
            // Validate inputs
            if (recursionLevel < 0)
                throw new ArgumentOutOfRangeException(nameof(recursionLevel), "Recursion level cannot be negative.");
            
            if (boundary < 0)
                throw new ArgumentOutOfRangeException(nameof(boundary), "Boundary cannot be negative.");
            
            if (sources == null)
                throw new ArgumentNullException(nameof(sources));
            
            // Base case: just return S
            if (recursionLevel == 0)
            {
                return (boundary, new HashSet<int>(sources));
            }

            // Initialize priority queue with sources
            var distanceQueue = new DistanceQueue();
            foreach (var source in sources)
            {
                if (source < 0 || source >= _graph.VertexCount)
                    throw new ArgumentOutOfRangeException(nameof(sources), $"Source vertex {source} is out of range [0, {_graph.VertexCount - 1}].");
                
                _distances[source] = 0;
                distanceQueue.Insert(source, 0);
            }

            int iterationCount = 0;
            int initialBoundary = boundary;
            var reachedVertices = new HashSet<int>();

            while (reachedVertices.Count < (1 << recursionLevel) && !distanceQueue.IsEmpty)
            {
                iterationCount++;
                var (vertex, distance) = distanceQueue.Pull() ?? throw new InvalidOperationException("Queue is unexpectedly empty");
                
                if (distance > boundary) 
                    break;

                reachedVertices.Add(vertex);

                foreach (var edge in _graph.AdjacencyList[vertex])
                {
                    int newDistance = distance + edge.Weight;
                    if (newDistance < _distances[edge.To])
                    {
                        _distances[edge.To] = newDistance;
                        distanceQueue.Insert(edge.To, newDistance);
                    }
                }
            }

            return (initialBoundary, reachedVertices);
        }
    }
}