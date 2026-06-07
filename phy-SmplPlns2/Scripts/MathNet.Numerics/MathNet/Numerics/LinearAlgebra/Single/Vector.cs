using System;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Single
{
	[Serializable]
	public abstract class Vector : Vector<float>
	{
		protected Vector(VectorStorage<float> storage)
			: base(storage)
		{
		}

		public override void CoerceZero(double threshold)
		{
			MapInplace((float x) => (!((double)Math.Abs(x) < threshold)) ? x : 0f);
		}

		protected sealed override void DoConjugate(Vector<float> result)
		{
			if (this != result)
			{
				CopyTo(result);
			}
		}

		protected override void DoNegate(Vector<float> result)
		{
			Map((float x) => 0f - x, result);
		}

		protected override void DoAdd(float scalar, Vector<float> result)
		{
			Map((float x) => x + scalar, result, Zeros.Include);
		}

		protected override void DoAdd(Vector<float> other, Vector<float> result)
		{
			Map2((float x, float y) => x + y, other, result);
		}

		protected override void DoSubtract(float scalar, Vector<float> result)
		{
			Map((float x) => x - scalar, result, Zeros.Include);
		}

		protected override void DoSubtract(Vector<float> other, Vector<float> result)
		{
			Map2((float x, float y) => x - y, other, result);
		}

		protected override void DoMultiply(float scalar, Vector<float> result)
		{
			Map((float x) => x * scalar, result);
		}

		protected override void DoDivide(float divisor, Vector<float> result)
		{
			Map((float x) => x / divisor, result, (divisor == 0f) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoDivideByThis(float dividend, Vector<float> result)
		{
			Map((float x) => dividend / x, result, Zeros.Include);
		}

		protected override void DoPointwiseMultiply(Vector<float> other, Vector<float> result)
		{
			Map2((float x, float y) => x * y, other, result);
		}

		protected override void DoPointwiseDivide(Vector<float> divisor, Vector<float> result)
		{
			Map2((float x, float y) => x / y, divisor, result, Zeros.Include);
		}

		protected override void DoPointwisePower(float exponent, Vector<float> result)
		{
			Map((float x) => (float)Math.Pow(x, exponent), result, (!(exponent > 0f)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwisePower(Vector<float> exponent, Vector<float> result)
		{
			Map2((float x, float y) => (float)Math.Pow(x, y), exponent, result, Zeros.Include);
		}

		protected override void DoPointwiseModulus(Vector<float> divisor, Vector<float> result)
		{
			Map2(Euclid.Modulus, divisor, result, Zeros.Include);
		}

		protected override void DoPointwiseRemainder(Vector<float> divisor, Vector<float> result)
		{
			Map2(Euclid.Remainder, divisor, result, Zeros.Include);
		}

		protected override void DoPointwiseExp(Vector<float> result)
		{
			Map((float x) => (float)Math.Exp(x), result, Zeros.Include);
		}

		protected override void DoPointwiseLog(Vector<float> result)
		{
			Map((float x) => (float)Math.Log(x), result, Zeros.Include);
		}

		protected override void DoPointwiseAbs(Vector<float> result)
		{
			Map((float x) => Math.Abs(x), result);
		}

		protected override void DoPointwiseAcos(Vector<float> result)
		{
			Map((float x) => (float)Math.Acos(x), result, Zeros.Include);
		}

		protected override void DoPointwiseAsin(Vector<float> result)
		{
			Map((float x) => (float)Math.Asin(x), result);
		}

		protected override void DoPointwiseAtan(Vector<float> result)
		{
			Map((float x) => (float)Math.Atan(x), result);
		}

		protected override void DoPointwiseAtan2(Vector<float> other, Vector<float> result)
		{
			Map2((float x, float y) => (float)Math.Atan2(x, y), other, result, Zeros.Include);
		}

		protected override void DoPointwiseAtan2(float scalar, Vector<float> result)
		{
			Map((float x) => (float)Math.Atan2(x, scalar), result, Zeros.Include);
		}

		protected override void DoPointwiseCeiling(Vector<float> result)
		{
			Map((float x) => (float)Math.Ceiling(x), result);
		}

		protected override void DoPointwiseCos(Vector<float> result)
		{
			Map((float x) => (float)Math.Cos(x), result, Zeros.Include);
		}

		protected override void DoPointwiseCosh(Vector<float> result)
		{
			Map((float x) => (float)Math.Cosh(x), result, Zeros.Include);
		}

		protected override void DoPointwiseFloor(Vector<float> result)
		{
			Map((float x) => (float)Math.Floor(x), result);
		}

		protected override void DoPointwiseLog10(Vector<float> result)
		{
			Map((float x) => (float)Math.Log10(x), result, Zeros.Include);
		}

		protected override void DoPointwiseRound(Vector<float> result)
		{
			Map((float x) => (float)Math.Round(x), result);
		}

		protected override void DoPointwiseSign(Vector<float> result)
		{
			Map((float x) => Math.Sign(x), result);
		}

		protected override void DoPointwiseSin(Vector<float> result)
		{
			Map((float x) => (float)Math.Sin(x), result);
		}

		protected override void DoPointwiseSinh(Vector<float> result)
		{
			Map((float x) => (float)Math.Sinh(x), result);
		}

		protected override void DoPointwiseSqrt(Vector<float> result)
		{
			Map((float x) => (float)Math.Sqrt(x), result);
		}

		protected override void DoPointwiseTan(Vector<float> result)
		{
			Map((float x) => (float)Math.Tan(x), result);
		}

		protected override void DoPointwiseTanh(Vector<float> result)
		{
			Map((float x) => (float)Math.Tanh(x), result);
		}

		protected override float DoDotProduct(Vector<float> other)
		{
			float num = 0f;
			for (int i = 0; i < base.Count; i++)
			{
				num += At(i) * other.At(i);
			}
			return num;
		}

		protected sealed override float DoConjugateDotProduct(Vector<float> other)
		{
			return DoDotProduct(other);
		}

		protected override void DoModulus(float divisor, Vector<float> result)
		{
			Map((float x) => Euclid.Modulus(x, divisor), result, Zeros.Include);
		}

		protected override void DoModulusByThis(float dividend, Vector<float> result)
		{
			Map((float x) => Euclid.Modulus(dividend, x), result, Zeros.Include);
		}

		protected override void DoRemainder(float divisor, Vector<float> result)
		{
			Map((float x) => Euclid.Remainder(x, divisor), result, Zeros.Include);
		}

		protected override void DoRemainderByThis(float dividend, Vector<float> result)
		{
			Map((float x) => Euclid.Remainder(dividend, x), result, Zeros.Include);
		}

		protected override void DoPointwiseMinimum(float scalar, Vector<float> result)
		{
			Map((float x) => Math.Min(scalar, x), result, (!((double)scalar >= 0.0)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwiseMaximum(float scalar, Vector<float> result)
		{
			Map((float x) => Math.Max(scalar, x), result, (!((double)scalar <= 0.0)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwiseAbsoluteMinimum(float scalar, Vector<float> result)
		{
			float absolute = Math.Abs(scalar);
			Map((float x) => Math.Min(absolute, Math.Abs(x)), result);
		}

		protected override void DoPointwiseAbsoluteMaximum(float scalar, Vector<float> result)
		{
			float absolute = Math.Abs(scalar);
			Map((float x) => Math.Max(absolute, Math.Abs(x)), result, Zeros.Include);
		}

		protected override void DoPointwiseMinimum(Vector<float> other, Vector<float> result)
		{
			Map2(Math.Min, other, result);
		}

		protected override void DoPointwiseMaximum(Vector<float> other, Vector<float> result)
		{
			Map2(Math.Max, other, result);
		}

		protected override void DoPointwiseAbsoluteMinimum(Vector<float> other, Vector<float> result)
		{
			Map2((float x, float y) => Math.Min(Math.Abs(x), Math.Abs(y)), other, result);
		}

		protected override void DoPointwiseAbsoluteMaximum(Vector<float> other, Vector<float> result)
		{
			Map2((float x, float y) => Math.Max(Math.Abs(x), Math.Abs(y)), other, result);
		}

		public override float AbsoluteMinimum()
		{
			return Math.Abs(At(AbsoluteMinimumIndex()));
		}

		public override int AbsoluteMinimumIndex()
		{
			int num = 0;
			float num2 = Math.Abs(At(num));
			for (int i = 1; i < base.Count; i++)
			{
				float num3 = Math.Abs(At(i));
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return num;
		}

		public override float AbsoluteMaximum()
		{
			return Math.Abs(At(AbsoluteMaximumIndex()));
		}

		public override int AbsoluteMaximumIndex()
		{
			int num = 0;
			float num2 = Math.Abs(At(num));
			for (int i = 1; i < base.Count; i++)
			{
				float num3 = Math.Abs(At(i));
				if (num3 > num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return num;
		}

		public override float Sum()
		{
			float num = 0f;
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
				num += (double)Math.Abs(At(i));
			}
			return num;
		}

		public override double L2Norm()
		{
			return Math.Sqrt(DoDotProduct(this));
		}

		public override double InfinityNorm()
		{
			return CommonParallel.Aggregate(0, base.Count, (int i) => Math.Abs(At(i)), Math.Max, 0f);
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
			float num2 = At(num);
			for (int i = 1; i < base.Count; i++)
			{
				float num3 = At(i);
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
			float num2 = At(num);
			for (int i = 1; i < base.Count; i++)
			{
				float num3 = At(i);
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return num;
		}

		public override Vector<float> Normalize(double p)
		{
			if (p < 0.0)
			{
				throw new ArgumentOutOfRangeException("p");
			}
			double num = Norm(p);
			Vector<float> vector = Clone();
			if (num == 0.0)
			{
				return vector;
			}
			vector.Multiply((float)(1.0 / num), vector);
			return vector;
		}
	}
}
