using System;
using System.Collections.Generic;
using MathNet.Numerics.Statistics;

namespace MathNet.Numerics
{
	public static class GoodnessOfFit
	{
		public static double RSquared(IEnumerable<double> modelledValues, IEnumerable<double> observedValues)
		{
			double num = Correlation.Pearson(modelledValues, observedValues);
			return num * num;
		}

		public static double R(IEnumerable<double> modelledValues, IEnumerable<double> observedValues)
		{
			return Correlation.Pearson(modelledValues, observedValues);
		}

		public static double PopulationStandardError(IEnumerable<double> modelledValues, IEnumerable<double> observedValues)
		{
			return StandardError(modelledValues, observedValues, 0);
		}

		public static double StandardError(IEnumerable<double> modelledValues, IEnumerable<double> observedValues, int degreesOfFreedom)
		{
			using IEnumerator<double> enumerator = modelledValues.GetEnumerator();
			using IEnumerator<double> enumerator2 = observedValues.GetEnumerator();
			double num = 0.0;
			double num2 = 0.0;
			while (enumerator.MoveNext())
			{
				if (!enumerator2.MoveNext())
				{
					throw new ArgumentOutOfRangeException("modelledValues", "The array arguments must have the same length.");
				}
				double current = enumerator.Current;
				double current2 = enumerator2.Current;
				double num3 = current - current2;
				num2 += num3 * num3;
				num += 1.0;
			}
			if ((double)degreesOfFreedom >= num)
			{
				throw new ArgumentOutOfRangeException("degreesOfFreedom", "The sample size must be larger than the given degrees of freedom.");
			}
			return Math.Sqrt(num2 / (num - (double)degreesOfFreedom));
		}

		public static double CoefficientOfDetermination(IEnumerable<double> modelledValues, IEnumerable<double> observedValues)
		{
			int num = 0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			using (IEnumerator<double> enumerator = observedValues.GetEnumerator())
			{
				using IEnumerator<double> enumerator2 = modelledValues.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (!enumerator2.MoveNext())
					{
						throw new ArgumentOutOfRangeException("modelledValues", "The array arguments must have the same length.");
					}
					double current = enumerator.Current;
					double current2 = enumerator2.Current;
					double num5 = current - num2;
					double num6 = num5 / (double)(++num);
					num2 += num6;
					num3 += num6 * num5 * (double)(num - 1);
					num4 += (current - current2) * (current - current2);
				}
				if (enumerator2.MoveNext())
				{
					throw new ArgumentOutOfRangeException("observedValues", "The array arguments must have the same length.");
				}
			}
			return 1.0 - num4 / num3;
		}
	}
}
