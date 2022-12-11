// Erzeuge ein Array, das 10 Elemente enthält.
// Jedes dieser 10 Elemente ist eine Referenz auf ein Array-Objekt.
// Nach Erzeugung des Arrays hat jedes Element (Referenz) den Wert null.
int[][] table = new int[10][];

for (int row = 0; row < table.Length; row++)
{
    table[row] = new int[10];

    for (int column = 0; column < table[row].Length; column++)
    {
        table[row][column] = (row + 1) * (column + 1);
        Console.Write("{0,3:D} ", table[row][column]);
    }
    Console.WriteLine();
}

char[][] pattern = new char[25][];


for (int i = 0; i < pattern.Length; ++i)
{
    if (i == 0 || i == pattern.Length - 1)
    {
        pattern[i] = null;
    }
    else if (i <= pattern.Length / 2)
    {
        pattern[i] = new char[i];
        Array.Fill(pattern[i], '*');
    } 
    else
    {
        pattern[i] = new char[pattern.Length - i - 1];
        Array.Fill(pattern[i], '*');
    }
    
    if (pattern[i] != null)
    {
        foreach (char c in pattern[i])
        {
            Console.Write(c);
        }
    }
    Console.WriteLine();
}

