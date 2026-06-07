using System;
using System.Collections.Generic;

namespace MathNet.Numerics.RootFinding
{
	public static class ZeroCrossingBracketing
	{
		public static IEnumerable<(double, double)> FindIntervalsWithin(Func<double, double> f, double lowerBound, double upperBound, int subdivisions)
		{
			double value = f(lowerBound);
			double value2 = f(upperBound);
			if (Math.Sign(value) != Math.Sign(value2))
			{
				yield return (lowerBound, upperBound);
				yield break;
			}
			double subdiv = (upperBound - lowerBound) / (double)subdivisions;
			double num = lowerBound;
			int num2 = Math.Sign(value);
			for (int k = 0; k < subdivisions; k++)
			{
				double smax = num + subdiv;
				double sfmax = f(smax);
				if (double.IsInfinity(sfmax))
				{
					num = smax;
					continue;
				}
				if (Math.Sign(sfmax) != num2)
				{
					yield return (num, smax);
					num2 = Math.Sign(sfmax);
				}
				num = smax;
			}
		}

		public static bool Expand(Func<double, double> f, ref double lowerBound, ref double upperBound, double factor = 1.6, int maxIterations = 50)
		{
			double num = lowerBound;
			double num2 = upperBound;
			if (lowerBound >= upperBound)
			{
				throw new ArgumentOutOfRangeException("upperBound", "xmax must be greater than xmin.");
			}
			double value = f(lowerBound);
			double value2 = f(upperBound);
			for (int i = 0; i < maxIterations; i++)
			{
				if (Math.Sign(value) != Math.Sign(value2))
				{
					return true;
				}
				if (Math.Abs(value) < Math.Abs(value2))
				{
					lowerBound += factor * (lowerBound - upperBound);
					value = f(lowerBound);
				}
				else
				{
					upperBound += factor * (upperBound - lowerBound);
					value2 = f(upperBound);
				}
			}
			lowerBound = num;
			upperBound = num2;
			return false;
		}

		public static bool Reduce(Func<double, double> f, ref double lowerBound, ref double upperBound, int subdivisions = 1000)
		{
			double num = lowerBound;
			double num2 = upperBound;
			if (lowerBound >= upperBound)
			{
				throw new ArgumentOutOfRangeException("upperBound", "xmax must be greater than xmin.");
			}
			double value = f(lowerBound);
			double value2 = f(upperBound);
			if (Math.Sign(value) != Math.Sign(value2))
			{
				return true;
			}
			double num3 = (upperBound - lowerBound) / (double)subdivisions;
			double num4 = lowerBound;
			int num5 = Math.Sign(value);
			for (int i = 0; i < subdivisions; i++)
			{
				double num6 = num4 + num3;
				double num7 = f(num6);
				if (double.IsInfinity(num7))
				{
					num4 = num6;
					continue;
				}
				if (Math.Sign(num7) != num5)
				{
					lowerBound = num4;
					upperBound = num6;
					return true;
				}
				num4 = num6;
			}
			lowerBound = num;
			upperBound = num2;
			return false;
		}

		public static bool ExpandReduce(Func<double, double> f, ref double lowerBound, ref double upperBound, double expansionFactor = 1.6, int expansionMaxIterations = 50, int reduceSubdivisions = 100)
		{
			if (!Expand(f, ref lowerBound, ref upperBound, expansionFactor, expansionMaxIterations))
			{
				return Reduce(f, ref lowerBound, ref upperBound, reduceSubdivisions);
			}
			return true;
		}
	}
}
