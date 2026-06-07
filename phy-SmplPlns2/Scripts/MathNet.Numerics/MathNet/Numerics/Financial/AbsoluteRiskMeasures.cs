using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Statistics;

namespace MathNet.Numerics.Financial
{
	public static class AbsoluteRiskMeasures
	{
		public static double GainStandardDeviation(this IEnumerable<double> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return data.Where((double x) => x >= 0.0).StandardDeviation();
		}

		public static double LossStandardDeviation(this IEnumerable<double> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return data.Where((double x) => x < 0.0).StandardDeviation();
		}

		public static double DownsideDeviation(this IEnumerable<double> data, double minimalAcceptableReturn)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return data.Where((double x) => x < minimalAcceptableReturn).StandardDeviation();
		}

		public static double SemiDeviation(this IEnumerable<double> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			double mean = data.Mean();
			return data.Where((double x) => x < mean).StandardDeviation();
		}

		public static double GainLossRatio(this IEnumerable<double> data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			IEnumerable<double> data2 = data.Where((double x) => x >= 0.0);
			IEnumerable<double> data3 = data.Where((double x) => x < 0.0);
			return Math.Abs(data2.Mean() / data3.Mean());
		}
	}
}
