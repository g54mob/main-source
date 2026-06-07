using System.Collections.Generic;
using MathNet.Numerics.Interpolation;

namespace MathNet.Numerics
{
	public static class Interpolate
	{
		public static IInterpolation Common(IEnumerable<double> points, IEnumerable<double> values)
		{
			return Barycentric.InterpolateRationalFloaterHormann(points, values);
		}

		public static IInterpolation RationalWithoutPoles(IEnumerable<double> points, IEnumerable<double> values)
		{
			return Barycentric.InterpolateRationalFloaterHormann(points, values);
		}

		public static IInterpolation RationalWithPoles(IEnumerable<double> points, IEnumerable<double> values)
		{
			return BulirschStoerRationalInterpolation.Interpolate(points, values);
		}

		public static IInterpolation PolynomialEquidistant(IEnumerable<double> points, IEnumerable<double> values)
		{
			return Barycentric.InterpolatePolynomialEquidistant(points, values);
		}

		public static IInterpolation Polynomial(IEnumerable<double> points, IEnumerable<double> values)
		{
			return NevillePolynomialInterpolation.Interpolate(points, values);
		}

		public static IInterpolation Linear(IEnumerable<double> points, IEnumerable<double> values)
		{
			return LinearSpline.Interpolate(points, values);
		}

		public static IInterpolation LogLinear(IEnumerable<double> points, IEnumerable<double> values)
		{
			return MathNet.Numerics.Interpolation.LogLinear.Interpolate(points, values);
		}

		public static IInterpolation CubicSpline(IEnumerable<double> points, IEnumerable<double> values)
		{
			return MathNet.Numerics.Interpolation.CubicSpline.InterpolateNatural(points, values);
		}

		public static IInterpolation CubicSplineRobust(IEnumerable<double> points, IEnumerable<double> values)
		{
			return MathNet.Numerics.Interpolation.CubicSpline.InterpolateAkima(points, values);
		}

		public static IInterpolation CubicSplineMonotone(IEnumerable<double> points, IEnumerable<double> values)
		{
			return MathNet.Numerics.Interpolation.CubicSpline.InterpolatePchip(points, values);
		}

		public static IInterpolation CubicSplineWithDerivatives(IEnumerable<double> points, IEnumerable<double> values, IEnumerable<double> firstDerivatives)
		{
			return MathNet.Numerics.Interpolation.CubicSpline.InterpolateHermite(points, values, firstDerivatives);
		}

		public static IInterpolation Step(IEnumerable<double> points, IEnumerable<double> values)
		{
			return StepInterpolation.Interpolate(points, values);
		}
	}
}
