using ShapeAreaCalculator.Shapes;

var rrr = new Triangle(3, 4, 5);

Console.WriteLine(String.Join("\t", rrr.GetAllSides().Select(x=>x.ToString("0.00"))) + "\t" + rrr.CalculateArea());


Triangle triangle = new Triangle(2, 3, 4);
List<decimal> expected = new List<decimal>() { 2, 3, 4 };
List<decimal> response = triangle.GetAllSides();

for (int i = 0; i < response.Count; i++)
{
    Console.WriteLine(expected[i] + "\t" + response[i]);
}

Console.WriteLine((expected.Equals(response)));
Console.ReadLine();
