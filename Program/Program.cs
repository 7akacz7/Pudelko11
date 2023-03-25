using Pudelko1;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pudelko p = new Pudelko(10, 3, 900, UnitOfMeasure.centimeter);

            Pudelko p1 = new Pudelko(2, UnitOfMeasure.milimeter);

            Console.WriteLine(p.ToString("cm") + " " + p1.ToString());
        }
    }
}