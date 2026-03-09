using System.Globalization;

public static class Program
{
    public static void Main()
    {
        var multiples = Arrays.MultiplesOf(7, 5);
        Console.WriteLine($"MultiplesOf(7, 5): [{string.Join(", ", multiples.Select(v => v.ToString(CultureInfo.InvariantCulture)))}]");

        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Arrays.RotateListRight(numbers, 3);
        Console.WriteLine($"RotateListRight([1..9], 3): [{string.Join(", ", numbers)}]");
    }
}
