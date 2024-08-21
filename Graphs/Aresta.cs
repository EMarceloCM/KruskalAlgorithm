namespace GraphTheory_Kruskal.Graphs;
public class Aresta : IComparable<Aresta>
{
    public int Origem { get; }
    public int Destino { get; }
    public int Peso { get; }

    public Aresta(int origem, int destino, int peso)
    {
        Origem = origem;
        Destino = destino;
        Peso = peso;
    }

    // Implementação da interface IComparable para ordenar as arestas pelo peso
    public int CompareTo(Aresta? outra)
    {
        return Peso.CompareTo(outra!.Peso);
    }
}