using System.Linq;

namespace Redgate.MineSweeper
{
    public class MineSweeper
    {
        public string GenerateHintField(string field)
        {
            const char newLine = '\n';
            var rows = field.Split(newLine);
            var hintField = GenerateHintField(new Field(rows));
            return string.Join(newLine.ToString(), hintField.Rows);
        }

        private HintField GenerateHintField(Field field)
        {
            var hintField = new HintField(field.Width, field.Height);
            var mineCount = field.Squares.Count(square => square.value == '*');

            foreach (var (x, y, value) in field.Squares)
            {
                if (value == '*')
                {
                    hintField.SetSquare(x, y, '*');
                }
                else
                {
                    hintField.SetSquare(x, y, mineCount);
                }
            }

            return hintField;
        }
    }
}
