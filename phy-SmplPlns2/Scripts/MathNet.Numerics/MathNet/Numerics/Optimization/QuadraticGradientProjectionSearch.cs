using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Optimization
{
	public static class QuadraticGradientProjectionSearch
	{
		public readonly struct GradientProjectionResult
		{
			public Vector<double> CauchyPoint { get; }

			public int FixedCount { get; }

			public List<bool> IsFixed { get; }

			public GradientProjectionResult(Vector<double> cauchyPoint, int fixedCount, List<bool> isFixed)
			{
				CauchyPoint = cauchyPoint;
				FixedCount = fixedCount;
				IsFixed = isFixed;
			}
		}

		public static GradientProjectionResult Search(Vector<double> x0, Vector<double> gradient, Matrix<double> hessian, Vector<double> lowerBound, Vector<double> upperBound)
		{
			List<bool> list = new List<bool>(x0.Count);
			List<double> list2 = new List<double>(x0.Count);
			for (int i = 0; i < x0.Count; i++)
			{
				list2.Add(0.0);
				list.Add(item: false);
				if (gradient[i] < 0.0)
				{
					list2[i] = (x0[i] - upperBound[i]) / gradient[i];
				}
				else if (gradient[i] > 0.0)
				{
					list2[i] = (x0[i] - lowerBound[i]) / gradient[i];
				}
				else if (Math.Abs(x0[i] - upperBound[i]) < 4.94E-322 || Math.Abs(x0[i] - lowerBound[i]) < 4.94E-322)
				{
					list2[i] = 0.0;
				}
				else
				{
					list2[i] = double.PositiveInfinity;
				}
			}
			List<double> list3 = new List<double>(x0.Count);
			list3.AddRange(list2);
			list3.Sort();
			Vector<double> vector = -gradient;
			for (int j = 0; j < vector.Count; j++)
			{
				if (list2[j] <= 0.0)
				{
					vector[j] *= 0.0;
				}
			}
			int num = -1;
			Vector<double> vector2 = x0;
			double num2 = gradient * vector;
			double num3 = 0.5 * vector * hessian * vector;
			double num4 = (0.0 - num2) / num3;
			double num5 = list3[0];
			if (num4 < num5)
			{
				return new GradientProjectionResult(vector2 + num4 * vector, 0, list);
			}
			int num6;
			do
			{
				if (num + 1 >= list3.Count - 1)
				{
					list[list.Count - 1] = true;
					return new GradientProjectionResult(vector2 + num5 * vector, lowerBound.Count, list);
				}
				num++;
				vector2 += vector * num5;
				num5 = list3[num + 1] - list3[num];
				num6 = 0;
				for (int k = 0; k < vector.Count; k++)
				{
					if (list3[num] >= list2[k])
					{
						vector[k] *= 0.0;
						list[k] = true;
						num6++;
					}
				}
				if (double.IsPositiveInfinity(list3[num + 1]))
				{
					return new GradientProjectionResult(vector2, num6, list);
				}
				double num7 = gradient * vector + (vector2 - x0) * hessian * vector;
				num3 = vector * hessian * vector;
				num4 = (0.0 - num7) / num3;
			}
			while (!(num4 < num5));
			return new GradientProjectionResult(vector2 + num4 * vector, num6, list);
		}
	}
}
