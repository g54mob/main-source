using System;

namespace MathNet.Numerics.Statistics
{
	public static class SortedArrayStatistics
	{
		public static double Minimum(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			return data[0];
		}

		public static double Maximum(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			return data[^1];
		}

		public static double OrderStatistic(double[] data, int order)
		{
			if (order < 1 || order > data.Length)
			{
				return double.NaN;
			}
			return data[order - 1];
		}

		public static double Median(double[] data)
		{
			if (data.Length == 0)
			{
				return double.NaN;
			}
			int num = data.Length / 2;
			if (!data.Length.IsOdd())
			{
				return (data[num - 1] + data[num]) / 2.0;
			}
			return data[num];
		}

		public static double Percentile(double[] data, int p)
		{
			return Quantile(data, (double)p / 100.0);
		}

		public static double LowerQuartile(double[] data)
		{
			return Quantile(data, 0.25);
		}

		public static double UpperQuartile(double[] data)
		{
			return Quantile(data, 0.75);
		}

		public static double InterquartileRange(double[] data)
		{
			return Quantile(data, 0.75) - Quantile(data, 0.25);
		}

		public static double[] FiveNumberSummary(double[] data)
		{
			if (data.Length != 0)
			{
				return new double[5]
				{
					data[0],
					Quantile(data, 0.25),
					Quantile(data, 0.5),
					Quantile(data, 0.75),
					data[^1]
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

		public static double Quantile(double[] data, double tau)
		{
			if (tau < 0.0 || tau > 1.0 || data.Length == 0)
			{
				return double.NaN;
			}
			if (tau == 0.0 || data.Length == 1)
			{
				return data[0];
			}
			if (tau == 1.0)
			{
				return data[^1];
			}
			double num = ((double)data.Length + 1.0 / 3.0) * tau + 1.0 / 3.0;
			int num2 = (int)num;
			if (num2 >= 1)
			{
				if (num2 < data.Length)
				{
					return data[num2 - 1] + (num - (double)num2) * (data[num2] - data[num2 - 1]);
				}
				return data[^1];
			}
			return data[0];
		}

		public static double QuantileCustom(double[] data, double tau, double a, double b, double c, double d)
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
				return data[Math.Min(Math.Max((int)num2, 0), data.Length - 1)];
			}
			double num4 = data[Math.Max((int)Math.Floor(num), 0)];
			double num5 = data[Math.Min((int)Math.Ceiling(num), data.Length - 1)];
			return num4 + (num5 - num4) * (c + d * num3);
		}

		public static double QuantileCustom(double[] data, double tau, QuantileDefinition definition)
		{
			if (tau < 0.0 || tau > 1.0 || data.Length == 0)
			{
				return double.NaN;
			}
			if (tau == 0.0 || data.Length == 1)
			{
				return data[0];
			}
			if (tau == 1.0)
			{
				return data[^1];
			}
			switch (definition)
			{
			case QuantileDefinition.R1:
			{
				double num26 = (double)data.Length * tau + 0.5;
				return data[(int)Math.Ceiling(num26 - 0.5) - 1];
			}
			case QuantileDefinition.R2:
			{
				double num25 = (double)data.Length * tau + 0.5;
				return (data[(int)Math.Ceiling(num25 - 0.5) - 1] + data[(int)(num25 + 0.5) - 1]) * 0.5;
			}
			case QuantileDefinition.R3:
			{
				double a = (double)data.Length * tau;
				return data[Math.Max((int)Math.Round(a) - 1, 0)];
			}
			case QuantileDefinition.R4:
			{
				double num21 = (double)data.Length * tau;
				int num22 = (int)num21;
				double num23 = data[Math.Max(num22 - 1, 0)];
				double num24 = data[Math.Min(num22, data.Length - 1)];
				return num23 + (num21 - (double)num22) * (num24 - num23);
			}
			case QuantileDefinition.R5:
			{
				double num17 = (double)data.Length * tau + 0.5;
				int num18 = (int)num17;
				double num19 = data[Math.Max(num18 - 1, 0)];
				double num20 = data[Math.Min(num18, data.Length - 1)];
				return num19 + (num17 - (double)num18) * (num20 - num19);
			}
			case QuantileDefinition.R6:
			{
				double num13 = (double)(data.Length + 1) * tau;
				int num14 = (int)num13;
				double num15 = data[Math.Max(num14 - 1, 0)];
				double num16 = data[Math.Min(num14, data.Length - 1)];
				return num15 + (num13 - (double)num14) * (num16 - num15);
			}
			case QuantileDefinition.R7:
			{
				double num9 = (double)(data.Length - 1) * tau + 1.0;
				int num10 = (int)num9;
				double num11 = data[Math.Max(num10 - 1, 0)];
				double num12 = data[Math.Min(num10, data.Length - 1)];
				return num11 + (num9 - (double)num10) * (num12 - num11);
			}
			case QuantileDefinition.R8:
			{
				double num5 = ((double)data.Length + 1.0 / 3.0) * tau + 1.0 / 3.0;
				int num6 = (int)num5;
				double num7 = data[Math.Max(num6 - 1, 0)];
				double num8 = data[Math.Min(num6, data.Length - 1)];
				return num7 + (num5 - (double)num6) * (num8 - num7);
			}
			case QuantileDefinition.R9:
			{
				double num = ((double)data.Length + 0.25) * tau + 0.375;
				int num2 = (int)num;
				double num3 = data[Math.Max(num2 - 1, 0)];
				double num4 = data[Math.Min(num2, data.Length - 1)];
				return num3 + (num - (double)num2) * (num4 - num3);
			}
			default:
				throw new NotSupportedException();
			}
		}

		public static double EmpiricalCDF(double[] data, double x)
		{
			if (x < data[0])
			{
				return 0.0;
			}
			if (x >= data[^1])
			{
				return 1.0;
			}
			int i = Array.BinarySearch(data, x);
			if (i >= 0)
			{
				for (; i < data.Length - 1 && data[i + 1] == data[i]; i++)
				{
				}
				return (double)(i + 1) / (double)data.Length;
			}
			return (double)(~i) / (double)data.Length;
		}

		public static double QuantileRank(double[] data, double x, RankDefinition definition = RankDefinition.Average)
		{
			if (x < data[0])
			{
				return 0.0;
			}
			if (x >= data[^1])
			{
				return 1.0;
			}
			int i = Array.BinarySearch(data, x);
			if (i >= 0)
			{
				int num = i;
				while (num > 0 && data[num - 1] == data[num])
				{
					num--;
				}
				for (; i < data.Length - 1 && data[i + 1] == data[i]; i++)
				{
				}
				return definition switch
				{
					RankDefinition.EmpiricalCDF => (double)(i + 1) / (double)data.Length, 
					RankDefinition.Max => (double)i / (double)(data.Length - 1), 
					RankDefinition.Min => (double)num / (double)(data.Length - 1), 
					RankDefinition.Average => ((double)num / (double)(data.Length - 1) + (double)i / (double)(data.Length - 1)) / 2.0, 
					_ => throw new NotSupportedException(), 
				};
			}
			i = ~i;
			int num2 = i - 1;
			if (definition == RankDefinition.EmpiricalCDF)
			{
				return (double)(num2 + 1) / (double)data.Length;
			}
			double num3 = (double)num2 / (double)(data.Length - 1);
			double num4 = (double)i / (double)(data.Length - 1);
			return ((data[i] - x) * num3 + (x - data[num2]) * num4) / (data[i] - data[num2]);
		}

		public static double[] Ranks(double[] data, RankDefinition definition = RankDefinition.Average)
		{
			double[] array = new double[data.Length];
			if (definition == RankDefinition.First)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = i + 1;
				}
				return array;
			}
			int num = 0;
			for (int j = 1; j < data.Length; j++)
			{
				if (!(Math.Abs(data[j] - data[num]) <= 0.0))
				{
					if (j == num + 1)
					{
						array[num] = j;
					}
					else
					{
						RanksTies(array, num, j, definition);
					}
					num = j;
				}
			}
			RanksTies(array, num, data.Length, definition);
			return array;
		}

