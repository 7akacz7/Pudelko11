using Pudelko1;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pudelko> pudelka = new List<Pudelko>
            {
                new Pudelko(2.0, 3.0, 4.0),
                new Pudelko(1.0, 3.0, 5.0),
                new Pudelko(2.0, 2.0, 2.0),
                new Pudelko(5.0, 1.0, 2.0),
                Pudelko.Parse("3.0 m x 3.0 m x 3.0 m")
            };

            Console.WriteLine("Lista pudełek:");
            foreach (var p in pudelka)
            {
                Console.WriteLine(p);
            }

            pudelka.Sort((p1, p2) =>
            {
                int cmp = p1.Objetosc.CompareTo(p2.Objetosc);
                if (cmp != 0) return cmp;

                cmp = p1.Pole.CompareTo(p2.Pole);
                if (cmp != 0) return cmp;

                return (p1.A + p1.B + p1.C).CompareTo(p2.A + p2.B + p2.C);
            });

            Console.WriteLine("Posortowana lista pudełek:");
            foreach (var p in pudelka)
            {
                Console.WriteLine(p);
            }

        }
    }
}