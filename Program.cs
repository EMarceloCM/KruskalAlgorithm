using GraphTheory_Kruskal.Graphs;
using System.Diagnostics;

int vertices = 4;
Grafo grafo = new(vertices);

grafo.AdicionarAresta(0, 1, 10);
grafo.AdicionarAresta(0, 2, 6);
grafo.AdicionarAresta(0, 3, 5);
grafo.AdicionarAresta(1, 3, 15);
grafo.AdicionarAresta(2, 3, 4);

// Contador para verificar tempo de execução do algoritmo de KruskalMST
Stopwatch stopwatch = new();

stopwatch.Start();

grafo.KruskalMST();

stopwatch.Stop();

Console.Write($"\n\nTempo de execução: {stopwatch.ElapsedMilliseconds} ms");