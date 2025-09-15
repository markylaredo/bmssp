using Bmssp.Algorithm;
using Bmssp.Models;
using System.Collections.Generic;
using Xunit;

namespace Bmssp.Tests
{
    public class BmsspTests
    {
        [Fact]
        public void Run_WithSimpleGraph_ReturnsCorrectResult()
        {
            // Arrange
            var graph = new Graph(4);
            graph.AddEdge(0, 1, 2);
            graph.AddEdge(0, 2, 4);
            graph.AddEdge(1, 3, 3);
            graph.AddEdge(2, 3, 1);
            
            var algorithm = new BmsspAlgorithm(graph);
            var sources = new HashSet<int> { 0 };
            
            // Act
            var (boundaryPrime, reachedVertices) = algorithm.Run(2, 10, sources);
            
            // Assert
            Assert.Equal(10, boundaryPrime);
            Assert.Contains(0, reachedVertices);
            Assert.Contains(1, reachedVertices);
            Assert.Contains(2, reachedVertices);
            Assert.Contains(3, reachedVertices);
        }
        
        [Fact]
        public void Run_WithBoundaryLimit_RespectsBoundary()
        {
            // Arrange
            var graph = new Graph(4);
            graph.AddEdge(0, 1, 2);
            graph.AddEdge(0, 2, 4);
            graph.AddEdge(1, 3, 3);
            graph.AddEdge(2, 3, 1);
            
            var algorithm = new BmsspAlgorithm(graph);
            var sources = new HashSet<int> { 0 };
            
            // Act
            var (boundaryPrime, reachedVertices) = algorithm.Run(2, 3, sources);
            
            // Assert
            Assert.Equal(3, boundaryPrime);
            Assert.Contains(0, reachedVertices);
            Assert.Contains(1, reachedVertices);
            // Vertex 2 (distance 4) and 3 (distance 5) should not be included due to boundary limit
            Assert.DoesNotContain(2, reachedVertices);
            Assert.DoesNotContain(3, reachedVertices);
        }
        
        [Fact]
        public void Run_WithMultipleSources_ReturnsCorrectResult()
        {
            // Arrange
            var graph = new Graph(4);
            graph.AddEdge(0, 1, 2);
            graph.AddEdge(2, 3, 1);
            
            var algorithm = new BmsspAlgorithm(graph);
            var sources = new HashSet<int> { 0, 2 };
            
            // Act
            var (boundaryPrime, reachedVertices) = algorithm.Run(2, 10, sources);
            
            // Assert
            Assert.Equal(10, boundaryPrime);
            Assert.Contains(0, reachedVertices);
            Assert.Contains(1, reachedVertices);
            Assert.Contains(2, reachedVertices);
            Assert.Contains(3, reachedVertices);
        }
    }
}