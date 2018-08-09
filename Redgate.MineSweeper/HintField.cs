using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Redgate.MineSweeper
{
    public class HintField
    {
        private readonly char[,] _squares;

        public HintField(int width, int height)
        {
            _squares = new char[width, height];
        }

        public void SetSquare(int x, int y, int digit)
        {
            SetSquare(x, y, digit.ToString().First());
        }

        public void SetSquare(int x, int y, char value)
        {
            _squares[x, y] = value;
        }

        public IEnumerable<string> Rows
        {
            get
            {
                var rows = new List<string>();

                for (var j = 0; j < _squares.GetLength(1); j++)
                {
                    var rowBuilder = new StringBuilder();

                    for (var i = 0; i < _squares.GetLength(0); i++)
                    {
                        rowBuilder.Append(_squares[i, j]);
                    }

                    rows.Add(rowBuilder.ToString());
                }

                return rows;
            }
        }
    }
}
