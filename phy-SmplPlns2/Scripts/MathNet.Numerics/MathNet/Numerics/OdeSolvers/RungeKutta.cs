using System;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.OdeSolvers
{
	public static class RungeKutta
	{
		public static double[] SecondOrder(double y0, double start, double end, int N, Func<double, double, double> f)
		{
			double num = (end - start) / (double)(N - 1);
			double num2 = start;
			double[] array = new double[N];
			array[0] = y0;
			for (int i = 1; i < N; i++)
			{
				double num3 = f(num2, y0);
				double num4 = f(num2 + num, y0 + num3 * num);
				array[i] = y0 + num * 0.5 * (num3 + num4);
				num2 += num;
				y0 = array[i];
			}
			return array;
		}

		public static double[] FourthOrder(double y0, double start, double end, int N, Func<double, double, double> f)
		{
			double num = (end - start) / (double)(N - 1);
			double num2 = start;
			double[] array = new double[N];
			array[0] = y0;
			for (int i = 1; i < N; i++)
			{
				double num3 = f(num2, y0);
				double num4 = f(num2 + num / 2.0, y0 + num3 * num / 2.0);
				double num5 = f(num2 + num / 2.0, y0 + num4 * num / 2.0);
				double num6 = f(num2 + num, y0 + num5 * num);
				array[i] = y0 + num / 6.0 * (num3 + 2.0 * num4 + 2.0 * num5 + num6);
				num2 += num;
				y0 = array[i];
			}
			return array;
		}

		public static Vector<double>[] SecondOrder(Vector<double> y0, double start, double end, int N, Func<double, Vector<double>, Vector<double>> f)
		{
			double num = (end - start) / (double)(N - 1);
			Vector<double>[] array = new Vector<double>[N];
			double num2 = start;
			array[0] = y0;
			for (int i = 1; i < N; i++)
			{
				Vector<double> vector = f(num2, y0);
				Vector<double> vector2 = f(num2, y0 + vector * num);
				array[i] = y0 + num * 0.5 * (vector + vector2);
				num2 += num;
				y0 = array[i];
			}
			return array;
		}

		public static Vector<double>[] FourthOrder(Vector<double> y0, double start, double end, int N, Func<double, Vector<double>, Vector<double>> f)
		{
			double num = (end - start) / (double)(N - 1);
			Vector<double>[] array = new Vector<double>[N];
			double num2 = start;
			array[0] = y0;
			for (int i = 1; i < N; i++)
			{
				Vector<double> vector = f(num2, y0);
				Vector<double> vector2 = f(num2 + num / 2.0, y0 + vector * num / 2.0);
				Vector<double> vector3 = f(num2 + num / 2.0, y0 + vector2 * num / 2.0);
				Vector<double> vector4 = f(num2 + num, y0 + vector3 * num);
				array[i] = y0 + num / 6.0 * (vector + 2.0 * vector2 + 2.0 * vector3 + vector4);
				num2 += num;
				y0 = array[i];
			}
			return array;
		}
	}
}
