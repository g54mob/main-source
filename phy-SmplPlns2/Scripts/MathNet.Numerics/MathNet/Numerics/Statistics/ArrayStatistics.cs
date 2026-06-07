using System;
using System.Numerics;

namespace MathNet.Numerics.Statistics
{
	public static class ArrayStatistics
	{
		public static Complex MinimumMagnitudePhase(Complex[] data)
		{
			if (data.Length == 0)
			{
				return new Complex(double.NaN, double.NaN);
			}
			double num = double.PositiveInfinity;
			Complex result = new Complex(double.PositiveInfinity, double.PositiveInfinity);
			for (int i = 0; i < data.Length; i++)
			{
				double magnitude = data[i].Magnitude;
				if (double.IsNaN(magnitude))
				{
					return new Complex(double.NaN, double.NaN);
				}
				if (magnitude < num || (magnitude == num && data[i].Phase < result.Phase))
				{
					num = magnitude;
					result = data[i];
				}
			}
			return result;
		}

		public static Complex32 MinimumMagnitudePhase(Complex32[] data)
		{
			if (data.Length == 0)
			{
				return new Complex32(float.NaN, float.NaN);
			}
			float num = float.PositiveInfinity;
			Complex32 result = new Complex32(float.PositiveInfinity, float.PositiveInfinity);
			for (int i = 0; i < data.Length; i++)
			{
				float magnitude = data[i].Magnitude;
				if (float.IsNaN(magnitude))
				{
					return new Complex32(float.NaN, float.NaN);
				}
				if (magnitude < num || (magnitude == num && data[i].Phase < result.Phase))
				{
					num = magnitude;
					result = data[i];
				}
			}
			return result;
		}

		public static Complex MaximumMagnitudePhase(Complex[] data)
		{
			if (data.Length == 0)
			{
				return new Complex(double.NaN, double.NaN);
			}
			double num = 0.0;
			Complex result = Complex.Zero;
			for (int i = 0; i < data.Length; i++)
			{
				double magnitude = data[i].Magnitude;
				if (double.IsNaN(magnitude))
				{
					return new Complex(double.NaN, double.NaN);
				}
				if (magnitude > num || (magnitude == num && data[i].Phase > result.Phase))
				{
					num = magnitude;
					result = data[i];
				}
			}
			return result;
		}

		public static Complex32 MaximumMagnitudePhase(Complex32[] data)
		{
			if (data.Length == 0)
			{
				return new Complex32(float.NaN, float.NaN);
			}
			float num = 0f;
			Complex32 result = Complex32.Zero;
			for (int i = 0; i < data.Length; i++)
			{
				float magnitude = data[i].Magnitude;
				if (float.IsNaN(magnitude))
				{
					return new Complex32(float.NaN, float.NaN);
				}
				if (magnitude > num || (magnitude == num && data[i].Phase > result.Phase))
				{
					num = magnitude;
					result = data[i];
				}
			}
			return result;
		}

