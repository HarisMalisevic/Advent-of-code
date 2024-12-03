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

    inputFile.Close();

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

Dictionary<int, int> numberAndOccurances = new Dictionary<int, int>();


for (int i = 0; i < firstColumn.Count; i++)
{
    sumOfDistances += Math.Abs(firstColumn[i] - secondColumn[i]);

    if (numberAndOccurances.ContainsKey(secondColumn[i]))
    {
        numberAndOccurances[secondColumn[i]]++;
    }
    else
    {
        numberAndOccurances[secondColumn[i]] = 1;
    }

}

long similarityScore = 0;

for (int i = 0; i < firstColumn.Count; i++)
{
    if (numberAndOccurances.ContainsKey(firstColumn[i]))
        similarityScore += firstColumn[i] * numberAndOccurances[firstColumn[i]];
}




Console.WriteLine("The sum of the distances between the elements of the two columns is: " + sumOfDistances);
Console.WriteLine("Similarity Score: " + similarityScore);
