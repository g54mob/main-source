using System;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Double.Factorization
{
	internal sealed class UserCholesky : Cholesky
	{
		private static void DoCholesky(Matrix<double> factor)
		{
			if (factor.RowCount != factor.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			double[] array = new double[factor.RowCount];
			for (int i = 0; i < factor.RowCount; i++)
			{
				double num = factor.At(i, i);
				if (num > 0.0)
				{
					num = Math.Sqrt(num);
					factor.At(i, i, num);
					array[i] = num;
					for (int j = i + 1; j < factor.RowCount; j++)
					{
						factor.At(j, i, factor.At(j, i) / num);
						array[j] = factor.At(j, i);
					}
					DoCholeskyStep(factor, factor.RowCount, i + 1, factor.RowCount, array, Control.MaxDegreeOfParallelism);
					for (int k = i + 1; k < factor.RowCount; k++)
					{
						factor.At(i, k, 0.0);
					}
					continue;
				}
				throw new ArgumentException("Matrix must be positive definite.");
			}
		}

		public static UserCholesky Create(Matrix<double> matrix)
		{
			Matrix<double> factor = matrix.Clone();
			DoCholesky(factor);
			return new UserCholesky(factor);
		}

		public override void Factorize(Matrix<double> matrix)
		{
			if (matrix.RowCount != base.Factor.RowCount || matrix.ColumnCount != base.Factor.ColumnCount)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(matrix, base.Factor);
			}
			matrix.CopyTo(base.Factor);
			DoCholesky(base.Factor);
		}

		private UserCholesky(Matrix<double> factor)
			: base(factor)
		{
		}

		private static void DoCholeskyStep(Matrix<double> data, int rowDim, int firstCol, int colLimit, double[] multipliers, int availableCores)
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
				double num3 = multipliers[num2];
				for (int num4 = num2; num4 < rowDim; num4++)
				{
					data.At(num4, num2, data.At(num4, num2) - multipliers[num4] * num3);
				}
			}
		}

		public override void Solve(Matrix<double> input, Matrix<double> result)
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
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(input, base.Factor);
			}
			input.CopyTo(result);
			int rowCount = base.Factor.RowCount;
			for (int i = 0; i < result.ColumnCount; i++)
			{
				for (int j = 0; j < rowCount; j++)
				{
					double num = result.At(j, i);
					for (int num2 = j - 1; num2 >= 0; num2--)
					{
						num -= base.Factor.At(j, num2) * result.At(num2, i);
					}
					result.At(j, i, num / base.Factor.At(j, j));
				}
				for (int num3 = rowCount - 1; num3 >= 0; num3--)
				{
					double num = result.At(num3, i);
					for (int k = num3 + 1; k < rowCount; k++)
					{
						num -= base.Factor.At(k, num3) * result.At(k, i);
					}
					result.At(num3, i, num / base.Factor.At(num3, num3));
				}
			}
		}

		public override void Solve(Vector<double> input, Vector<double> result)
		{
			if (input.Count != result.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (input.Count != base.Factor.RowCount)
			{
				throw Matrix<double>.DimensionsDontMatch<ArgumentException>(input, base.Factor);
			}
			input.CopyTo(result);
			int rowCount = base.Factor.RowCount;
			for (int i = 0; i < rowCount; i++)
			{
				double num = result[i];
				for (int num2 = i - 1; num2 >= 0; num2--)
				{
					num -= base.Factor.At(i, num2) * result[num2];
				}
				result[i] = num / base.Factor.At(i, i);
			}
			for (int num3 = rowCount - 1; num3 >= 0; num3--)
			{
				double num = result[num3];
				for (int j = num3 + 1; j < rowCount; j++)
				{
					num -= base.Factor.At(j, num3) * result[j];
				}
				result[num3] = num / base.Factor.At(num3, num3);
			}
		}
	}
}
