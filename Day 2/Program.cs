
using System.ComponentModel;

bool isSafeData(int[] data)
{

    int numberOfDataPoints = data.Length;

    if (numberOfDataPoints <= 1)
        return false;

    bool areCloseNumbers(int a, int b)
    {
        int diff = Math.Abs(a - b);

        return 1 <= diff && diff <= 3;
    }

    if (numberOfDataPoints == 2)
    {
        return areCloseNumbers(data[0], data[1]);
    }

    bool firstIncrement = (data[1] - data[0]) > 0;

    for (int i = 0; i < numberOfDataPoints - 1; i++)
    {
        bool currentIncrement = (data[i + 1] - data[i]) > 0;

        if (currentIncrement != firstIncrement)
            return false;

        if (!areCloseNumbers(data[i + 1], data[i]))
            return false;
    }

    return true;
}


String? line;

int safeDataCount = 0;

try
{
    StreamReader inputFile = new("input.txt");

    line = inputFile.ReadLine();

    while (line != null)
    {
        string[] parts = line.Split(' ');

        int[] inputDataRow = Array.ConvertAll(parts, int.Parse);

        if (isSafeData(inputDataRow))
            safeDataCount++;


        line = inputFile.ReadLine();
    }

    inputFile.Close();
}
catch (Exception e)
{
    Console.WriteLine("Ecxeption: " + e.Message);
}

Console.WriteLine("Number of safe data rows: " + safeDataCount);