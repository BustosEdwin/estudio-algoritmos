
using Xunit;
using System.Collections.Generic;
using estudio.hash_table.hash_encadenamiento_simple;

namespace investigacion_tests;
public class HashTest
{

    [Fact]
    public void HashInt_Insert_ShouldAddElementsToCorrectBucket()
    {
        // Given
        var hash = new HashInt(10);

        // When
        hash.Insert(5);
        hash.Insert(15); // 15 % 10 = 5, debería estar en el mismo bucket que 5
        hash.Insert(7);

        // Then
        Assert.Equal(5, hash.GetIndex(5));
        Assert.Equal(5, hash.GetIndex(15)); // Mismo índice debido al módulo 10
        Assert.Equal(7, hash.GetIndex(7));

        List<int> bucket5 = hash.GetValue(5);
        Assert.Contains(5, bucket5);
        Assert.Contains(15, bucket5);

        List<int> bucket7 = hash.GetValue(7);
        Assert.Contains(7, bucket7);
        
    }
    
    [Fact]
    public void HashInt_Remove_ShouldRemoveElementsFromBucket()
    {
        // Given
        var hash = new HashInt(10);
        hash.Insert(5);
        hash.Insert(15);
        
        // When
        hash.Remove(5);
        
        // Then
        List<int> bucket5 = hash.GetValue(5);
        Assert.DoesNotContain(5, bucket5);
        Assert.Contains(15, bucket5);
    }
    
    [Fact]
    public void HashInt_GetIndex_ShouldReturnMinusOneForNonExistingElement()
    {
        // Given
        var hash = new HashInt(10);
        
        // When & Then
        Assert.Equal(-1, hash.GetIndex(42));
    }
}