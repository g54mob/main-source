using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MathNet.Numerics.Statistics
{
	public static class StreamingStatistics
	{
		public static double Minimum(IEnumerable<double> stream)
		{
			double num = double.PositiveInfinity;
			bool flag = false;
			foreach (double item in stream)
			{
				if (item < num || double.IsNaN(item))
				{
					num = item;
				}
				flag = true;
			}
			if (!flag)
			{
				return double.NaN;
			}
			return num;
		}

		public static float Minimum(IEnumerable<float> stream)
		{
			float num = float.PositiveInfinity;
			bool flag = false;
			foreach (float item in stream)
			{
				if (item < num || float.IsNaN(item))
				{
					num = item;
				}
				flag = true;
			}
			if (!flag)
			{
				return float.NaN;
			}
			return num;
		}

		public static double Maximum(IEnumerable<double> stream)
		{
			double num = double.NegativeInfinity;
			bool flag = false;
			foreach (double item in stream)
			{
				if (item > num || double.IsNaN(item))
				{
					num = item;
				}
				flag = true;
			}
			if (!flag)
			{
				return double.NaN;
			}
			return num;
		}

		public static float Maximum(IEnumerable<float> stream)
		{
			float num = float.NegativeInfinity;
			bool flag = false;
			foreach (float item in stream)
			{
				if (item > num || float.IsNaN(item))
				{
					num = item;
				}
				flag = true;
			}
			if (!flag)
			{
				return float.NaN;
			}
			return num;
		}

		public static double MinimumAbsolute(IEnumerable<double> stream)
		{
			double num = double.PositiveInfinity;
			bool flag = false;
			foreach (double item in stream)
			{
				if (Math.Abs(item) < num || double.IsNaN(item))
				{
					num = Math.Abs(item);
				}
				flag = true;
			}
			if (!flag)
			{
				return double.NaN;
			}
			return num;
		}

		public static float MinimumAbsolute(IEnumerable<float> stream)
		{
			float num = float.PositiveInfinity;
			bool flag = false;
			foreach (float item in stream)
			{
				if (Math.Abs(item) < num || float.IsNaN(item))
				{
					num = Math.Abs(item);
				}
				flag = true;
			}
			if (!flag)
			{
				return float.NaN;
			}
			return num;
		}

		public static double MaximumAbsolute(IEnumerable<double> stream)
		{
			double num = 0.0;
			bool flag = false;
			foreach (double item in stream)
			{
				if (Math.Abs(item) > num || double.IsNaN(item))
				{
					num = Math.Abs(item);
				}
				flag = true;
			}
			if (!flag)
			{
				return double.NaN;
			}
			return num;
		}

		public static float MaximumAbsolute(IEnumerable<float> stream)
		{
			float num = 0f;
			bool flag = false;
			foreach (float item in stream)
			{
				if (Math.Abs(item) > num || float.IsNaN(item))
				{
					num = Math.Abs(item);
				}
				flag = true;
			}
			if (!flag)
			{
				return float.NaN;
			}
			return num;
		}

		public static Complex MinimumMagnitudePhase(IEnumerable<Complex> stream)
		{
			double num = double.PositiveInfinity;
			Complex result = new Complex(double.PositiveInfinity, double.PositiveInfinity);
			bool flag = false;
			foreach (Complex item in stream)
			{
				double magnitude = item.Magnitude;
				if (double.IsNaN(magnitude))
				{
					return new Complex(double.NaN, double.NaN);
				}
				if (magnitude < num || (magnitude == num && item.Phase < result.Phase))
				{
					num = magnitude;
					result = item;
				}
				flag = true;
			}
			if (!flag)
			{
				return new Complex(double.NaN, double.NaN);
			}
			return result;
		}

		public static Complex32 MinimumMagnitudePhase(IEnumerable<Complex32> stream)
		{
			float num = float.PositiveInfinity;
			Complex32 result = new Complex32(float.PositiveInfinity, float.PositiveInfinity);
			bool flag = false;
			foreach (Complex32 item in stream)
			{
				float magnitude = item.Magnitude;
				if (float.IsNaN(magnitude))
				{
					return new Complex32(float.NaN, float.NaN);
				}
				if (magnitude < num || (magnitude == num && item.Phase < result.Phase))
				{
					num = magnitude;
					result = item;
				}
				flag = true;
			}
			if (!flag)
			{
				return new Complex32(float.NaN, float.NaN);
			}
			return result;
		}

		public static Complex MaximumMagnitudePhase(IEnumerable<Complex> stream)
		{
			double num = 0.0;
			Complex result = Complex.Zero;
			bool flag = false;
			foreach (Complex item in stream)
			{
				double magnitude = item.Magnitude;
				if (double.IsNaN(magnitude))
				{
					return new Complex(double.NaN, double.NaN);
				}
				if (magnitude > num || (magnitude == num && item.Phase > result.Phase))
				{
					num = magnitude;
					result = item;
				}
				flag = true;
			}
			if (!flag)
			{
				return new Complex(double.NaN, double.NaN);
			}
			return result;
		}

		public static Complex32 MaximumMagnitudePhase(IEnumerable<Complex32> stream)
		{
			float num = 0f;
			Complex32 result = Complex32.Zero;
			bool flag = false;
			foreach (Complex32 item in stream)
			{
				float magnitude = item.Magnitude;
				if (float.IsNaN(magnitude))
				{
					return new Complex32(float.NaN, float.NaN);
				}
				if (magnitude > num || (magnitude == num && item.Phase > result.Phase))
				{
					num = magnitude;
					result = item;
				}
				flag = true;
			}
			if (!flag)
			{
				return new Complex32(float.NaN, float.NaN);
			}
			return result;
		}

		public static double Mean(IEnumerable<double> stream)
		{
			double num = 0.0;
			ulong num2 = 0uL;
			bool flag = false;
			foreach (double item in stream)
			{
				num += (item - num) / (double)(++num2);
				flag = true;
			}
			if (!flag)
			{
				return double.NaN;
			}
			return num;
		}

		public static double Mean(IEnumerable<float> stream)
		{
			return Mean(stream.Select((Func<float, double>)((float x) => x)));
		}

		public static double GeometricMean(IEnumerable<double> stream)
		{
			ulong num = 0uL;
			double num2 = 0.0;
			foreach (double item in stream)
			{
				num2 += Math.Log(item);
				num++;
			}
			if (num == 0)
			{
				return double.NaN;
			}
			return Math.Exp(num2 / (double)num);
		}

		public static double GeometricMean(IEnumerable<float> stream)
		{
			return GeometricMean(stream.Select((Func<float, double>)((float x) => x)));
		}

		public static double HarmonicMean(IEnumerable<double> stream)
		{
			ulong num = 0uL;
			double num2 = 0.0;
			foreach (double item in stream)
			{
				num2 += 1.0 / item;
				num++;
			}
			if (num == 0)
			{
				return double.NaN;
			}
			return (double)num / num2;
		}

		public static double HarmonicMean(IEnumerable<float> stream)
		{
			return HarmonicMean(stream.Select((Func<float, double>)((float x) => x)));
		}

		public static double Variance(IEnumerable<double> samples)
		{
			double num = 0.0;
			double num2 = 0.0;
			ulong num3 = 0uL;
			using (IEnumerator<double> enumerator = samples.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					num3++;
					num2 = enumerator.Current;
				}
				while (enumerator.MoveNext())
				{
					num3++;
					double current = enumerator.Current;
					num2 += current;
					double num4 = (double)num3 * current - num2;
					num += num4 * num4 / (double)(num3 * (num3 - 1));
				}
			}
			if (num3 <= 1)
			{
				return double.NaN;
			}
			return num / (double)(num3 - 1);
		}

		public static double Variance(IEnumerable<float> samples)
		{
			return Variance(samples.Select((Func<float, double>)((float x) => x)));
		}

		public static double PopulationVariance(IEnumerable<double> population)
		{
			double num = 0.0;
			double num2 = 0.0;
			ulong num3 = 0uL;
			using (IEnumerator<double> enumerator = population.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					num3++;
					num2 = enumerator.Current;
				}
				while (enumerator.MoveNext())
				{
					num3++;
					double current = enumerator.Current;
					num2 += current;
					double num4 = (double)num3 * current - num2;
					num += num4 * num4 / (double)(num3 * (num3 - 1));
				}
			}
			return num / (double)num3;
		}

		public static double PopulationVariance(IEnumerable<float> population)
		{
			return PopulationVariance(population.Select((Func<float, double>)((float x) => x)));
		}

		public static double StandardDeviation(IEnumerable<double> samples)
		{
			return Math.Sqrt(Variance(samples));
		}

		public static double StandardDeviation(IEnumerable<float> samples)
		{
			return Math.Sqrt(Variance(samples));
		}

		public static double PopulationStandardDeviation(IEnumerable<double> population)
		{
			return Math.Sqrt(PopulationVariance(population));
		}

		public static double PopulationStandardDeviation(IEnumerable<float> population)
		{
			return Math.Sqrt(PopulationVariance(population));
		}

		public static (double Mean, double Variance) MeanVariance(IEnumerable<double> samples)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			ulong num4 = 0uL;
			using (IEnumerator<double> enumerator = samples.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					num4++;
					num3 = (num = enumerator.Current);
				}
				while (enumerator.MoveNext())
				{
					num4++;
					double current = enumerator.Current;
					num3 += current;
					double num5 = (double)num4 * current - num3;
					num2 += num5 * num5 / (double)(num4 * (num4 - 1));
					num += (current - num) / (double)num4;
				}
			}
			return (Mean: (num4 != 0) ? num : double.NaN, Variance: (num4 > 1) ? (num2 / (double)(num4 - 1)) : double.NaN);
		}

		public static (double Mean, double Variance) MeanVariance(IEnumerable<float> samples)
		{
			return MeanVariance(samples.Select((Func<float, double>)((float x) => x)));
		}

		public static (double Mean, double StandardDeviation) MeanStandardDeviation(IEnumerable<double> samples)
		{
			(double, double) tuple = MeanVariance(samples);
			return (Mean: tuple.Item1, StandardDeviation: Math.Sqrt(tuple.Item2));
		}

		public static (double Mean, double StandardDeviation) MeanStandardDeviation(IEnumerable<float> samples)
		{
			return MeanStandardDeviation(samples.Select((Func<float, double>)((float x) => x)));
		}

		public static double Covariance(IEnumerable<double> samples1, IEnumerable<double> samples2)
		{
			int num = 0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			using (IEnumerator<double> enumerator = samples1.GetEnumerator())
			{
				using IEnumerator<double> enumerator2 = samples2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (!enumerator2.MoveNext())
					{
						throw new ArgumentException("All vectors must have the same dimensionality.");
					}
					double num5 = num3;
					num++;
					num2 += (enumerator.Current - num2) / (double)num;
					num3 += (enumerator2.Current - num3) / (double)num;
					num4 += (enumerator.Current - num2) * (enumerator2.Current - num5);
				}
				if (enumerator2.MoveNext())
				{
					throw new ArgumentException("All vectors must have the same dimensionality.");
				}
			}
			if (num <= 1)
			{
				return double.NaN;
			}
			return num4 / (double)(num - 1);
		}

		public static double Covariance(IEnumerable<float> samples1, IEnumerable<float> samples2)
		{
			return Covariance(samples1.Select((Func<float, double>)((float x) => x)), samples2.Select((Func<float, double>)((float x) => x)));
		}

		public static double PopulationCovariance(IEnumerable<double> population1, IEnumerable<double> population2)
		{
			int num = 0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			using (IEnumerator<double> enumerator = population1.GetEnumerator())
			{
				using IEnumerator<double> enumerator2 = population2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (!enumerator2.MoveNext())
					{
						throw new ArgumentException("All vectors must have the same dimensionality.");
					}
					double num5 = num3;
					num++;
					num2 += (enumerator.Current - num2) / (double)num;
					num3 += (enumerator2.Current - num3) / (double)num;
					num4 += (enumerator.Current - num2) * (enumerator2.Current - num5);
				}
				if (enumerator2.MoveNext())
				{
					throw new ArgumentException("All vectors must have the same dimensionality.");
				}
			}
			return num4 / (double)num;
		}

		public static double PopulationCovariance(IEnumerable<float> population1, IEnumerable<float> population2)
		{
			return PopulationCovariance(population1.Select((Func<float, double>)((float x) => x)), population2.Select((Func<float, double>)((float x) => x)));
		}

		public static double RootMeanSquare(IEnumerable<double> stream)
		{
			double num = 0.0;
			ulong num2 = 0uL;
			bool flag = false;
			foreach (double item in stream)
			{
				num += (item * item - num) / (double)(++num2);
				flag = true;
			}
			if (!flag)
			{
				return double.NaN;
			}
			return Math.Sqrt(num);
		}

		public static double RootMeanSquare(IEnumerable<float> stream)
		{
			return RootMeanSquare(stream.Select((Func<float, double>)((float x) => x)));
		}

		public static double Entropy(IEnumerable<double> stream)
		{
			Dictionary<double, double> dictionary = new Dictionary<double, double>();
			int num = 0;
			foreach (double item in stream)
			{
				if (double.IsNaN(item))
				{
					return double.NaN;
				}
				if (dictionary.TryGetValue(item, out var value))
				{
					value = (dictionary[item] = value + 1.0);
				}
				else
				{
					dictionary.Add(item, 1.0);
				}
				num++;
			}
			double num3 = 0.0;
			foreach (KeyValuePair<double, double> item2 in dictionary)
			{
				double num4 = item2.Value / (double)num;
				num3 += num4 * Math.Log(num4, 2.0);
			}
			return 0.0 - num3;
		}
	}
}
