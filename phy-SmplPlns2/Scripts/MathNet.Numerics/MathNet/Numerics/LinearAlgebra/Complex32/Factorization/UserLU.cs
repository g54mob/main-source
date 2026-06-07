using System;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal sealed class UserLU : LU
	{
		public static UserLU Create(Matrix<MathNet.Numerics.Complex32> matrix)
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
			Matrix<MathNet.Numerics.Complex32> matrix2 = matrix.Clone();
			int[] array = new int[rowCount];
			for (int i = 0; i < rowCount; i++)
			{
				array[i] = i;
			}
			MathNet.Numerics.Complex32[] array2 = new MathNet.Numerics.Complex32[rowCount];
			for (int j = 0; j < rowCount; j++)
			{
				for (int k = 0; k < rowCount; k++)
				{
					array2[k] = matrix2.At(k, j);
				}
				for (int l = 0; l < rowCount; l++)
				{
					int num = Math.Min(l, j);
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int m = 0; m < num; m++)
					{
						zero += matrix2.At(l, m) * array2[m];
					}
					array2[l] -= zero;
					matrix2.At(l, j, array2[l]);
				}
				int num2 = j;
				for (int n = j + 1; n < rowCount; n++)
				{
					if (array2[n].Magnitude > array2[num2].Magnitude)
					{
						num2 = n;
					}
				}
				if (num2 != j)
				{
					for (int num3 = 0; num3 < rowCount; num3++)
					{
						MathNet.Numerics.Complex32 value = matrix2.At(num2, num3);
						matrix2.At(num2, num3, matrix2.At(j, num3));
						matrix2.At(j, num3, value);
					}
					array[j] = num2;
				}
				if ((j < rowCount) & (matrix2.At(j, j) != 0f))
				{
					for (int num4 = j + 1; num4 < rowCount; num4++)
					{
						matrix2.At(num4, j, matrix2.At(num4, j) / matrix2.At(j, j));
					}
				}
			}
			return new UserLU(matrix2, array);
		}

		private UserLU(Matrix<MathNet.Numerics.Complex32> factors, int[] pivots)
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
			input.CopyTo(result);
			for (int i = 0; i < Pivots.Length; i++)
			{
				if (Pivots[i] != i)
				{
					int row = Pivots[i];
					for (int j = 0; j < result.ColumnCount; j++)
					{
						MathNet.Numerics.Complex32 value = result.At(row, j);
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
						MathNet.Numerics.Complex32 complex = result.At(k, m) * Factors.At(l, k);
						result.At(l, m, result.At(l, m) - complex);
					}
				}
			}
			for (int num = rowCount - 1; num >= 0; num--)
			{
				for (int n = 0; n < result.ColumnCount; n++)
				{
					result.At(num, n, result.At(num, n) / Factors.At(num, num));
				}
				for (int num2 = 0; num2 < num; num2++)
				{
					for (int num3 = 0; num3 < result.ColumnCount; num3++)
					{
						MathNet.Numerics.Complex32 complex2 = result.At(num, num3) * Factors.At(num2, num);
						result.At(num2, num3, result.At(num2, num3) - complex2);
					}
				}
			}
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
			input.CopyTo(result);
			for (int i = 0; i < Pivots.Length; i++)
			{
				if (Pivots[i] != i)
				{
					int num = Pivots[i];
					Vector<MathNet.Numerics.Complex32> vector = result;
					int index = num;
					int index2 = i;
					MathNet.Numerics.Complex32 value = result[i];
					MathNet.Numerics.Complex32 value2 = result[num];
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

		public override Matrix<MathNet.Numerics.Complex32> Inverse()
		{
			int rowCount = Factors.RowCount;
			Matrix<MathNet.Numerics.Complex32> matrix = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(Factors, rowCount, rowCount);
			for (int i = 0; i < rowCount; i++)
			{
				matrix.At(i, i, 1f);
			}
			return Solve(matrix);
		}
	}
}
