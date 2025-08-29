namespace estudio.hash_table.hash_encadenamiento_simple;

public interface IHashFunction<T>
{
    int GetHashIndex(T key, int bucketCount);
}