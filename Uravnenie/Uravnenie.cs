using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UravnenieLib
{
    public class Uravnenie
    {
        static Random rnd = new Random();
        public static int countObjects = 0;
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public Uravnenie() { countObjects++; }
        ~Uravnenie() { countObjects--; }
        public Uravnenie(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            countObjects++;
        }
        public static Uravnenie operator ++ (Uravnenie u)
        {
            return new Uravnenie { A = u.A + 1, B = u.B + 1, C = u.C + 1 };
        }
        public static Uravnenie operator --(Uravnenie u)
        {
            return new Uravnenie { A = u.A - 1, B = u.B - 1, C = u.C - 1 };
        }
        public static bool operator == (Uravnenie u1, Uravnenie u2)
        {
            if (u1.A == u2.A && u1.B == u2.B && u1.C == u2.C)
                return true;
            else
                return false;
        }
        public static bool operator !=(Uravnenie u1, Uravnenie u2)
        {
            if (u1.A != u2.A || u1.B != u2.B || u1.C != u2.C)
                return true;
            else
                return false;
        }
        public static implicit operator double(Uravnenie u)
        {
            double d = u.B * u.B - 4 * u.A * u.C;
            if (d < 0) return -10E20;
            else return (-u.B + Math.Sqrt(d)) / 2 * u.A;
        }
        public static explicit operator bool(Uravnenie u)
        {
            double d = u.B * u.B - 4 * u.A * u.C;
            if (d < 0) return false;
            else return true;
        }
        public double[] SolveEquation()
        {
            double d = B * B - 4 * A * C;
            double[] roots = new double[2];
            if (d < 0)
            {
                roots[0] = -10E20;
                roots[1] = -10E20;
            }
            if (d == 0)
            {
                roots[0] = -B / 2 * A;
                roots[1] = -B / 2 * A;
            }
            if (d > 0)
            {
                roots[0] = (-B + Math.Sqrt(d)) / 2 * A;
                roots[1] = (-B - Math.Sqrt(d)) / 2 * A;
            }
            return roots;
        }
        public static double[] SolveEquation(double a, double b, double c)
        {
            double d = b * b - 4 * a * c;
            double[] roots = new double[2];
            if (d == 0)
            {
                roots[0] = -b / 2 * a;
                roots[1] = -b / 2 * a;
            }
            if (d > 0)
            {
                roots[0] = (-b + Math.Sqrt(d)) / 2 * a;
                roots[1] = (-b - Math.Sqrt(d)) / 2 * a;
            }
            return roots;
        }
        public Uravnenie Random()
        {
            A = rnd.Next(100);
            B = rnd.Next(100);
            C = rnd.Next(100);
            return this;
        }
        public override string ToString()
        {
            return
                $"a = {A}" +
                $" b = {B}" +
                $" c = {C}";
        }
    }
}
