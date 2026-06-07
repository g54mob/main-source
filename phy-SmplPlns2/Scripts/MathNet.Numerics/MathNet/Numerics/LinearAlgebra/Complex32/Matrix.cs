using System;
using MathNet.Numerics.LinearAlgebra.Complex32.Factorization;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Complex32
{
	[Serializable]
	public abstract class Matrix : Matrix<MathNet.Numerics.Complex32>
	{
		protected Matrix(MatrixStorage<MathNet.Numerics.Complex32> storage)
			: base(storage)
		{
		}

		public override void CoerceZero(double threshold)
		{
			MapInplace((MathNet.Numerics.Complex32 x) => (!((double)x.Magnitude < threshold)) ? x : MathNet.Numerics.Complex32.Zero);
		}

		public sealed override Matrix<MathNet.Numerics.Complex32> ConjugateTranspose()
		{
			Matrix<MathNet.Numerics.Complex32> matrix = Transpose();
			matrix.MapInplace((MathNet.Numerics.Complex32 c) => c.Conjugate());
			return matrix;
		}

		public sealed override void ConjugateTranspose(Matrix<MathNet.Numerics.Complex32> result)
		{
			Transpose(result);
			result.MapInplace((MathNet.Numerics.Complex32 c) => c.Conjugate());
		}

		protected override void DoConjugate(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Conjugate, result);
		}

		protected override void DoNegate(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Negate, result);
		}

		protected override void DoAdd(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => x + scalar, result, Zeros.Include);
		}

		protected override void DoAdd(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map2(MathNet.Numerics.Complex32.Add, other, result);
		}

		protected override void DoSubtract(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => x - scalar, result, Zeros.Include);
		}

		protected override void DoSubtract(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map2(MathNet.Numerics.Complex32.Subtract, other, result);
		}

		protected override void DoMultiply(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => x * scalar, result);
		}

		protected override void DoMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			for (int i = 0; i < base.RowCount; i++)
			{
				MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
				for (int j = 0; j < base.ColumnCount; j++)
				{
					zero += At(i, j) * rightSide[j];
				}
				result[i] = zero;
			}
		}

		protected override void DoDivide(MathNet.Numerics.Complex32 divisor, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => x / divisor, result, divisor.IsZero() ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoDivideByThis(MathNet.Numerics.Complex32 dividend, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => dividend / x, result, Zeros.Include);
		}

		protected override void DoMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			for (int i = 0; i < base.RowCount; i++)
			{
				for (int j = 0; j != other.ColumnCount; j++)
				{
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int k = 0; k < base.ColumnCount; k++)
					{
						zero += At(i, k) * other.At(k, j);
					}
					result.At(i, j, zero);
				}
			}
		}

		protected override void DoTransposeAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			for (int i = 0; i < other.RowCount; i++)
			{
				for (int j = 0; j < base.RowCount; j++)
				{
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int k = 0; k < base.ColumnCount; k++)
					{
						zero += At(j, k) * other.At(i, k);
					}
					result.At(j, i, zero);
				}
			}
		}

		protected override void DoConjugateTransposeAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			for (int i = 0; i < other.RowCount; i++)
			{
				for (int j = 0; j < base.RowCount; j++)
				{
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int k = 0; k < base.ColumnCount; k++)
					{
						zero += At(j, k) * other.At(i, k).Conjugate();
					}
					result.At(j, i, zero);
				}
			}
		}

		protected override void DoTransposeThisAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			for (int i = 0; i < other.ColumnCount; i++)
			{
				for (int j = 0; j < base.ColumnCount; j++)
				{
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int k = 0; k < base.RowCount; k++)
					{
						zero += At(k, j) * other.At(k, i);
					}
					result.At(j, i, zero);
				}
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			for (int i = 0; i < other.ColumnCount; i++)
			{
				for (int j = 0; j < base.ColumnCount; j++)
				{
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int k = 0; k < base.RowCount; k++)
					{
						zero += At(k, j).Conjugate() * other.At(k, i);
					}
					result.At(j, i, zero);
				}
			}
		}

		protected override void DoTransposeThisAndMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			for (int i = 0; i < base.ColumnCount; i++)
			{
				MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
				for (int j = 0; j < base.RowCount; j++)
				{
					zero += At(j, i) * rightSide[j];
				}
				result[i] = zero;
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			for (int i = 0; i < base.ColumnCount; i++)
			{
				MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
				for (int j = 0; j < base.RowCount; j++)
				{
					zero += At(j, i).Conjugate() * rightSide[j];
				}
				result[i] = zero;
			}
		}

		protected override void DoPointwiseMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map2(MathNet.Numerics.Complex32.Multiply, other, result);
		}

		protected override void DoPointwiseDivide(Matrix<MathNet.Numerics.Complex32> divisor, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map2(MathNet.Numerics.Complex32.Divide, divisor, result, Zeros.Include);
		}

		protected override void DoPointwisePower(MathNet.Numerics.Complex32 exponent, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => x.Power(exponent), result, Zeros.Include);
		}

		protected override void DoPointwisePower(Matrix<MathNet.Numerics.Complex32> exponent, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map2(MathNet.Numerics.Complex32.Pow, result, Zeros.Include);
		}

		protected sealed override void DoPointwiseModulus(Matrix<MathNet.Numerics.Complex32> divisor, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoPointwiseRemainder(Matrix<MathNet.Numerics.Complex32> divisor, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoModulus(MathNet.Numerics.Complex32 divisor, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoModulusByThis(MathNet.Numerics.Complex32 dividend, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoRemainder(MathNet.Numerics.Complex32 divisor, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoRemainderByThis(MathNet.Numerics.Complex32 dividend, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseExp(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Exp, result, Zeros.Include);
		}

		protected override void DoPointwiseLog(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Log, result, Zeros.Include);
		}

		protected override void DoPointwiseAbs(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map((MathNet.Numerics.Complex32 x) => (MathNet.Numerics.Complex32)MathNet.Numerics.Complex32.Abs(x), result);
		}

		protected override void DoPointwiseAcos(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Acos, result, Zeros.Include);
		}

		protected override void DoPointwiseAsin(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Asin, result);
		}

		protected override void DoPointwiseAtan(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Atan, result);
		}

		protected override void DoPointwiseAtan2(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseCeiling(Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseCos(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Cos, result, Zeros.Include);
		}

		protected override void DoPointwiseCosh(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Cosh, result, Zeros.Include);
		}

		protected override void DoPointwiseFloor(Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseLog10(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Log10, result, Zeros.Include);
		}

		protected override void DoPointwiseRound(Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseSign(Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseSin(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Sin, result);
		}

		protected override void DoPointwiseSinh(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Sinh, result);
		}

		protected override void DoPointwiseSqrt(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Sqrt, result);
		}

		protected override void DoPointwiseTan(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Tan, result);
		}

		protected override void DoPointwiseTanh(Matrix<MathNet.Numerics.Complex32> result)
		{
			Map(MathNet.Numerics.Complex32.Tanh, result);
		}

		public override Matrix<MathNet.Numerics.Complex32> PseudoInverse()
		{
			Svd<MathNet.Numerics.Complex32> svd = Svd();
			Matrix<MathNet.Numerics.Complex32> w = svd.W;
			Vector<MathNet.Numerics.Complex32> s = svd.S;
			float num = (float)((double)Math.Max(base.RowCount, base.ColumnCount) * svd.L2Norm * Precision.SinglePrecision);
			for (int i = 0; i < s.Count; i++)
			{
				s[i] = ((s[i].Magnitude < num) ? ((MathNet.Numerics.Complex32)0) : (1f / s[i]));
			}
			w.SetDiagonal(s);
			return (svd.U * (w * svd.VT)).ConjugateTranspose();
		}

		public override MathNet.Numerics.Complex32 Trace()
		{
			if (base.RowCount != base.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
			for (int i = 0; i < base.RowCount; i++)
			{
				zero += At(i, i);
			}
			return zero;
		}

		protected override void DoPointwiseMinimum(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseMaximum(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseAbsoluteMinimum(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			float absolute = scalar.Magnitude;
			Map((MathNet.Numerics.Complex32 x) => Math.Min(absolute, x.Magnitude), result);
		}

		protected override void DoPointwiseAbsoluteMaximum(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			float absolute = scalar.Magnitude;
			Map((MathNet.Numerics.Complex32 x) => Math.Max(absolute, x.Magnitude), result, Zeros.Include);
		}

		protected override void DoPointwiseMinimum(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseMaximum(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseAbsoluteMinimum(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map2((MathNet.Numerics.Complex32 x, MathNet.Numerics.Complex32 y) => Math.Min(x.Magnitude, y.Magnitude), other, result);
		}

		protected override void DoPointwiseAbsoluteMaximum(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			Map2((MathNet.Numerics.Complex32 x, MathNet.Numerics.Complex32 y) => Math.Max(x.Magnitude, y.Magnitude), other, result);
		}

		public override double L1Norm()
		{
			double num = 0.0;
			for (int i = 0; i < base.ColumnCount; i++)
			{
				double num2 = 0.0;
				for (int j = 0; j < base.RowCount; j++)
				{
					num2 += (double)At(j, i).Magnitude;
				}
				num = Math.Max(num, num2);
			}
			return num;
		}

		public override double InfinityNorm()
		{
			double num = 0.0;
			for (int i = 0; i < base.RowCount; i++)
			{
				double num2 = 0.0;
				for (int j = 0; j < base.ColumnCount; j++)
				{
					num2 += (double)At(i, j).Magnitude;
				}
				num = Math.Max(num, num2);
			}
			return num;
		}

		public override double FrobeniusNorm()
		{
			Matrix<MathNet.Numerics.Complex32> matrix = ConjugateTranspose();
			Matrix<MathNet.Numerics.Complex32> matrix2 = this * matrix;
			double num = 0.0;
			for (int i = 0; i < base.RowCount; i++)
			{
				num += (double)matrix2.At(i, i).Magnitude;
			}
			return Math.Sqrt(num);
		}

		public override Vector<double> RowNorms(double norm)
		{
			if (norm <= 0.0)
			{
				throw new ArgumentOutOfRangeException("norm", "Value must be positive.");
			}
			double[] array = new double[base.RowCount];
			if (norm == 2.0)
			{
				base.Storage.FoldByRowUnchecked(array, (double s, MathNet.Numerics.Complex32 x) => s + (double)x.MagnitudeSquared, (double x, int _) => Math.Sqrt(x), array, Zeros.AllowSkip);
			}
			else if (norm == 1.0)
			{
				base.Storage.FoldByRowUnchecked(array, (double s, MathNet.Numerics.Complex32 x) => s + (double)x.Magnitude, (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else if (double.IsPositiveInfinity(norm))
			{
				base.Storage.FoldByRowUnchecked(array, (double s, MathNet.Numerics.Complex32 x) => Math.Max(s, x.Magnitude), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else
			{
				double invnorm = 1.0 / norm;
				base.Storage.FoldByRowUnchecked(array, (double s, MathNet.Numerics.Complex32 x) => s + Math.Pow(x.Magnitude, norm), (double x, int _) => Math.Pow(x, invnorm), array, Zeros.AllowSkip);
			}
			return Vector<double>.Build.Dense(array);
		}

		public override Vector<double> ColumnNorms(double norm)
		{
			if (norm <= 0.0)
			{
				throw new ArgumentOutOfRangeException("norm", "Value must be positive.");
			}
			double[] array = new double[base.ColumnCount];
			if (norm == 2.0)
			{
				base.Storage.FoldByColumnUnchecked(array, (double s, MathNet.Numerics.Complex32 x) => s + (double)x.MagnitudeSquared, (double x, int _) => Math.Sqrt(x), array, Zeros.AllowSkip);
			}
			else if (norm == 1.0)
			{
				base.Storage.FoldByColumnUnchecked(array, (double s, MathNet.Numerics.Complex32 x) => s + (double)x.Magnitude, (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else if (double.IsPositiveInfinity(norm))
			{
				base.Storage.FoldByColumnUnchecked(array, (double s, MathNet.Numerics.Complex32 x) => Math.Max(s, x.Magnitude), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else
			{
				double invnorm = 1.0 / norm;
				base.Storage.FoldByColumnUnchecked(array, (double s, MathNet.Numerics.Complex32 x) => s + Math.Pow(x.Magnitude, norm), (double x, int _) => Math.Pow(x, invnorm), array, Zeros.AllowSkip);
			}
			return Vector<double>.Build.Dense(array);
		}

		public sealed override Matrix<MathNet.Numerics.Complex32> NormalizeRows(double norm)
		{
			double[] norminv = ((DenseVectorStorage<double>)RowNorms(norm).Storage).Data;
			for (int i = 0; i < norminv.Length; i++)
			{
				norminv[i] = ((norminv[i] == 0.0) ? 1.0 : (1.0 / norminv[i]));
			}
			Matrix<MathNet.Numerics.Complex32> matrix = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(this, base.RowCount, base.ColumnCount);
			base.Storage.MapIndexedTo(matrix.Storage, (int num, int _, MathNet.Numerics.Complex32 x) => (float)norminv[num] * x, Zeros.AllowSkip, ExistingData.AssumeZeros);
			return matrix;
		}

		public sealed override Matrix<MathNet.Numerics.Complex32> NormalizeColumns(double norm)
		{
			double[] norminv = ((DenseVectorStorage<double>)ColumnNorms(norm).Storage).Data;
			for (int i = 0; i < norminv.Length; i++)
			{
				norminv[i] = ((norminv[i] == 0.0) ? 1.0 : (1.0 / norminv[i]));
			}
			Matrix<MathNet.Numerics.Complex32> matrix = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(this, base.RowCount, base.ColumnCount);
			base.Storage.MapIndexedTo(matrix.Storage, (int _, int j, MathNet.Numerics.Complex32 x) => (float)norminv[j] * x, Zeros.AllowSkip, ExistingData.AssumeZeros);
			return matrix;
		}

		public override Vector<MathNet.Numerics.Complex32> RowSums()
		{
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[base.RowCount];
			base.Storage.FoldByRowUnchecked(array, (MathNet.Numerics.Complex32 s, MathNet.Numerics.Complex32 x) => s + x, (MathNet.Numerics.Complex32 x, int _) => x, array, Zeros.AllowSkip);
			return Vector<MathNet.Numerics.Complex32>.Build.Dense(array);
		}

		public override Vector<MathNet.Numerics.Complex32> RowAbsoluteSums()
		{
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[base.RowCount];
			base.Storage.FoldByRowUnchecked(array, (MathNet.Numerics.Complex32 s, MathNet.Numerics.Complex32 x) => s + x.Magnitude, (MathNet.Numerics.Complex32 x, int _) => x, array, Zeros.AllowSkip);
			return Vector<MathNet.Numerics.Complex32>.Build.Dense(array);
		}

		public override Vector<MathNet.Numerics.Complex32> ColumnSums()
		{
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[base.ColumnCount];
			base.Storage.FoldByColumnUnchecked(array, (MathNet.Numerics.Complex32 s, MathNet.Numerics.Complex32 x) => s + x, (MathNet.Numerics.Complex32 x, int _) => x, array, Zeros.AllowSkip);
			return Vector<MathNet.Numerics.Complex32>.Build.Dense(array);
		}

		public override Vector<MathNet.Numerics.Complex32> ColumnAbsoluteSums()
		{
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[base.ColumnCount];
			base.Storage.FoldByColumnUnchecked(array, (MathNet.Numerics.Complex32 s, MathNet.Numerics.Complex32 x) => s + x.Magnitude, (MathNet.Numerics.Complex32 x, int _) => x, array, Zeros.AllowSkip);
			return Vector<MathNet.Numerics.Complex32>.Build.Dense(array);
		}

		public override bool IsHermitian()
		{
			if (base.RowCount != base.ColumnCount)
			{
				return false;
			}
			for (int i = 0; i < base.RowCount; i++)
			{
				if (!At(i, i).IsReal())
				{
					return false;
				}
			}
			for (int j = 0; j < base.RowCount; j++)
			{
				for (int k = j + 1; k < base.ColumnCount; k++)
				{
					if (!At(j, k).Equals(At(k, j).Conjugate()))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override Cholesky<MathNet.Numerics.Complex32> Cholesky()
		{
			return UserCholesky.Create(this);
		}

		public override LU<MathNet.Numerics.Complex32> LU()
		{
			return UserLU.Create(this);
		}

		public override QR<MathNet.Numerics.Complex32> QR(QRMethod method = QRMethod.Thin)
		{
			return UserQR.Create(this, method);
		}

		public override GramSchmidt<MathNet.Numerics.Complex32> GramSchmidt()
		{
			return UserGramSchmidt.Create(this);
		}

		public override Svd<MathNet.Numerics.Complex32> Svd(bool computeVectors = true)
		{
			return UserSvd.Create(this, computeVectors);
		}

		public override Evd<MathNet.Numerics.Complex32> Evd(Symmetricity symmetricity = Symmetricity.Unknown)
		{
			return UserEvd.Create(this, symmetricity);
		}
	}
}
