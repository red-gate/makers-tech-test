using System.Collections.Generic;
using System.Linq;

namespace Redgate.MineSweeper
{
    public class Field
    {
        private readonly string[] _rows;

        public Field(string[] rows)
        {
            _rows = rows;
        }

        public int Width => _rows.Max(row => row.Length);

        public int Height => _rows.Length;

        public IEnumerable<(int x, int y, char value)> Squares
        {
            get
            {
                for (var y = 0; y < _rows.Length; y++)
                {
                    for (var x = 0; x < _rows[y].Length; x++)
                    {
                        yield return (x, y, SquareAt(x, y));
                    }
                }
            }
        }

        public char SquareAt(int x, int y)
        {
            return _rows[y][x];
        }
    }
}