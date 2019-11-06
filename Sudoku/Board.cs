using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace Sudoku
{
    public class Board
    {
        public Board(int?[,] cells)
        {
            Cells = cells ?? throw new ArgumentNullException(nameof(cells));
            if(Cells.GetLength(0) != Cells.GetLength(1))
                throw new ArgumentNullException(nameof(cells), "Square board required.");
            if (Cells.GetLength(0) % 3 != 0)
                throw new ArgumentNullException(nameof(cells), "Board size should be multiple of 3.");
        }

        int? [,] Cells { get; }
        int N => Cells.Length;

        public bool Valid => ColumnsValid && RowsValid && GridsValid;

        bool RowsValid => Rows.All(AllUnique);
        bool ColumnsValid => Columns.All(AllUnique);
        bool GridsValid => Grids.All(AllUnique);

        IEnumerable<IEnumerable<int>> Rows => 
            Range(0, N).Select(r => Numbers(0, N - 1, r, r));
        IEnumerable<IEnumerable<int>> Columns => 
            Range(0, N).Select(c => Numbers(c, c, 0, N - 1));
        IEnumerable<IEnumerable<int>> Grids => 
            from r in Range(0, N / 3)
            from c in Range(0, N / 3)
            select Numbers(
                c * 3, c * 3 + 2, r * 3, r * 3 + 2);
               
        bool AllUnique(IEnumerable<int> numbers) =>
            numbers.Distinct().Count() == numbers.Count();

        IEnumerable<int> Numbers(int left, int right, int top, int bottom) =>
            from r in Range(top, bottom - top + 1)
            from c in Range(left, right - left + 1)
            where Cells[r, c].HasValue
            select Cells[r, c].Value;
    }
}
