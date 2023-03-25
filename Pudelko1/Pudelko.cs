namespace Pudelko1
{

    public sealed class Pudelko
    {

        public double A { get; set; } = 0.1;
        public double B { get; set; } = 0.1;
        public double C { get; set; } = 0.1;
        UnitOfMeasure unit = UnitOfMeasure.centimeter;

        public Pudelko()
        {


        }
        public Pudelko(double a)
        {
            A = a;
            if (A < 0) throw new ArgumentOutOfRangeException();
            if (A > 10) throw new ArgumentOutOfRangeException();
        }
        public Pudelko(double a, double b)
        {
            A = a;
            B = b;
            if (A < 0 || B < 0) throw new ArgumentOutOfRangeException();
            if (A > 10 || B > 10) throw new ArgumentOutOfRangeException();
        }
        public Pudelko(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            if (A < 0 || B < 0 || C < 0) throw new ArgumentOutOfRangeException();
            if (A > 10 || B > 10 || C > 10) throw new ArgumentOutOfRangeException();
        }
        public Pudelko(UnitOfMeasure unit)
        {


        }
        public Pudelko(double a, UnitOfMeasure unit)
        {
            if (unit == UnitOfMeasure.centimeter)
            {
                A = a / 100;

            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                A = a / 1000;

            }
            else
            {
                A = a;

            }
            if (A < 0) throw new ArgumentOutOfRangeException();
            if (A > 10) throw new ArgumentOutOfRangeException();
        }
        public Pudelko(double a, double b, UnitOfMeasure unit)
        {
            if (unit == UnitOfMeasure.centimeter)
            {
                A = a / 100;
                B = b / 100;

            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                A = a / 1000;
                B = b / 1000;

            }
            else
            {
                A = a;
                B = b;

            }
            if (A < 0 || B < 0) throw new ArgumentOutOfRangeException();
            if (A > 10 || B > 10) throw new ArgumentOutOfRangeException();
        }
        public Pudelko(double a, double b, double c, UnitOfMeasure unit)
        {
            if (unit == UnitOfMeasure.centimeter)
            {
                A = a / 100;
                B = b / 100;
                C = c / 100;
            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                A = a / 1000;
                B = b / 1000;
                C = c / 1000;
            }
            else
            {
                A = a;
                B = b;
                C = c;
            }
            if (A < 0 || B < 0 || C < 0) throw new ArgumentOutOfRangeException();
            if (A > 10 || B > 10 || C > 10) throw new ArgumentOutOfRangeException();
        }

        public override string ToString() => $"({String.Format("{0:N3}", A)}m x {String.Format("{0:N3}", B)}m x {String.Format("{0:N3}", C)}m)";
        public string ToString(string format)
        {
            switch (format)
            {

                case "m":
                    return $"{String.Format("{0:N3}", A)}m x {String.Format("{0:N3}", B)}m x {String.Format("{0:N3}", C)}m";
                case "mm":
                    return $"{String.Format("{0:N1}", A)}mm x {String.Format("{0:N1}", B)}mm x {String.Format("{0:N1}", C)}mm";
                case "cm":
                    return $"{String.Format("{0:N2}", A)}cm x {String.Format("{0:N2}", B)}cm x {String.Format("{0:N2}", C)}cm";
                default:
                    throw new FormatException();
            }

        }
    }
        
}