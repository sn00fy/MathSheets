
using System.Text;
using MathSheets;
using MathSheets.Configuration;

var config = Config.Level1();
var result = new StringBuilder();



for (int reps = 0; reps < 4; reps++)
{
    result.AppendLine(AdditionSubtraction.RandomAdditionOrSubtraction(130));
    result.AppendLine(MultiplicationDivision.RandomMultiplicationOrDivision(13));
}
result.AppendLine(Equations.RandomEquations(12, 3));

File.WriteAllText("tasks.txt", result.ToString());
