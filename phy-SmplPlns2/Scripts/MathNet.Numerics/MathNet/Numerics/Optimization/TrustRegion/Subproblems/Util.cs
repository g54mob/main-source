using System;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization.TrustRegion.Subproblems
{
	internal static class Util
	{
		public static (double, double) FindBeta(double alpha, Vector<double> sd, Vector<double> gn, double delta)
		{
			Vector<double> vector = alpha * sd;
			Vector<double> vector2 = gn - vector;
			double num = vector2.DotProduct(vector2);
			double num2 = 2.0 * vector.DotProduct(vector2);
			double num3 = vector.DotProduct(vector) - delta * delta;
			double num4 = num2 + ((num2 >= 0.0) ? 1.0 : (-1.0)) * Math.Sqrt(num2 * num2 - 4.0 * num * num3);
			double num5 = (0.0 - num4) / 2.0 / num;
			double num6 = -2.0 * num3 / num4;
			if (!(num5 < num6))
			{
				return (num6, num5);
			}
			return (num5, num6);
		}
	}
}
