
internal class Program
{
    private static void Main(string[] args)
    {
        MyList<int> l = new MyList<int>();
        l.Add(1);
        l.Add(7);
        l.Add(5);
        l.Add(2);
        l.Add(4);
        l.Add(3);
        l.Sort((x, y) =>
        {
            if (x == y)
            {
                return 0;
            }
            else if (x > y)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        );
        Console.WriteLine(l.ListToString());
        Console.ReadLine();
    }
}