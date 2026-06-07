using System;
using System.Collections.Generic;
using System.Linq;

namespace MathNet.Numerics.Interpolation
{
	public class CubicSpline : IInterpolation
	{
		private readonly double[] _x;

		private readonly double[] _c0;

		private readonly double[] _c1;

		private readonly double[] _c2;

		private readonly double[] _c3;

		private readonly Lazy<double[]> _indefiniteIntegral;

		bool IInterpolation.SupportsDifferentiation => true;

		bool IInterpolation.SupportsIntegration => true;

		public CubicSpline(double[] x, double[] c0, double[] c1, double[] c2, double[] c3)
		{
			if (x.Length != c0.Length + 1 || x.Length != c1.Length + 1 || x.Length != c2.Length + 1 || x.Length != c3.Length + 1)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 2)
			{
				throw new ArgumentException("The given array is too small. It must be at least 2 long.", "x");
			}
			_x = x;
			_c0 = c0;
			_c1 = c1;
			_c2 = c2;
			_c3 = c3;
			_indefiniteIntegral = new Lazy<double[]>(ComputeIndefiniteIntegral);
		}

		public static CubicSpline InterpolateHermiteSorted(double[] x, double[] y, double[] firstDerivatives)
		{
			if (x.Length != y.Length || x.Length != firstDerivatives.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 2)
			{
				throw new ArgumentException("The given array is too small. It must be at least 2 long.", "x");
			}
			double[] array = new double[x.Length - 1];
			double[] array2 = new double[x.Length - 1];
			double[] array3 = new double[x.Length - 1];
			double[] array4 = new double[x.Length - 1];
			for (int i = 0; i < array2.Length; i++)
			{
				double num = x[i + 1] - x[i];
				double num2 = num * num;
				array[i] = y[i];
				array2[i] = firstDerivatives[i];
				array3[i] = (3.0 * (y[i + 1] - y[i]) / num - 2.0 * firstDerivatives[i] - firstDerivatives[i + 1]) / num;
				array4[i] = (2.0 * (y[i] - y[i + 1]) / num + firstDerivatives[i] + firstDerivatives[i + 1]) / num2;
			}
			return new CubicSpline(x, array, array2, array3, array4);
		}

		public static CubicSpline InterpolateHermiteInplace(double[] x, double[] y, double[] firstDerivatives)
		{
			if (x.Length != y.Length || x.Length != firstDerivatives.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 2)
			{
				throw new ArgumentException("The given array is too small. It must be at least 2 long.", "x");
			}
			Sorting.Sort(x, y, firstDerivatives);
			return InterpolateHermiteSorted(x, y, firstDerivatives);
		}

		public static CubicSpline InterpolateHermite(IEnumerable<double> x, IEnumerable<double> y, IEnumerable<double> firstDerivatives)
		{
			return InterpolateHermiteInplace(x.ToArray(), y.ToArray(), firstDerivatives.ToArray());
		}

