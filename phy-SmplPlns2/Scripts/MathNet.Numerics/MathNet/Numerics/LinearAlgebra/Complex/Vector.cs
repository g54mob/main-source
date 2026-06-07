using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Complex
{
	[Serializable]
	public abstract class Vector : Vector<System.Numerics.Complex>
	{
		protected Vector(VectorStorage<System.Numerics.Complex> storage)
			: base(storage)
		{
		}

		public override void CoerceZero(double threshold)
		{
			MapInplace((System.Numerics.Complex x) => (!(x.Magnitude < threshold)) ? x : System.Numerics.Complex.Zero);
		}

		protected override void DoConjugate(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Conjugate, result);
		}

		protected override void DoNegate(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Negate, result);
		}

		protected override void DoAdd(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => x + scalar, result, Zeros.Include);
		}

		protected override void DoAdd(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			Map2(System.Numerics.Complex.Add, other, result);
		}

		protected override void DoSubtract(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => x - scalar, result, Zeros.Include);
		}

		protected override void DoSubtract(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			Map2(System.Numerics.Complex.Subtract, other, result);
		}

		protected override void DoMultiply(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => x * scalar, result);
		}

		protected override void DoDivide(System.Numerics.Complex divisor, Vector<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => x / divisor, result, divisor.IsZero() ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoDivideByThis(System.Numerics.Complex dividend, Vector<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => dividend / x, result, Zeros.Include);
		}

		protected override void DoPointwiseMultiply(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			Map2(System.Numerics.Complex.Multiply, other, result);
		}

		protected override void DoPointwiseDivide(Vector<System.Numerics.Complex> divisor, Vector<System.Numerics.Complex> result)
		{
			Map2(System.Numerics.Complex.Divide, divisor, result, Zeros.Include);
		}

		protected override void DoPointwisePower(System.Numerics.Complex exponent, Vector<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => x.Power(exponent), result, Zeros.Include);
		}

		protected override void DoPointwisePower(Vector<System.Numerics.Complex> exponent, Vector<System.Numerics.Complex> result)
		{
			Map2(System.Numerics.Complex.Pow, exponent, result, Zeros.Include);
		}

		protected sealed override void DoPointwiseModulus(Vector<System.Numerics.Complex> divisor, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoPointwiseRemainder(Vector<System.Numerics.Complex> divisor, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseExp(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Exp, result, Zeros.Include);
		}

		protected override void DoPointwiseLog(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Log, result, Zeros.Include);
		}

		protected override void DoPointwiseAbs(Vector<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => System.Numerics.Complex.Abs(x), result);
		}

		protected override void DoPointwiseAcos(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Acos, result, Zeros.Include);
		}

		protected override void DoPointwiseAsin(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Asin, result);
		}

		protected override void DoPointwiseAtan(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Atan, result);
		}

		protected override void DoPointwiseAtan2(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseAtan2(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseCeiling(Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseCos(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Cos, result, Zeros.Include);
		}

		protected override void DoPointwiseCosh(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Cosh, result, Zeros.Include);
		}

		protected override void DoPointwiseFloor(Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseLog10(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Log10, result, Zeros.Include);
		}

		protected override void DoPointwiseRound(Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseSign(Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseSin(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Sin, result);
		}

		protected override void DoPointwiseSinh(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Sinh, result);
		}

		protected override void DoPointwiseSqrt(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Sqrt, result);
		}

		protected override void DoPointwiseTan(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Tan, result);
		}

		protected override void DoPointwiseTanh(Vector<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Tanh, result);
		}

		protected override System.Numerics.Complex DoDotProduct(Vector<System.Numerics.Complex> other)
		{
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
			for (int i = 0; i < base.Count; i++)
			{
				zero += At(i) * other.At(i);
			}
			return zero;
		}

		protected override System.Numerics.Complex DoConjugateDotProduct(Vector<System.Numerics.Complex> other)
		{
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
			for (int i = 0; i < base.Count; i++)
			{
				zero += At(i).Conjugate() * other.At(i);
			}
			return zero;
		}

		protected sealed override void DoModulus(System.Numerics.Complex divisor, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoModulusByThis(System.Numerics.Complex dividend, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoRemainder(System.Numerics.Complex divisor, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoRemainderByThis(System.Numerics.Complex dividend, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseMinimum(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseMaximum(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseAbsoluteMinimum(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			double absolute = scalar.Magnitude;
			Map((System.Numerics.Complex x) => Math.Min(absolute, x.Magnitude), result);
		}

		protected override void DoPointwiseAbsoluteMaximum(System.Numerics.Complex scalar, Vector<System.Numerics.Complex> result)
		{
			double absolute = scalar.Magnitude;
			Map((System.Numerics.Complex x) => Math.Max(absolute, x.Magnitude), result, Zeros.Include);
		}

		protected override void DoPointwiseMinimum(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseMaximum(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseAbsoluteMinimum(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			Map2((System.Numerics.Complex x, System.Numerics.Complex y) => Math.Min(x.Magnitude, y.Magnitude), other, result);
		}

		protected override void DoPointwiseAbsoluteMaximum(Vector<System.Numerics.Complex> other, Vector<System.Numerics.Complex> result)
		{
			Map2((System.Numerics.Complex x, System.Numerics.Complex y) => Math.Max(x.Magnitude, y.Magnitude), other, result);
		}

		public sealed override System.Numerics.Complex AbsoluteMinimum()
		{
			return At(AbsoluteMinimumIndex()).Magnitude;
		}

		public override int AbsoluteMinimumIndex()
		{
			int num = 0;
			double num2 = At(num).Magnitude;
			for (int i = 1; i < base.Count; i++)
			{
				double magnitude = At(i).Magnitude;
				if (magnitude < num2)
				{
					num = i;
					num2 = magnitude;
				}
			}
			return num;
		}

		public override System.Numerics.Complex AbsoluteMaximum()
		{
			return At(AbsoluteMaximumIndex()).Magnitude;
		}

		public override int AbsoluteMaximumIndex()
		{
			int num = 0;
			double num2 = At(num).Magnitude;
			for (int i = 1; i < base.Count; i++)
			{
				double magnitude = At(i).Magnitude;
				if (magnitude > num2)
				{
					num = i;
					num2 = magnitude;
				}
			}
			return num;
		}

		public override System.Numerics.Complex Sum()
		{
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
			for (int i = 0; i < base.Count; i++)
			{
				zero += At(i);
			}
			return zero;
		}

		public override double L1Norm()
		{
			double num = 0.0;
			for (int i = 0; i < base.Count; i++)
			{
				num += At(i).Magnitude;
			}
			return num;
		}

		public override double L2Norm()
		{
			return DoConjugateDotProduct(this).SquareRoot().Real;
		}

		public override double InfinityNorm()
		{
			return CommonParallel.Aggregate(0, base.Count, (int i) => At(i).Magnitude, Math.Max, 0.0);
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
				num += Math.Pow(At(i).Magnitude, p);
			}
			return Math.Pow(num, 1.0 / p);
		}

		public override int MaximumIndex()
		{
			throw new NotSupportedException();
		}

		public override int MinimumIndex()
		{
			throw new NotSupportedException();
		}

		public override Vector<System.Numerics.Complex> Normalize(double p)
		{
			if (p < 0.0)
			{
				throw new ArgumentOutOfRangeException("p");
			}
			double num = Norm(p);
			Vector<System.Numerics.Complex> vector = Clone();
			if (num == 0.0)
			{
				return vector;
			}
			vector.Multiply(1.0 / num, vector);
			return vector;
		}
	}
}
