using System;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal sealed class DenseSvd : Svd
	{
		public static DenseSvd Create(DenseMatrix matrix, bool computeVectors)
		{
			DenseVector denseVector = new DenseVector(Math.Min(matrix.RowCount, matrix.ColumnCount));
			DenseMatrix denseMatrix = new DenseMatrix(matrix.RowCount);
			DenseMatrix denseMatrix2 = new DenseMatrix(matrix.ColumnCount);
			LinearAlgebraControl.Provider.SingularValueDecomposition(computeVectors, ((DenseMatrix)matrix.Clone()).Values, matrix.RowCount, matrix.ColumnCount, denseVector.Values, denseMatrix.Values, denseMatrix2.Values);
			return new DenseSvd(denseVector, denseMatrix, denseMatrix2, computeVectors);
		}

		private DenseSvd(Vector<double> s, Matrix<double> u, Matrix<double> vt, bool vectorsComputed)
			: base(s, u, vt, vectorsComputed)
		{
		}

		public override void Solve(Matrix<double> input, Matrix<double> result)
		{
			if (!VectorsComputed)
			{
				throw new InvalidOperationException("The singular vectors were not computed.");
			}
			if (input.ColumnCount != result.ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (base.U.RowCount != input.RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			if (base.VT.ColumnCount != result.RowCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (input is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.SvdSolveFactored(base.U.RowCount, base.VT.ColumnCount, ((DenseVector)base.S).Values, ((DenseMatrix)base.U).Values, ((DenseMatrix)base.VT).Values, denseMatrix.Values, input.ColumnCount, denseMatrix2.Values);
				return;
			}
			throw new NotSupportedException("Can only do SVD factorization for dense matrices at the moment.");
		}

		public override void Solve(Vector<double> input, Vector<double> result)
		{
			if (!VectorsComputed)
			{
				throw new InvalidOperationException("The singular vectors were not computed.");
			}
			if (base.U.RowCount != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (base.VT.ColumnCount != result.Count)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(base.VT, result);
			}
			if (input is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.SvdSolveFactored(base.U.RowCount, base.VT.ColumnCount, ((DenseVector)base.S).Values, ((DenseMatrix)base.U).Values, ((DenseMatrix)base.VT).Values, denseVector.Values, 1, denseVector2.Values);
				return;
			}
			throw new NotSupportedException("Can only do SVD factorization for dense vectors at the moment.");
		}
	}
}
