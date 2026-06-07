using System;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal sealed class UserCholesky : Cholesky
	{
		private static void DoCholesky(Matrix<MathNet.Numerics.Complex32> factor)
		{
			if (factor.RowCount != factor.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[factor.RowCount];
			for (int i = 0; i < factor.RowCount; i++)
			{
				MathNet.Numerics.Complex32 complex = factor.At(i, i);
				if ((double)complex.Real > 0.0)
				{
					complex = complex.SquareRoot();
					factor.At(i, i, complex);
					array[i] = complex;
					for (int j = i + 1; j < factor.RowCount; j++)
					{
						factor.At(j, i, factor.At(j, i) / complex);
						array[j] = factor.At(j, i);
					}
					DoCholeskyStep(factor, factor.RowCount, i + 1, factor.RowCount, array, Control.MaxDegreeOfParallelism);
					for (int k = i + 1; k < factor.RowCount; k++)
					{
						factor.At(i, k, MathNet.Numerics.Complex32.Zero);
					}
					continue;
				}
				throw new ArgumentException("Matrix must be positive definite.");
			}
		}

		public static UserCholesky Create(Matrix<MathNet.Numerics.Complex32> matrix)
		{
			Matrix<MathNet.Numerics.Complex32> factor = matrix.Clone();
			DoCholesky(factor);
			return new UserCholesky(factor);
		}

		public override void Factorize(Matrix<MathNet.Numerics.Complex32> matrix)
		{
			if (matrix.RowCount != base.Factor.RowCount || matrix.ColumnCount != base.Factor.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(matrix, base.Factor);
			}
			matrix.CopyTo(base.Factor);
			DoCholesky(base.Factor);
		}

		private UserCholesky(Matrix<MathNet.Numerics.Complex32> factor)
			: base(factor)
		{
		}

		private static void DoCholeskyStep(Matrix<MathNet.Numerics.Complex32> data, int rowDim, int firstCol, int colLimit, MathNet.Numerics.Complex32[] multipliers, int availableCores)
		{
			int num = colLimit - firstCol;
			if (availableCores > 1 && num > 200)
			{
				int tmpSplit = firstCol + num / 3;
				int tmpCores = availableCores / 2;
				CommonParallel.Invoke(delegate
				{
					DoCholeskyStep(data, rowDim, firstCol, tmpSplit, multipliers, tmpCores);
				}, delegate
				{
					DoCholeskyStep(data, rowDim, tmpSplit, colLimit, multipliers, tmpCores);
				});
				return;
			}
			for (int num2 = firstCol; num2 < colLimit; num2++)
			{
				MathNet.Numerics.Complex32 complex = multipliers[num2];
				for (int num3 = num2; num3 < rowDim; num3++)
				{
					data.At(num3, num2, data.At(num3, num2) - multipliers[num3] * complex.Conjugate());
				}
			}
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
			input.CopyTo(result);
			int rowCount = base.Factor.RowCount;
			for (int i = 0; i < result.ColumnCount; i++)
			{
				for (int j = 0; j < rowCount; j++)
				{
					MathNet.Numerics.Complex32 complex = result.At(j, i);
					for (int num = j - 1; num >= 0; num--)
					{
						complex -= base.Factor.At(j, num) * result.At(num, i);
					}
					result.At(j, i, complex / base.Factor.At(j, j));
				}
				for (int num2 = rowCount - 1; num2 >= 0; num2--)
				{
					MathNet.Numerics.Complex32 complex = result.At(num2, i);
					for (int k = num2 + 1; k < rowCount; k++)
					{
						complex -= base.Factor.At(k, num2).Conjugate() * result.At(k, i);
					}
					result.At(num2, i, complex / base.Factor.At(num2, num2));
				}
			}
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
			input.CopyTo(result);
			int rowCount = base.Factor.RowCount;
			for (int i = 0; i < rowCount; i++)
			{
				MathNet.Numerics.Complex32 complex = result[i];
				for (int num = i - 1; num >= 0; num--)
				{
					complex -= base.Factor.At(i, num) * result[num];
				}
				result[i] = complex / base.Factor.At(i, i);
			}
			for (int num2 = rowCount - 1; num2 >= 0; num2--)
			{
				MathNet.Numerics.Complex32 complex = result[num2];
				for (int j = num2 + 1; j < rowCount; j++)
				{
					complex -= base.Factor.At(j, num2).Conjugate() * result[j];
				}
				result[num2] = complex / base.Factor.At(num2, num2);
			}
		}
	}
}
