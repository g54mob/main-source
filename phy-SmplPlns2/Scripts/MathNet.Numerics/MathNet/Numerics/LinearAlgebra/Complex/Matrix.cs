using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Complex.Factorization;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Complex
{
	[Serializable]
	public abstract class Matrix : Matrix<System.Numerics.Complex>
	{
		protected Matrix(MatrixStorage<System.Numerics.Complex> storage)
			: base(storage)
		{
		}

		public override void CoerceZero(double threshold)
		{
			MapInplace((System.Numerics.Complex x) => (!(x.Magnitude < threshold)) ? x : System.Numerics.Complex.Zero);
		}

		public sealed override Matrix<System.Numerics.Complex> ConjugateTranspose()
		{
			Matrix<System.Numerics.Complex> matrix = Transpose();
			matrix.MapInplace((System.Numerics.Complex c) => c.Conjugate());
			return matrix;
		}

		public sealed override void ConjugateTranspose(Matrix<System.Numerics.Complex> result)
		{
			Transpose(result);
			result.MapInplace((System.Numerics.Complex c) => c.Conjugate());
		}

		protected override void DoConjugate(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Conjugate, result);
		}

		protected override void DoNegate(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Negate, result);
		}

		protected override void DoAdd(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => x + scalar, result, Zeros.Include);
		}

		protected override void DoAdd(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			Map2(System.Numerics.Complex.Add, other, result);
		}

		protected override void DoSubtract(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => x - scalar, result, Zeros.Include);
		}

		protected override void DoSubtract(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			Map2(System.Numerics.Complex.Subtract, other, result);
		}

		protected override void DoMultiply(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => x * scalar, result);
		}

		protected override void DoMultiply(Vector<System.Numerics.Complex> rightSide, Vector<System.Numerics.Complex> result)
		{
			for (int i = 0; i < base.RowCount; i++)
			{
				System.Numerics.Complex zero = System.Numerics.Complex.Zero;
				for (int j = 0; j < base.ColumnCount; j++)
				{
					zero += At(i, j) * rightSide[j];
				}
				result[i] = zero;
			}
		}

		protected override void DoMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			for (int i = 0; i < base.RowCount; i++)
			{
				for (int j = 0; j != other.ColumnCount; j++)
				{
					System.Numerics.Complex zero = System.Numerics.Complex.Zero;
					for (int k = 0; k < base.ColumnCount; k++)
					{
						zero += At(i, k) * other.At(k, j);
					}
					result.At(i, j, zero);
				}
			}
		}

		protected override void DoDivide(System.Numerics.Complex divisor, Matrix<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => x / divisor, result, divisor.IsZero() ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoDivideByThis(System.Numerics.Complex dividend, Matrix<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => dividend / x, result, Zeros.Include);
		}

		protected override void DoTransposeAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			for (int i = 0; i < other.RowCount; i++)
			{
				for (int j = 0; j < base.RowCount; j++)
				{
					System.Numerics.Complex zero = System.Numerics.Complex.Zero;
					for (int k = 0; k < base.ColumnCount; k++)
					{
						zero += At(j, k) * other.At(i, k);
					}
					result.At(j, i, zero);
				}
			}
		}

		protected override void DoConjugateTransposeAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			for (int i = 0; i < other.RowCount; i++)
			{
				for (int j = 0; j < base.RowCount; j++)
				{
					System.Numerics.Complex zero = System.Numerics.Complex.Zero;
					for (int k = 0; k < base.ColumnCount; k++)
					{
						zero += At(j, k) * other.At(i, k).Conjugate();
					}
					result.At(j, i, zero);
				}
			}
		}

		protected override void DoTransposeThisAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			for (int i = 0; i < other.ColumnCount; i++)
			{
				for (int j = 0; j < base.ColumnCount; j++)
				{
					System.Numerics.Complex zero = System.Numerics.Complex.Zero;
					for (int k = 0; k < base.RowCount; k++)
					{
						zero += At(k, j) * other.At(k, i);
					}
					result.At(j, i, zero);
				}
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			for (int i = 0; i < other.ColumnCount; i++)
			{
				for (int j = 0; j < base.ColumnCount; j++)
				{
					System.Numerics.Complex zero = System.Numerics.Complex.Zero;
					for (int k = 0; k < base.RowCount; k++)
					{
						zero += At(k, j).Conjugate() * other.At(k, i);
					}
					result.At(j, i, zero);
				}
			}
		}

		protected override void DoTransposeThisAndMultiply(Vector<System.Numerics.Complex> rightSide, Vector<System.Numerics.Complex> result)
		{
			for (int i = 0; i < base.ColumnCount; i++)
			{
				System.Numerics.Complex zero = System.Numerics.Complex.Zero;
				for (int j = 0; j < base.RowCount; j++)
				{
					zero += At(j, i) * rightSide[j];
				}
				result[i] = zero;
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Vector<System.Numerics.Complex> rightSide, Vector<System.Numerics.Complex> result)
		{
			for (int i = 0; i < base.ColumnCount; i++)
			{
				System.Numerics.Complex zero = System.Numerics.Complex.Zero;
				for (int j = 0; j < base.RowCount; j++)
				{
					zero += At(j, i).Conjugate() * rightSide[j];
				}
				result[i] = zero;
			}
		}

		protected override void DoPointwiseMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			Map2(System.Numerics.Complex.Multiply, other, result);
		}

		protected override void DoPointwiseDivide(Matrix<System.Numerics.Complex> divisor, Matrix<System.Numerics.Complex> result)
		{
			Map2(System.Numerics.Complex.Divide, divisor, result, Zeros.Include);
		}

		protected override void DoPointwisePower(System.Numerics.Complex exponent, Matrix<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => x.Power(exponent), result, Zeros.Include);
		}

		protected override void DoPointwisePower(Matrix<System.Numerics.Complex> exponent, Matrix<System.Numerics.Complex> result)
		{
			Map2(System.Numerics.Complex.Pow, result, Zeros.Include);
		}

		protected sealed override void DoPointwiseModulus(Matrix<System.Numerics.Complex> divisor, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoPointwiseRemainder(Matrix<System.Numerics.Complex> divisor, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoModulus(System.Numerics.Complex divisor, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoModulusByThis(System.Numerics.Complex dividend, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoRemainder(System.Numerics.Complex divisor, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected sealed override void DoRemainderByThis(System.Numerics.Complex dividend, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseExp(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Exp, result, Zeros.Include);
		}

		protected override void DoPointwiseLog(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Log, result, Zeros.Include);
		}

		protected override void DoPointwiseAbs(Matrix<System.Numerics.Complex> result)
		{
			Map((System.Numerics.Complex x) => System.Numerics.Complex.Abs(x), result);
		}

		protected override void DoPointwiseAcos(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Acos, result, Zeros.Include);
		}

		protected override void DoPointwiseAsin(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Asin, result);
		}

		protected override void DoPointwiseAtan(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Atan, result);
		}

		protected override void DoPointwiseAtan2(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseCeiling(Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseCos(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Cos, result, Zeros.Include);
		}

		protected override void DoPointwiseCosh(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Cosh, result, Zeros.Include);
		}

		protected override void DoPointwiseFloor(Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseLog10(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Log10, result, Zeros.Include);
		}

		protected override void DoPointwiseRound(Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseSign(Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseSin(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Sin, result);
		}

		protected override void DoPointwiseSinh(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Sinh, result);
		}

		protected override void DoPointwiseSqrt(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Sqrt, result);
		}

		protected override void DoPointwiseTan(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Tan, result);
		}

		protected override void DoPointwiseTanh(Matrix<System.Numerics.Complex> result)
		{
			Map(System.Numerics.Complex.Tanh, result);
		}

		public override Matrix<System.Numerics.Complex> PseudoInverse()
		{
			Svd<System.Numerics.Complex> svd = Svd();
			Matrix<System.Numerics.Complex> w = svd.W;
			Vector<System.Numerics.Complex> s = svd.S;
			double num = (double)Math.Max(base.RowCount, base.ColumnCount) * svd.L2Norm * Precision.DoublePrecision;
			for (int i = 0; i < s.Count; i++)
			{
				s[i] = ((s[i].Magnitude < num) ? ((System.Numerics.Complex)0) : (1 / s[i]));
			}
			w.SetDiagonal(s);
			return (svd.U * (w * svd.VT)).ConjugateTranspose();
		}

		public override System.Numerics.Complex Trace()
		{
			if (base.RowCount != base.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
			for (int i = 0; i < base.RowCount; i++)
			{
				zero += At(i, i);
			}
			return zero;
		}

		protected override void DoPointwiseMinimum(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseMaximum(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseAbsoluteMinimum(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
		{
			double absolute = scalar.Magnitude;
			Map((System.Numerics.Complex x) => Math.Min(absolute, x.Magnitude), result);
		}

		protected override void DoPointwiseAbsoluteMaximum(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
		{
			double absolute = scalar.Magnitude;
			Map((System.Numerics.Complex x) => Math.Max(absolute, x.Magnitude), result, Zeros.Include);
		}

		protected override void DoPointwiseMinimum(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseMaximum(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			throw new NotSupportedException();
		}

		protected override void DoPointwiseAbsoluteMinimum(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			Map2((System.Numerics.Complex x, System.Numerics.Complex y) => Math.Min(x.Magnitude, y.Magnitude), other, result);
		}

		protected override void DoPointwiseAbsoluteMaximum(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			Map2((System.Numerics.Complex x, System.Numerics.Complex y) => Math.Max(x.Magnitude, y.Magnitude), other, result);
		}

		public override double L1Norm()
		{
			double num = 0.0;
			for (int i = 0; i < base.ColumnCount; i++)
			{
				double num2 = 0.0;
				for (int j = 0; j < base.RowCount; j++)
				{
					num2 += At(j, i).Magnitude;
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
					num2 += At(i, j).Magnitude;
				}
				num = Math.Max(num, num2);
			}
			return num;
		}

		public override double FrobeniusNorm()
		{
			Matrix<System.Numerics.Complex> matrix = ConjugateTranspose();
			Matrix<System.Numerics.Complex> matrix2 = this * matrix;
			double num = 0.0;
			for (int i = 0; i < base.RowCount; i++)
			{
				num += matrix2.At(i, i).Magnitude;
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
				base.Storage.FoldByRowUnchecked(array, (double s, System.Numerics.Complex x) => s + x.MagnitudeSquared(), (double x, int _) => Math.Sqrt(x), array, Zeros.AllowSkip);
			}
			else if (norm == 1.0)
			{
				base.Storage.FoldByRowUnchecked(array, (double s, System.Numerics.Complex x) => s + x.Magnitude, (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else if (double.IsPositiveInfinity(norm))
			{
				base.Storage.FoldByRowUnchecked(array, (double s, System.Numerics.Complex x) => Math.Max(s, x.Magnitude), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else
			{
				double invnorm = 1.0 / norm;
				base.Storage.FoldByRowUnchecked(array, (double s, System.Numerics.Complex x) => s + Math.Pow(x.Magnitude, norm), (double x, int _) => Math.Pow(x, invnorm), array, Zeros.AllowSkip);
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
				base.Storage.FoldByColumnUnchecked(array, (double s, System.Numerics.Complex x) => s + x.MagnitudeSquared(), (double x, int _) => Math.Sqrt(x), array, Zeros.AllowSkip);
			}
			else if (norm == 1.0)
			{
				base.Storage.FoldByColumnUnchecked(array, (double s, System.Numerics.Complex x) => s + x.Magnitude, (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else if (double.IsPositiveInfinity(norm))
			{
				base.Storage.FoldByColumnUnchecked(array, (double s, System.Numerics.Complex x) => Math.Max(s, x.Magnitude), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else
			{
				double invnorm = 1.0 / norm;
				base.Storage.FoldByColumnUnchecked(array, (double s, System.Numerics.Complex x) => s + Math.Pow(x.Magnitude, norm), (double x, int _) => Math.Pow(x, invnorm), array, Zeros.AllowSkip);
			}
			return Vector<double>.Build.Dense(array);
		}

		public sealed override Matrix<System.Numerics.Complex> NormalizeRows(double norm)
		{
			double[] norminv = ((DenseVectorStorage<double>)RowNorms(norm).Storage).Data;
			for (int i = 0; i < norminv.Length; i++)
			{
				norminv[i] = ((norminv[i] == 0.0) ? 1.0 : (1.0 / norminv[i]));
			}
			Matrix<System.Numerics.Complex> matrix = Matrix<System.Numerics.Complex>.Build.SameAs(this, base.RowCount, base.ColumnCount);
			base.Storage.MapIndexedTo(matrix.Storage, (int num, int _, System.Numerics.Complex x) => norminv[num] * x, Zeros.AllowSkip, ExistingData.AssumeZeros);
			return matrix;
		}

		public sealed override Matrix<System.Numerics.Complex> NormalizeColumns(double norm)
		{
			double[] norminv = ((DenseVectorStorage<double>)ColumnNorms(norm).Storage).Data;
			for (int i = 0; i < norminv.Length; i++)
			{
				norminv[i] = ((norminv[i] == 0.0) ? 1.0 : (1.0 / norminv[i]));
			}
			Matrix<System.Numerics.Complex> matrix = Matrix<System.Numerics.Complex>.Build.SameAs(this, base.RowCount, base.ColumnCount);
			base.Storage.MapIndexedTo(matrix.Storage, (int _, int j, System.Numerics.Complex x) => norminv[j] * x, Zeros.AllowSkip, ExistingData.AssumeZeros);
			return matrix;
		}

		public override Vector<System.Numerics.Complex> RowSums()
		{
			System.Numerics.Complex[] array = new System.Numerics.Complex[base.RowCount];
			base.Storage.FoldByRowUnchecked(array, (System.Numerics.Complex s, System.Numerics.Complex x) => s + x, (System.Numerics.Complex x, int _) => x, array, Zeros.AllowSkip);
			return Vector<System.Numerics.Complex>.Build.Dense(array);
		}

		public override Vector<System.Numerics.Complex> RowAbsoluteSums()
		{
			System.Numerics.Complex[] array = new System.Numerics.Complex[base.RowCount];
			base.Storage.FoldByRowUnchecked(array, (System.Numerics.Complex s, System.Numerics.Complex x) => s + x.Magnitude, (System.Numerics.Complex x, int _) => x, array, Zeros.AllowSkip);
			return Vector<System.Numerics.Complex>.Build.Dense(array);
		}

		public override Vector<System.Numerics.Complex> ColumnSums()
		{
			System.Numerics.Complex[] array = new System.Numerics.Complex[base.ColumnCount];
			base.Storage.FoldByColumnUnchecked(array, (System.Numerics.Complex s, System.Numerics.Complex x) => s + x, (System.Numerics.Complex x, int _) => x, array, Zeros.AllowSkip);
			return Vector<System.Numerics.Complex>.Build.Dense(array);
		}

		public override Vector<System.Numerics.Complex> ColumnAbsoluteSums()
		{
			System.Numerics.Complex[] array = new System.Numerics.Complex[base.ColumnCount];
			base.Storage.FoldByColumnUnchecked(array, (System.Numerics.Complex s, System.Numerics.Complex x) => s + x.Magnitude, (System.Numerics.Complex x, int _) => x, array, Zeros.AllowSkip);
			return Vector<System.Numerics.Complex>.Build.Dense(array);
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

		public override Cholesky<System.Numerics.Complex> Cholesky()
		{
			return UserCholesky.Create(this);
		}

		public override LU<System.Numerics.Complex> LU()
		{
			return UserLU.Create(this);
		}

		public override QR<System.Numerics.Complex> QR(QRMethod method = QRMethod.Thin)
		{
			return UserQR.Create(this, method);
		}

		public override GramSchmidt<System.Numerics.Complex> GramSchmidt()
		{
			return UserGramSchmidt.Create(this);
		}

		public override Svd<System.Numerics.Complex> Svd(bool computeVectors = true)
		{
			return UserSvd.Create(this, computeVectors);
		}

		public override Evd<System.Numerics.Complex> Evd(Symmetricity symmetricity = Symmetricity.Unknown)
		{
			return UserEvd.Create(this, symmetricity);
		}
	}
}
