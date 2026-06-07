using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Factorization
{
	internal sealed class UserQR : QR
	{
		public static UserQR Create(Matrix<MathNet.Numerics.Complex32> matrix, QRMethod method = QRMethod.Full)
		{
			if (matrix.RowCount < matrix.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(matrix);
			}
			int num = Math.Min(matrix.RowCount, matrix.ColumnCount);
			MathNet.Numerics.Complex32[][] array = new MathNet.Numerics.Complex32[num][];
			Matrix<MathNet.Numerics.Complex32> matrix2;
			Matrix<MathNet.Numerics.Complex32> matrix3;
			if (method == QRMethod.Full)
			{
				matrix2 = matrix.Clone();
				matrix3 = Matrix<MathNet.Numerics.Complex32>.Build.SameAs(matrix, matrix.RowCount, matrix.RowCount, fullyMutable: true);
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

		private UserQR(Matrix<MathNet.Numerics.Complex32> q, Matrix<MathNet.Numerics.Complex32> rFull, QRMethod method)
			: base(q, rFull, method)
		{
		}

		private static MathNet.Numerics.Complex32[] GenerateColumn(Matrix<MathNet.Numerics.Complex32> a, int row, int column)
		{
			int num = a.RowCount - row;
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[num];
			for (int i = row; i < a.RowCount; i++)
			{
				array[i - row] = a.At(i, column);
				a.At(i, column, 0f);
			}
			MathNet.Numerics.Complex32 complex = array.Aggregate(MathNet.Numerics.Complex32.Zero, (MathNet.Numerics.Complex32 current, MathNet.Numerics.Complex32 t) => current + t.Magnitude * t.Magnitude).SquareRoot();
			if (row == a.RowCount - 1 || complex.Magnitude == 0f)
			{
				a.At(row, column, -array[0]);
				array[0] = 1.4142135f;
				return array;
			}
			if (array[0].Magnitude != 0f)
			{
				complex = complex.Magnitude * (array[0] / array[0].Magnitude);
			}
			a.At(row, column, -complex);
			for (int num2 = 0; num2 < num; num2++)
			{
				array[num2] /= complex;
			}
			array[0] += 1f;
			MathNet.Numerics.Complex32 complex2 = (1f / array[0]).SquareRoot();
			for (int num3 = 0; num3 < num; num3++)
			{
				array[num3] = array[num3].Conjugate() * complex2;
			}
			return array;
		}

		private static void ComputeQR(MathNet.Numerics.Complex32[] u, Matrix<MathNet.Numerics.Complex32> a, int rowStart, int rowDim, int columnStart, int columnDim, int availableCores)
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
				MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
				for (int num3 = rowStart; num3 < rowDim; num3++)
				{
					zero += u[num3 - rowStart] * a.At(num3, num2);
				}
				for (int num4 = rowStart; num4 < rowDim; num4++)
				{
					a.At(num4, num2, a.At(num4, num2) - u[num4 - rowStart].Conjugate() * zero);
				}
			}
		}

		public override void Solve(Matrix<MathNet.Numerics.Complex32> input, Matrix<MathNet.Numerics.Complex32> result)
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
			Matrix<MathNet.Numerics.Complex32> matrix = input.Clone();
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[FullR.RowCount];
			for (int i = 0; i < input.ColumnCount; i++)
			{
				for (int j = 0; j < FullR.RowCount; j++)
				{
					array[j] = matrix.At(j, i);
				}
				for (int k = 0; k < FullR.RowCount; k++)
				{
					MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
					for (int l = 0; l < FullR.RowCount; l++)
					{
						zero += base.Q.At(l, k).Conjugate() * array[l];
					}
					matrix.At(k, i, zero);
				}
			}
			for (int num = FullR.ColumnCount - 1; num >= 0; num--)
			{
				for (int m = 0; m < input.ColumnCount; m++)
				{
					matrix.At(num, m, matrix.At(num, m) / FullR.At(num, num));
				}
				for (int n = 0; n < num; n++)
				{
					for (int num2 = 0; num2 < input.ColumnCount; num2++)
					{
						matrix.At(n, num2, matrix.At(n, num2) - matrix.At(num, num2) * FullR.At(n, num));
					}
				}
			}
			for (int num3 = 0; num3 < FullR.ColumnCount; num3++)
			{
				for (int num4 = 0; num4 < matrix.ColumnCount; num4++)
				{
					result.At(num3, num4, matrix.At(num3, num4));
				}
			}
		}

		public override void Solve(Vector<MathNet.Numerics.Complex32> input, Vector<MathNet.Numerics.Complex32> result)
		{
			if (FullR.RowCount != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (FullR.ColumnCount != result.Count)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(FullR, result);
			}
			Vector<MathNet.Numerics.Complex32> vector = input.Clone();
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[FullR.RowCount];
			for (int i = 0; i < FullR.RowCount; i++)
			{
				array[i] = vector[i];
			}
			for (int j = 0; j < FullR.RowCount; j++)
			{
				MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
				for (int k = 0; k < FullR.RowCount; k++)
				{
					zero += base.Q.At(k, j).Conjugate() * array[k];
				}
				vector[j] = zero;
			}
			for (int num = FullR.ColumnCount - 1; num >= 0; num--)
			{
				vector[num] /= FullR.At(num, num);
				for (int l = 0; l < num; l++)
				{
					vector[l] -= vector[num] * FullR.At(l, num);
				}
			}
			for (int m = 0; m < FullR.ColumnCount; m++)
			{
				result[m] = vector[m];
			}
		}
	}
}
