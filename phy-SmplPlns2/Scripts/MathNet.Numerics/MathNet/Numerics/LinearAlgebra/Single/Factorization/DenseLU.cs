using System;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Single.Factorization
{
	internal sealed class DenseLU : LU
	{
		public static DenseLU Create(DenseMatrix matrix)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException("matrix");
			}
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			int[] array = new int[matrix.RowCount];
			DenseMatrix denseMatrix = (DenseMatrix)matrix.Clone();
			LinearAlgebraControl.Provider.LUFactor(denseMatrix.Values, denseMatrix.RowCount, array);
			return new DenseLU(denseMatrix, array);
		}

		private DenseLU(Matrix<float> factors, int[] pivots)
			: base(factors, pivots)
		{
		}

		public override void Solve(Matrix<float> input, Matrix<float> result)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (result.RowCount != input.RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			if (result.ColumnCount != input.ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (input.RowCount != Factors.RowCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(input, Factors);
			}
			if (input is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				Buffer.BlockCopy(denseMatrix.Values, 0, denseMatrix2.Values, 0, denseMatrix.Values.Length * 4);
				DenseMatrix denseMatrix3 = (DenseMatrix)Factors;
				LinearAlgebraControl.Provider.LUSolveFactored(input.ColumnCount, denseMatrix3.Values, denseMatrix3.RowCount, Pivots, denseMatrix2.Values);
				return;
			}
			throw new NotSupportedException("Can only do LU factorization for dense matrices at the moment.");
		}

		public override void Solve(Vector<float> input, Vector<float> result)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (result == null)
			{
				throw new ArgumentNullException("result");
			}
			if (input.Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (input.Count != Factors.RowCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(input, Factors);
			}
			if (input is DenseVector denseVector && result is DenseVector denseVector2)
			{
				Buffer.BlockCopy(denseVector.Values, 0, denseVector2.Values, 0, denseVector.Values.Length * 4);
				DenseMatrix denseMatrix = (DenseMatrix)Factors;
				LinearAlgebraControl.Provider.LUSolveFactored(1, denseMatrix.Values, denseMatrix.RowCount, Pivots, denseVector2.Values);
				return;
			}
			throw new NotSupportedException("Can only do LU factorization for dense vectors at the moment.");
		}

		public override Matrix<float> Inverse()
		{
			DenseMatrix denseMatrix = (DenseMatrix)Factors.Clone();
			LinearAlgebraControl.Provider.LUInverseFactored(denseMatrix.Values, denseMatrix.RowCount, Pivots);
			return denseMatrix;
		}
	}
}
