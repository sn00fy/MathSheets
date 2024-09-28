
using System.Text;
using MathSheets;

var result = new StringBuilder();

for (int page = 0; page < 10; page++)
{
    for (int reps = 0; reps < 4; reps++)
    {
        for (int i = 0; i < 10; i++)
        {
            result.AppendLine(AdditionSubtraction.RandomAdditionOrSubtraction(100));
        }

        result.AppendLine();

        for (int i = 0; i < 10; i++)
        {
            result.AppendLine(MultiplicationDivision.RandomMultiplicationOrDivision(11));
        }

        result.AppendLine();
    }

    for (int i = 0; i < 10; i++)
    {
        result.AppendLine(AdditionSubtraction.RandomAdditionOrSubtraction(100));
    }

    result.AppendLine();
}

File.WriteAllText("tasks.txt", result.ToString());
