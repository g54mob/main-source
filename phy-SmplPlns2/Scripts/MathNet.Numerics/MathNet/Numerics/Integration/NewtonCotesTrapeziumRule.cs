using System;
using System.Collections.Generic;
using System.Numerics;

namespace MathNet.Numerics.Integration
{
	public static class NewtonCotesTrapeziumRule
	{
		public static double IntegrateTwoPoint(Func<double, double> f, double intervalBegin, double intervalEnd)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			return (intervalEnd - intervalBegin) / 2.0 * (f(intervalBegin) + f(intervalEnd));
		}

		public static Complex ContourIntegrateTwoPoint(Func<double, Complex> f, double intervalBegin, double intervalEnd)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			return (intervalEnd - intervalBegin) / 2.0 * (f(intervalBegin) + f(intervalEnd));
		}

		public static double IntegrateComposite(Func<double, double> f, double intervalBegin, double intervalEnd, int numberOfPartitions)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			if (numberOfPartitions <= 0)
			{
				throw new ArgumentOutOfRangeException("numberOfPartitions", "Value must be positive (and not zero).");
			}
			double num = (intervalEnd - intervalBegin) / (double)numberOfPartitions;
			double num2 = num;
			double num3 = 0.5 * (f(intervalBegin) + f(intervalEnd));
			for (int i = 0; i < numberOfPartitions - 1; i++)
			{
				num3 += f(intervalBegin + num2);
				num2 += num;
			}
			return num * num3;
		}

		public static Complex ContourIntegrateComposite(Func<double, Complex> f, double intervalBegin, double intervalEnd, int numberOfPartitions)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			if (numberOfPartitions <= 0)
			{
				throw new ArgumentOutOfRangeException("numberOfPartitions", "Value must be positive (and not zero).");
			}
			double num = (intervalEnd - intervalBegin) / (double)numberOfPartitions;
			double num2 = num;
			Complex complex = 0.5 * (f(intervalBegin) + f(intervalEnd));
			for (int i = 0; i < numberOfPartitions - 1; i++)
			{
				complex += f(intervalBegin + num2);
				num2 += num;
			}
			return num * complex;
		}

		public static double IntegrateAdaptive(Func<double, double> f, double intervalBegin, double intervalEnd, double targetError)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			int num = 1;
			double num2 = intervalEnd - intervalBegin;
			double num3 = 0.5 * num2 * (f(intervalBegin) + f(intervalEnd));
			for (int i = 0; i < 20; i++)
			{
				double num4 = 0.0;
				for (int j = 0; j < num; j++)
				{
					num4 += f(intervalBegin + ((double)j + 0.5) * num2);
				}
				num4 *= num2;
				num3 = 0.5 * (num3 + num4);
				num2 *= 0.5;
				num *= 2;
				if (num3.AlmostEqualRelative(num4, targetError))
				{
					break;
				}
			}
			return num3;
		}

		public static Complex ContourIntegrateAdaptive(Func<double, Complex> f, double intervalBegin, double intervalEnd, double targetError)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			int num = 1;
			double num2 = intervalEnd - intervalBegin;
			Complex complex = 0.5 * num2 * (f(intervalBegin) + f(intervalEnd));
			for (int i = 0; i < 20; i++)
			{
				Complex complex2 = 0;
				for (int j = 0; j < num; j++)
				{
					complex2 += f(intervalBegin + ((double)j + 0.5) * num2);
				}
				complex2 *= (Complex)num2;
				complex = 0.5 * (complex + complex2);
				num2 *= 0.5;
				num *= 2;
				if (complex.AlmostEqualRelative(complex2, targetError))
				{
					break;
				}
			}
			return complex;
		}

		public static double IntegrateAdaptiveTransformedOdd(Func<double, double> f, double intervalBegin, double intervalEnd, IEnumerable<double[]> levelAbscissas, IEnumerable<double[]> levelWeights, double levelOneStep, double targetRelativeError)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			if (levelAbscissas == null)
			{
				throw new ArgumentNullException("levelAbscissas");
			}
			if (levelWeights == null)
			{
				throw new ArgumentNullException("levelWeights");
			}
			double num = 0.5 * (intervalEnd - intervalBegin);
			double num2 = 0.5 * (intervalEnd + intervalBegin);
			targetRelativeError /= 5.0 * num;
			using IEnumerator<double[]> enumerator = levelAbscissas.GetEnumerator();
			using IEnumerator<double[]> enumerator2 = levelWeights.GetEnumerator();
			double num3 = levelOneStep;
			enumerator.MoveNext();
			enumerator2.MoveNext();
			double[] array = enumerator.Current ?? throw new ArgumentNullException("levelAbscissas");
			double[] array2 = enumerator2.Current ?? throw new ArgumentNullException("levelWeights");
			double num4 = f(num2) * array2[0];
			for (int i = 1; i < array.Length; i++)
			{
				num4 += array2[i] * (f(num * array[i] + num2) + f(0.0 - num * array[i] + num2));
			}
			num4 *= num3;
			double d = double.MaxValue;
			int num5 = 1;
			while (enumerator.MoveNext() && enumerator2.MoveNext())
			{
				double[] array3 = enumerator.Current ?? throw new ArgumentNullException("levelAbscissas");
				double[] array4 = enumerator2.Current ?? throw new ArgumentNullException("levelWeights");
				double num6 = 0.0;
				for (int j = 0; j < array3.Length; j++)
				{
					num6 += array4[j] * (f(num * array3[j] + num2) + f(0.0 - num * array3[j] + num2));
				}
				num6 *= num3;
				num4 = 0.5 * (num4 + num6);
				num3 *= 0.5;
				double num7 = Math.Abs(num4 - num6);
				if (num5 == 1)
				{
					d = num7;
				}
				else
				{
					double num8 = Math.Log(num7) / Math.Log(d);
					d = num7;
					if (num8 > 1.9 && num8 < 2.1)
					{
						num7 = Math.Sqrt(num7);
					}
					if (num4.AlmostEqualNormRelative(num6, num7, targetRelativeError))
					{
						break;
					}
				}
				num5++;
			}
			return num4 * num;
		}

		public static Complex ContourIntegrateAdaptiveTransformedOdd(Func<double, Complex> f, double intervalBegin, double intervalEnd, IEnumerable<double[]> levelAbscissas, IEnumerable<double[]> levelWeights, double levelOneStep, double targetRelativeError)
		{
			if (f == null)
			{
				throw new ArgumentNullException("f");
			}
			if (levelAbscissas == null)
			{
				throw new ArgumentNullException("levelAbscissas");
			}
			if (levelWeights == null)
			{
				throw new ArgumentNullException("levelWeights");
			}
			double num = 0.5 * (intervalEnd - intervalBegin);
			double num2 = 0.5 * (intervalEnd + intervalBegin);
			targetRelativeError /= 5.0 * num;
			using IEnumerator<double[]> enumerator = levelAbscissas.GetEnumerator();
			using IEnumerator<double[]> enumerator2 = levelWeights.GetEnumerator();
			double num3 = levelOneStep;
			enumerator.MoveNext();
			enumerator2.MoveNext();
			double[] array = enumerator.Current ?? throw new ArgumentNullException("levelAbscissas");
			double[] array2 = enumerator2.Current ?? throw new ArgumentNullException("levelWeights");
			Complex complex = f(num2) * array2[0];
			for (int i = 1; i < array.Length; i++)
			{
				complex += array2[i] * (f(num * array[i] + num2) + f(0.0 - num * array[i] + num2));
			}
			complex *= (Complex)num3;
			double d = double.MaxValue;
			int num4 = 1;
			while (enumerator.MoveNext() && enumerator2.MoveNext())
			{
				double[] array3 = enumerator.Current ?? throw new ArgumentNullException("levelAbscissas");
				double[] array4 = enumerator2.Current ?? throw new ArgumentNullException("levelWeights");
				Complex complex2 = 0;
				for (int j = 0; j < array3.Length; j++)
				{
					complex2 += array4[j] * (f(num * array3[j] + num2) + f(0.0 - num * array3[j] + num2));
				}
				complex2 *= (Complex)num3;
				complex = 0.5 * (complex + complex2);
				num3 *= 0.5;
				double num5 = Complex.Abs(complex - complex2);
				if (num4 == 1)
				{
					d = num5;
				}
				else
				{
					double num6 = Math.Log(num5) / Math.Log(d);
					d = num5;
					if (num6 > 1.9 && num6 < 2.1)
					{
						num5 = Math.Sqrt(num5);
					}
					if (complex.Real.AlmostEqualNormRelative(complex2.Real, num5, targetRelativeError) && complex.Imaginary.AlmostEqualNormRelative(complex2.Imaginary, num5, targetRelativeError))
					{
						break;
					}
				}
				num4++;
			}
			return complex * num;
		}
	}
}
