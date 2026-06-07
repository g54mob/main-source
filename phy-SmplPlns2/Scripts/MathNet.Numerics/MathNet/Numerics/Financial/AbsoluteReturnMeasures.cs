using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Statistics;

namespace MathNet.Numerics.Financial
{
	public static class AbsoluteReturnMeasures
	{
		public static double CompoundReturn(this IEnumerable<double> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			int num = 0;
			double num2 = 1.0;
			foreach (double datum in data)
			{
				num++;
				num2 *= 1.0 + datum;
			}
			if (num != 0)
			{
				return Math.Pow(num2, 1.0 / (double)num) - 1.0;
			}
			return double.NaN;
		}

		public static double GainMean(this IEnumerable<double> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return data.Where((double x) => x >= 0.0).Mean();
		}

		public static double LossMean(this IEnumerable<double> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return data.Where((double x) => x < 0.0).Mean();
		}
	}
}