		private static void RanksTies(double[] ranks, int a, int b, RankDefinition definition)
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
				ranks[i] = num;
			}
		}

		public static float Minimum(float[] data)
		{
			if (data.Length == 0)
			{
				return float.NaN;
			}
			return data[0];
		}

		public static float Maximum(float[] data)
		{
			if (data.Length == 0)
			{
				return float.NaN;
			}
			return data[^1];
		}

		public static float OrderStatistic(float[] data, int order)
		{
			if (order < 1 || order > data.Length)
			{
				return float.NaN;
			}
			return data[order - 1];
		}

		public static float Median(float[] data)
		{
			if (data.Length == 0)
			{
				return float.NaN;
			}
			int num = data.Length / 2;
			if (!data.Length.IsOdd())
			{
				return (data[num - 1] + data[num]) / 2f;
			}
			return data[num];
		}

		public static float Percentile(float[] data, int p)
		{
			return Quantile(data, (double)p / 100.0);
		}

		public static float LowerQuartile(float[] data)
		{
			return Quantile(data, 0.25);
		}

		public static float UpperQuartile(float[] data)
		{
			return Quantile(data, 0.75);
		}

		public static float InterquartileRange(float[] data)
		{
			return Quantile(data, 0.75) - Quantile(data, 0.25);
		}

		public static float[] FiveNumberSummary(float[] data)
		{
			if (data.Length != 0)
			{
				return new float[5]
				{
					data[0],
					Quantile(data, 0.25),
					Median(data),
					Quantile(data, 0.75),
					data[^1]
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

		public static float Quantile(float[] data, double tau)
		{
			if (tau < 0.0 || tau > 1.0 || data.Length == 0)
			{
				return float.NaN;
			}
			if (tau == 0.0 || data.Length == 1)
			{
				return data[0];
			}
			if (tau == 1.0)
			{
				return data[^1];
			}
			double num = ((double)data.Length + 1.0 / 3.0) * tau + 1.0 / 3.0;
			int num2 = (int)num;
			if (num2 >= 1)
			{
				if (num2 < data.Length)
				{
					return (float)((double)data[num2 - 1] + (num - (double)num2) * (double)(data[num2] - data[num2 - 1]));
				}
				return data[^1];
			}
			return data[0];
		}

		public static float QuantileCustom(float[] data, double tau, double a, double b, double c, double d)
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
				return data[Math.Min(Math.Max((int)num2, 0), data.Length - 1)];
			}
			float num4 = data[Math.Max((int)Math.Floor(num), 0)];
			float num5 = data[Math.Min((int)Math.Ceiling(num), data.Length - 1)];
			return (float)((double)num4 + (double)(num5 - num4) * (c + d * num3));
		}

		public static float QuantileCustom(float[] data, double tau, QuantileDefinition definition)
		{
			if (tau < 0.0 || tau > 1.0 || data.Length == 0)
			{
				return float.NaN;
			}
			if (tau == 0.0 || data.Length == 1)
			{
				return data[0];
			}
			if (tau == 1.0)
			{
				return data[^1];
			}
			switch (definition)
			{
			case QuantileDefinition.R1:
			{
				double num26 = (double)data.Length * tau + 0.5;
				return data[(int)Math.Ceiling(num26 - 0.5) - 1];
			}
			case QuantileDefinition.R2:
			{
				double num25 = (double)data.Length * tau + 0.5;
				return (data[(int)Math.Ceiling(num25 - 0.5) - 1] + data[(int)(num25 + 0.5) - 1]) * 0.5f;
			}
			case QuantileDefinition.R3:
			{
				double a = (double)data.Length * tau;
				return data[Math.Max((int)Math.Round(a) - 1, 0)];
			}
			case QuantileDefinition.R4:
			{
				double num21 = (double)data.Length * tau;
				int num22 = (int)num21;
				float num23 = data[Math.Max(num22 - 1, 0)];
				float num24 = data[Math.Min(num22, data.Length - 1)];
				return (float)((double)num23 + (num21 - (double)num22) * (double)(num24 - num23));
			}
			case QuantileDefinition.R5:
			{
				double num17 = (double)data.Length * tau + 0.5;
				int num18 = (int)num17;
				float num19 = data[Math.Max(num18 - 1, 0)];
				float num20 = data[Math.Min(num18, data.Length - 1)];
				return (float)((double)num19 + (num17 - (double)num18) * (double)(num20 - num19));
			}
			case QuantileDefinition.R6:
			{
				double num13 = (double)(data.Length + 1) * tau;
				int num14 = (int)num13;
				float num15 = data[Math.Max(num14 - 1, 0)];
				float num16 = data[Math.Min(num14, data.Length - 1)];
				return (float)((double)num15 + (num13 - (double)num14) * (double)(num16 - num15));
			}
			case QuantileDefinition.R7:
			{
				double num9 = (double)(data.Length - 1) * tau + 1.0;
				int num10 = (int)num9;
				float num11 = data[Math.Max(num10 - 1, 0)];
				float num12 = data[Math.Min(num10, data.Length - 1)];
				return (float)((double)num11 + (num9 - (double)num10) * (double)(num12 - num11));
			}
			case QuantileDefinition.R8:
			{
				double num5 = ((double)data.Length + 1.0 / 3.0) * tau + 1.0 / 3.0;
				int num6 = (int)num5;
				float num7 = data[Math.Max(num6 - 1, 0)];
				float num8 = data[Math.Min(num6, data.Length - 1)];
				return (float)((double)num7 + (num5 - (double)num6) * (double)(num8 - num7));
			}
			case QuantileDefinition.R9:
			{
				double num = ((double)data.Length + 0.25) * tau + 0.375;
				int num2 = (int)num;
				float num3 = data[Math.Max(num2 - 1, 0)];
				float num4 = data[Math.Min(num2, data.Length - 1)];
				return (float)((double)num3 + (num - (double)num2) * (double)(num4 - num3));
			}
			default:
				throw new NotSupportedException();
			}
		}

		public static double EmpiricalCDF(float[] data, float x)
		{
			if (x < data[0])
			{
				return 0.0;
			}
			if (x >= data[^1])
			{
				return 1.0;
			}
			int i = Array.BinarySearch(data, x);
			if (i >= 0)
			{
				for (; i < data.Length - 1 && data[i + 1] == data[i]; i++)
				{
				}
				return (double)(i + 1) / (double)data.Length;
			}
			return (double)(~i) / (double)data.Length;
		}

		public static double QuantileRank(float[] data, float x, RankDefinition definition = RankDefinition.Average)
		{
			if (x < data[0])
			{
				return 0.0;
			}
			if (x >= data[^1])
			{
				return 1.0;
			}
			int i = Array.BinarySearch(data, x);
			if (i >= 0)
			{
				int num = i;
				while (num > 0 && data[num - 1] == data[num])
				{
					num--;
				}
				for (; i < data.Length - 1 && data[i + 1] == data[i]; i++)
				{
				}
				return definition switch
				{
					RankDefinition.EmpiricalCDF => (double)(i + 1) / (double)data.Length, 
					RankDefinition.Max => (double)i / (double)(data.Length - 1), 
					RankDefinition.Min => (double)num / (double)(data.Length - 1), 
					RankDefinition.Average => ((double)num / (double)(data.Length - 1) + (double)i / (double)(data.Length - 1)) / 2.0, 
					_ => throw new NotSupportedException(), 
				};
			}
			i = ~i;
			int num2 = i - 1;
			if (definition == RankDefinition.EmpiricalCDF)
			{
				return (double)(num2 + 1) / (double)data.Length;
			}
			double num3 = (double)num2 / (double)(data.Length - 1);
			double num4 = (double)i / (double)(data.Length - 1);
			return ((double)(data[i] - x) * num3 + (double)(x - data[num2]) * num4) / (double)(data[i] - data[num2]);
		}

		public static double[] Ranks(float[] data, RankDefinition definition = RankDefinition.Average)
		{
			double[] array = new double[data.Length];
			if (definition == RankDefinition.First)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = i + 1;
				}
				return array;
			}
			int num = 0;
			for (int j = 1; j < data.Length; j++)
			{
				if (!((double)Math.Abs(data[j] - data[num]) <= 0.0))
				{
					if (j == num + 1)
					{
						array[num] = j;
					}
					else
					{
						RanksTies(array, num, j, definition);
					}
					num = j;
				}
			}
			RanksTies(array, num, data.Length, definition);
			return array;
		}
	}
}
