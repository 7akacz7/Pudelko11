namespace Pudelko1
{
    using System.Globalization;
    using P = Pudelko1.Pudelko;
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>
    {
       
        public bool Equals(Pudelko? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return A == other.A && B == other.B && C == other.C;
        }
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj is not Pudelko) return false;

            return this.Equals(obj as Pudelko); //(Matrix2D)obj
        }
        public override int GetHashCode() => HashCode.Combine(A, B, C);
        public static bool operator ==(Pudelko? left, Pudelko? right)
        {
            if (left is null && right is null) return true;
            if (left is null) return false;
            return left.Equals(right);
        }
        public static bool operator !=(Pudelko? left, Pudelko? right)
        {
            return !(left == right);
        }
        public double A { get; set; } = 0.1;
        public double B { get; set; } = 0.1;
        public double C { get; set; } = 0.1;
        UnitOfMeasure unit = UnitOfMeasure.centimeter;
        double Objetosc { get => Math.Round(A * B * C, 9); }
        double Pole { get => Math.Round(2 * A * B + 2 * B * C + 2 * A * C, 6); }

        /*public Pudelko(double a, double b, double c, UnitOfMeasure unit)
        {
            A = a;
            B = b;
            C = c;
            unit = UnitOfMeasure.centimeter;
        }
        public Pudelko() : this(0.1, 0.1, 0.1, UnitOfMeasure.centimeter) { }
        */
        public Pudelko()
        {
        }
        public Pudelko(double a)
        {
            A = a;
            if (A <= 0) throw new ArgumentOutOfRangeException();
            if (A > 10) throw new ArgumentOutOfRangeException();
        }
        public Pudelko(double a, double b)
        {
            A = a;
            B = b;
            if (A <= 0 || B <= 0) throw new ArgumentOutOfRangeException();
            if (A > 10 || B > 10) throw new ArgumentOutOfRangeException();
        }
        public Pudelko(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            if (A <= 0 || B <= 0 || C <= 0) throw new ArgumentOutOfRangeException();
            if (A > 10 || B > 10 || C > 10) throw new ArgumentOutOfRangeException();
        }
        public Pudelko(UnitOfMeasure unit)
        {


        }

        public Pudelko(double a, UnitOfMeasure unit)
        {
            if (unit == UnitOfMeasure.centimeter)
            {
                if (a < 1) throw new ArgumentOutOfRangeException();
                A = a / 100;

            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                if (a < 1) throw new ArgumentOutOfRangeException();
                A = a / 1000;

            }
            else
            {
                A = a;

            }
            if (A <= 0) throw new ArgumentOutOfRangeException();
            if (A > 10) throw new ArgumentOutOfRangeException();
        }
        public Pudelko(double a, double b, UnitOfMeasure unit)
        {
            if (unit == UnitOfMeasure.centimeter)
            {
                if (a < 1 || b < 1) throw new ArgumentOutOfRangeException();
                A = a / 100;
                B = b / 100;

            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                if (a < 1 || b < 1) throw new ArgumentOutOfRangeException();
                A = a / 1000;
                B = b / 1000;

            }
            else
            {
                A = a;
                B = b;

            }
            if (A <= 0 || B <= 0) throw new ArgumentOutOfRangeException();
            if (A > 10 || B > 10) throw new ArgumentOutOfRangeException();
        }

        public Pudelko(double a, double b, double c, UnitOfMeasure unit)
        {
            if (unit == UnitOfMeasure.centimeter)
            {
                if (a < 1 || b < 1 || c < 1) throw new ArgumentOutOfRangeException();
                A = a / 100;
                B = b / 100;
                C = c / 100;
            }
            else if (unit == UnitOfMeasure.milimeter)
            {
                if (a < 1 || b < 1 || c < 1) throw new ArgumentOutOfRangeException();
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
            if (A <= 0 || B <= 0 || C <= 0) throw new ArgumentOutOfRangeException();
            if (A > 10 || B > 10 || C > 10) throw new ArgumentOutOfRangeException();
        }

        public override string ToString()
        {
            return this.ToString("m", CultureInfo.CurrentCulture);
        }
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }
        public string ToString(string format, IFormatProvider provider)
        {

            if (String.IsNullOrEmpty(format))
            {
                format = "m";
            }
            if (provider == null) { provider = CultureInfo.CurrentCulture; }
            switch (format.ToLower())
            {
                case "m":
                    return $"{String.Format("{0:N3}", A)} m × {String.Format("{0:N3}", B)} m × {String.Format("{0:N3}", C)} m";
                case "mm":
                    return $"{String.Format("{0}", A * 1000)} mm × {String.Format("{0}", B * 1000)} mm × {String.Format("{0}", C * 1000)} mm";
                case "cm":
                    return $"{String.Format("{0:N1}", A * 100)} cm × {String.Format("{0:N1}", B * 100)} cm × {String.Format("{0:N1}", C * 100)} cm";
                default:
                    throw new FormatException();
            }
        }
    
    }
        
}