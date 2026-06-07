using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Complex.Factorization
{
	internal sealed class DenseGramSchmidt : GramSchmidt
	{
		public static DenseGramSchmidt Create(Matrix<System.Numerics.Complex> matrix)
		{
			if (matrix.RowCount < matrix.ColumnCount)
			{
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(matrix);
			}
			DenseMatrix denseMatrix = (DenseMatrix)matrix.Clone();
			DenseMatrix denseMatrix2 = new DenseMatrix(matrix.ColumnCount, matrix.ColumnCount);
			Factorize(denseMatrix.Values, denseMatrix.RowCount, denseMatrix.ColumnCount, denseMatrix2.Values);
			return new DenseGramSchmidt(denseMatrix, denseMatrix2);
		}

		private DenseGramSchmidt(Matrix<System.Numerics.Complex> q, Matrix<System.Numerics.Complex> rFull)
			: base(q, rFull)
		{
		}

		private static void Factorize(System.Numerics.Complex[] q, int rowsQ, int columnsQ, System.Numerics.Complex[] r)
		{
			for (int i = 0; i < columnsQ; i++)
			{
				double num = 0.0;
				for (int j = 0; j < rowsQ; j++)
				{
					num += q[i * rowsQ + j].Magnitude * q[i * rowsQ + j].Magnitude;
				}
				num = Math.Sqrt(num);
				if (num == 0.0)
				{
					throw new ArgumentException("Matrix must not be rank deficient.");
				}
				r[i * columnsQ + i] = num;
				for (int k = 0; k < rowsQ; k++)
				{
					q[i * rowsQ + k] /= (System.Numerics.Complex)num;
				}
				for (int l = i + 1; l < columnsQ; l++)
				{
					int num2 = i;
					int num3 = l;
					System.Numerics.Complex zero = System.Numerics.Complex.Zero;
					for (int m = 0; m < rowsQ; m++)
					{
						zero += q[num2 * rowsQ + m].Conjugate() * q[num3 * rowsQ + m];
					}
					r[l * columnsQ + i] = zero;
					for (int n = 0; n < rowsQ; n++)
					{
						System.Numerics.Complex complex = q[l * rowsQ + n] - q[i * rowsQ + n] * zero;
						q[l * rowsQ + n] = complex;
					}
				}
			}
		}

		public override void Solve(Matrix<System.Numerics.Complex> input, Matrix<System.Numerics.Complex> result)
		{
			if (input.ColumnCount != result.ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (base.Q.RowCount != input.RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			if (base.Q.ColumnCount != result.RowCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (input is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.QRSolveFactored(((DenseMatrix)base.Q).Values, ((DenseMatrix)FullR).Values, base.Q.RowCount, FullR.ColumnCount, null, denseMatrix.Values, input.ColumnCount, denseMatrix2.Values, QRMethod.Thin);
				return;
			}
			throw new NotSupportedException("Can only do GramSchmidt factorization for dense matrices at the moment.");
		}

		public override void Solve(Vector<System.Numerics.Complex> input, Vector<System.Numerics.Complex> result)
		{
			if (base.Q.RowCount != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (base.Q.ColumnCount != result.Count)
			{
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(base.Q, result);
			}
			if (input is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.QRSolveFactored(((DenseMatrix)base.Q).Values, ((DenseMatrix)FullR).Values, base.Q.RowCount, FullR.ColumnCount, null, denseVector.Values, 1, denseVector2.Values, QRMethod.Thin);
				return;
			}
			throw new NotSupportedException("Can only do GramSchmidt factorization for dense vectors at the moment.");
		}
	}
}
