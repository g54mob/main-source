using System;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Complex32
{
	[Serializable]
	public abstract class Vector : Vector<MathNet.Numerics.Complex32>
	{
		protected Vector(VectorStorage<MathNet.Numerics.Complex32> storage)
			: base(storage)
		{
		}

		public override void CoerceZero(double threshold)
		{
			MapInplace((MathNet.Numerics.Complex32 x) => (!((double)x.Magnitude < threshold)) ? x : MathNet.Numerics.Complex32.Zero);
		}

		protected override void DoConjugate(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Conjugate, result);
		}

		protected override void DoNegate(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Negate, result);
		}

		protected override void DoAdd(MathNet.Numerics.Complex32 scalar, Vector<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => x + scalar, result, Zeros.Include);
		}

		protected override void DoAdd(Vector<MathNet.Numerics.Complex32> other, Vector<MathNet.Numerics.Complex32> result)
		{
			Map2(MathNet.Numerics.Complex32.Add, other, result);
		}

		protected override void DoSubtract(MathNet.Numerics.Complex32 scalar, Vector<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => x - scalar, result, Zeros.Include);
		}

		protected override void DoSubtract(Vector<MathNet.Numerics.Complex32> other, Vector<MathNet.Numerics.Complex32> result)
		{
			Map2(MathNet.Numerics.Complex32.Subtract, other, result);
		}

		protected override void DoMultiply(MathNet.Numerics.Complex32 scalar, Vector<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => x * scalar, result);
		}

		protected override void DoDivide(MathNet.Numerics.Complex32 divisor, Vector<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => x / divisor, result, divisor.IsZero() ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoDivideByThis(MathNet.Numerics.Complex32 dividend, Vector<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => dividend / x, result, Zeros.Include);
		}

		protected override void DoPointwiseMultiply(Vector<MathNet.Numerics.Complex32> other, Vector<MathNet.Numerics.Complex32> result)
		{
			Map2(MathNet.Numerics.Complex32.Multiply, other, result);
		}

		protected override void DoPointwiseDivide(Vector<MathNet.Numerics.Complex32> divisor, Vector<MathNet.Numerics.Complex32> result)
		{
			Map2(MathNet.Numerics.Complex32.Divide, divisor, result, Zeros.Include);
		}

		protected override void DoPointwisePower(MathNet.Numerics.Complex32 exponent, Vector<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => x.Power(exponent), result, Zeros.Include);
		}

		protected override void DoPointwisePower(Vector<MathNet.Numerics.Complex32> exponent, Vector<MathNet.Numerics.Complex32> result)
		{
			Map2(MathNet.Numerics.Complex32.Pow, exponent, result, Zeros.Include);
		}

		protected sealed override void DoPointwiseModulus(Vector<MathNet.Numerics.Complex32> divisor, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoPointwiseRemainder(Vector<MathNet.Numerics.Complex32> divisor, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseExp(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Exp, result, Zeros.Include);
		}

		protected override void DoPointwiseLog(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Log, result, Zeros.Include);
		}

		protected override void DoPointwiseAbs(Vector<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => (MathNet.Numerics.Complex32)MathNet.Numerics.Complex32.Abs(x), result);
		}

		protected override void DoPointwiseAcos(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Acos, result, Zeros.Include);
		}

		protected override void DoPointwiseAsin(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Asin, result);
		}

		protected override void DoPointwiseAtan(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Atan, result);
		}

		protected override void DoPointwiseAtan2(Vector<MathNet.Numerics.Complex32> other, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseAtan2(MathNet.Numerics.Complex32 scalar, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseCeiling(Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseCos(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Cos, result, Zeros.Include);
		}

		protected override void DoPointwiseCosh(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Cosh, result, Zeros.Include);
		}

		protected override void DoPointwiseFloor(Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseLog10(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Log10, result, Zeros.Include);
		}

		protected override void DoPointwiseRound(Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseSign(Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseSin(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Sin, result);
		}

		protected override void DoPointwiseSinh(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Sinh, result);
		}

		protected override void DoPointwiseSqrt(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Sqrt, result);
		}

		protected override void DoPointwiseTan(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Tan, result);
		}

		protected override void DoPointwiseTanh(Vector<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Tanh, result);
		}

		protected override MathNet.Numerics.Complex32 DoDotProduct(Vector<MathNet.Numerics.Complex32> other)
		{
			MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
			for (int i = 0; i < base.Count; i++)
			{
				zero += At(i) * other.At(i);
			}
			return zero;
		}

		protected override MathNet.Numerics.Complex32 DoConjugateDotProduct(Vector<MathNet.Numerics.Complex32> other)
		{
			MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
			for (int i = 0; i < base.Count; i++)
			{
				zero += At(i).Conjugate() * other.At(i);
			}
			return zero;
		}

		protected sealed override void DoModulus(MathNet.Numerics.Complex32 divisor, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoModulusByThis(MathNet.Numerics.Complex32 dividend, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoRemainder(MathNet.Numerics.Complex32 divisor, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoRemainderByThis(MathNet.Numerics.Complex32 dividend, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseMinimum(MathNet.Numerics.Complex32 scalar, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseMaximum(MathNet.Numerics.Complex32 scalar, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseAbsoluteMinimum(MathNet.Numerics.Complex32 scalar, Vector<MathNet.Numerics.Complex32> result)
		{
			float absolute = scalar.Magnitude;
			Map((MathNet.Numerics.Complex32 x) => Math.Min(absolute, x.Magnitude), result);
		}

		protected override void DoPointwiseAbsoluteMaximum(MathNet.Numerics.Complex32 scalar, Vector<MathNet.Numerics.Complex32> result)
		{
			float absolute = scalar.Magnitude;
			Map((MathNet.Numerics.Complex32 x) => Math.Max(absolute, x.Magnitude), result, Zeros.Include);
		}

		protected override void DoPointwiseMinimum(Vector<MathNet.Numerics.Complex32> other, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseMaximum(Vector<MathNet.Numerics.Complex32> other, Vector<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseAbsoluteMinimum(Vector<MathNet.Numerics.Complex32> other, Vector<MathNet.Numerics.Complex32> result)
		{
			Map2((MathNet.Numerics.Complex32 x, MathNet.Numerics.Complex32 y) => Math.Min(x.Magnitude, y.Magnitude), other, result);
		}

		protected override void DoPointwiseAbsoluteMaximum(Vector<MathNet.Numerics.Complex32> other, Vector<MathNet.Numerics.Complex32> result)
		{
			Map2((MathNet.Numerics.Complex32 x, MathNet.Numerics.Complex32 y) => Math.Max(x.Magnitude, y.Magnitude), other, result);
		}

		public sealed override MathNet.Numerics.Complex32 AbsoluteMinimum()
		{
			return At(AbsoluteMinimumIndex()).Magnitude;
		}

		public override int AbsoluteMinimumIndex()
		{
			int num = 0;
			float num2 = At(num).Magnitude;
			for (int i = 1; i < base.Count; i++)
			{
				float magnitude = At(i).Magnitude;
				if (magnitude < num2)
				{
					num = i;
					num2 = magnitude;
				}
			}
			return num;
		}

		public override MathNet.Numerics.Complex32 AbsoluteMaximum()
		{
			return At(AbsoluteMaximumIndex()).Magnitude;
		}

		public override int AbsoluteMaximumIndex()
		{
			int num = 0;
			float num2 = At(num).Magnitude;
			for (int i = 1; i < base.Count; i++)
			{
				float magnitude = At(i).Magnitude;
				if (magnitude > num2)
				{
					num = i;
					num2 = magnitude;
				}
			}
			return num;
		}

		public override MathNet.Numerics.Complex32 Sum()
		{
			MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
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
				num += (double)At(i).Magnitude;
			}
			return num;
		}

		public override double L2Norm()
		{
			return DoConjugateDotProduct(this).SquareRoot().Real;
		}

		public override double InfinityNorm()
		{
			return CommonParallel.Aggregate(0, base.Count, (int i) => At(i).Magnitude, Math.Max, 0f);
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

		public override Vector<MathNet.Numerics.Complex32> Normalize(double p)
		{
			if (p < 0.0)
			{
				throw new ArgumentOutOfRangeException("p");
			}
			double num = Norm(p);
			Vector<MathNet.Numerics.Complex32> vector = Clone();
			if (num == 0.0)
			{
				return vector;
			}
			vector.Multiply((float)(1.0 / num), vector);
			return vector;
		}
	}
}
