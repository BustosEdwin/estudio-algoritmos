namespace estudio.hash_table.hash_encadenamiento_simple;
public interface IHash<T>
{

    void Insert(T key);

    void Remove(T Key);

    void Display();

    int GetIndex(T Key);

    List<T> GetValue(int index);

}