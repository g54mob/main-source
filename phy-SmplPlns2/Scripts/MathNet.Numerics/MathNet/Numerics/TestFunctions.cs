using System;
using System.Linq;

namespace MathNet.Numerics
{
	public static class TestFunctions
	{
		public static double Rosenbrock(double x, double y)
		{
			double num = 1.0 - x;
			double num2 = y - x * x;
			return num * num + 100.0 * num2 * num2;
		}

		public static double Rosenbrock(params double[] x)
		{
			double num = 0.0;
			for (int i = 1; i < x.Length; i++)
			{
				num += Rosenbrock(x[i - 1], x[i]);
			}
			return num;
		}

		public static double Himmelblau(double x, double y)
		{
			double num = x * x + y - 11.0;
			double num2 = x + y * y - 7.0;
			return num * num + num2 * num2;
		}

		public static double Rastrigin(params double[] x)
		{
			return x.Sum((double xi) => xi * xi - 10.0 * Math.Cos(Math.PI * 2.0 * xi)) + 10.0 * (double)x.Length;
		}

		public static double DropWave(double x, double y)
		{
			double num = x * x + y * y;
			return (0.0 - (1.0 + Math.Cos(12.0 * Math.Sqrt(num)))) / (0.5 * num + 2.0);
		}

		public static double Ackley(params double[] x)
		{
			double d = x.Sum((double xi) => xi * xi) / (double)x.Length;
			double d2 = x.Sum((double xi) => Math.Cos(Math.PI * 2.0 * xi)) / (double)x.Length;
			return -20.0 * Math.Exp(-0.2 * Math.Sqrt(d)) - Math.Exp(d2) + 20.0 + Math.E;
		}

		public static double Bohachevsky1(double x, double y)
		{
			return x * x + 2.0 * y * y - 0.3 * Math.Cos(Math.PI * 3.0 * x) - 0.4 * Math.Cos(Math.PI * 4.0 * y);
		}

		public static double Matyas(double x, double y)
		{
			return 0.26 * (x * x + y * y) - 0.48 * x * y;
		}

		public static double SixHumpCamel(double x, double y)
		{
			double num = x * x;
			double num2 = y * y;
			return (4.0 - 2.1 * num + num * num / 3.0) * num + x * y + (-4.0 + 4.0 * num2) * num2;
		}
	}
}