		public static double Minimum(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = double.PositiveInfinity;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] < num || double.IsNaN(data[i]))
				{
					num = data[i];
				}
			}
			return num;
		}

		public static double Maximum(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = double.NegativeInfinity;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] > num || double.IsNaN(data[i]))
				{
					num = data[i];
				}
			}
			return num;
		}

		public static double MinimumAbsolute(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = double.PositiveInfinity;
			for (int i = 0; i < data.Length; i++)
			{
				if (Math.Abs(data[i]) < num || double.IsNaN(data[i]))
				{
					num = Math.Abs(data[i]);
				}
			}
			return num;
		}

		public static double MaximumAbsolute(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			for (int i = 0; i < data.Length; i++)
			{
				if (Math.Abs(data[i]) > num || double.IsNaN(data[i]))
				{
					num = Math.Abs(data[i]);
				}
			}
			return num;
		}

		public static double Mean(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			ulong num2 = 0uL;
			for (int i = 0; i < data.Length; i++)
			{
				num += (data[i] - num) / (double)(++num2);
			}
			return num;
		}

		public static double GeometricMean(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			for (int i = 0; i < data.Length; i++)
			{
				num += Math.Log(data[i]);
			}
			return Math.Exp(num / (double)data.Length);
		}

		public static double HarmonicMean(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			for (int i = 0; i < data.Length; i++)
			{
				num += 1.0 / data[i];
			}
			return (double)data.Length / num;
		}

		public static double Variance(double[] samples)
		{
			if (samples.Length <= 1)
			{
				return double.NaN;
			}
			double num = 0.0;
			double num2 = samples[0];
			for (int i = 1; i < samples.Length; i++)
			{
				num2 += samples[i];
				double num3 = (double)(i + 1) * samples[i] - num2;
				num += num3 * num3 / (((double)i + 1.0) * (double)i);
			}
			return num / (double)(samples.Length - 1);
		}

		public static double PopulationVariance(double[] population)
		{
			if (population.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			double num2 = population[0];
			for (int i = 1; i < population.Length; i++)
			{
				num2 += population[i];
				double num3 = (double)(i + 1) * population[i] - num2;
				num += num3 * num3 / (((double)i + 1.0) * (double)i);
			}
			return num / (double)population.Length;
		}

		public static double StandardDeviation(double[] samples)
		{
			return Math.Sqrt(Variance(samples));
		}

		public static double PopulationStandardDeviation(double[] population)
		{
			return Math.Sqrt(PopulationVariance(population));
		}

		public static (double Mean, double Variance) MeanVariance(double[] samples)
		{
			return (Mean: Mean(samples), Variance: Variance(samples));
		}

		public static (double Mean, double StandardDeviation) MeanStandardDeviation(double[] samples)
		{
			return (Mean: Mean(samples), StandardDeviation: StandardDeviation(samples));
		}

		public static double Covariance(double[] samples1, double[] samples2)
		{
			if (samples1.Length != samples2.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (samples1.Length <= 1)
			{
				return double.NaN;
			}
			double num = Mean(samples1);
			double num2 = Mean(samples2);
			double num3 = 0.0;
			for (int i = 0; i < samples1.Length; i++)
			{
				num3 += (samples1[i] - num) * (samples2[i] - num2);
			}
			return num3 / (double)(samples1.Length - 1);
		}

		public static double PopulationCovariance(double[] population1, double[] population2)
		{
			if (population1.Length != population2.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (population1.Length == 0)
			{
				return double.NaN;
			}
			double num = Mean(population1);
			double num2 = Mean(population2);
			double num3 = 0.0;
			for (int i = 0; i < population1.Length; i++)
			{
				num3 += (population1[i] - num) * (population2[i] - num2);
			}
			return num3 / (double)population1.Length;
		}

		public static double RootMeanSquare(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			ulong num2 = 0uL;
			for (int i = 0; i < data.Length; i++)
			{
				num += (data[i] * data[i] - num) / (double)(++num2);
			}
			return Math.Sqrt(num);
		}

		public static double OrderStatisticInplace(double[] data, int order)
		{
			if (order < 1 || order > data.Length)
			{
				return double.NaN;
			}
			if (order == 1)
			{
				return Minimum(data);
			}
			if (order == data.Length)
			{
				return Maximum(data);
			}
			return SelectInplace(data, order - 1);
		}

		public static double MedianInplace(double[] data)
		{
			int num = data.Length / 2;
			if (!data.Length.IsOdd())
			{
				return (SelectInplace(data, num - 1) + SelectInplace(data, num)) / 2.0;
			}
			return SelectInplace(data, num);
		}

		public static double PercentileInplace(double[] data, int p)
		{
			return QuantileInplace(data, (double)p / 100.0);
		}

		public static double LowerQuartileInplace(double[] data)
		{
			return QuantileInplace(data, 0.25);
		}

		public static double UpperQuartileInplace(double[] data)
		{
			return QuantileInplace(data, 0.75);
		}

		public static double InterquartileRangeInplace(double[] data)
		{
			return QuantileInplace(data, 0.75) - QuantileInplace(data, 0.25);
		}

		public static double[] FiveNumberSummaryInplace(double[] data)
		{
			if (data.Length != 0)
			{
				return new double[5]
				{
					Minimum(data),
					QuantileInplace(data, 0.25),
					MedianInplace(data),
					QuantileInplace(data, 0.75),
					Maximum(data)
				};
			}
			return new double[5]
			{
				double.NaN,
				double.NaN,
				double.NaN,
				double.NaN,
				double.NaN
			};
		}

		public static double QuantileInplace(double[] data, double tau)
		{
			if (tau < 0.0 || tau > 1.0 || data.Length == 0)
			{
				return double.NaN;
			}
			double num = ((double)data.Length + 1.0 / 3.0) * tau + 1.0 / 3.0;
			int num2 = (int)num;
			if (num2 <= 0 || tau == 0.0)
			{
				return Minimum(data);
			}
			if (num2 >= data.Length || tau == 1.0)
			{
				return Maximum(data);
			}
			double num3 = SelectInplace(data, num2 - 1);
			double num4 = SelectInplace(data, num2);
			return num3 + (num - (double)num2) * (num4 - num3);
		}

		public static double QuantileCustomInplace(double[] data, double tau, double a, double b, double c, double d)
		{
			if (tau < 0.0 || tau > 1.0 || data.Length == 0)
			{
				return double.NaN;
			}
			double num = a + ((double)data.Length + b) * tau - 1.0;
			double num2 = Math.Truncate(num);
			double num3 = num - num2;
			if (Math.Abs(num3) < 1E-09)
			{
				return SelectInplace(data, (int)num2);
			}
			double num4 = SelectInplace(data, (int)Math.Floor(num));
			double num5 = SelectInplace(data, (int)Math.Ceiling(num));
			return num4 + (num5 - num4) * (c + d * num3);
		}

		public static double QuantileCustomInplace(double[] data, double tau, QuantileDefinition definition)
		{
			if (tau < 0.0 || tau > 1.0 || data.Length == 0)
			{
				return double.NaN;
			}
			if (tau == 0.0 || data.Length == 1)
			{
				return Minimum(data);
			}
			if (tau == 1.0)
			{
				return Maximum(data);
			}
			switch (definition)
			{
			case QuantileDefinition.R1:
			{
				double num26 = (double)data.Length * tau + 0.5;
				return SelectInplace(data, (int)Math.Ceiling(num26 - 0.5) - 1);
			}
			case QuantileDefinition.R2:
			{
				double num25 = (double)data.Length * tau + 0.5;
				return (SelectInplace(data, (int)Math.Ceiling(num25 - 0.5) - 1) + SelectInplace(data, (int)(num25 + 0.5) - 1)) * 0.5;
			}
			case QuantileDefinition.R3:
			{
				double a = (double)data.Length * tau;
				return SelectInplace(data, (int)Math.Round(a) - 1);
			}
			case QuantileDefinition.R4:
			{
				double num21 = (double)data.Length * tau;
				int num22 = (int)num21;
				double num23 = SelectInplace(data, num22 - 1);
				double num24 = SelectInplace(data, num22);
				return num23 + (num21 - (double)num22) * (num24 - num23);
			}
			case QuantileDefinition.R5:
			{
				double num17 = (double)data.Length * tau + 0.5;
				int num18 = (int)num17;
				double num19 = SelectInplace(data, num18 - 1);
				double num20 = SelectInplace(data, num18);
				return num19 + (num17 - (double)num18) * (num20 - num19);
			}
			case QuantileDefinition.R6:
			{
				double num13 = (double)(data.Length + 1) * tau;
				int num14 = (int)num13;
				double num15 = SelectInplace(data, num14 - 1);
				double num16 = SelectInplace(data, num14);
				return num15 + (num13 - (double)num14) * (num16 - num15);
			}
			case QuantileDefinition.R7:
			{
				double num9 = (double)(data.Length - 1) * tau + 1.0;
				int num10 = (int)num9;
				double num11 = SelectInplace(data, num10 - 1);
				double num12 = SelectInplace(data, num10);
				return num11 + (num9 - (double)num10) * (num12 - num11);
			}
			case QuantileDefinition.R8:
			{
				double num5 = ((double)data.Length + 1.0 / 3.0) * tau + 1.0 / 3.0;
				int num6 = (int)num5;
				double num7 = SelectInplace(data, num6 - 1);
				double num8 = SelectInplace(data, num6);
				return num7 + (num5 - (double)num6) * (num8 - num7);
			}
			case QuantileDefinition.R9:
			{
				double num = ((double)data.Length + 0.25) * tau + 0.375;
				int num2 = (int)num;
				double num3 = SelectInplace(data, num2 - 1);
				double num4 = SelectInplace(data, num2);
				return num3 + (num - (double)num2) * (num4 - num3);
			}
			default:
				throw new NotSupportedException();
			}
		}

		private static double SelectInplace(double[] workingData, int rank)
		{
			if (rank <= 0)
			{
				return Minimum(workingData);
			}
			if (rank >= workingData.Length - 1)
			{
				return Maximum(workingData);
			}
			int num = 0;
			int num2 = workingData.Length - 1;
			while (num2 > num + 1)
			{
				int num3 = num + num2 >> 1;
				ref double reference = ref workingData[num3];
				ref double reference2 = ref workingData[num + 1];
				double num4 = workingData[num + 1];
				double num5 = workingData[num3];
				reference = num4;
				reference2 = num5;
				if (workingData[num] > workingData[num2])
				{
					reference = ref workingData[num];
					ref double reference3 = ref workingData[num2];
					num5 = workingData[num2];
					num4 = workingData[num];
					reference = num5;
					reference3 = num4;
				}
				if (workingData[num + 1] > workingData[num2])
				{
					reference = ref workingData[num + 1];
					ref double reference4 = ref workingData[num2];
					num4 = workingData[num2];
					num5 = workingData[num + 1];
					reference = num4;
					reference4 = num5;
				}
				if (workingData[num] > workingData[num + 1])
				{
					reference = ref workingData[num];
					ref double reference5 = ref workingData[num + 1];
					num5 = workingData[num + 1];
					num4 = workingData[num];
					reference = num5;
					reference5 = num4;
				}
				int num6 = num + 1;
				int num7 = num2;
				double num8 = workingData[num6];
				while (true)
				{
					num6++;
					if (!(workingData[num6] < num8))
					{
						do
						{
							num7--;
						}
						while (workingData[num7] > num8);
						if (num7 < num6)
						{
							break;
						}
						reference = ref workingData[num6];
						ref double reference6 = ref workingData[num7];
						num4 = workingData[num7];
						num5 = workingData[num6];
						reference = num4;
						reference6 = num5;
					}
				}
				workingData[num + 1] = workingData[num7];
				workingData[num7] = num8;
				if (num7 >= rank)
				{
					num2 = num7 - 1;
				}
				if (num7 <= rank)
				{
					num = num6;
				}
			}
			if (num2 == num + 1 && workingData[num2] < workingData[num])
			{
				ref double reference = ref workingData[num];
				ref double reference7 = ref workingData[num2];
				double num5 = workingData[num2];
				double num4 = workingData[num];
				reference = num5;
				reference7 = num4;
			}
			return workingData[rank];
		}

		public static double[] RanksInplace(double[] data, RankDefinition definition = RankDefinition.Average)
		{
			double[] array = new double[data.Length];
			int[] array2 = new int[data.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = i;
			}
			if (definition == RankDefinition.First)
			{
				Sorting.SortAll(data, array2);
				for (int j = 0; j < array.Length; j++)
				{
					array[array2[j]] = j + 1;
				}
				return array;
			}
			Sorting.Sort(data, array2);
			int num = 0;
			for (int k = 1; k < data.Length; k++)
			{
				if (!(Math.Abs(data[k] - data[num]) <= 0.0))
				{
					if (k == num + 1)
					{
						array[array2[num]] = k;
					}
					else
					{
						RanksTies(array, array2, num, k, definition);
					}
					num = k;
				}
			}
			RanksTies(array, array2, num, data.Length, definition);
			return array;
		}

		private static void RanksTies(double[] ranks, int[] index, int a, int b, RankDefinition definition)
		{
			double num = definition switch
			{
				RankDefinition.Average => (double)(b + a - 1) / 2.0 + 1.0, 
				RankDefinition.Min => a + 1, 
				RankDefinition.Max => b, 
				_ => throw new NotSupportedException(), 
			};
			for (int i = a; i < b; i++)
			{
				ranks[index[i]] = num;
			}
		}

		public static double Mean(int[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			ulong num2 = 0uL;
			for (int i = 0; i < data.Length; i++)
			{
				num += ((double)data[i] - num) / (double)(++num2);
			}
			return num;
		}

		public static double GeometricMean(int[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			for (int i = 0; i < data.Length; i++)
			{
				num += Math.Log(data[i]);
			}
			return Math.Exp(num / (double)data.Length);
		}

		public static double HarmonicMean(int[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			for (int i = 0; i < data.Length; i++)
			{
				num += 1.0 / (double)data[i];
			}
			return (double)data.Length / num;
		}

		public static double Variance(int[] samples)
		{
			if (samples.Length <= 1)
			{
				return double.NaN;
			}
			double num = 0.0;
			double num2 = samples[0];
			for (int i = 1; i < samples.Length; i++)
			{
				num2 += (double)samples[i];
				double num3 = (double)((i + 1) * samples[i]) - num2;
				num += num3 * num3 / (((double)i + 1.0) * (double)i);
			}
			return num / (double)(samples.Length - 1);
		}

		public static double PopulationVariance(int[] population)
		{
			if (population.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			double num2 = population[0];
			for (int i = 1; i < population.Length; i++)
			{
				num2 += (double)population[i];
				double num3 = (double)((i + 1) * population[i]) - num2;
				num += num3 * num3 / (((double)i + 1.0) * (double)i);
			}
			return num / (double)population.Length;
		}

		public static double StandardDeviation(int[] samples)
		{
			return Math.Sqrt(Variance(samples));
		}

		public static double PopulationStandardDeviation(int[] population)
		{
			return Math.Sqrt(PopulationVariance(population));
		}

		public static (double Mean, double Variance) MeanVariance(int[] samples)
		{
			return (Mean: Mean(samples), Variance: Variance(samples));
		}

		public static (double Mean, double StandardDeviation) MeanStandardDeviation(int[] samples)
		{
			return (Mean: Mean(samples), StandardDeviation: StandardDeviation(samples));
		}

		public static double Covariance(int[] samples1, int[] samples2)
		{
			if (samples1.Length != samples2.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (samples1.Length <= 1)
			{
				return double.NaN;
			}
			double num = Mean(samples1);
			double num2 = Mean(samples2);
			double num3 = 0.0;
			for (int i = 0; i < samples1.Length; i++)
			{
				num3 += ((double)samples1[i] - num) * ((double)samples2[i] - num2);
			}
			return num3 / (double)(samples1.Length - 1);
		}

		public static double PopulationCovariance(int[] population1, int[] population2)
		{
			if (population1.Length != population2.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (population1.Length == 0)
			{
				return double.NaN;
			}
			double num = Mean(population1);
			double num2 = Mean(population2);
			double num3 = 0.0;
			for (int i = 0; i < population1.Length; i++)
			{
				num3 += ((double)population1[i] - num) * ((double)population2[i] - num2);
			}
			return num3 / (double)population1.Length;
		}

		public static double RootMeanSquare(int[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			ulong num2 = 0uL;
			for (int i = 0; i < data.Length; i++)
			{
				num += ((double)(data[i] * data[i]) - num) / (double)(++num2);
			}
			return Math.Sqrt(num);
		}

		public static float Minimum(float[] data)
		{
			if (data.Length == 0)
			{
				return float.NaN;
			}
			float num = float.PositiveInfinity;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] < num || float.IsNaN(data[i]))
				{
					num = data[i];
				}
			}
			return num;
		}

		public static float Maximum(float[] data)
		{
			if (data.Length == 0)
			{
				return float.NaN;
			}
			float num = float.NegativeInfinity;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] > num || float.IsNaN(data[i]))
				{
					num = data[i];
				}
			}
			return num;
		}

		public static float MinimumAbsolute(float[] data)
		{
			if (data.Length == 0)
			{
				return float.NaN;
			}
			float num = float.PositiveInfinity;
			for (int i = 0; i < data.Length; i++)
			{
				if (Math.Abs(data[i]) < num || float.IsNaN(data[i]))
				{
					num = Math.Abs(data[i]);
				}
			}
			return num;
		}

		public static float MaximumAbsolute(float[] data)
		{
			if (data.Length == 0)
			{
				return float.NaN;
			}
			float num = 0f;
			for (int i = 0; i < data.Length; i++)
			{
				if (Math.Abs(data[i]) > num || float.IsNaN(data[i]))
				{
					num = Math.Abs(data[i]);
				}
			}
			return num;
		}

		public static double Mean(float[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			ulong num2 = 0uL;
			for (int i = 0; i < data.Length; i++)
			{
				num += ((double)data[i] - num) / (double)(++num2);
			}
			return num;
		}

		public static double GeometricMean(float[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			for (int i = 0; i < data.Length; i++)
			{
				num += Math.Log(data[i]);
			}
			return Math.Exp(num / (double)data.Length);
		}

		public static double HarmonicMean(float[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			for (int i = 0; i < data.Length; i++)
			{
				num += 1.0 / (double)data[i];
			}
			return (double)data.Length / num;
		}

		public static double Variance(float[] samples)
		{
			if (samples.Length <= 1)
			{
				return double.NaN;
			}
			double num = 0.0;
			double num2 = samples[0];
			for (int i = 1; i < samples.Length; i++)
			{
				num2 += (double)samples[i];
				double num3 = (double)((float)(i + 1) * samples[i]) - num2;
				num += num3 * num3 / (((double)i + 1.0) * (double)i);
			}
			return num / (double)(samples.Length - 1);
		}

		public static double PopulationVariance(float[] population)
		{
			if (population.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			double num2 = population[0];
			for (int i = 1; i < population.Length; i++)
			{
				num2 += (double)population[i];
				double num3 = (double)((float)(i + 1) * population[i]) - num2;
				num += num3 * num3 / (((double)i + 1.0) * (double)i);
			}
			return num / (double)population.Length;
		}

		public static double StandardDeviation(float[] samples)
		{
			return Math.Sqrt(Variance(samples));
		}

		public static double PopulationStandardDeviation(float[] population)
		{
			return Math.Sqrt(PopulationVariance(population));
		}

		public static (double Mean, double Variance) MeanVariance(float[] samples)
		{
			return (Mean: Mean(samples), Variance: Variance(samples));
		}

		public static (double Mean, double StandardDeviation) MeanStandardDeviation(float[] samples)
		{
			return (Mean: Mean(samples), StandardDeviation: StandardDeviation(samples));
		}

		public static double Covariance(float[] samples1, float[] samples2)
		{
			if (samples1.Length != samples2.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (samples1.Length <= 1)
			{
				return double.NaN;
			}
			double num = Mean(samples1);
			double num2 = Mean(samples2);
			double num3 = 0.0;
			for (int i = 0; i < samples1.Length; i++)
			{
				num3 += ((double)samples1[i] - num) * ((double)samples2[i] - num2);
			}
			return num3 / (double)(samples1.Length - 1);
		}

		public static double PopulationCovariance(float[] population1, float[] population2)
		{
			if (population1.Length != population2.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (population1.Length == 0)
			{
				return double.NaN;
			}
			double num = Mean(population1);
			double num2 = Mean(population2);
			double num3 = 0.0;
			for (int i = 0; i < population1.Length; i++)
			{
				num3 += ((double)population1[i] - num) * ((double)population2[i] - num2);
			}
			return num3 / (double)population1.Length;
		}

		public static double RootMeanSquare(float[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			double num = 0.0;
			ulong num2 = 0uL;
			for (int i = 0; i < data.Length; i++)
			{
				num += ((double)(data[i] * data[i]) - num) / (double)(++num2);
			}
			return Math.Sqrt(num);
		}

		public static float OrderStatisticInplace(float[] data, int order)
		{
			if (order < 1 || order > data.Length)
			{
				return float.NaN;
			}
			if (order == 1)
			{
				return Minimum(data);
			}
			if (order == data.Length)
			{
				return Maximum(data);
			}
			return SelectInplace(data, order - 1);
		}

		public static float MedianInplace(float[] data)
		{
			int num = data.Length / 2;
			if (!data.Length.IsOdd())
			{
				return (SelectInplace(data, num - 1) + SelectInplace(data, num)) / 2f;
			}
			return SelectInplace(data, num);
		}

		public static float PercentileInplace(float[] data, int p)
		{
			return QuantileInplace(data, (double)p / 100.0);
		}

		public static float LowerQuartileInplace(float[] data)
		{
			return QuantileInplace(data, 0.25);
		}

		public static float UpperQuartileInplace(float[] data)
		{
			return QuantileInplace(data, 0.75);
		}

		public static float InterquartileRangeInplace(float[] data)
		{
			return QuantileInplace(data, 0.75) - QuantileInplace(data, 0.25);
		}

		public static float[] FiveNumberSummaryInplace(float[] data)
		{
			if (data.Length != 0)
			{
				return new float[5]
				{
					Minimum(data),
					QuantileInplace(data, 0.25),
					MedianInplace(data),
					QuantileInplace(data, 0.75),
					Maximum(data)
				};
			}
			return new float[5]
			{
				float.NaN,
				float.NaN,
				float.NaN,
				float.NaN,
				float.NaN
			};
		}

		public static float QuantileInplace(float[] data, double tau)
		{
			if (tau < 0.0 || tau > 1.0 || data.Length == 0)
			{
				return float.NaN;
			}
			double num = ((double)data.Length + 1.0 / 3.0) * tau + 1.0 / 3.0;
			int num2 = (int)num;
			if (num2 <= 0 || tau == 0.0)
			{
				return Minimum(data);
			}
			if (num2 >= data.Length || tau == 1.0)
			{
				return Maximum(data);
			}
			float num3 = SelectInplace(data, num2 - 1);
			float num4 = SelectInplace(data, num2);
			return (float)((double)num3 + (num - (double)num2) * (double)(num4 - num3));
		}

		public static float QuantileCustomInplace(float[] data, double tau, double a, double b, double c, double d)
		{
			if (tau < 0.0 || tau > 1.0 || data.Length == 0)
			{
				return float.NaN;
			}
			double num = a + ((double)data.Length + b) * tau - 1.0;
			double num2 = Math.Truncate(num);
			double num3 = num - num2;
			if (Math.Abs(num3) < 1E-09)
			{
				return SelectInplace(data, (int)num2);
			}
			float num4 = SelectInplace(data, (int)Math.Floor(num));
			float num5 = SelectInplace(data, (int)Math.Ceiling(num));
			return (float)((double)num4 + (double)(num5 - num4) * (c + d * num3));
		}

		public static float QuantileCustomInplace(float[] data, double tau, QuantileDefinition definition)
		{
			if (tau < 0.0 || tau > 1.0 || data.Length == 0)
			{
				return float.NaN;
			}
			if (tau == 0.0 || data.Length == 1)
			{
				return Minimum(data);
			}
			if (tau == 1.0)
			{
				return Maximum(data);
			}
			switch (definition)
			{
			case QuantileDefinition.R1:
			{
				double num26 = (double)data.Length * tau + 0.5;
				return SelectInplace(data, (int)Math.Ceiling(num26 - 0.5) - 1);
			}
			case QuantileDefinition.R2:
			{
				double num25 = (double)data.Length * tau + 0.5;
				return (SelectInplace(data, (int)Math.Ceiling(num25 - 0.5) - 1) + SelectInplace(data, (int)(num25 + 0.5) - 1)) * 0.5f;
			}
			case QuantileDefinition.R3:
			{
				double a = (double)data.Length * tau;
				return SelectInplace(data, (int)Math.Round(a) - 1);
			}
			case QuantileDefinition.R4:
			{
				double num21 = (double)data.Length * tau;
				int num22 = (int)num21;
				float num23 = SelectInplace(data, num22 - 1);
				float num24 = SelectInplace(data, num22);
				return (float)((double)num23 + (num21 - (double)num22) * (double)(num24 - num23));
			}
			case QuantileDefinition.R5:
			{
				double num17 = (double)data.Length * tau + 0.5;
				int num18 = (int)num17;
				float num19 = SelectInplace(data, num18 - 1);
				float num20 = SelectInplace(data, num18);
				return (float)((double)num19 + (num17 - (double)num18) * (double)(num20 - num19));
			}
			case QuantileDefinition.R6:
			{
				double num13 = (double)(data.Length + 1) * tau;
				int num14 = (int)num13;
				float num15 = SelectInplace(data, num14 - 1);
				float num16 = SelectInplace(data, num14);
				return (float)((double)num15 + (num13 - (double)num14) * (double)(num16 - num15));
			}
			case QuantileDefinition.R7:
			{
				double num9 = (double)(data.Length - 1) * tau + 1.0;
				int num10 = (int)num9;
				float num11 = SelectInplace(data, num10 - 1);
				float num12 = SelectInplace(data, num10);
				return (float)((double)num11 + (num9 - (double)num10) * (double)(num12 - num11));
			}
			case QuantileDefinition.R8:
			{
				double num5 = ((double)data.Length + 1.0 / 3.0) * tau + 1.0 / 3.0;
				int num6 = (int)num5;
				float num7 = SelectInplace(data, num6 - 1);
				float num8 = SelectInplace(data, num6);
				return (float)((double)num7 + (num5 - (double)num6) * (double)(num8 - num7));
			}
			case QuantileDefinition.R9:
			{
				double num = ((double)data.Length + 0.25) * tau + 0.375;
				int num2 = (int)num;
				float num3 = SelectInplace(data, num2 - 1);
				float num4 = SelectInplace(data, num2);
				return (float)((double)num3 + (num - (double)num2) * (double)(num4 - num3));
			}
			default:
				throw new NotSupportedException();
			}
		}

		private static float SelectInplace(float[] workingData, int rank)
		{
			if (rank <= 0)
			{
				return Minimum(workingData);
			}
			if (rank >= workingData.Length - 1)
			{
				return Maximum(workingData);
			}
			int num = 0;
			int num2 = workingData.Length - 1;
			while (num2 > num + 1)
			{
				int num3 = num + num2 >> 1;
				ref float reference = ref workingData[num3];
				ref float reference2 = ref workingData[num + 1];
				float num4 = workingData[num + 1];
				float num5 = workingData[num3];
				reference = num4;
				reference2 = num5;
				if (workingData[num] > workingData[num2])
				{
					reference = ref workingData[num];
					ref float reference3 = ref workingData[num2];
					num5 = workingData[num2];
					num4 = workingData[num];
					reference = num5;
					reference3 = num4;
				}
				if (workingData[num + 1] > workingData[num2])
				{
					reference = ref workingData[num + 1];
					ref float reference4 = ref workingData[num2];
					num4 = workingData[num2];
					num5 = workingData[num + 1];
					reference = num4;
					reference4 = num5;
				}
				if (workingData[num] > workingData[num + 1])
				{
					reference = ref workingData[num];
					ref float reference5 = ref workingData[num + 1];
					num5 = workingData[num + 1];
					num4 = workingData[num];
					reference = num5;
					reference5 = num4;
				}
				int num6 = num + 1;
				int num7 = num2;
				float num8 = workingData[num6];
				while (true)
				{
					num6++;
					if (!(workingData[num6] < num8))
					{
						do
						{
							num7--;
						}
						while (workingData[num7] > num8);
						if (num7 < num6)
						{
							break;
						}
						reference = ref workingData[num6];
						ref float reference6 = ref workingData[num7];
						num4 = workingData[num7];
						num5 = workingData[num6];
						reference = num4;
						reference6 = num5;
					}
				}
				workingData[num + 1] = workingData[num7];
				workingData[num7] = num8;
				if (num7 >= rank)
				{
					num2 = num7 - 1;
				}
				if (num7 <= rank)
				{
					num = num6;
				}
			}
			if (num2 == num + 1 && workingData[num2] < workingData[num])
			{
				ref float reference = ref workingData[num];
				ref float reference7 = ref workingData[num2];
				float num5 = workingData[num2];
				float num4 = workingData[num];
				reference = num5;
				reference7 = num4;
			}
			return workingData[rank];
		}

		public static float[] RanksInplace(float[] data, RankDefinition definition = RankDefinition.Average)
		{
			float[] array = new float[data.Length];
			int[] array2 = new int[data.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = i;
			}
			if (definition == RankDefinition.First)
			{
				Sorting.SortAll(data, array2);
				for (int j = 0; j < array.Length; j++)
				{
					array[array2[j]] = j + 1;
				}
				return array;
			}
			Sorting.Sort(data, array2);
			int num = 0;
			for (int k = 1; k < data.Length; k++)
			{
				if (!((double)Math.Abs(data[k] - data[num]) <= 0.0))
				{
					if (k == num + 1)
					{
						array[array2[num]] = k;
					}
					else
					{
						RanksTies(array, array2, num, k, definition);
					}
					num = k;
				}
			}
			RanksTies(array, array2, num, data.Length, definition);
			return array;
		}

		private static void RanksTies(float[] ranks, int[] index, int a, int b, RankDefinition definition)
		{
			float num = definition switch
			{
				RankDefinition.Average => (float)(b + a - 1) / 2f + 1f, 
				RankDefinition.Min => a + 1, 
				RankDefinition.Max => b, 
				_ => throw new NotSupportedException(), 
			};
			for (int i = a; i < b; i++)
			{
				ranks[index[i]] = num;
			}
		}
	}
}
