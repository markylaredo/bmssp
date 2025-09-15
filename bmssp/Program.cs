using Bmssp.Algorithm;
using Bmssp.Models;

// Create a sample graph
var graph = new Graph(6);
graph.AddEdge(0, 1, 2);
graph.AddEdge(0, 2, 4);
graph.AddEdge(1, 2, 1);
graph.AddEdge(1, 3, 7);
graph.AddEdge(2, 4, 3);
graph.AddEdge(3, 5, 1);
graph.AddEdge(4, 5, 5);

// Run BMSSP with sources = {0}, boundary = 10, recursion level = 2
var algorithm = new BmsspAlgorithm(graph);
var result = algorithm.Run(
    recursionLevel: 2,
    boundary: 10,
    sources: new HashSet<int> { 0 });

var boundaryPrime = result.boundaryPrime;
var reachedVertices = result.reachedVertices;

Console.WriteLine($"Boundary B' = {boundaryPrime}");
Console.WriteLine("Reached vertices U = " + string.Join(", ", reachedVertices));