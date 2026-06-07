using System;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Providers.LinearAlgebra;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal sealed class DenseGramSchmidt : GramSchmidt
	{
		public static DenseGramSchmidt Create(Matrix<MathNet.Numerics.Complex32> matrix)
		{
			if (matrix.RowCount < matrix.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(matrix);
			}
			DenseMatrix denseMatrix = (DenseMatrix)matrix.Clone();
			DenseMatrix denseMatrix2 = new DenseMatrix(matrix.ColumnCount, matrix.ColumnCount);
			Factorize(denseMatrix.Values, denseMatrix.RowCount, denseMatrix.ColumnCount, denseMatrix2.Values);
			return new DenseGramSchmidt(denseMatrix, denseMatrix2);
		}

		private DenseGramSchmidt(Matrix<MathNet.Numerics.Complex32> q, Matrix<MathNet.Numerics.Complex32> rFull)
			: base(q, rFull)
		{
		}

		private static void Factorize(MathNet.Numerics.Complex32[] q, int rowsQ, int columnsQ, MathNet.Numerics.Complex32[] r)
		{
			for (int i = 0; i < columnsQ; i++)
			{
				float num = 0f;
				for (int j = 0; j < rowsQ; j++)
				{
					num += q[i * rowsQ + j].Magnitude * q[i * rowsQ + j].Magnitude;
				}
				num = (float)Math.Sqrt(num);
				if (num == 0f)
				{
					throw new ArgumentException("Matrix must not be rank deficient.");
				}
				r[i * columnsQ + i] = num;
				for (int k = 0; k < rowsQ; k++)
				{
					q[i * rowsQ + k] /= num;
				}
				for (int l = i + 1; l < columnsQ; l++)
				{
					int num2 = i;
					int num3 = l;
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int m = 0; m < rowsQ; m++)
					{
						zero += q[num2 * rowsQ + m].Conjugate() * q[num3 * rowsQ + m];
					}
					r[l * columnsQ + i] = zero;
					for (int n = 0; n < rowsQ; n++)
					{
						MathNet.Numerics.Complex32 complex = q[l * rowsQ + n] - q[i * rowsQ + n] * zero;
						q[l * rowsQ + n] = complex;
					}
				}
			}
		}

		public override void Solve(Matrix<MathNet.Numerics.Complex32> input, Matrix<MathNet.Numerics.Complex32> result)
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

		public override void Solve(Vector<MathNet.Numerics.Complex32> input, Vector<MathNet.Numerics.Complex32> result)
		{
			if (base.Q.RowCount != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (base.Q.ColumnCount != result.Count)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(base.Q, result);
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
