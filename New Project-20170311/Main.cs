using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Grid grid = new Grid("schelling10x10.txt");
        Console.WriteLine(grid.ToString());
        
        Console.WriteLine(grid.Dissimilarity(1, 7, 4, 10));
    }
    
}
