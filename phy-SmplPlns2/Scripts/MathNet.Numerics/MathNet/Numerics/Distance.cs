using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Statistics;

namespace MathNet.Numerics
{
	public static class Distance
	{
		public static double SAD<T>(Vector<T> a, Vector<T> b) where T : struct, IEquatable<T>, IFormattable
		{
			return (a - b).L1Norm();
		}

		public static double SAD(double[] a, double[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			double num = 0.0;
			for (int i = 0; i < a.Length; i++)
			{
				num += Math.Abs(a[i] - b[i]);
			}
			return num;
		}

		public static float SAD(float[] a, float[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			float num = 0f;
			for (int i = 0; i < a.Length; i++)
			{
				num += Math.Abs(a[i] - b[i]);
			}
			return num;
		}

		public static double MAE<T>(Vector<T> a, Vector<T> b) where T : struct, IEquatable<T>, IFormattable
		{
			return (a - b).L1Norm() / (double)a.Count;
		}

		public static double MAE(double[] a, double[] b)
		{
			return SAD(a, b) / (double)a.Length;
		}

		public static float MAE(float[] a, float[] b)
		{
			return SAD(a, b) / (float)a.Length;
		}

		public static double SSD<T>(Vector<T> a, Vector<T> b) where T : struct, IEquatable<T>, IFormattable
		{
			double num = (a - b).L2Norm();
			return num * num;
		}

		public static double SSD(double[] a, double[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			double[] array = new double[a.Length];
			LinearAlgebraControl.Provider.SubtractArrays(a, b, array);
			return LinearAlgebraControl.Provider.DotProduct(array, array);
		}

		public static float SSD(float[] a, float[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			float[] array = new float[a.Length];
			LinearAlgebraControl.Provider.SubtractArrays(a, b, array);
			return LinearAlgebraControl.Provider.DotProduct(array, array);
		}

		public static double MSE<T>(Vector<T> a, Vector<T> b) where T : struct, IEquatable<T>, IFormattable
		{
			double num = (a - b).L2Norm();
			return num * num / (double)a.Count;
		}

		public static double MSE(double[] a, double[] b)
		{
			return SSD(a, b) / (double)a.Length;
		}

		public static float MSE(float[] a, float[] b)
		{
			return SSD(a, b) / (float)a.Length;
		}

		public static double Euclidean<T>(Vector<T> a, Vector<T> b) where T : struct, IEquatable<T>, IFormattable
		{
			return (a - b).L2Norm();
		}

		public static double Euclidean(double[] a, double[] b)
		{
			return Math.Sqrt(SSD(a, b));
		}

		public static float Euclidean(float[] a, float[] b)
		{
			return (float)Math.Sqrt(SSD(a, b));
		}

		public static double Manhattan<T>(Vector<T> a, Vector<T> b) where T : struct, IEquatable<T>, IFormattable
		{
			return (a - b).L1Norm();
		}

		public static double Manhattan(double[] a, double[] b)
		{
			return SAD(a, b);
		}

		public static float Manhattan(float[] a, float[] b)
		{
			return SAD(a, b);
		}

		public static double Chebyshev<T>(Vector<T> a, Vector<T> b) where T : struct, IEquatable<T>, IFormattable
		{
			return (a - b).InfinityNorm();
		}

		public static double Chebyshev(double[] a, double[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			double num = Math.Abs(a[0] - b[0]);
			for (int i = 1; i < a.Length; i++)
			{
				double num2 = Math.Abs(a[i] - b[i]);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		public static float Chebyshev(float[] a, float[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			float num = Math.Abs(a[0] - b[0]);
			for (int i = 1; i < a.Length; i++)
			{
				float num2 = Math.Abs(a[i] - b[i]);
				if (num2 > num)
				{
					num = num2;
				}
			}
			return num;
		}

		public static double Minkowski<T>(double p, Vector<T> a, Vector<T> b) where T : struct, IEquatable<T>, IFormattable
		{
			return (a - b).Norm(p);
		}

		public static double Minkowski(double p, double[] a, double[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (p < 0.0)
			{
				throw new ArgumentOutOfRangeException("p");
			}
			if (p == 1.0)
			{
				return Manhattan(a, b);
			}
			if (p == 2.0)
			{
				return Euclidean(a, b);
			}
			if (double.IsPositiveInfinity(p))
			{
				return Chebyshev(a, b);
			}
			double num = 0.0;
			for (int i = 0; i < a.Length; i++)
			{
				num += Math.Pow(Math.Abs(a[i] - b[i]), p);
			}
			return Math.Pow(num, 1.0 / p);
		}

		public static float Minkowski(double p, float[] a, float[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (p < 0.0)
			{
				throw new ArgumentOutOfRangeException("p");
			}
			if (p == 1.0)
			{
				return Manhattan(a, b);
			}
			if (p == 2.0)
			{
				return Euclidean(a, b);
			}
			if (double.IsPositiveInfinity(p))
			{
				return Chebyshev(a, b);
			}
			double num = 0.0;
			for (int i = 0; i < a.Length; i++)
			{
				num += Math.Pow(Math.Abs(a[i] - b[i]), p);
			}
			return (float)Math.Pow(num, 1.0 / p);
		}

		public static double Canberra(double[] a, double[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			double num = 0.0;
			for (int i = 0; i < a.Length; i++)
			{
				num += Math.Abs(a[i] - b[i]) / (Math.Abs(a[i]) + Math.Abs(b[i]));
			}
			return num;
		}

		public static float Canberra(float[] a, float[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			float num = 0f;
			for (int i = 0; i < a.Length; i++)
			{
				num += Math.Abs(a[i] - b[i]) / (Math.Abs(a[i]) + Math.Abs(b[i]));
			}
			return num;
		}

		public static double Cosine(double[] a, double[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			double num = LinearAlgebraControl.Provider.DotProduct(a, b);
			double num2 = LinearAlgebraControl.Provider.DotProduct(a, a);
			double num3 = LinearAlgebraControl.Provider.DotProduct(b, b);
			return 1.0 - num / Math.Sqrt(num2 * num3);
		}

		public static float Cosine(float[] a, float[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			float num = LinearAlgebraControl.Provider.DotProduct(a, b);
			float num2 = LinearAlgebraControl.Provider.DotProduct(a, a);
			float num3 = LinearAlgebraControl.Provider.DotProduct(b, b);
			return (float)(1.0 - (double)num / Math.Sqrt(num2 * num3));
		}

		public static double Hamming(double[] a, double[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			int num = 0;
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] != b[i])
				{
					num++;
				}
			}
			return num;
		}

		public static float Hamming(float[] a, float[] b)
		{
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			int num = 0;
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] != b[i])
				{
					num++;
				}
			}
			return num;
		}

		public static double Pearson(IEnumerable<double> a, IEnumerable<double> b)
		{
			return 1.0 - Correlation.Pearson(a, b);
		}

		public static double Jaccard(double[] a, double[] b)
		{
			int num = 0;
			int num2 = 0;
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (a.Length == 0 && b.Length == 0)
			{
				return 0.0;
			}
			int i = 0;
			for (int num3 = a.Length; i < num3; i++)
			{
				if (a[i] != 0.0 && b[i] != 0.0)
				{
					if (a[i] == b[i])
					{
						num++;
					}
					num2++;
				}
			}
			return 1.0 - (double)num / (double)num2;
		}

		public static double Jaccard(float[] a, float[] b)
		{
			int num = 0;
			int num2 = 0;
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			if (a.Length != b.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (a.Length == 0 && b.Length == 0)
			{
				return 0.0;
			}
			int i = 0;
			for (int num3 = a.Length; i < num3; i++)
			{
				if (a[i] != 0f && b[i] != 0f)
				{
					if (a[i] == b[i])
					{
						num++;
					}
					num2++;
				}
			}
			return 1.0 - (double)((float)num / (float)num2);
		}
	}
}
