class Crocodile
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Length {get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public Crocodile(string name, double weight, double length, int age, string gender)
    {
        Name = name;
        Weight = weight;
        Length = length;
        Age = age;
        Gender = gender;
    }
    public override string ToString()
    {
        return $"Name: {Name}, Weight: {Weight}, Length: {Length}, Age: {Age}, Gender: {Gender}";
    }
}

static class CrocodileExtensions
{
    public static Crocodile FindCrocodile(this Crocodile[] crocodiles, Func<Crocodile, bool> predicate) => crocodiles.FirstOrDefault(predicate);
}

class CrocodileService
{
    public static Crocodile[] CreateCrocodiles()
    {
        Crocodile[] crocodiles = new Crocodile[]
        {
            new("Crocodile1", 100, 3, 10, "Male"),
            new("Crocodile2", 150, 6, 15, "Female"),
            new("Grocodile3", 200, 8, 20, "Male")
        };
        return crocodiles;
    }

   public static void PrintCrocodilesInfo(Crocodile[] crocodiles, double minLength)
    {

        foreach (var croc in crocodiles)
        {
            if (croc.Length > minLength)
            {
                Console.WriteLine(croc.ToString());
            }
        }

    }

    public static void PrintAllCrocodiles(Crocodile[] crocodiles)
    {

        foreach (var croc in crocodiles)
        {
            Console.WriteLine(croc.ToString());
        }

    }

    public static void RandomLengthChange(Crocodile[] crocodiles)
    {
        Random random = new Random();

        foreach (var crocodile in crocodiles)
        {
            double growth = random.NextDouble();
            crocodile.Length += growth;
           
            Console.WriteLine($"{crocodile.Name} grew by {growth} meters");
        }
        
    }

    public static void PrintOldestCrocodile(Crocodile[] crocodiles)
    {
        var oldestCroc = crocodiles.OrderByDescending(c => c.Age).First();
        Console.WriteLine("Oldest crocodile: " + oldestCroc.ToString());
    }

    public static void PrintHeaviestCrocodile(Crocodile[] crocodiles)
    {
        var heaviestCroc = crocodiles.OrderByDescending(c => c.Weight).First();
        Console.WriteLine("Heaviest crocodile: " + heaviestCroc.ToString());
    }

    public static void PrintFemaleCrocodiles(Crocodile[] crocodiles)
    {
        var females = crocodiles.Where(c => c.Gender == "Female");
        Console.WriteLine("All female crocodiles:");

        foreach (var female in females)
        {
            Console.WriteLine(female.ToString());
        }

    }
}

class Program
{
    static void Main()
    {
        CrocodileService service = new CrocodileService();
        Crocodile[] crocodiles = CrocodileService.CreateCrocodiles();
        CrocodileService.PrintCrocodilesInfo(crocodiles,6);
        CrocodileService.PrintAllCrocodiles(crocodiles);
        CrocodileService.RandomLengthChange(crocodiles);
        CrocodileService.PrintOldestCrocodile(crocodiles);
        CrocodileService.PrintHeaviestCrocodile(crocodiles);
        CrocodileService.PrintFemaleCrocodiles(crocodiles);
        Crocodile bigCrocodile = crocodiles.FindCrocodile(c => c.Weight > 150);
        Console.WriteLine("Found a big crocodile: " + bigCrocodile);
    }
}
