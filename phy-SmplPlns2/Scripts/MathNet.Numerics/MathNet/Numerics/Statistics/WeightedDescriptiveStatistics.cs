using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Statistics
{
	[DataContract(Namespace = "urn:MathNet/Numerics")]
	public class WeightedDescriptiveStatistics
	{
		[DataMember(Order = 1)]
		public long Count { get; private set; }

		[DataMember(Order = 2)]
		public double Mean { get; private set; }

		[DataMember(Order = 3)]
		public double Variance { get; private set; }

		[DataMember(Order = 4)]
		public double StandardDeviation { get; private set; }

		[DataMember(Order = 5)]
		public double Skewness { get; private set; }

		[DataMember(Order = 6)]
		public double Kurtosis { get; private set; }

		[DataMember(Order = 7)]
		public double Maximum { get; private set; }

		[DataMember(Order = 8)]
		public double Minimum { get; private set; }

		[DataMember(Order = 9)]
		public double TotalWeight { get; private set; }

		[DataMember(Order = 10)]
		public double EffectiveSampleSize { get; private set; }

		public WeightedDescriptiveStatistics(IEnumerable<Tuple<double, double>> data, bool increasedAccuracy = false)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			IEnumerable<(double, double)> data2 = data.Select((Tuple<double, double> x) => (x.Item1, x.Item2));
			if (increasedAccuracy)
			{
				ComputeDecimal(data2);
			}
			else
			{
				Compute(data2);
			}
		}

		public WeightedDescriptiveStatistics(IEnumerable<(double, double)> data, bool increasedAccuracy = false)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (increasedAccuracy)
			{
				ComputeDecimal(data);
			}
			else
			{
				Compute(data);
			}
		}

		private void Compute(IEnumerable<(double, double)> data)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = double.PositiveInfinity;
			double num6 = double.NegativeInfinity;
			long num7 = 0L;
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			double num11 = 0.0;
			double num12 = 0.0;
			foreach (var (num13, num14) in data)
			{
				if (num13 < 0.0)
				{
					throw new ArgumentOutOfRangeException("data", num13, "Expected non-negative weighting of sample");
				}
				if (num13 > 0.0)
				{
					num7++;
					double num15 = num14 - num;
					double num16 = num8;
					num8 += num13;
					num10 += num13 * num13;
					num11 += num13 * num13 * num13;
					num12 += num13 * num13 * num13 * num13;
					num9 += num13 * (2.0 * num16 - num9) / num8;
					double num17 = num15 * num13 / num8;
					double num18 = num17 * num17;
					double num19 = num15 * num17 * num16;
					double num20 = num16 / num13;
					num += num17;
					num4 += num19 * num18 * (num20 * num20 - num20 + 1.0) + 6.0 * num18 * num2 - 4.0 * num17 * num3;
					num3 += num19 * num17 * (num20 - 1.0) - 3.0 * num17 * num2;
					num2 += num19;
					if (num5 > num14)
					{
						num5 = num14;
					}
					if (num6 < num14)
					{
						num6 = num14;
					}
				}
			}
			SetStatisticsWeighted(num, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12);
		}

		private void ComputeDecimal(IEnumerable<(double, double)> data)
		{
			decimal num = default(decimal);
			decimal num2 = default(decimal);
			decimal num3 = default(decimal);
			decimal num4 = default(decimal);
			decimal num5 = decimal.MaxValue;
			decimal num6 = decimal.MinValue;
			decimal num7 = default(decimal);
			long num8 = 0L;
			decimal num9 = default(decimal);
			decimal num10 = default(decimal);
			decimal num11 = default(decimal);
			decimal num12 = default(decimal);
			foreach (var (num13, num14) in data)
			{
				if (num13 < 0.0)
				{
					throw new ArgumentOutOfRangeException("data", num13, "Expected non-negative weighting of sample");
				}
				if (num13 > 0.0)
				{
					decimal num15 = (decimal)num14;
					decimal num16 = (decimal)num13;
					num8++;
					decimal num17 = num15 - num;
					decimal num18 = num7;
					num7 += num16;
					num10 += num16 * num16;
					num11 += num16 * num16 * num16;
					num12 += num16 * num16 * num16 * num16;
					num9 += num16 * (2.0m * num18 - num9) / num7;
					decimal num19 = num17 * num16 / num7;
					decimal num20 = num19 * num19;
					decimal num21 = num17 * num19 * num18;
					decimal num22 = num18 / num16;
					num += num19;
					num4 += num21 * num20 * (num22 * num22 - num22 + 1.0m) + 6.0m * num20 * num2 - 4.0m * num19 * num3;
					num3 += num21 * num19 * (num22 - 1.0m) - 3.0m * num19 * num2;
					num2 += num21;
					if (num5 > num15)
					{
						num5 = num15;
					}
					if (num6 < num15)
					{
						num6 = num15;
					}
				}
			}
			SetStatisticsWeighted((double)num, (double)num2, (double)num3, (double)num4, (double)num5, (double)num6, num8, (double)num7, (double)num9, (double)num10, (double)num11, (double)num12);
		}

		private void SetStatisticsWeighted(double mean, double variance, double skewness, double kurtosis, double minimum, double maximum, long n, double w1, double den, double w2, double w3, double w4)
		{
			Mean = mean;
			Count = n;
			TotalWeight = w1;
			EffectiveSampleSize = w1 * w1 / w2;
			Minimum = double.NaN;
			Maximum = double.NaN;
			Variance = double.NaN;
			StandardDeviation = double.NaN;
			Skewness = double.NaN;
			Kurtosis = double.NaN;
			if (n <= 0)
			{
				return;
			}
			Minimum = minimum;
			Maximum = maximum;
			if (n > 1)
			{
				Variance = variance / den;
				StandardDeviation = Math.Sqrt(Variance);
			}
			if (Variance != 0.0)
			{
				if (n > 2)
				{
					double num = (w1 * (w1 * w1 - 3.0 * w2) + 2.0 * w3) / (w1 * w1);
					Skewness = skewness / (num * Variance * StandardDeviation);
				}
				if (n > 3)
				{
					double num2 = w1 * w1;
					double num3 = num2 * num2;
					double num4 = w2 * w2;
					double num5 = num3 - 6.0 * num2 * w2 + 8.0 * w1 * w3 + 3.0 * num4 - 6.0 * w4;
					double num6 = num3 - 4.0 * w1 * w3 + 3.0 * num4;
					double num7 = 3.0 * (num3 - 2.0 * num2 * w2 + 4.0 * w1 * w3 - 3.0 * num4);
					Kurtosis = (num6 * w1 * kurtosis / (variance * variance) - num7) * (den / (w1 * num5));
				}
			}
		}
	}
}
