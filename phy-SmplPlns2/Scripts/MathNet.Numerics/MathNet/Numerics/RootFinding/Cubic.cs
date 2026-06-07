using System;
using System.Numerics;

namespace MathNet.Numerics.RootFinding
{
	public static class Cubic
	{
		private static void QR(double a2, double a1, double a0, out double Q, out double R)
		{
			Q = (3.0 * a1 - a2 * a2) / 9.0;
			R = (9.0 * a2 * a1 - 27.0 * a0 - 2.0 * a2 * a2 * a2) / 54.0;
		}

		private static double PowThird(double n)
		{
			return Math.Pow(Math.Abs(n), 1.0 / 3.0) * (double)Math.Sign(n);
		}

		public static (double, double, double) RealRoots(double a0, double a1, double a2)
		{
			QR(a2, a1, a0, out var Q, out var R);
			double num = Q * Q * Q;
			double num2 = num + R * R;
			double num3 = (0.0 - a2) / 3.0;
			double item = double.NaN;
			double item2 = double.NaN;
			double item3;
			if (num2 >= 0.0)
			{
				double num4 = Math.Pow(num2, 0.5);
				double num5 = PowThird(R + num4);
				double num6 = PowThird(R - num4);
				item3 = num3 + (num5 + num6);
				if (num2 == 0.0)
				{
					item = num3 - num5;
				}
			}
			else
			{
				double num7 = Math.Acos(R / Math.Sqrt(0.0 - num));
				item3 = 2.0 * Math.Sqrt(0.0 - Q) * Math.Cos(num7 / 3.0) + num3;
				item = 2.0 * Math.Sqrt(0.0 - Q) * Math.Cos((num7 + Math.PI * 2.0) / 3.0) + num3;
				item2 = 2.0 * Math.Sqrt(0.0 - Q) * Math.Cos((num7 - Math.PI * 2.0) / 3.0) + num3;
			}
			return (item3, item, item2);
		}

		public static (Complex, Complex, Complex) Roots(double d, double c, double b, double a)
		{
			double num = b * b - 3.0 * a * c;
			double num2 = 2.0 * b * b * b - 9.0 * a * b * c + 27.0 * a * a * d;
			double num3 = -1.0 / (3.0 * a);
			if ((num2 * num2 - 4.0 * num * num * num) / (-27.0 * a * a) == 0.0)
			{
				if (num == 0.0)
				{
					Complex complex = new Complex(num3 * b, 0.0);
					return (complex, complex, complex);
				}
				Complex complex2 = new Complex((9.0 * a * d - b * c) / (2.0 * num), 0.0);
				Complex item = new Complex((4.0 * a * b * c - 9.0 * a * a * d - b * b * b) / (a * num), 0.0);
				return (complex2, complex2, item);
			}
			(Complex, Complex, Complex) tuple = ((num == 0.0) ? new Complex(num2, 0.0).CubicRoots() : ((num2 + Complex.Sqrt(num2 * num2 - 4.0 * num * num * num)) / 2).CubicRoots());
			return (num3 * (b + tuple.Item1 + num / tuple.Item1), num3 * (b + tuple.Item2 + num / tuple.Item2), num3 * (b + tuple.Item3 + num / tuple.Item3));
		}
	}
}
