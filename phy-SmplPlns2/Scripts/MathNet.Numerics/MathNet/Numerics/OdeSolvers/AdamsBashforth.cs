using System;

namespace MathNet.Numerics.OdeSolvers
{
	public static class AdamsBashforth
	{
		public static double[] FirstOrder(double y0, double start, double end, int N, Func<double, double, double> f)
		{
			double num = (end - start) / (double)(N - 1);
			double num2 = start;
			double[] array = new double[N];
			array[0] = y0;
			for (int i = 1; i < N; i++)
			{
				array[i] = y0 + num * f(num2, y0);
				num2 += num;
				y0 = array[i];
			}
			return array;
		}

		public static double[] SecondOrder(double y0, double start, double end, int N, Func<double, double, double> f)
		{
			double num = (end - start) / (double)(N - 1);
			double num2 = start;
			double[] array = new double[N];
			double num3 = f(num2, y0);
			double num4 = f(num2 + num, y0 + num * num3);
			double num5 = y0 + 0.5 * num * (num3 + num4);
			array[0] = y0;
			array[1] = num5;
			for (int i = 2; i < N; i++)
			{
				array[i] = num5 + num * (1.5 * f(num2 + num, num5) - 0.5 * f(num2, y0));
				num2 += num;
				y0 = array[i - 1];
				num5 = array[i];
			}
			return array;
		}

		public static double[] ThirdOrder(double y0, double start, double end, int N, Func<double, double, double> f)
		{
			double num = (end - start) / (double)(N - 1);
			double num2 = start;
			double[] array = new double[N];
			array[0] = y0;
			for (int i = 1; i < 3; i++)
			{
				double num3 = num * f(num2, y0);
				double num4 = num * f(num2 + num / 2.0, y0 + num3 / 2.0);
				double num5 = num * f(num2 + num / 2.0, y0 + num4 / 2.0);
				double num6 = num * f(num2 + num, y0 + num5);
				array[i] = y0 + (num3 + 2.0 * num4 + 2.0 * num5 + num6) / 6.0;
				num2 += num;
				y0 = array[i];
			}
			for (int j = 3; j < N; j++)
			{
				array[j] = array[j - 1] + num * (23.0 * f(num2, array[j - 1]) - 16.0 * f(num2 - num, array[j - 2]) + 5.0 * f(num2 - 2.0 * num, array[j - 3])) / 12.0;
				num2 += num;
			}
			return array;
		}

		public static double[] FourthOrder(double y0, double start, double end, int N, Func<double, double, double> f)
		{
			double num = (end - start) / (double)(N - 1);
			double num2 = start;
			double[] array = new double[N];
			array[0] = y0;
			for (int i = 1; i < 4; i++)
			{
				double num3 = num * f(num2, y0);
				double num4 = num * f(num2 + num / 2.0, y0 + num3 / 2.0);
				double num5 = num * f(num2 + num / 2.0, y0 + num4 / 2.0);
				double num6 = num * f(num2 + num, y0 + num5);
				array[i] = y0 + (num3 + 2.0 * num4 + 2.0 * num5 + num6) / 6.0;
				num2 += num;
				y0 = array[i];
			}
			for (int j = 4; j < N; j++)
			{
				array[j] = array[j - 1] + num * (55.0 * f(num2, array[j - 1]) - 59.0 * f(num2 - num, array[j - 2]) + 37.0 * f(num2 - 2.0 * num, array[j - 3]) - 9.0 * f(num2 - 3.0 * num, array[j - 4])) / 24.0;
				num2 += num;
			}
			return array;
		}
	}
}
