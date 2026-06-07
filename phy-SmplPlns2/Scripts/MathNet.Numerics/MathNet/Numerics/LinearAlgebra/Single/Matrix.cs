using System;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra.Single.Factorization;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Single
{
	[Serializable]
	public abstract class Matrix : Matrix<float>
	{
		protected Matrix(MatrixStorage<float> storage)
			: base(storage)
		{
		}

		public override void CoerceZero(double threshold)
		{
			MapInplace((float x) => (!((double)Math.Abs(x) < threshold)) ? x : 0f);
		}

		public sealed override Matrix<float> ConjugateTranspose()
		{
			return Transpose();
		}

		public sealed override void ConjugateTranspose(Matrix<float> result)
		{
			Transpose(result);
		}

		protected sealed override void DoConjugate(Matrix<float> result)
		{
			if (this != result)
			{
				CopyTo(result);
			}
		}

		protected override void DoNegate(Matrix<float> result)
		{
			Map((float x) => 0f - x, result);
		}

		protected override void DoAdd(float scalar, Matrix<float> result)
		{
			Map((float x) => x + scalar, result, Zeros.Include);
		}

		protected override void DoAdd(Matrix<float> other, Matrix<float> result)
		{
			Map2((float x, float y) => x + y, other, result);
		}

		protected override void DoSubtract(float scalar, Matrix<float> result)
		{
			Map((float x) => x - scalar, result, Zeros.Include);
		}

		protected override void DoSubtract(Matrix<float> other, Matrix<float> result)
		{
			Map2((float x, float y) => x - y, other, result);
		}

		protected override void DoMultiply(float scalar, Matrix<float> result)
		{
			Map((float x) => x * scalar, result);
		}

		protected override void DoMultiply(Vector<float> rightSide, Vector<float> result)
		{
			for (int i = 0; i < base.RowCount; i++)
			{
				float num = 0f;
				for (int j = 0; j < base.ColumnCount; j++)
				{
					num += At(i, j) * rightSide[j];
				}
				result[i] = num;
			}
		}

		protected override void DoMultiply(Matrix<float> other, Matrix<float> result)
		{
			for (int i = 0; i < base.RowCount; i++)
			{
				for (int j = 0; j < other.ColumnCount; j++)
				{
					float num = 0f;
					for (int k = 0; k < base.ColumnCount; k++)
					{
						num += At(i, k) * other.At(k, j);
					}
					result.At(i, j, num);
				}
			}
		}

		protected override void DoDivide(float divisor, Matrix<float> result)
		{
			Map((float x) => x / divisor, result, (divisor == 0f) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoDivideByThis(float dividend, Matrix<float> result)
		{
			Map((float x) => dividend / x, result, Zeros.Include);
		}

		protected override void DoTransposeAndMultiply(Matrix<float> other, Matrix<float> result)
		{
			for (int i = 0; i < other.RowCount; i++)
			{
				for (int j = 0; j < base.RowCount; j++)
				{
					float num = 0f;
					for (int k = 0; k < base.ColumnCount; k++)
					{
						num += At(j, k) * other.At(i, k);
					}
					result.At(j, i, num);
				}
			}
		}

		protected sealed override void DoConjugateTransposeAndMultiply(Matrix<float> other, Matrix<float> result)
		{
			DoTransposeAndMultiply(other, result);
		}

		protected override void DoTransposeThisAndMultiply(Matrix<float> other, Matrix<float> result)
		{
			for (int i = 0; i < other.ColumnCount; i++)
			{
				for (int j = 0; j < base.ColumnCount; j++)
				{
					float num = 0f;
					for (int k = 0; k < base.RowCount; k++)
					{
						num += At(k, j) * other.At(k, i);
					}
					result.At(j, i, num);
				}
			}
		}

		protected sealed override void DoConjugateTransposeThisAndMultiply(Matrix<float> other, Matrix<float> result)
		{
			DoTransposeThisAndMultiply(other, result);
		}

		protected override void DoTransposeThisAndMultiply(Vector<float> rightSide, Vector<float> result)
		{
			for (int i = 0; i < base.ColumnCount; i++)
			{
				float num = 0f;
				for (int j = 0; j < base.RowCount; j++)
				{
					num += At(j, i) * rightSide[j];
				}
				result[i] = num;
			}
		}

		protected sealed override void DoConjugateTransposeThisAndMultiply(Vector<float> rightSide, Vector<float> result)
		{
			DoTransposeThisAndMultiply(rightSide, result);
		}

		protected override void DoModulus(float divisor, Matrix<float> result)
		{
			Map((float x) => Euclid.Modulus(x, divisor), result, Zeros.Include);
		}

		protected override void DoModulusByThis(float dividend, Matrix<float> result)
		{
			Map((float x) => Euclid.Modulus(dividend, x), result, Zeros.Include);
		}

		protected override void DoRemainder(float divisor, Matrix<float> result)
		{
			Map((float x) => Euclid.Remainder(x, divisor), result, Zeros.Include);
		}

		protected override void DoRemainderByThis(float dividend, Matrix<float> result)
		{
			Map((float x) => Euclid.Remainder(dividend, x), result, Zeros.Include);
		}

		protected override void DoPointwiseMultiply(Matrix<float> other, Matrix<float> result)
		{
			Map2((float x, float y) => x * y, other, result);
		}

		protected override void DoPointwiseDivide(Matrix<float> divisor, Matrix<float> result)
		{
			Map2((float x, float y) => x / y, divisor, result, Zeros.Include);
		}

		protected override void DoPointwisePower(float exponent, Matrix<float> result)
		{
			Map((float x) => (float)Math.Pow(x, exponent), result, (!(exponent > 0f)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwisePower(Matrix<float> exponent, Matrix<float> result)
		{
			Map2((float x, float y) => (float)Math.Pow(x, y), result, Zeros.Include);
		}

		protected override void DoPointwiseModulus(Matrix<float> divisor, Matrix<float> result)
		{
			Map2(Euclid.Modulus, divisor, result, Zeros.Include);
		}

		protected override void DoPointwiseRemainder(Matrix<float> divisor, Matrix<float> result)
		{
			Map2(Euclid.Remainder, divisor, result, Zeros.Include);
		}

		protected override void DoPointwiseExp(Matrix<float> result)
		{
			Map((float x) => (float)Math.Exp(x), result, Zeros.Include);
		}

		protected override void DoPointwiseLog(Matrix<float> result)
		{
			Map((float x) => (float)Math.Log(x), result, Zeros.Include);
		}

		protected override void DoPointwiseAbs(Matrix<float> result)
		{
			Map((float x) => Math.Abs(x), result);
		}

		protected override void DoPointwiseAcos(Matrix<float> result)
		{
			Map((float x) => (float)Math.Acos(x), result, Zeros.Include);
		}

		protected override void DoPointwiseAsin(Matrix<float> result)
		{
			Map((float x) => (float)Math.Asin(x), result);
		}

		protected override void DoPointwiseAtan(Matrix<float> result)
		{
			Map((float x) => (float)Math.Atan(x), result);
		}

		protected override void DoPointwiseAtan2(Matrix<float> other, Matrix<float> result)
		{
			Map2((float x, float y) => (float)Math.Atan2(x, y), other, result, Zeros.Include);
		}

		protected override void DoPointwiseCeiling(Matrix<float> result)
		{
			Map((float x) => (float)Math.Ceiling(x), result);
		}

		protected override void DoPointwiseCos(Matrix<float> result)
		{
			Map((float x) => (float)Math.Cos(x), result, Zeros.Include);
		}

		protected override void DoPointwiseCosh(Matrix<float> result)
		{
			Map((float x) => (float)Math.Cosh(x), result, Zeros.Include);
		}

		protected override void DoPointwiseFloor(Matrix<float> result)
		{
			Map((float x) => (float)Math.Floor(x), result);
		}

		protected override void DoPointwiseLog10(Matrix<float> result)
		{
			Map((float x) => (float)Math.Log10(x), result, Zeros.Include);
		}

		protected override void DoPointwiseRound(Matrix<float> result)
		{
			Map((float x) => (float)Math.Round(x), result);
		}

		protected override void DoPointwiseSign(Matrix<float> result)
		{
			Map((float x) => Math.Sign(x), result);
		}

		protected override void DoPointwiseSin(Matrix<float> result)
		{
			Map((float x) => (float)Math.Sin(x), result);
		}

		protected override void DoPointwiseSinh(Matrix<float> result)
		{
			Map((float x) => (float)Math.Sinh(x), result);
		}

		protected override void DoPointwiseSqrt(Matrix<float> result)
		{
			Map((float x) => (float)Math.Sqrt(x), result);
		}

		protected override void DoPointwiseTan(Matrix<float> result)
		{
			Map((float x) => (float)Math.Tan(x), result);
		}

		protected override void DoPointwiseTanh(Matrix<float> result)
		{
			Map((float x) => (float)Math.Tanh(x), result);
		}

		public override Matrix<float> PseudoInverse()
		{
			Svd<float> svd = Svd();
			Matrix<float> w = svd.W;
			Vector<float> s = svd.S;
			float num = (float)((double)Math.Max(base.RowCount, base.ColumnCount) * svd.L2Norm * Precision.SinglePrecision);
			for (int i = 0; i < s.Count; i++)
			{
				s[i] = ((s[i] < num) ? 0f : (1f / s[i]));
			}
			w.SetDiagonal(s);
			return (svd.U * (w * svd.VT)).Transpose();
		}

		public override float Trace()
		{
			if (base.RowCount != base.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			float num = 0f;
			for (int i = 0; i < base.RowCount; i++)
			{
				num += At(i, i);
			}
			return num;
		}

		protected override void DoPointwiseMinimum(float scalar, Matrix<float> result)
		{
			Map((float x) => Math.Min(scalar, x), result, (!((double)scalar >= 0.0)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwiseMaximum(float scalar, Matrix<float> result)
		{
			Map((float x) => Math.Max(scalar, x), result, (!((double)scalar <= 0.0)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwiseAbsoluteMinimum(float scalar, Matrix<float> result)
		{
			float absolute = Math.Abs(scalar);
			Map((float x) => Math.Min(absolute, Math.Abs(x)), result);
		}

		protected override void DoPointwiseAbsoluteMaximum(float scalar, Matrix<float> result)
		{
			float absolute = Math.Abs(scalar);
			Map((float x) => Math.Max(absolute, Math.Abs(x)), result, Zeros.Include);
		}

		protected override void DoPointwiseMinimum(Matrix<float> other, Matrix<float> result)
		{
			Map2(Math.Min, other, result);
		}

		protected override void DoPointwiseMaximum(Matrix<float> other, Matrix<float> result)
		{
			Map2(Math.Max, other, result);
		}

		protected override void DoPointwiseAbsoluteMinimum(Matrix<float> other, Matrix<float> result)
		{
			Map2((float x, float y) => Math.Min(Math.Abs(x), Math.Abs(y)), other, result);
		}

		protected override void DoPointwiseAbsoluteMaximum(Matrix<float> other, Matrix<float> result)
		{
			Map2((float x, float y) => Math.Max(Math.Abs(x), Math.Abs(y)), other, result);
		}

		public override double L1Norm()
		{
			double num = 0.0;
			for (int i = 0; i < base.ColumnCount; i++)
			{
				double num2 = 0.0;
				for (int j = 0; j < base.RowCount; j++)
				{
					num2 += (double)Math.Abs(At(j, i));
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
					num2 += (double)Math.Abs(At(i, j));
				}
				num = Math.Max(num, num2);
			}
			return num;
		}

		public override double FrobeniusNorm()
		{
			Matrix<float> matrix = Transpose();
			Matrix<float> matrix2 = this * matrix;
			double num = 0.0;
			for (int i = 0; i < base.RowCount; i++)
			{
				num += (double)matrix2.At(i, i);
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
				base.Storage.FoldByRowUnchecked(array, (double s, float x) => s + (double)(x * x), (double x, int _) => Math.Sqrt(x), array, Zeros.AllowSkip);
			}
			else if (norm == 1.0)
			{
				base.Storage.FoldByRowUnchecked(array, (double s, float x) => s + (double)Math.Abs(x), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else if (double.IsPositiveInfinity(norm))
			{
				base.Storage.FoldByRowUnchecked(array, (double s, float x) => Math.Max(s, Math.Abs(x)), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else
			{
				double invnorm = 1.0 / norm;
				base.Storage.FoldByRowUnchecked(array, (double s, float x) => s + Math.Pow(Math.Abs(x), norm), (double x, int _) => Math.Pow(x, invnorm), array, Zeros.AllowSkip);
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
				base.Storage.FoldByColumnUnchecked(array, (double s, float x) => s + (double)(x * x), (double x, int _) => Math.Sqrt(x), array, Zeros.AllowSkip);
			}
			else if (norm == 1.0)
			{
				base.Storage.FoldByColumnUnchecked(array, (double s, float x) => s + (double)Math.Abs(x), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else if (double.IsPositiveInfinity(norm))
			{
				base.Storage.FoldByColumnUnchecked(array, (double s, float x) => Math.Max(s, Math.Abs(x)), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else
			{
				double invnorm = 1.0 / norm;
				base.Storage.FoldByColumnUnchecked(array, (double s, float x) => s + Math.Pow(Math.Abs(x), norm), (double x, int _) => Math.Pow(x, invnorm), array, Zeros.AllowSkip);
			}
			return Vector<double>.Build.Dense(array);
		}

		public sealed override Matrix<float> NormalizeRows(double norm)
		{
			double[] norminv = ((DenseVectorStorage<double>)RowNorms(norm).Storage).Data;
			for (int i = 0; i < norminv.Length; i++)
			{
				norminv[i] = ((norminv[i] == 0.0) ? 1.0 : (1.0 / norminv[i]));
			}
			Matrix<float> matrix = Matrix<float>.Build.SameAs(this, base.RowCount, base.ColumnCount);
			base.Storage.MapIndexedTo(matrix.Storage, (int num, int _, float x) => (float)norminv[num] * x, Zeros.AllowSkip, ExistingData.AssumeZeros);
			return matrix;
		}

		public sealed override Matrix<float> NormalizeColumns(double norm)
		{
			double[] norminv = ((DenseVectorStorage<double>)ColumnNorms(norm).Storage).Data;
			for (int i = 0; i < norminv.Length; i++)
			{
				norminv[i] = ((norminv[i] == 0.0) ? 1.0 : (1.0 / norminv[i]));
			}
			Matrix<float> matrix = Matrix<float>.Build.SameAs(this, base.RowCount, base.ColumnCount);
			base.Storage.MapIndexedTo(matrix.Storage, (int _, int j, float x) => (float)norminv[j] * x, Zeros.AllowSkip, ExistingData.AssumeZeros);
			return matrix;
		}

		public override Vector<float> RowSums()
		{
			float[] array = new float[base.RowCount];
			base.Storage.FoldByRowUnchecked(array, (float s, float x) => s + x, (float x, int _) => x, array, Zeros.AllowSkip);
			return Vector<float>.Build.Dense(array);
		}

		public override Vector<float> RowAbsoluteSums()
		{
			float[] array = new float[base.RowCount];
			base.Storage.FoldByRowUnchecked(array, (float s, float x) => s + Math.Abs(x), (float x, int _) => x, array, Zeros.AllowSkip);
			return Vector<float>.Build.Dense(array);
		}

		public override Vector<float> ColumnSums()
		{
			float[] array = new float[base.ColumnCount];
			base.Storage.FoldByColumnUnchecked(array, (float s, float x) => s + x, (float x, int _) => x, array, Zeros.AllowSkip);
			return Vector<float>.Build.Dense(array);
		}

		public override Vector<float> ColumnAbsoluteSums()
		{
			float[] array = new float[base.ColumnCount];
			base.Storage.FoldByColumnUnchecked(array, (float s, float x) => s + Math.Abs(x), (float x, int _) => x, array, Zeros.AllowSkip);
			return Vector<float>.Build.Dense(array);
		}

		public sealed override bool IsHermitian()
		{
			return IsSymmetric();
		}

		public override Cholesky<float> Cholesky()
		{
			return UserCholesky.Create(this);
		}

		public override LU<float> LU()
		{
			return UserLU.Create(this);
		}

		public override QR<float> QR(QRMethod method = QRMethod.Thin)
		{
			return UserQR.Create(this, method);
		}

		public override GramSchmidt<float> GramSchmidt()
		{
			return UserGramSchmidt.Create(this);
		}

		public override Svd<float> Svd(bool computeVectors = true)
		{
			return UserSvd.Create(this, computeVectors);
		}

		public override Evd<float> Evd(Symmetricity symmetricity = Symmetricity.Unknown)
		{
			return UserEvd.Create(this, symmetricity);
		}
	}
}
