
using System.Text;
using MathSheets;

var result = new StringBuilder();

for (int page = 0; page < 10; page++)
{
    for (int reps = 0; reps < 4; reps++)
    {
        result.AppendLine(AdditionSubtraction.RandomAdditionOrSubtraction(120));
        result.AppendLine(MultiplicationDivision.RandomMultiplicationOrDivision(13));
    }
    result.AppendLine(Equations.RandomEquations(12, 2));

}

File.WriteAllText("tasks.txt", result.ToString());
