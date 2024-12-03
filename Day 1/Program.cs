String? line;

List<int> firstColumn = new();
List<int> secondColumn = new();

try
{
    StreamReader inputFile = new("input.txt");

    line = inputFile.ReadLine();

    while (line != null)
    {
        string[] parts = line.Split("   ");

        firstColumn.Add(int.Parse(parts[0]));
        secondColumn.Add(int.Parse(parts[1]));

        line = inputFile.ReadLine();
    }


}
catch (Exception e)
{
    Console.WriteLine("Ecxeption: " + e.Message);
}

if (firstColumn.Count != secondColumn.Count)
{
    Console.WriteLine("The number of elements in the two columns is not equal");
    return;
}

try
{
    firstColumn.Sort();
    secondColumn.Sort();
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}

long sumOfDistances = 0;

for (int i = 0; i < firstColumn.Count; i++)
{
    sumOfDistances += Math.Abs(firstColumn[i] - secondColumn[i]);
}

Console.WriteLine("The sum of the distances between the elements of the two columns is: " + sumOfDistances);
