namespace estudio.hash_table.hash_encadenamiento_simple;    
public class HashInt : IHash<int>
{
    private int bucketCount;
    private List<List<int>> table;
    private readonly DefaultHashFunction<int> defaultHashFunction = new DefaultHashFunction<int>();

    public HashInt(int buckets)
    {
        bucketCount = buckets;
        table = new List<List<int>>(buckets);
        for (int i = 0; i < bucketCount; i++)
        {
            table.Add(new List<int>());
        }
    }

    public void Insert(int key)
    {
        int index = defaultHashFunction.GetHashIndex(key, bucketCount);
        if (!table[index].Contains(key))
            table[index].Add(key);
    }

    public void Remove(int key)
    {
        int index = defaultHashFunction.GetHashIndex(key, bucketCount);

        table[index].Remove(key);
    }

    public void Display()
    {
        for (int i = 0; i < bucketCount; i++)
        {
            Console.Write(i);

            foreach (int key in table[i])
            {
                Console.Write(" --> " + key);
            }

            Console.WriteLine();
        }
    }

    public int GetIndex(int key)
    {
        int index = defaultHashFunction.GetHashIndex(key, bucketCount);

        return table[index].Any(a => a.Equals(key)) ? index : -1;
    }

    public List<int> GetValue(int index)
    {
        return table[index];
    }

}