		public static CubicSpline InterpolateAkimaSorted(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 5)
			{
				throw new ArgumentException("The given array is too small. It must be at least 5 long.", "x");
			}
			double[] array = new double[x.Length - 1];
			double[] array2 = new double[x.Length - 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (y[i + 1] - y[i]) / (x[i + 1] - x[i]);
			}
			for (int j = 1; j < array2.Length; j++)
			{
				array2[j] = Math.Abs(array[j] - array[j - 1]);
			}
			double[] array3 = new double[x.Length];
			for (int k = 2; k < array3.Length - 2; k++)
			{
				array3[k] = ((array2[k - 1].AlmostEqual(0.0) && array2[k + 1].AlmostEqual(0.0)) ? (((x[k + 1] - x[k]) * array[k - 1] + (x[k] - x[k - 1]) * array[k]) / (x[k + 1] - x[k - 1])) : ((array2[k + 1] * array[k - 1] + array2[k - 1] * array[k]) / (array2[k + 1] + array2[k - 1])));
			}
			array3[0] = DifferentiateThreePoint(x, y, 0, 0, 1, 2);
			array3[1] = DifferentiateThreePoint(x, y, 1, 0, 1, 2);
			array3[x.Length - 2] = DifferentiateThreePoint(x, y, x.Length - 2, x.Length - 3, x.Length - 2, x.Length - 1);
			array3[x.Length - 1] = DifferentiateThreePoint(x, y, x.Length - 1, x.Length - 3, x.Length - 2, x.Length - 1);
			return InterpolateHermiteSorted(x, y, array3);
		}

		public static CubicSpline InterpolateAkimaInplace(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Sorting.Sort(x, y);
			return InterpolateAkimaSorted(x, y);
		}

		public static CubicSpline InterpolateAkima(IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolateAkimaInplace(x.ToArray(), y.ToArray());
		}

		public static CubicSpline InterpolateMakimaSorted(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 5)
			{
				throw new ArgumentException("The given array is too small. It must be at least 5 long.", "x");
			}
			int num = x.Length;
			double[] array = new double[num - 1];
			for (int i = 0; i < num - 1; i++)
			{
				array[i] = x[i + 1] - x[i];
			}
			int num2 = num + 3;
			double[] array2 = new double[num2];
			for (int j = 0; j < num - 1; j++)
			{
				array2[j + 2] = (y[j + 1] - y[j]) / array[j];
			}
			array2[1] = 2.0 * array2[2] - array2[3];
			array2[0] = 2.0 * array2[1] - array2[2];
			array2[num + 1] = 2.0 * array2[num] - array2[num - 1];
			array2[num + 2] = 2.0 * array2[num + 1] - array2[num];
			int num3 = num2 - 1;
			double[] array3 = new double[num3];
			double[] array4 = new double[num3];
			for (int k = 0; k < num3; k++)
			{
				array3[k] = Math.Abs(array2[k + 1] - array2[k]);
				array4[k] = Math.Abs(array2[k + 1] + array2[k]);
			}
			double[] array5 = new double[num];
			double[] array6 = new double[num];
			for (int l = 0; l < num; l++)
			{
				array5[l] = array3[l + 2] + 0.5 * array4[l + 2];
				array6[l] = array3[l] + 0.5 * array4[l];
			}
			double[] array7 = new double[num];
			for (int m = 0; m < num; m++)
			{
				array7[m] = array5[m] + array6[m];
			}
			double[] array8 = new double[num];
			for (int n = 0; n < num; n++)
			{
				array8[n] = 0.5 * (array2[n + 3] + array2[n]);
			}
			double num4 = 0.0;
			for (int num5 = 0; num5 < num; num5++)
			{
				if (array7[num5] > num4)
				{
					num4 = array7[num5];
				}
			}
			double num6 = 1E-09 * num4;
			for (int num7 = 0; num7 < num; num7++)
			{
				if (array7[num7] > num6)
				{
					array8[num7] = (array5[num7] * array2[num7 + 1] + array6[num7] * array2[num7 + 2]) / array7[num7];
				}
			}
			return InterpolateHermiteSorted(x, y, array8);
		}

		public static CubicSpline InterpolateMakimaInplace(double[] x, double[] y)
		{
			Sorting.Sort(x, y);
			return InterpolateMakimaSorted(x, y);
		}

		public static CubicSpline InterpolateMakima(IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolateMakimaInplace(x.ToArray(), y.ToArray());
		}

		public static CubicSpline InterpolatePchipSorted(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 3)
			{
				throw new ArgumentException("The given array is too small. It must be at least 3 long.", "x");
			}
			double[] array = new double[x.Length - 1];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (y[i + 1] - y[i]) / (x[i + 1] - x[i]);
			}
			double[] array2 = new double[x.Length];
			double num = x[1] - x[0];
			bool flag = array[0].AlmostEqual(0.0);
			for (int j = 1; j < x.Length - 1; j++)
			{
				double num2 = x[j + 1] - x[j];
				bool num3 = array[j].AlmostEqual(0.0);
				if (num3 || flag || Math.Sign(array[j]) != Math.Sign(array[j - 1]))
				{
					array2[j] = 0.0;
				}
				else
				{
					double num4 = 2.0 * num2 + num;
					double num5 = num2 + 2.0 * num;
					array2[j] = (num4 + num5) / (num4 / array[j - 1] + num5 / array[j]);
				}
				num = num2;
				flag = num3;
			}
			array2[0] = PchipEndPoints(x[1] - x[0], x[2] - x[1], array[0], array[1]);
			array2[^1] = PchipEndPoints(x[^1] - x[^2], x[^2] - x[^3], array[^1], array[^2]);
			return InterpolateHermiteSorted(x, y, array2);
		}

		private static double PchipEndPoints(double h0, double h1, double m0, double m1)
		{
			double num = ((2.0 * h0 + h1) * m0 - h0 * m1) / (h0 + h1);
			if (Math.Sign(num) != Math.Sign(m0))
			{
				return 0.0;
			}
			if (Math.Sign(m0) != Math.Sign(m1) && Math.Abs(num) > 3.0 * Math.Abs(m0))
			{
				return 3.0 * m0;
			}
			return num;
		}

		public static CubicSpline InterpolatePchipInplace(double[] x, double[] y)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Sorting.Sort(x, y);
			return InterpolatePchipSorted(x, y);
		}

		public static CubicSpline InterpolatePchip(IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolatePchipInplace(x.ToArray(), y.ToArray());
		}

		public static CubicSpline InterpolateBoundariesSorted(double[] x, double[] y, SplineBoundaryCondition leftBoundaryCondition, double leftBoundary, SplineBoundaryCondition rightBoundaryCondition, double rightBoundary)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (x.Length < 2)
			{
				throw new ArgumentException("The given array is too small. It must be at least 2 long.", "x");
			}
			int num = x.Length;
			if (num == 2 && leftBoundaryCondition == SplineBoundaryCondition.ParabolicallyTerminated && rightBoundaryCondition == SplineBoundaryCondition.ParabolicallyTerminated)
			{
				leftBoundaryCondition = SplineBoundaryCondition.SecondDerivative;
				leftBoundary = 0.0;
				rightBoundaryCondition = SplineBoundaryCondition.SecondDerivative;
				rightBoundary = 0.0;
			}
			if (leftBoundaryCondition == SplineBoundaryCondition.Natural)
			{
				leftBoundaryCondition = SplineBoundaryCondition.SecondDerivative;
				leftBoundary = 0.0;
			}
			if (rightBoundaryCondition == SplineBoundaryCondition.Natural)
			{
				rightBoundaryCondition = SplineBoundaryCondition.SecondDerivative;
				rightBoundary = 0.0;
			}
			double[] array = new double[num];
			double[] array2 = new double[num];
			double[] array3 = new double[num];
			double[] array4 = new double[num];
			switch (leftBoundaryCondition)
			{
			case SplineBoundaryCondition.ParabolicallyTerminated:
				array[0] = 0.0;
				array2[0] = 1.0;
				array3[0] = 1.0;
				array4[0] = 2.0 * (y[1] - y[0]) / (x[1] - x[0]);
				break;
			case SplineBoundaryCondition.FirstDerivative:
				array[0] = 0.0;
				array2[0] = 1.0;
				array3[0] = 0.0;
				array4[0] = leftBoundary;
				break;
			case SplineBoundaryCondition.SecondDerivative:
				array[0] = 0.0;
				array2[0] = 2.0;
				array3[0] = 1.0;
				array4[0] = 3.0 * ((y[1] - y[0]) / (x[1] - x[0])) - 0.5 * leftBoundary * (x[1] - x[0]);
				break;
			default:
				throw new NotSupportedException("Invalid Left Boundary Condition.");
			}
			for (int i = 1; i < x.Length - 1; i++)
			{
				array[i] = x[i + 1] - x[i];
				array2[i] = 2.0 * (x[i + 1] - x[i - 1]);
				array3[i] = x[i] - x[i - 1];
				array4[i] = 3.0 * (y[i] - y[i - 1]) / (x[i] - x[i - 1]) * (x[i + 1] - x[i]) + 3.0 * (y[i + 1] - y[i]) / (x[i + 1] - x[i]) * (x[i] - x[i - 1]);
			}
			switch (rightBoundaryCondition)
			{
			case SplineBoundaryCondition.ParabolicallyTerminated:
				array[num - 1] = 1.0;
				array2[num - 1] = 1.0;
				array3[num - 1] = 0.0;
				array4[num - 1] = 2.0 * (y[num - 1] - y[num - 2]) / (x[num - 1] - x[num - 2]);
				break;
			case SplineBoundaryCondition.FirstDerivative:
				array[num - 1] = 0.0;
				array2[num - 1] = 1.0;
				array3[num - 1] = 0.0;
				array4[num - 1] = rightBoundary;
				break;
			case SplineBoundaryCondition.SecondDerivative:
				array[num - 1] = 1.0;
				array2[num - 1] = 2.0;
				array3[num - 1] = 0.0;
				array4[num - 1] = 3.0 * (y[num - 1] - y[num - 2]) / (x[num - 1] - x[num - 2]) + 0.5 * rightBoundary * (x[num - 1] - x[num - 2]);
				break;
			default:
				throw new NotSupportedException("Invalid Right Boundary Condition.");
			}
			double[] firstDerivatives = SolveTridiagonal(array, array2, array3, array4);
			return InterpolateHermiteSorted(x, y, firstDerivatives);
		}

		public static CubicSpline InterpolateBoundariesInplace(double[] x, double[] y, SplineBoundaryCondition leftBoundaryCondition, double leftBoundary, SplineBoundaryCondition rightBoundaryCondition, double rightBoundary)
		{
			if (x.Length != y.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			Sorting.Sort(x, y);
			return InterpolateBoundariesSorted(x, y, leftBoundaryCondition, leftBoundary, rightBoundaryCondition, rightBoundary);
		}

		public static CubicSpline InterpolateBoundaries(IEnumerable<double> x, IEnumerable<double> y, SplineBoundaryCondition leftBoundaryCondition, double leftBoundary, SplineBoundaryCondition rightBoundaryCondition, double rightBoundary)
		{
			return InterpolateBoundariesInplace(x.ToArray(), y.ToArray(), leftBoundaryCondition, leftBoundary, rightBoundaryCondition, rightBoundary);
		}

		public static CubicSpline InterpolateNaturalSorted(double[] x, double[] y)
		{
			return InterpolateBoundariesSorted(x, y, SplineBoundaryCondition.SecondDerivative, 0.0, SplineBoundaryCondition.SecondDerivative, 0.0);
		}

		public static CubicSpline InterpolateNaturalInplace(double[] x, double[] y)
		{
			return InterpolateBoundariesInplace(x, y, SplineBoundaryCondition.SecondDerivative, 0.0, SplineBoundaryCondition.SecondDerivative, 0.0);
		}

		public static CubicSpline InterpolateNatural(IEnumerable<double> x, IEnumerable<double> y)
		{
			return InterpolateBoundaries(x, y, SplineBoundaryCondition.SecondDerivative, 0.0, SplineBoundaryCondition.SecondDerivative, 0.0);
		}

		private static double DifferentiateThreePoint(double[] xx, double[] yy, int indexT, int index0, int index1, int index2)
		{
			double num = yy[index0];
			double num2 = yy[index1];
			double num3 = yy[index2];
			double num4 = xx[indexT] - xx[index0];
			double num5 = xx[index1] - xx[index0];
			double num6 = xx[index2] - xx[index0];
			double num7 = (num3 - num - num6 / num5 * (num2 - num)) / (num6 * (num6 - num5));
			double num8 = (num2 - num - num7 * num5 * num5) / num5;
			return 2.0 * num7 * num4 + num8;
		}

		private static double[] SolveTridiagonal(double[] a, double[] b, double[] c, double[] d)
		{
			for (int i = 1; i < a.Length; i++)
			{
				double num = a[i] / b[i - 1];
				b[i] -= num * c[i - 1];
				d[i] -= num * d[i - 1];
			}
			double[] array = new double[a.Length];
			array[^1] = d[^1] / b[^1];
			for (int num2 = array.Length - 2; num2 >= 0; num2--)
			{
				array[num2] = (d[num2] - c[num2] * array[num2 + 1]) / b[num2];
			}
			return array;
		}

		public double Interpolate(double t)
		{
			int num = LeftSegmentIndex(t);
			double num2 = t - _x[num];
			return _c0[num] + num2 * (_c1[num] + num2 * (_c2[num] + num2 * _c3[num]));
		}

		public double Differentiate(double t)
		{
			int num = LeftSegmentIndex(t);
			double num2 = t - _x[num];
			return _c1[num] + num2 * (2.0 * _c2[num] + num2 * 3.0 * _c3[num]);
		}

		public double Differentiate2(double t)
		{
			int num = LeftSegmentIndex(t);
			double num2 = t - _x[num];
			return 2.0 * _c2[num] + num2 * 6.0 * _c3[num];
		}

		public double Integrate(double t)
		{
			int num = LeftSegmentIndex(t);
			double num2 = t - _x[num];
			return _indefiniteIntegral.Value[num] + num2 * (_c0[num] + num2 * (_c1[num] / 2.0 + num2 * (_c2[num] / 3.0 + num2 * _c3[num] / 4.0)));
		}

		public double Integrate(double a, double b)
		{
			return Integrate(b) - Integrate(a);
		}

		private double[] ComputeIndefiniteIntegral()
		{
			double[] array = new double[_c1.Length];
			for (int i = 0; i < array.Length - 1; i++)
			{
				double num = _x[i + 1] - _x[i];
				array[i + 1] = array[i] + num * (_c0[i] + num * (_c1[i] / 2.0 + num * (_c2[i] / 3.0 + num * _c3[i] / 4.0)));
			}
			return array;
		}

		private int LeftSegmentIndex(double t)
		{
			int num = Array.BinarySearch(_x, t);
			if (num < 0)
			{
				num = ~num - 1;
			}
			return Math.Min(Math.Max(num, 0), _x.Length - 2);
		}

		public double[] StationaryPoints()
		{
			List<double> list = new List<double>();
			for (int i = 0; i < _x.Length - 1; i++)
			{
				double num = 6.0 * _c3[i];
				double num2 = 2.0 * _c2[i];
				double num3 = _c1[i];
				double num4 = num2 * num2 - 2.0 * num * num3;
				if (num.AlmostEqual(0.0))
				{
					double num5 = _x[i] - num3 / num2;
					if (_x[i] <= num5 && num5 <= _x[i + 1])
					{
						list.Add(num5);
					}
				}
				else if (num4.AlmostEqual(0.0))
				{
					double num6 = _x[i] - num2 / num;
					if (_x[i] <= num6 && num6 <= _x[i + 1])
					{
						list.Add(num6);
					}
				}
				else if (num4 > 0.0)
				{
					num4 = Math.Sqrt(num4);
					double num7 = _x[i] + (0.0 - num2 + num4) / num;
					double num8 = _x[i] + (0.0 - num2 - num4) / num;
					if (_x[i] <= num7 && num7 <= _x[i + 1])
					{
						list.Add(num7);
					}
					if (_x[i] <= num8 && num8 <= _x[i + 1])
					{
						list.Add(num8);
					}
				}
			}
			return list.ToArray();
		}

		public Tuple<double, double> Extrema()
		{
			double num = _x[0];
			double num2 = Interpolate(num);
			double num3 = num2;
			double item = num;
			double item2 = num;
			num = _x[_x.Length - 1];
			double num4 = Interpolate(num);
			if (num4 > num2)
			{
				num2 = num4;
				item2 = num;
			}
			if (num4 < num3)
			{
				num3 = num4;
				item = num;
			}
			double[] array = StationaryPoints();
			foreach (double num5 in array)
			{
				double num6 = Interpolate(num5);
				if (num6 > num2)
				{
					num2 = num6;
					item2 = num5;
				}
				if (num6 < num3)
				{
					num3 = num6;
					item = num5;
				}
			}
			return new Tuple<double, double>(item, item2);
		}
	}
}
