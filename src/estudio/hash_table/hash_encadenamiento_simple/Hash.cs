
namespace estudio.hash_table.hash_encadenamiento_simple;


public class Hash<T> : IHash<T>
{
    private int bucketCount;
    private List<List<T>> table;
    private readonly DefaultHashFunction<T> defaultHashFunction = new DefaultHashFunction<T>();

    public Hash(int buckets)
    {
        bucketCount = buckets;
        table = new List<List<T>>(buckets);

        for (int i = 0; i < buckets; i++)
        {
            table.Add(new List<T>());
        }
    }

    public void Display()
    {
        for (int i = 0; i < bucketCount; i++)
        {
            Console.Write(i);
            foreach (var value in table[i])
            {
                Console.Write($" --> {value}");
            }
            Console.WriteLine();
        }
    }

    public int GetIndex(T Key)
    {
        int index = defaultHashFunction.GetHashIndex(Key, bucketCount);

        return table[index].Any(a => a!.Equals(Key)) ? index : -1;
    }

    public List<T> GetValue(int index)
    {
        return table[index];
    }

    public void Insert(T key)
    {
        int index = defaultHashFunction.GetHashIndex(key, bucketCount);

        table[index].Add(key);
    }

    public void Remove(T Key)
    {
        int index = defaultHashFunction.GetHashIndex(Key, bucketCount);

        table[index].Remove(Key);
    }
}