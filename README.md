# BMSSP - Bounded Multi-source Shortest Path

This project implements the Bounded Multi-source Shortest Path (BMSSP) algorithm in C#.

## Algorithm Overview

The BMSSP algorithm finds the shortest paths from multiple source vertices within a specified distance boundary. It's particularly useful in scenarios where you need to limit the search space for shortest paths.

## Features

- Efficient implementation using priority queues
- Support for weighted directed graphs
- Configurable distance boundary
- Multi-source shortest path computation
- Comprehensive unit test coverage
- Professional code structure and documentation

## Algorithm Purpose

  The BMSSP algorithm is particularly useful in scenarios
  where:

- You need to find the closest reachable vertices from
     multiple starting points
- You want to limit search space to improve performance
- You're working with large graphs but only need results
     within a certain distance threshold

## Usage

```csharp
// Create a graph
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

Console.WriteLine($"Boundary B' = {result.boundaryPrime}");
Console.WriteLine("Reached vertices U = " + string.Join(", ", result.reachedVertices));
```

## Project Structure

```
bmssp/
├── bmssp.csproj                 # Main application project
├── Program.cs                   # Application entry point
├── Models/
│   ├── Edge.cs                  # Graph edge data model
│   └── Graph.cs                 # Graph data structure
├── DataStructures/
│   └── DistanceQueue.cs         # Priority queue implementation
├── Algorithm/
│   └── BmsspAlgorithm.cs        # Main BMSSP algorithm implementation
├── bmssp.tests/                 # Unit test project
│   ├── bmssp.tests.csproj       # Test project file
│   └── BmsspTests.cs            # Unit tests
└── bmssp.sln                    # Solution file
```

## Requirements

- .NET 9.0 or later

## Building and Running

```bash
# Clean the solution
dotnet clean

# Restore dependencies
dotnet restore

# Build the entire solution
dotnet build

# Run the main program
dotnet run --project bmssp.csproj

# Run all tests
dotnet test

# Run tests with verbose output
dotnet test --verbosity normal
```

## Solution Structure

The solution consists of two projects:

1. **`bmssp.csproj`** - The main application
   - Contains all algorithm implementation
   - Follows clean architecture principles
   - Properly separated concerns across namespaces

2. **`bmssp.tests.csproj`** - Unit tests for the application
   - Comprehensive test coverage
   - Uses xUnit testing framework
   - Tests all major functionality

## Code Quality Features

- **Comprehensive Documentation**: XML documentation for all public types and members
- **Error Handling**: Proper validation with meaningful exception messages
- **Type Safety**: Strong typing with nullable reference types
- **Clean Code**: Follows C# coding conventions and best practices
- **Test Coverage**: Unit tests for all major functionality