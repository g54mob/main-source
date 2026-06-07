using System;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Double
{
	[Serializable]
	public abstract class Vector : Vector<double>
	{
		protected Vector(VectorStorage<double> storage)
			: base(storage)
		{
		}

		public override void CoerceZero(double threshold)
		{
			MapInplace((double x) => (!(Math.Abs(x) < threshold)) ? x : 0.0);
		}

		protected sealed override void DoConjugate(Vector<double> result)
		{
			if (this != result)
			{
				CopyTo(result);
			}
		}

		protected override void DoNegate(Vector<double> result)
		{
			Map((double x) => 0.0 - x, result);
		}

		protected override void DoAdd(double scalar, Vector<double> result)
		{
			Map((double x) => x + scalar, result, Zeros.Include);
		}

		protected override void DoAdd(Vector<double> other, Vector<double> result)
		{
			Map2((double x, double y) => x + y, other, result);
		}

		protected override void DoSubtract(double scalar, Vector<double> result)
		{
			Map((double x) => x - scalar, result, Zeros.Include);
		}

		protected override void DoSubtract(Vector<double> other, Vector<double> result)
		{
			Map2((double x, double y) => x - y, other, result);
		}

		protected override void DoMultiply(double scalar, Vector<double> result)
		{
			Map((double x) => x * scalar, result);
		}

		protected override void DoDivide(double divisor, Vector<double> result)
		{
			Map((double x) => x / divisor, result, (divisor == 0.0) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoDivideByThis(double dividend, Vector<double> result)
		{
			Map((double x) => dividend / x, result, Zeros.Include);
		}

		protected override void DoPointwiseMultiply(Vector<double> other, Vector<double> result)
		{
			Map2((double x, double y) => x * y, other, result);
		}

		protected override void DoPointwiseDivide(Vector<double> divisor, Vector<double> result)
		{
			Map2((double x, double y) => x / y, divisor, result, Zeros.Include);
		}

		protected override void DoPointwisePower(double exponent, Vector<double> result)
		{
			Map((double x) => Math.Pow(x, exponent), result, (!(exponent > 0.0)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwisePower(Vector<double> exponent, Vector<double> result)
		{
			Map2(Math.Pow, exponent, result, Zeros.Include);
		}

		protected override void DoPointwiseModulus(Vector<double> divisor, Vector<double> result)
		{
			Map2(Euclid.Modulus, divisor, result, Zeros.Include);
		}

		protected override void DoPointwiseRemainder(Vector<double> divisor, Vector<double> result)
		{
			Map2(Euclid.Remainder, divisor, result, Zeros.Include);
		}

		protected override void DoPointwiseExp(Vector<double> result)
		{
			Map(Math.Exp, result, Zeros.Include);
		}

		protected override void DoPointwiseLog(Vector<double> result)
		{
			Map(Math.Log, result, Zeros.Include);
		}

		protected override void DoPointwiseAbs(Vector<double> result)
		{
			Map(Math.Abs, result);
		}

		protected override void DoPointwiseAcos(Vector<double> result)
		{
			Map(Math.Acos, result, Zeros.Include);
		}

		protected override void DoPointwiseAsin(Vector<double> result)
		{
			Map(Math.Asin, result);
		}

		protected override void DoPointwiseAtan(Vector<double> result)
		{
			Map(Math.Atan, result);
		}

		protected override void DoPointwiseAtan2(Vector<double> other, Vector<double> result)
		{
			Map2(Math.Atan2, other, result, Zeros.Include);
		}

		protected override void DoPointwiseAtan2(double scalar, Vector<double> result)
		{
			Map((double x) => Math.Atan2(x, scalar), result, Zeros.Include);
		}

		protected override void DoPointwiseCeiling(Vector<double> result)
		{
			Map(Math.Ceiling, result);
		}

		protected override void DoPointwiseCos(Vector<double> result)
		{
			Map(Math.Cos, result, Zeros.Include);
		}

		protected override void DoPointwiseCosh(Vector<double> result)
		{
			Map(Math.Cosh, result, Zeros.Include);
		}

		protected override void DoPointwiseFloor(Vector<double> result)
		{
			Map(Math.Floor, result);
		}

		protected override void DoPointwiseLog10(Vector<double> result)
		{
			Map(Math.Log10, result, Zeros.Include);
		}

		protected override void DoPointwiseRound(Vector<double> result)
		{
			Map(Math.Round, result);
		}

		protected override void DoPointwiseSign(Vector<double> result)
		{
			Map((double x) => Math.Sign(x), result);
		}

		protected override void DoPointwiseSin(Vector<double> result)
		{
			Map(Math.Sin, result);
		}

		protected override void DoPointwiseSinh(Vector<double> result)
		{
			Map(Math.Sinh, result);
		}

		protected override void DoPointwiseSqrt(Vector<double> result)
		{
			Map(Math.Sqrt, result);
		}

		protected override void DoPointwiseTan(Vector<double> result)
		{
			Map(Math.Tan, result);
		}

		protected override void DoPointwiseTanh(Vector<double> result)
		{
			Map(Math.Tanh, result);
		}

		protected override double DoDotProduct(Vector<double> other)
		{
			double num = 0.0;
			for (int i = 0; i < base.Count; i++)
			{
				num += At(i) * other.At(i);
			}
			return num;
		}

		protected sealed override double DoConjugateDotProduct(Vector<double> other)
		{
			return DoDotProduct(other);
		}

		protected override void DoModulus(double divisor, Vector<double> result)
		{
			Map((double x) => Euclid.Modulus(x, divisor), result, Zeros.Include);
		}

		protected override void DoModulusByThis(double dividend, Vector<double> result)
		{
			Map((double x) => Euclid.Modulus(dividend, x), result, Zeros.Include);
		}

		protected override void DoRemainder(double divisor, Vector<double> result)
		{
			Map((double x) => Euclid.Remainder(x, divisor), result, Zeros.Include);
		}

		protected override void DoRemainderByThis(double dividend, Vector<double> result)
		{
			Map((double x) => Euclid.Remainder(dividend, x), result, Zeros.Include);
		}

		protected override void DoPointwiseMinimum(double scalar, Vector<double> result)
		{
			Map((double x) => Math.Min(scalar, x), result, (!(scalar >= 0.0)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwiseMaximum(double scalar, Vector<double> result)
		{
			Map((double x) => Math.Max(scalar, x), result, (!(scalar <= 0.0)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwiseAbsoluteMinimum(double scalar, Vector<double> result)
		{
			double absolute = Math.Abs(scalar);
			Map((double x) => Math.Min(absolute, Math.Abs(x)), result);
		}

		protected override void DoPointwiseAbsoluteMaximum(double scalar, Vector<double> result)
		{
			double absolute = Math.Abs(scalar);
			Map((double x) => Math.Max(absolute, Math.Abs(x)), result, Zeros.Include);
		}

		protected override void DoPointwiseMinimum(Vector<double> other, Vector<double> result)
		{
			Map2(Math.Min, other, result);
		}

		protected override void DoPointwiseMaximum(Vector<double> other, Vector<double> result)
		{
			Map2(Math.Max, other, result);
		}

		protected override void DoPointwiseAbsoluteMinimum(Vector<double> other, Vector<double> result)
		{
			Map2((double x, double y) => Math.Min(Math.Abs(x), Math.Abs(y)), other, result);
		}

		protected override void DoPointwiseAbsoluteMaximum(Vector<double> other, Vector<double> result)
		{
			Map2((double x, double y) => Math.Max(Math.Abs(x), Math.Abs(y)), other, result);
		}

		public override double AbsoluteMinimum()
		{
			return Math.Abs(At(AbsoluteMinimumIndex()));
		}

		public override int AbsoluteMinimumIndex()
		{
			int num = 0;
			double num2 = Math.Abs(At(num));
			for (int i = 1; i < base.Count; i++)
			{
				double num3 = Math.Abs(At(i));
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return num;
		}

		public override double AbsoluteMaximum()
		{
			return Math.Abs(At(AbsoluteMaximumIndex()));
		}

		public override int AbsoluteMaximumIndex()
		{
			int num = 0;
			double num2 = Math.Abs(At(num));
			for (int i = 1; i < base.Count; i++)
			{
				double num3 = Math.Abs(At(i));
				if (num3 > num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return num;
		}

		public override double Sum()
		{
			double num = 0.0;
			for (int i = 0; i < base.Count; i++)
			{
				num += At(i);
			}
			return num;
		}

		public override double L1Norm()
		{
			double num = 0.0;
			for (int i = 0; i < base.Count; i++)
			{
				num += Math.Abs(At(i));
			}
			return num;
		}

		public override double L2Norm()
		{
			return Math.Sqrt(DoDotProduct(this));
		}

		public override double InfinityNorm()
		{
			return CommonParallel.Aggregate(0, base.Count, (int i) => Math.Abs(At(i)), Math.Max, 0.0);
		}

		public override double Norm(double p)
		{
			if (p < 0.0)
			{
				throw new ArgumentOutOfRangeException("p");
			}
			if (p == 1.0)
			{
				return L1Norm();
			}
			if (p == 2.0)
			{
				return L2Norm();
			}
			if (double.IsPositiveInfinity(p))
			{
				return InfinityNorm();
			}
			double num = 0.0;
			for (int i = 0; i < base.Count; i++)
			{
				num += Math.Pow(Math.Abs(At(i)), p);
			}
			return Math.Pow(num, 1.0 / p);
		}

		public override int MaximumIndex()
		{
			int num = 0;
			double num2 = At(num);
			for (int i = 1; i < base.Count; i++)
			{
				double num3 = At(i);
				if (num3 > num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return num;
		}

		public override int MinimumIndex()
		{
			int num = 0;
			double num2 = At(num);
			for (int i = 1; i < base.Count; i++)
			{
				double num3 = At(i);
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return num;
		}

		public override Vector<double> Normalize(double p)
		{
			if (p < 0.0)
			{
				throw new ArgumentOutOfRangeException("p");
			}
			double num = Norm(p);
			Vector<double> vector = Clone();
			if (num == 0.0)
			{
				return vector;
			}
			vector.Multiply(1.0 / num, vector);
			return vector;
		}
	}
}
