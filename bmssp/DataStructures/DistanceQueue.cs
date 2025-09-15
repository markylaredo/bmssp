namespace Bmssp.DataStructures
{
    /// <summary>
    /// A priority queue implementation for vertices with distances.
    /// </summary>
    internal class DistanceQueue
    {
        private readonly PriorityQueue<(int vertex, int dist), int> _priorityQueue = new();

        /// <summary>
        /// Inserts a vertex with its distance into the queue.
        /// </summary>
        /// <param name="vertex">The vertex to insert.</param>
        /// <param name="distance">The distance associated with the vertex.</param>
        public void Insert(int vertex, int distance)
        {
            _priorityQueue.Enqueue((vertex, distance), distance);
        }

        /// <summary>
        /// Removes and returns the vertex with the smallest distance.
        /// </summary>
        /// <returns>The vertex with the smallest distance, or null if the queue is empty.</returns>
        public (int vertex, int dist)? Pull()
        {
            return _priorityQueue.Count > 0 ? _priorityQueue.Dequeue() : null;
        }

        /// <summary>
        /// Gets a value indicating whether the queue is empty.
        /// </summary>
        public bool IsEmpty => _priorityQueue.Count == 0;
    }
}