
using System.ComponentModel;

bool isSafeData(List<int> data)
{

    int numberOfDataPoints = data.Count();

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

bool isSafeDataWithDamper(List<int> data)
{

    int numberOfDataPoints = data.Count();

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

    List<int> tempData;


    for (int ignoredIndex = -1; ignoredIndex < numberOfDataPoints; ignoredIndex++)
    {
        tempData = new(data);
        if (ignoredIndex != -1)
        {
            tempData.RemoveAt(ignoredIndex);
        }

        if (isSafeData(tempData))
        {
            return true;
        }
    }

    return false;
}

String? line;

int safeDataCount = 0;
int safeDataWithDamperCount = 0;

try
{
    StreamReader inputFile = new("input.txt");

    line = inputFile.ReadLine();

    while (line != null)
    {
        string[] parts = line.Split(' ');

        List<int> inputDataRow = [.. Array.ConvertAll(parts, int.Parse)];

        if (isSafeData(inputDataRow))
            safeDataCount++;
        
        if (isSafeDataWithDamper(inputDataRow))
            safeDataWithDamperCount++;


        line = inputFile.ReadLine();
    }

    inputFile.Close();
}
catch (Exception e)
{
    Console.WriteLine("Ecxeption: " + e.Message);
}

Console.WriteLine("Number of safe data rows: " + safeDataCount);
Console.WriteLine("Number of safe data rows with damper: " + safeDataWithDamperCount);
