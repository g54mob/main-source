using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Single.Factorization
{
	internal sealed class UserQR : QR
	{
		public static UserQR Create(Matrix<float> matrix, QRMethod method = QRMethod.Full)
		{
			if (matrix.RowCount < matrix.ColumnCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(matrix);
			}
			int num = Math.Min(matrix.RowCount, matrix.ColumnCount);
			float[][] array = new float[num][];
			Matrix<float> matrix2;
			Matrix<float> matrix3;
			if (method == QRMethod.Full)
			{
				matrix2 = matrix.Clone();
				matrix3 = Matrix<float>.Build.SameAs(matrix, matrix.RowCount, matrix.RowCount, fullyMutable: true);
				for (int i = 0; i < matrix.RowCount; i++)
				{
					matrix3.At(i, i, 1f);
				}
				for (int j = 0; j < num; j++)
				{
					array[j] = GenerateColumn(matrix2, j, j);
					ComputeQR(array[j], matrix2, j, matrix.RowCount, j + 1, matrix.ColumnCount, Control.MaxDegreeOfParallelism);
				}
				for (int num2 = num - 1; num2 >= 0; num2--)
				{
					ComputeQR(array[num2], matrix3, num2, matrix.RowCount, num2, matrix.RowCount, Control.MaxDegreeOfParallelism);
				}
			}
			else
			{
				matrix3 = matrix.Clone();
				for (int k = 0; k < num; k++)
				{
					array[k] = GenerateColumn(matrix3, k, k);
					ComputeQR(array[k], matrix3, k, matrix.RowCount, k + 1, matrix.ColumnCount, Control.MaxDegreeOfParallelism);
				}
				matrix2 = matrix3.SubMatrix(0, matrix.ColumnCount, 0, matrix.ColumnCount);
				matrix3.Clear();
				for (int l = 0; l < matrix.ColumnCount; l++)
				{
					matrix3.At(l, l, 1f);
				}
				for (int num3 = num - 1; num3 >= 0; num3--)
				{
					ComputeQR(array[num3], matrix3, num3, matrix.RowCount, num3, matrix.ColumnCount, Control.MaxDegreeOfParallelism);
				}
			}
			return new UserQR(matrix3, matrix2, method);
		}

		private UserQR(Matrix<float> q, Matrix<float> rFull, QRMethod method)
			: base(q, rFull, method)
		{
		}

		private static float[] GenerateColumn(Matrix<float> a, int row, int column)
		{
			int num = a.RowCount - row;
			float[] array = new float[num];
			for (int i = row; i < a.RowCount; i++)
			{
				array[i - row] = a.At(i, row);
				a.At(i, row, 0f);
			}
			float num2 = array.Sum((float t) => t * t);
			num2 = (float)Math.Sqrt(num2);
			if (row == a.RowCount - 1 || num2 == 0f)
			{
				a.At(row, column, 0f - array[0]);
				array[0] = 1.4142135f;
				return array;
			}
			float num3 = 1f / num2;
			if ((double)array[0] < 0.0)
			{
				num3 *= -1f;
			}
			a.At(row, column, -1f / num3);
			for (int num4 = 0; num4 < num; num4++)
			{
				array[num4] *= num3;
			}
			array[0] += 1f;
			float num5 = (float)Math.Sqrt(1.0 / (double)array[0]);
			for (int num6 = 0; num6 < num; num6++)
			{
				array[num6] *= num5;
			}
			return array;
		}

		private static void ComputeQR(float[] u, Matrix<float> a, int rowStart, int rowDim, int columnStart, int columnDim, int availableCores)
		{
			if (rowDim < rowStart || columnDim < columnStart)
			{
				return;
			}
			int num = columnDim - columnStart;
			if (availableCores > 1 && num > 200)
			{
				int tmpSplit = columnStart + num / 2;
				int tmpCores = availableCores / 2;
				CommonParallel.Invoke(delegate
				{
					ComputeQR(u, a, rowStart, rowDim, columnStart, tmpSplit, tmpCores);
				}, delegate
				{
					ComputeQR(u, a, rowStart, rowDim, tmpSplit, columnDim, tmpCores);
				});
				return;
			}
			for (int num2 = columnStart; num2 < columnDim; num2++)
			{
				float num3 = 0f;
				for (int num4 = rowStart; num4 < rowDim; num4++)
				{
					num3 += u[num4 - rowStart] * a.At(num4, num2);
				}
				for (int num5 = rowStart; num5 < rowDim; num5++)
				{
					a.At(num5, num2, a.At(num5, num2) - u[num5 - rowStart] * num3);
				}
			}
		}

		public override void Solve(Matrix<float> input, Matrix<float> result)
		{
			if (input.ColumnCount != result.ColumnCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			if (FullR.RowCount != input.RowCount)
			{
				throw new ArgumentException("Matrix row dimensions must agree.");
			}
			if (FullR.ColumnCount != result.RowCount)
			{
				throw new ArgumentException("Matrix column dimensions must agree.");
			}
			Matrix<float> matrix = input.Clone();
			float[] array = new float[FullR.RowCount];
			for (int i = 0; i < input.ColumnCount; i++)
			{
				for (int j = 0; j < FullR.RowCount; j++)
				{
					array[j] = matrix.At(j, i);
				}
				for (int k = 0; k < FullR.RowCount; k++)
				{
					float num = 0f;
					for (int l = 0; l < FullR.RowCount; l++)
					{
						num += base.Q.At(l, k) * array[l];
					}
					matrix.At(k, i, num);
				}
			}
			for (int num2 = FullR.ColumnCount - 1; num2 >= 0; num2--)
			{
				for (int m = 0; m < input.ColumnCount; m++)
				{
					matrix.At(num2, m, matrix.At(num2, m) / FullR.At(num2, num2));
				}
				for (int n = 0; n < num2; n++)
				{
					for (int num3 = 0; num3 < input.ColumnCount; num3++)
					{
						matrix.At(n, num3, matrix.At(n, num3) - matrix.At(num2, num3) * FullR.At(n, num2));
					}
				}
			}
			for (int num4 = 0; num4 < FullR.ColumnCount; num4++)
			{
				for (int num5 = 0; num5 < matrix.ColumnCount; num5++)
				{
					result.At(num4, num5, matrix.At(num4, num5));
				}
			}
		}

		public override void Solve(Vector<float> input, Vector<float> result)
		{
			if (FullR.RowCount != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (FullR.ColumnCount != result.Count)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(FullR, result);
			}
			Vector<float> vector = input.Clone();
			float[] array = new float[FullR.RowCount];
			for (int i = 0; i < FullR.RowCount; i++)
			{
				array[i] = vector[i];
			}
			for (int j = 0; j < FullR.RowCount; j++)
			{
				float num = 0f;
				for (int k = 0; k < FullR.RowCount; k++)
				{
					num += base.Q.At(k, j) * array[k];
				}
				vector[j] = num;
			}
			for (int num2 = FullR.ColumnCount - 1; num2 >= 0; num2--)
			{
				vector[num2] /= FullR.At(num2, num2);
				for (int l = 0; l < num2; l++)
				{
					vector[l] -= vector[num2] * FullR.At(l, num2);
				}
			}
			for (int m = 0; m < FullR.ColumnCount; m++)
			{
				result[m] = vector[m];
			}
		}
	}
}
