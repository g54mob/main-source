using System;
using System.Collections.Generic;
using System.Linq;

namespace MathNet.Numerics.Statistics.Mcmc
{
	public static class MCMCDiagnostics
	{
		public static double ACF<T>(IEnumerable<T> series, int lag, Func<T, double> f)
		{
			if (lag < 0)
			{
				throw new ArgumentOutOfRangeException("lag", "Lag must be positive");
			}
			int num = series.Count();
			if (lag >= num)
			{
				throw new ArgumentOutOfRangeException("lag", "Lag must be smaller than the sample size");
			}
			IEnumerable<double> enumerable = series.Select(f);
			double[] source = (enumerable as double[]) ?? enumerable.ToArray();
			IEnumerable<double> dataA = source.Take(num - lag);
			IEnumerable<double> dataB = source.Skip(lag);
			return Correlation.Pearson(dataA, dataB);
		}

		public static double EffectiveSize<T>(IEnumerable<T> series, Func<T, double> f)
		{
			int num = series.Count();
			double num2 = ACF(series, 1, f);
			return (1.0 - num2) / (1.0 + num2) * (double)num;
		}
	}
}
