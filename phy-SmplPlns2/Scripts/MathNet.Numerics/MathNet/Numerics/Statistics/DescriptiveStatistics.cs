using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MathNet.Numerics.Statistics
{
	[DataContract(Namespace = "urn:MathNet/Numerics")]
	public class DescriptiveStatistics
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

		public DescriptiveStatistics(IEnumerable<double> data, bool increasedAccuracy = false)
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

		public DescriptiveStatistics(IEnumerable<double?> data, bool increasedAccuracy = false)
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

		private void Compute(IEnumerable<double> data)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = double.PositiveInfinity;
			double num6 = double.NegativeInfinity;
			long num7 = 0L;
			foreach (double datum in data)
			{
				double num8 = datum - num;
				double num9 = num8 / (double)(++num7);
				double num10 = num9 * num9;
				double num11 = num8 * (double)(num7 - 1);
				num += num9;
				num4 += num11 * num9 * num10 * (double)(num7 * num7 - 3 * num7 + 3) + 6.0 * num10 * num2 - 4.0 * num9 * num3;
				num3 += num11 * num10 * (double)(num7 - 2) - 3.0 * num9 * num2;
				num2 += num11 * num9;
				if (num5 > datum)
				{
					num5 = datum;
				}
				if (num6 < datum)
				{
					num6 = datum;
				}
			}
			SetStatistics(num, num2, num3, num4, num5, num6, num7);
		}

		private void Compute(IEnumerable<double?> data)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = double.PositiveInfinity;
			double num6 = double.NegativeInfinity;
			long num7 = 0L;
			foreach (double? datum in data)
			{
				if (datum.HasValue)
				{
					double num8 = datum.Value - num;
					double num9 = num8 / (double)(++num7);
					double num10 = num9 * num9;
					double num11 = num8 * (double)(num7 - 1);
					num += num9;
					num4 += num11 * num9 * num10 * (double)(num7 * num7 - 3 * num7 + 3) + 6.0 * num10 * num2 - 4.0 * num9 * num3;
					num3 += num11 * num10 * (double)(num7 - 2) - 3.0 * num9 * num2;
					num2 += num11 * num9;
					if (num5 > datum)
					{
						num5 = datum.Value;
					}
					if (num6 < datum)
					{
						num6 = datum.Value;
					}
				}
			}
			SetStatistics(num, num2, num3, num4, num5, num6, num7);
		}

		private void ComputeDecimal(IEnumerable<double> data)
		{
			decimal num = default(decimal);
			decimal num2 = default(decimal);
			decimal num3 = default(decimal);
			decimal num4 = default(decimal);
			decimal num5 = decimal.MaxValue;
			decimal num6 = decimal.MinValue;
			long num7 = 0L;
			foreach (double datum in data)
			{
				decimal num8 = (decimal)datum;
				decimal num9 = num8 - num;
				decimal num10 = num9 / (decimal)(num7 += 1);
				decimal num11 = num10 * num10;
				decimal num12 = num9 * (decimal)(num7 - 1);
				num += num10;
				num4 += num12 * num10 * num11 * (decimal)(num7 * num7 - 3 * num7 + 3) + 6m * num11 * num2 - 4m * num10 * num3;
				num3 += num12 * num11 * (decimal)(num7 - 2) - 3m * num10 * num2;
				num2 += num12 * num10;
				if (num5 > num8)
				{
					num5 = num8;
				}
				if (num6 < num8)
				{
					num6 = num8;
				}
			}
			SetStatistics((double)num, (double)num2, (double)num3, (double)num4, (double)num5, (double)num6, num7);
		}

		private void ComputeDecimal(IEnumerable<double?> data)
		{
			decimal num = default(decimal);
			decimal num2 = default(decimal);
			decimal num3 = default(decimal);
			decimal num4 = default(decimal);
			decimal num5 = decimal.MaxValue;
			decimal num6 = decimal.MinValue;
			long num7 = 0L;
			foreach (double? datum in data)
			{
				if (datum.HasValue)
				{
					decimal num8 = (decimal)datum.Value;
					decimal num9 = num8 - num;
					decimal num10 = num9 / (decimal)(num7 += 1);
					decimal num11 = num10 * num10;
					decimal num12 = num9 * (decimal)(num7 - 1);
					num += num10;
					num4 += num12 * num10 * num11 * (decimal)(num7 * num7 - 3 * num7 + 3) + 6m * num11 * num2 - 4m * num10 * num3;
					num3 += num12 * num11 * (decimal)(num7 - 2) - 3m * num10 * num2;
					num2 += num12 * num10;
					if (num5 > num8)
					{
						num5 = num8;
					}
					if (num6 < num8)
					{
						num6 = num8;
					}
				}
			}
			SetStatistics((double)num, (double)num2, (double)num3, (double)num4, (double)num5, (double)num6, num7);
		}

		private void SetStatistics(double mean, double variance, double skewness, double kurtosis, double minimum, double maximum, long n)
		{
			Mean = mean;
			Count = n;
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
				Variance = variance / (double)(n - 1);
				StandardDeviation = Math.Sqrt(Variance);
			}
			if (Variance != 0.0)
			{
				if (n > 2)
				{
					Skewness = (double)n / (double)((n - 1) * (n - 2)) * (skewness / (Variance * StandardDeviation));
				}
				if (n > 3)
				{
					Kurtosis = ((double)n * (double)n - 1.0) / (double)((n - 2) * (n - 3)) * ((double)n * kurtosis / (variance * variance) - 3.0 + 6.0 / (double)(n + 1));
				}
			}
		}
	}
}
