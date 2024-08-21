namespace GraphTheory_Kruskal.Graphs;

public class Grafo
{
    public int Vertices { get; }
    public List<Aresta> Arestas { get; }

    public Grafo(int vertices)
    {
        Vertices = vertices;
        Arestas = [];
    }

    public void AdicionarAresta(int origem, int destino, int peso)
    {
        Arestas.Add(new Aresta(origem, destino, peso));
    }

    // Método encontrar o conjunto de um vértice (com caminho comprimido)
    private int Encontrar(int[] pai, int vertice)
    {
        if (pai[vertice] != vertice)
        {
            pai[vertice] = Encontrar(pai, pai[vertice]);
        }
        return pai[vertice];
    }

    // Método para unir dois subconjuntos em um único conjunto
    private void Unir(int[] pai, int[] rank, int origem, int destino)
    {
        int raizOrigem = Encontrar(pai, origem);
        int raizDestino = Encontrar(pai, destino);

        if (rank[raizOrigem] < rank[raizDestino])
        {
            pai[raizOrigem] = raizDestino;
        }
        else if (rank[raizOrigem] > rank[raizDestino])
        {
            pai[raizDestino] = raizOrigem;
        }
        else
        {
            pai[raizDestino] = raizOrigem;
            rank[raizOrigem]++;
        }
    }

    public void KruskalMST()
    {
        List<Aresta> resultado = [];

        // Ordena todas as arestas em ordem crescente de peso
        Arestas.Sort();

        // Array para representar os subconjuntos e outro para armazenar os ranks dos subconjuntos
        int[] pai = new int[Vertices];
        int[] rank = new int[Vertices];

        // Inicializa os conjuntos: cada vértice é o próprio pai (conjunto individual)
        for (int i = 0; i < Vertices; i++)
        {
            pai[i] = i;
            rank[i] = 0;
        }

        int arestasIncluidas = 0;
        int indice = 0;

        // Itera sobre as arestas ordenadas e constrói a MST
        while (arestasIncluidas < Vertices - 1 && indice < Arestas.Count)
        {
            Aresta proximaAresta = Arestas[indice++];

            // Encontra os subconjuntos (conjuntos disjuntos) de dois vértices da aresta
            int x = Encontrar(pai, proximaAresta.Origem);
            int y = Encontrar(pai, proximaAresta.Destino);

            // Se os vértices pertencem a subconjuntos diferentes, adicione esta aresta ao resultado
            if (x != y)
            {
                resultado.Add(proximaAresta);
                Unir(pai, rank, x, y);  // Une os dois subconjuntos
                arestasIncluidas++;
            }
        }

        Console.WriteLine("As arestas na Árvore Geradora Mínima (MST) são:");
        foreach (var aresta in resultado)
        {
            Console.WriteLine($"{aresta.Origem} -- {aresta.Destino} == {aresta.Peso}");
        }
    }
}