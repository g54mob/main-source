using System;
using MathNet.Numerics.LinearAlgebra.Double.Factorization;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Double
{
	[Serializable]
	public abstract class Matrix : Matrix<double>
	{
		protected Matrix(MatrixStorage<double> storage)
			: base(storage)
		{
		}

		public override void CoerceZero(double threshold)
		{
			MapInplace((double x) => (!(Math.Abs(x) < threshold)) ? x : 0.0);
		}

		public sealed override Matrix<double> ConjugateTranspose()
		{
			return Transpose();
		}

		public sealed override void ConjugateTranspose(Matrix<double> result)
		{
			Transpose(result);
		}

		protected sealed override void DoConjugate(Matrix<double> result)
		{
			if (this != result)
			{
				CopyTo(result);
			}
		}

		protected override void DoNegate(Matrix<double> result)
		{
			Map((double x) => 0.0 - x, result);
		}

		protected override void DoAdd(double scalar, Matrix<double> result)
		{
			Map((double x) => x + scalar, result, Zeros.Include);
		}

		protected override void DoAdd(Matrix<double> other, Matrix<double> result)
		{
			Map2((double x, double y) => x + y, other, result);
		}

		protected override void DoSubtract(double scalar, Matrix<double> result)
		{
			Map((double x) => x - scalar, result, Zeros.Include);
		}

		protected override void DoSubtract(Matrix<double> other, Matrix<double> result)
		{
			Map2((double x, double y) => x - y, other, result);
		}

		protected override void DoMultiply(double scalar, Matrix<double> result)
		{
			Map((double x) => x * scalar, result);
		}

		protected override void DoMultiply(Vector<double> rightSide, Vector<double> result)
		{
			for (int i = 0; i < base.RowCount; i++)
			{
				double num = 0.0;
				for (int j = 0; j < base.ColumnCount; j++)
				{
					num += At(i, j) * rightSide[j];
				}
				result[i] = num;
			}
		}

		protected override void DoDivide(double divisor, Matrix<double> result)
		{
			Map((double x) => x / divisor, result, (divisor == 0.0) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoDivideByThis(double dividend, Matrix<double> result)
		{
			Map((double x) => dividend / x, result, Zeros.Include);
		}

		protected override void DoMultiply(Matrix<double> other, Matrix<double> result)
		{
			for (int i = 0; i < base.RowCount; i++)
			{
				for (int j = 0; j < other.ColumnCount; j++)
				{
					double num = 0.0;
					for (int k = 0; k < base.ColumnCount; k++)
					{
						num += At(i, k) * other.At(k, j);
					}
					result.At(i, j, num);
				}
			}
		}

		protected override void DoTransposeAndMultiply(Matrix<double> other, Matrix<double> result)
		{
			for (int i = 0; i < other.RowCount; i++)
			{
				for (int j = 0; j < base.RowCount; j++)
				{
					double num = 0.0;
					for (int k = 0; k < base.ColumnCount; k++)
					{
						num += At(j, k) * other.At(i, k);
					}
					result.At(j, i, num);
				}
			}
		}

		protected sealed override void DoConjugateTransposeAndMultiply(Matrix<double> other, Matrix<double> result)
		{
			DoTransposeAndMultiply(other, result);
		}

		protected override void DoTransposeThisAndMultiply(Matrix<double> other, Matrix<double> result)
		{
			for (int i = 0; i < other.ColumnCount; i++)
			{
				for (int j = 0; j < base.ColumnCount; j++)
				{
					double num = 0.0;
					for (int k = 0; k < base.RowCount; k++)
					{
						num += At(k, j) * other.At(k, i);
					}
					result.At(j, i, num);
				}
			}
		}

		protected sealed override void DoConjugateTransposeThisAndMultiply(Matrix<double> other, Matrix<double> result)
		{
			DoTransposeThisAndMultiply(other, result);
		}

		protected override void DoTransposeThisAndMultiply(Vector<double> rightSide, Vector<double> result)
		{
			for (int i = 0; i < base.ColumnCount; i++)
			{
				double num = 0.0;
				for (int j = 0; j < base.RowCount; j++)
				{
					num += At(j, i) * rightSide[j];
				}
				result[i] = num;
			}
		}

		protected sealed override void DoConjugateTransposeThisAndMultiply(Vector<double> rightSide, Vector<double> result)
		{
			DoTransposeThisAndMultiply(rightSide, result);
		}

		protected override void DoModulus(double divisor, Matrix<double> result)
		{
			Map((double x) => Euclid.Modulus(x, divisor), result, Zeros.Include);
		}

		protected override void DoModulusByThis(double dividend, Matrix<double> result)
		{
			Map((double x) => Euclid.Modulus(dividend, x), result, Zeros.Include);
		}

		protected override void DoRemainder(double divisor, Matrix<double> result)
		{
			Map((double x) => Euclid.Remainder(x, divisor), result, Zeros.Include);
		}

		protected override void DoRemainderByThis(double dividend, Matrix<double> result)
		{
			Map((double x) => Euclid.Remainder(dividend, x), result, Zeros.Include);
		}

		protected override void DoPointwiseMultiply(Matrix<double> other, Matrix<double> result)
		{
			Map2((double x, double y) => x * y, other, result);
		}

		protected override void DoPointwiseDivide(Matrix<double> divisor, Matrix<double> result)
		{
			Map2((double x, double y) => x / y, divisor, result, Zeros.Include);
		}

		protected override void DoPointwisePower(double exponent, Matrix<double> result)
		{
			Map((double x) => Math.Pow(x, exponent), result, (!(exponent > 0.0)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwisePower(Matrix<double> exponent, Matrix<double> result)
		{
			Map2(Math.Pow, result, Zeros.Include);
		}

		protected override void DoPointwiseModulus(Matrix<double> divisor, Matrix<double> result)
		{
			Map2(Euclid.Modulus, divisor, result, Zeros.Include);
		}

		protected override void DoPointwiseRemainder(Matrix<double> divisor, Matrix<double> result)
		{
			Map2(Euclid.Remainder, divisor, result, Zeros.Include);
		}

		protected override void DoPointwiseExp(Matrix<double> result)
		{
			Map(Math.Exp, result, Zeros.Include);
		}

		protected override void DoPointwiseLog(Matrix<double> result)
		{
			Map(Math.Log, result, Zeros.Include);
		}

		protected override void DoPointwiseAbs(Matrix<double> result)
		{
			Map(Math.Abs, result);
		}

		protected override void DoPointwiseAcos(Matrix<double> result)
		{
			Map(Math.Acos, result, Zeros.Include);
		}

		protected override void DoPointwiseAsin(Matrix<double> result)
		{
			Map(Math.Asin, result);
		}

		protected override void DoPointwiseAtan(Matrix<double> result)
		{
			Map(Math.Atan, result);
		}

		protected override void DoPointwiseAtan2(Matrix<double> other, Matrix<double> result)
		{
			Map2(Math.Atan2, other, result, Zeros.Include);
		}

		protected override void DoPointwiseCeiling(Matrix<double> result)
		{
			Map(Math.Ceiling, result);
		}

		protected override void DoPointwiseCos(Matrix<double> result)
		{
			Map(Math.Cos, result, Zeros.Include);
		}

		protected override void DoPointwiseCosh(Matrix<double> result)
		{
			Map(Math.Cosh, result, Zeros.Include);
		}

		protected override void DoPointwiseFloor(Matrix<double> result)
		{
			Map(Math.Floor, result);
		}

		protected override void DoPointwiseLog10(Matrix<double> result)
		{
			Map(Math.Log10, result, Zeros.Include);
		}

		protected override void DoPointwiseRound(Matrix<double> result)
		{
			Map(Math.Round, result);
		}

		protected override void DoPointwiseSign(Matrix<double> result)
		{
			Map((double x) => Math.Sign(x), result);
		}

		protected override void DoPointwiseSin(Matrix<double> result)
		{
			Map(Math.Sin, result);
		}

		protected override void DoPointwiseSinh(Matrix<double> result)
		{
			Map(Math.Sinh, result);
		}

		protected override void DoPointwiseSqrt(Matrix<double> result)
		{
			Map(Math.Sqrt, result);
		}

		protected override void DoPointwiseTan(Matrix<double> result)
		{
			Map(Math.Tan, result);
		}

		protected override void DoPointwiseTanh(Matrix<double> result)
		{
			Map(Math.Tanh, result);
		}

		public override Matrix<double> PseudoInverse()
		{
			Svd<double> svd = Svd();
			Matrix<double> w = svd.W;
			Vector<double> s = svd.S;
			double num = (double)Math.Max(base.RowCount, base.ColumnCount) * svd.L2Norm * Precision.DoublePrecision;
			for (int i = 0; i < s.Count; i++)
			{
				s[i] = ((s[i] < num) ? 0.0 : (1.0 / s[i]));
			}
			w.SetDiagonal(s);
			return (svd.U * (w * svd.VT)).Transpose();
		}

		public override double Trace()
		{
			if (base.RowCount != base.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			double num = 0.0;
			for (int i = 0; i < base.RowCount; i++)
			{
				num += At(i, i);
			}
			return num;
		}

		protected override void DoPointwiseMinimum(double scalar, Matrix<double> result)
		{
			Map((double x) => Math.Min(scalar, x), result, (!(scalar >= 0.0)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwiseMaximum(double scalar, Matrix<double> result)
		{
			Map((double x) => Math.Max(scalar, x), result, (!(scalar <= 0.0)) ? Zeros.Include : Zeros.AllowSkip);
		}

		protected override void DoPointwiseAbsoluteMinimum(double scalar, Matrix<double> result)
		{
			double absolute = Math.Abs(scalar);
			Map((double x) => Math.Min(absolute, Math.Abs(x)), result);
		}

		protected override void DoPointwiseAbsoluteMaximum(double scalar, Matrix<double> result)
		{
			double absolute = Math.Abs(scalar);
			Map((double x) => Math.Max(absolute, Math.Abs(x)), result, Zeros.Include);
		}

		protected override void DoPointwiseMinimum(Matrix<double> other, Matrix<double> result)
		{
			Map2(Math.Min, other, result);
		}

		protected override void DoPointwiseMaximum(Matrix<double> other, Matrix<double> result)
		{
			Map2(Math.Max, other, result);
		}

		protected override void DoPointwiseAbsoluteMinimum(Matrix<double> other, Matrix<double> result)
		{
			Map2((double x, double y) => Math.Min(Math.Abs(x), Math.Abs(y)), other, result);
		}

		protected override void DoPointwiseAbsoluteMaximum(Matrix<double> other, Matrix<double> result)
		{
			Map2((double x, double y) => Math.Max(Math.Abs(x), Math.Abs(y)), other, result);
		}

		public override double L1Norm()
		{
			double num = 0.0;
			for (int i = 0; i < base.ColumnCount; i++)
			{
				double num2 = 0.0;
				for (int j = 0; j < base.RowCount; j++)
				{
					num2 += Math.Abs(At(j, i));
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
					num2 += Math.Abs(At(i, j));
				}
				num = Math.Max(num, num2);
			}
			return num;
		}

		public override double FrobeniusNorm()
		{
			Matrix<double> matrix = Transpose();
			Matrix<double> matrix2 = this * matrix;
			double num = 0.0;
			for (int i = 0; i < base.RowCount; i++)
			{
				num += matrix2.At(i, i);
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
				base.Storage.FoldByRowUnchecked(array, (double s, double x) => s + x * x, (double x, int _) => Math.Sqrt(x), array, Zeros.AllowSkip);
			}
			else if (norm == 1.0)
			{
				base.Storage.FoldByRowUnchecked(array, (double s, double x) => s + Math.Abs(x), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else if (double.IsPositiveInfinity(norm))
			{
				base.Storage.FoldByRowUnchecked(array, (double s, double x) => Math.Max(s, Math.Abs(x)), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else
			{
				double invnorm = 1.0 / norm;
				base.Storage.FoldByRowUnchecked(array, (double s, double x) => s + Math.Pow(Math.Abs(x), norm), (double x, int _) => Math.Pow(x, invnorm), array, Zeros.AllowSkip);
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
				base.Storage.FoldByColumnUnchecked(array, (double s, double x) => s + x * x, (double x, int _) => Math.Sqrt(x), array, Zeros.AllowSkip);
			}
			else if (norm == 1.0)
			{
				base.Storage.FoldByColumnUnchecked(array, (double s, double x) => s + Math.Abs(x), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else if (double.IsPositiveInfinity(norm))
			{
				base.Storage.FoldByColumnUnchecked(array, (double s, double x) => Math.Max(s, Math.Abs(x)), (double x, int _) => x, array, Zeros.AllowSkip);
			}
			else
			{
				double invnorm = 1.0 / norm;
				base.Storage.FoldByColumnUnchecked(array, (double s, double x) => s + Math.Pow(Math.Abs(x), norm), (double x, int _) => Math.Pow(x, invnorm), array, Zeros.AllowSkip);
			}
			return Vector<double>.Build.Dense(array);
		}

		public sealed override Matrix<double> NormalizeRows(double norm)
		{
			double[] norminv = ((DenseVectorStorage<double>)RowNorms(norm).Storage).Data;
			for (int i = 0; i < norminv.Length; i++)
			{
				norminv[i] = ((norminv[i] == 0.0) ? 1.0 : (1.0 / norminv[i]));
			}
			Matrix<double> matrix = Matrix<double>.Build.SameAs(this, base.RowCount, base.ColumnCount);
			base.Storage.MapIndexedTo(matrix.Storage, (int num, int _, double x) => norminv[num] * x, Zeros.AllowSkip, ExistingData.AssumeZeros);
			return matrix;
		}

		public sealed override Matrix<double> NormalizeColumns(double norm)
		{
			double[] norminv = ((DenseVectorStorage<double>)ColumnNorms(norm).Storage).Data;
			for (int i = 0; i < norminv.Length; i++)
			{
				norminv[i] = ((norminv[i] == 0.0) ? 1.0 : (1.0 / norminv[i]));
			}
			Matrix<double> matrix = Matrix<double>.Build.SameAs(this, base.RowCount, base.ColumnCount);
			base.Storage.MapIndexedTo(matrix.Storage, (int _, int j, double x) => norminv[j] * x, Zeros.AllowSkip, ExistingData.AssumeZeros);
			return matrix;
		}

		public override Vector<double> RowSums()
		{
			double[] array = new double[base.RowCount];
			base.Storage.FoldByRowUnchecked(array, (double s, double x) => s + x, (double x, int _) => x, array, Zeros.AllowSkip);
			return Vector<double>.Build.Dense(array);
		}

		public override Vector<double> RowAbsoluteSums()
		{
			double[] array = new double[base.RowCount];
			base.Storage.FoldByRowUnchecked(array, (double s, double x) => s + Math.Abs(x), (double x, int _) => x, array, Zeros.AllowSkip);
			return Vector<double>.Build.Dense(array);
		}

		public override Vector<double> ColumnSums()
		{
			double[] array = new double[base.ColumnCount];
			base.Storage.FoldByColumnUnchecked(array, (double s, double x) => s + x, (double x, int _) => x, array, Zeros.AllowSkip);
			return Vector<double>.Build.Dense(array);
		}

		public override Vector<double> ColumnAbsoluteSums()
		{
			double[] array = new double[base.ColumnCount];
			base.Storage.FoldByColumnUnchecked(array, (double s, double x) => s + Math.Abs(x), (double x, int _) => x, array, Zeros.AllowSkip);
			return Vector<double>.Build.Dense(array);
		}

		public sealed override bool IsHermitian()
		{
			return IsSymmetric();
		}

		public override Cholesky<double> Cholesky()
		{
			return UserCholesky.Create(this);
		}

		public override LU<double> LU()
		{
			return UserLU.Create(this);
		}

		public override QR<double> QR(QRMethod method = QRMethod.Thin)
		{
			return UserQR.Create(this, method);
		}

		public override GramSchmidt<double> GramSchmidt()
		{
			return UserGramSchmidt.Create(this);
		}

		public override Svd<double> Svd(bool computeVectors = true)
		{
			return UserSvd.Create(this, computeVectors);
		}

		public override Evd<double> Evd(Symmetricity symmetricity = Symmetricity.Unknown)
		{
			return UserEvd.Create(this, symmetricity);
		}
	}
}
