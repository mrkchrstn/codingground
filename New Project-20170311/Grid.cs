using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

public class Grid
{
    private List<List<char>> _items = new List<List<char>>();  
    private int _xCount = 0;
    private int _oCount = 0;
    private string _toString = String.Empty;
    
    public List<List<char>> Items{
        get { return _items; }
    }
    
    public int XCount{
        get { return _xCount; }
    }
    
    public int OCount{
        get { return _oCount; }
    }
    
    public override string ToString()
    {
        return _toString;
    }
    
    public Grid(){
    }
    
    public Grid(string fileName){
        string[] rows = File.ReadAllLines(fileName);
                        
        foreach (string row in rows){
            List<char> cols = new List<char>(); 
            
            foreach (char col in row){
                if (col == 'X') _xCount++;
                else if (col == 'O') _oCount++;
                cols.Add(col);
            }
            
            _items.Add(cols);
        }
        
        _toString = String.Join(Environment.NewLine, rows);
    }
    
    public double Dissimilarity(int row1,
                                int col1,
                                int row2,
                                int col2){
        return Dissimilarity(this, row1, col1, row2, col2);
    }
    
    public static double Dissimilarity(Grid grid,
                                       int row1,
                                       int col1,
                                       int row2,
                                       int col2){
        double result = 0;
        int xCount = 0;
        int oCount = 0;
        
        int rowCount = 1;
        foreach (List<char> row in grid.Items){
            if (row1 <= rowCount && rowCount <= row2){
                
                int colCount = 1;
                foreach (char col in row){
                    if (col1 <= colCount && colCount <= col2){
                        if (col == 'X') xCount++;
                        else if (col == 'O') oCount++;
                    }
                    
                    colCount++;
                }
            }
            
            rowCount++;
        }
        
        result = ((double)xCount/(double)grid.XCount);
        result -= ((double)oCount/(double)grid.OCount);
        result = 0.5 * Math.Abs(result);
        
        return result;
    }
}
