using System;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal sealed class DenseCholesky : Cholesky
	{
		public static DenseCholesky Create(DenseMatrix matrix)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			DenseMatrix denseMatrix = (DenseMatrix)matrix.Clone();
			LinearAlgebraControl.Provider.CholeskyFactor(denseMatrix.Values, denseMatrix.RowCount);
			return new DenseCholesky(denseMatrix);
		}

		private DenseCholesky(Matrix<MathNet.Numerics.Complex32> factor)
			: base(factor)
		{
		}

		public override void Solve(Matrix<MathNet.Numerics.Complex32> input, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result.RowCount != input.RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			if (result.ColumnCount != input.ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (input.RowCount != base.Factor.RowCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(input, base.Factor);
			}
			if (input is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				Array.Copy(denseMatrix.Values, 0, denseMatrix2.Values, 0, denseMatrix.Values.Length);
				DenseMatrix denseMatrix3 = (DenseMatrix)base.Factor;
				LinearAlgebraControl.Provider.CholeskySolveFactored(denseMatrix3.Values, denseMatrix3.RowCount, denseMatrix2.Values, denseMatrix2.ColumnCount);
				return;
			}
			throw new NotSupportedException("Can only do Cholesky factorization for dense matrices at the moment.");
		}

		public override void Solve(Vector<MathNet.Numerics.Complex32> input, Vector<MathNet.Numerics.Complex32> result)
		{
			if (input.Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (input.Count != base.Factor.RowCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(input, base.Factor);
			}
			if (input is DenseVector denseVector && result is DenseVector denseVector2)
			{
				Array.Copy(denseVector.Values, 0, denseVector2.Values, 0, denseVector.Values.Length);
				DenseMatrix denseMatrix = (DenseMatrix)base.Factor;
				LinearAlgebraControl.Provider.CholeskySolveFactored(denseMatrix.Values, denseMatrix.RowCount, denseVector2.Values, 1);
				return;
			}
			throw new NotSupportedException("Can only do Cholesky factorization for dense vectors at the moment.");
		}

		public override void Factorize(Matrix<MathNet.Numerics.Complex32> matrix)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			if (matrix.RowCount != base.Factor.RowCount || matrix.ColumnCount != base.Factor.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(matrix, base.Factor);
			}
			if (matrix is DenseMatrix denseMatrix)
			{
				DenseMatrix denseMatrix2 = (DenseMatrix)base.Factor;
				Array.Copy(denseMatrix.Values, 0, denseMatrix2.Values, 0, denseMatrix.Values.Length);
				LinearAlgebraControl.Provider.CholeskyFactor(denseMatrix2.Values, denseMatrix2.RowCount);
				return;
			}
			throw new NotSupportedException("Can only do Cholesky factorization for dense matrices at the moment.");
		}
	}
}
