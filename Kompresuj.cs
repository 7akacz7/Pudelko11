using System;

public static class Kompresuj
{
    public static Pudelko Kompresuj(this Pudelko p)
    {
        var objetosc = p.Objetosc;
        var krawedz = Math.Pow(objetosc, 1.0 / 3.0);
        return new Pudelko(krawedz, krawedz, krawedz, UnitOfMeasure.meter);
    }
}
