using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics.Statistics
{
	public static class Correlation
	{
		public static double[] Auto(double[] x)
		{
			return AutoCorrelationFft(x, 0, x.Length - 1);
		}

		public static double[] Auto(double[] x, int kMax, int kMin = 0)
		{
			int kHigh = Math.Max(kMax, kMin);
			int kLow = Math.Min(kMax, kMin);
			return AutoCorrelationFft(x, kLow, kHigh);
		}

		public static double[] Auto(double[] x, int[] k)
		{
			if (k == null)
			{
				throw new ArgumentNullException("k");
			}
			if (k.Length < 1)
			{
				throw new ArgumentException("k");
			}
			int num = k.Min();
			int kHigh = k.Max();
			double[] array = AutoCorrelationFft(x, num, kHigh);
			double[] array2 = new double[k.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = array[k[i] - num];
			}
			return array2;
		}

		private static double[] AutoCorrelationFft(double[] x, int kLow, int kHigh)
		{
			if (x == null)
			{
				throw new ArgumentNullException("x");
			}
			int num = x.Length;
			if (kLow < 0 || kLow >= num)
			{
				throw new ArgumentOutOfRangeException("kLow", "kMin must be zero or positive and smaller than x.Length");
			}
			if (kHigh < 0 || kHigh >= num)
			{
				throw new ArgumentOutOfRangeException("kHigh", "kMax must be positive and smaller than x.Length");
			}
			int num2 = num.CeilingToPowerOfTwo() * 2;
			Complex[] array = new Complex[num2];
			Complex[] array2 = new Complex[num2];
			double num3 = ArrayStatistics.Mean(x);
			for (int i = 0; i < x.Length; i++)
			{
				array[i] = new Complex(x[i] - num3, 0.0);
			}
			Fourier.Forward(array, FourierOptions.AsymmetricScaling);
			for (int j = 0; j < array.Length; j++)
			{
				array2[j] = Complex.Multiply(array[j], Complex.Conjugate(array[j]));
			}
			Fourier.Inverse(array2, FourierOptions.AsymmetricScaling);
			double real = array2[0].Real;
			double[] array3 = new double[kHigh - kLow + 1];
			for (int k = 0; k < kHigh - kLow + 1; k++)
			{
				array3[k] = array2[kLow + k].Real / real;
			}
			return array3;
		}

		public static double Pearson(IEnumerable<double> dataA, IEnumerable<double> dataB)
		{
			int num = 0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			using (IEnumerator<double> enumerator = dataA.GetEnumerator())
			{
				using IEnumerator<double> enumerator2 = dataB.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (!enumerator2.MoveNext())
					{
						throw new ArgumentOutOfRangeException("dataB", "The array arguments must have the same length.");
					}
					double current = enumerator.Current;
					double current2 = enumerator2.Current;
					double num7 = current - num3;
					double num8 = num7 / (double)(++num);
					double num9 = current2 - num4;
					double num10 = num9 / (double)num;
					num3 += num8;
					num4 += num10;
					num5 += num8 * num7 * (double)(num - 1);
					num6 += num10 * num9 * (double)(num - 1);
					num2 += num7 * num9 * (double)(num - 1) / (double)num;
				}
				if (enumerator2.MoveNext())
				{
					throw new ArgumentOutOfRangeException("dataA", "The array arguments must have the same length.");
				}
			}
			return num2 / Math.Sqrt(num5 * num6);
		}

		public static double WeightedPearson(IEnumerable<double> dataA, IEnumerable<double> dataB, IEnumerable<double> weights)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			using (IEnumerator<double> enumerator = dataA.GetEnumerator())
			{
				using IEnumerator<double> enumerator2 = dataB.GetEnumerator();
				using IEnumerator<double> enumerator3 = weights.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (!enumerator2.MoveNext())
					{
						throw new ArgumentOutOfRangeException("dataB", "The array arguments must have the same length.");
					}
					if (!enumerator3.MoveNext())
					{
						throw new ArgumentOutOfRangeException("weights", "The array arguments must have the same length.");
					}
					double current = enumerator.Current;
					double current2 = enumerator2.Current;
					double current3 = enumerator3.Current;
					double num7 = num5 + current3;
					double num8 = current - num;
					double num9 = num8 * current3 / num7;
					num += num9;
					num3 += num5 * num8 * num9;
					double num10 = current2 - num2;
					double num11 = num10 * current3 / num7;
					num2 += num11;
					num4 += num5 * num10 * num11;
					num6 += num8 * num10 * current3 * (num5 / num7);
					num5 = num7;
				}
				if (enumerator2.MoveNext())
				{
					throw new ArgumentOutOfRangeException("dataB", "The array arguments must have the same length.");
				}
				if (enumerator3.MoveNext())
				{
					throw new ArgumentOutOfRangeException("weights", "The array arguments must have the same length.");
				}
			}
			return num6 / Math.Sqrt(num3 * num4);
		}

		public static Matrix<double> PearsonMatrix(params double[][] vectors)
		{
			Matrix<double> matrix = Matrix<double>.Build.DenseIdentity(vectors.Length);
			for (int i = 0; i < vectors.Length; i++)
			{
				for (int j = i + 1; j < vectors.Length; j++)
				{
					double value = Pearson(vectors[i], vectors[j]);
					matrix.At(i, j, value);
					matrix.At(j, i, value);
				}
			}
			return matrix;
		}

		public static Matrix<double> PearsonMatrix(IEnumerable<double[]> vectors)
		{
			return PearsonMatrix((vectors as double[][]) ?? vectors.ToArray());
		}

		public static double Spearman(IEnumerable<double> dataA, IEnumerable<double> dataB)
		{
			return Pearson(Rank(dataA), Rank(dataB));
		}

		public static Matrix<double> SpearmanMatrix(params double[][] vectors)
		{
			return PearsonMatrix(vectors.Select(Rank).ToArray());
		}

		public static Matrix<double> SpearmanMatrix(IEnumerable<double[]> vectors)
		{
			return PearsonMatrix(vectors.Select(Rank).ToArray());
		}

		private static double[] Rank(IEnumerable<double> series)
		{
			if (series == null)
			{
				return Array.Empty<double>();
			}
			return ArrayStatistics.RanksInplace(series.ToArray());
		}
	}
}
