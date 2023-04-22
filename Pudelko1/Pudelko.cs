namespace Pudelko1
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using P = Pudelko1.Pudelko;
    public enum UnitOfMeasure
    {
        milimeter,
        centimeter,
        meter
    }
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable<double>
    {
        #region Equals ===================================
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Equals((Pudelko)obj);
        }

        public bool Equals(Pudelko other)
        {
            if (other == null) return false;
            var sortedDimensions1 = new[] { A, B, C }.OrderBy(x => x);
            var sortedDimensions2 = new[] { other.A, other.B, other.C }.OrderBy(x => x);
            return sortedDimensions1.SequenceEqual(sortedDimensions2) && Unit == other.Unit;
        }

        public override int GetHashCode() => HashCode.Combine(A, B, C);

        public static bool operator ==(Pudelko p1, Pudelko p2)
        {
            if (p1 is null) return p2 is null;
            return p1.Equals(p2);
        }
       
        public static bool operator !=(Pudelko p1, Pudelko p2)
        {
            return !(p1 == p2);
        }
        #endregion
        #region Konstruktory ===================================
        public double A { get; set; } = 0.1;
        public double B { get; set; } = 0.1;
        public double C { get; set; } = 0.1;
        public UnitOfMeasure Unit { get; set; } = UnitOfMeasure.centimeter;
        

        public double Objetosc { get => Math.Round(A * B * C, 9); }
        public double Pole { get => Math.Round(2 * A * B + 2 * B * C + 2 * A * C, 6); }
        
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
       
       
        #endregion
        #region ToString ===================================
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
        #endregion
        public static Pudelko operator +(Pudelko p1, Pudelko p2)
        {
            double maxA = Math.Max(p1.A, p2.A);
            double maxB = Math.Max(p1.B, p2.B);
            double maxC = Math.Max(p1.C, p2.C);

            double obj = maxA * maxB * maxC;

            double a =obj / (maxB * maxC);
            double b = obj / (maxA * maxC);
            double c = obj / (maxA * maxB);

            return new Pudelko(a, b, c);
        }

        public static explicit operator double[](Pudelko p)
        {
            return new double[] { p.A, p.B, p.C };
        }

        public static implicit operator Pudelko((int A, int B, int C) dimensions)
        {
            return new Pudelko(dimensions.A / 1000.0, dimensions.B / 1000.0, dimensions.C / 1000.0, UnitOfMeasure.meter);
        }
        public double this[int index]
        {
            get
            {
                if (index == 0)
                    return A;
                else if (index == 1)
                    return B;
                else if (index == 2)
                    return C;
                else
                    throw new IndexOutOfRangeException();
            }
        }
        public IEnumerator<double> GetEnumerator()
        {
            yield return A;
            yield return B;
            yield return C;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static P Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new FormatException();
            }

            var pattern = @"^\s*(\d+(?:\.\d+)?)(?:\s*(mm|cm|m))?\s*[xX*]\s*(\d+(?:\.\d+)?)(?:\s*(mm|cm|m))?\s*[xX*]\s*(\d+(?:\.\d+)?)(?:\s*(mm|cm|m))?\s*$";

            var match = Regex.Match(input, pattern);
            if (!match.Success)
            {
                throw new FormatException();
            }

            var a = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
            var b = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            var c = double.Parse(match.Groups[5].Value, CultureInfo.InvariantCulture);

            var unitA = ParseUnit(match.Groups[2].Value);
            var unitB = ParseUnit(match.Groups[4].Value);
            var unitC = ParseUnit(match.Groups[6].Value);

            if (unitA != unitB || unitA != unitC)
            {
                throw new FormatException();
            }

            var unitOfMeasure = unitA;

            return new P(a, b, c, unitOfMeasure);
        }

        private static UnitOfMeasure ParseUnit(string input)
        {
            switch (input)
            {
                case "mm":
                    return UnitOfMeasure.milimeter;
                case "cm":
                    return UnitOfMeasure.centimeter;
                case "m":
                    return UnitOfMeasure.meter;
                default:
                    throw new FormatException();
            }
        }
    }

}
        
