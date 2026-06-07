using System;

namespace MathNet.Numerics.LinearAlgebra.Single.Factorization
{
	internal sealed class UserLU : LU
	{
		public static UserLU Create(Matrix<float> matrix)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException("matrix");
			}
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			int rowCount = matrix.RowCount;
			Matrix<float> matrix2 = matrix.Clone();
			int[] array = new int[rowCount];
			for (int i = 0; i < rowCount; i++)
			{
				array[i] = i;
			}
			float[] array2 = new float[rowCount];
			for (int j = 0; j < rowCount; j++)
			{
				for (int k = 0; k < rowCount; k++)
				{
					array2[k] = matrix2.At(k, j);
				}
				for (int l = 0; l < rowCount; l++)
				{
					int num = Math.Min(l, j);
					float num2 = 0f;
					for (int m = 0; m < num; m++)
					{
						num2 += matrix2.At(l, m) * array2[m];
					}
					array2[l] -= num2;
					matrix2.At(l, j, array2[l]);
				}
				int num3 = j;
				for (int n = j + 1; n < rowCount; n++)
				{
					if (Math.Abs(array2[n]) > Math.Abs(array2[num3]))
					{
						num3 = n;
					}
				}
				if (num3 != j)
				{
					for (int num4 = 0; num4 < rowCount; num4++)
					{
						float value = matrix2.At(num3, num4);
						matrix2.At(num3, num4, matrix2.At(j, num4));
						matrix2.At(j, num4, value);
					}
					array[j] = num3;
				}
				if ((j < rowCount) & ((double)matrix2.At(j, j) != 0.0))
				{
					for (int num5 = j + 1; num5 < rowCount; num5++)
					{
						matrix2.At(num5, j, matrix2.At(num5, j) / matrix2.At(j, j));
					}
				}
			}
			return new UserLU(matrix2, array);
		}

		private UserLU(Matrix<float> factors, int[] pivots)
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
			input.CopyTo(result);
			for (int i = 0; i < Pivots.Length; i++)
			{
				if (Pivots[i] != i)
				{
					int row = Pivots[i];
					for (int j = 0; j < result.ColumnCount; j++)
					{
						float value = result.At(row, j);
						result.At(row, j, result.At(i, j));
						result.At(i, j, value);
					}
				}
			}
			int rowCount = Factors.RowCount;
			for (int k = 0; k < rowCount; k++)
			{
				for (int l = k + 1; l < rowCount; l++)
				{
					for (int m = 0; m < result.ColumnCount; m++)
					{
						float num = result.At(k, m) * Factors.At(l, k);
						result.At(l, m, result.At(l, m) - num);
					}
				}
			}
			for (int num2 = rowCount - 1; num2 >= 0; num2--)
			{
				for (int n = 0; n < result.ColumnCount; n++)
				{
					result.At(num2, n, result.At(num2, n) / Factors.At(num2, num2));
				}
				for (int num3 = 0; num3 < num2; num3++)
				{
					for (int num4 = 0; num4 < result.ColumnCount; num4++)
					{
						float num5 = result.At(num2, num4) * Factors.At(num3, num2);
						result.At(num3, num4, result.At(num3, num4) - num5);
					}
				}
			}
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
			input.CopyTo(result);
			for (int i = 0; i < Pivots.Length; i++)
			{
				if (Pivots[i] != i)
				{
					int num = Pivots[i];
					Vector<float> vector = result;
					int index = num;
					int index2 = i;
					float value = result[i];
					float value2 = result[num];
					vector[index] = value;
					result[index2] = value2;
				}
			}
			int rowCount = Factors.RowCount;
			for (int j = 0; j < rowCount; j++)
			{
				for (int k = j + 1; k < rowCount; k++)
				{
					result[k] -= result[j] * Factors.At(k, j);
				}
			}
			for (int num2 = rowCount - 1; num2 >= 0; num2--)
			{
				result[num2] /= Factors.At(num2, num2);
				for (int l = 0; l < num2; l++)
				{
					result[l] -= result[num2] * Factors.At(l, num2);
				}
			}
		}

		public override Matrix<float> Inverse()
		{
			int rowCount = Factors.RowCount;
			Matrix<float> matrix = Matrix<float>.Build.SameAs(Factors, rowCount, rowCount);
			for (int i = 0; i < rowCount; i++)
			{
				matrix.At(i, i, 1f);
			}
			return Solve(matrix);
		}
	}
}
