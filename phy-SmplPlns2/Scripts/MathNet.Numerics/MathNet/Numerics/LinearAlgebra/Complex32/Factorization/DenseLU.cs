using System;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
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

		private DenseLU(Matrix<MathNet.Numerics.Complex32> factors, int[] pivots)
			: base(factors, pivots)
		{
		}

		public override void Solve(Matrix<MathNet.Numerics.Complex32> input, Matrix<MathNet.Numerics.Complex32> result)
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
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(input, Factors);
			}
			if (input is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				Array.Copy(denseMatrix.Values, 0, denseMatrix2.Values, 0, denseMatrix.Values.Length);
				DenseMatrix denseMatrix3 = (DenseMatrix)Factors;
				LinearAlgebraControl.Provider.LUSolveFactored(input.ColumnCount, denseMatrix3.Values, denseMatrix3.RowCount, Pivots, denseMatrix2.Values);
				return;
			}
			throw new NotSupportedException("Can only do LU factorization for dense matrices at the moment.");
		}

		public override void Solve(Vector<MathNet.Numerics.Complex32> input, Vector<MathNet.Numerics.Complex32> result)
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
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(input, Factors);
			}
			if (input is DenseVector denseVector && result is DenseVector denseVector2)
			{
				Array.Copy(denseVector.Values, 0, denseVector2.Values, 0, denseVector.Values.Length);
				DenseMatrix denseMatrix = (DenseMatrix)Factors;
				LinearAlgebraControl.Provider.LUSolveFactored(1, denseMatrix.Values, denseMatrix.RowCount, Pivots, denseVector2.Values);
				return;
			}
			throw new NotSupportedException("Can only do LU factorization for dense vectors at the moment.");
		}

		public override Matrix<MathNet.Numerics.Complex32> Inverse()
		{
			DenseMatrix denseMatrix = (DenseMatrix)Factors.Clone();
			LinearAlgebraControl.Provider.LUInverseFactored(denseMatrix.Values, denseMatrix.RowCount, Pivots);
			return denseMatrix;
		}
	}
}
