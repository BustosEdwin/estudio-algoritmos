namespace estudio.hash_table.hash_encadenamiento_simple;

public class DefaultHashFunction<T> : IHashFunction<T>
{
    public int GetHashIndex(T key, int bucketCount)
    {
        return Math.Abs(key!.GetHashCode()) % bucketCount;
    }
}