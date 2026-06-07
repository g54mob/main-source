using System;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
	public class LUDecomposition : IDecomposition
	{
		private Matrix LU;

		private int pivotSign;

		private int[] pivots;

		public bool NonSingular
		{
			get
			{
				for (int i = 0; i < LU.Columns; i++)
				{
					if (LU.GetValue(i, i) == 0.0)
					{
						return false;
					}
				}
				return true;
			}
		}

		public Matrix LeftFactorMatrix
		{
			get
			{
				return GetLowerTriangularFactor();
			}
		}

		public Matrix RightFactorMatrix
		{
			get
			{
				return GetUpperTriangularFactor();
			}
		}

		public LUDecomposition(Matrix matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			matrix.ValidateIsSquare();
			Decompose(matrix);
		}

		public double Determinant()
		{
			double num = pivotSign;
			for (int i = 0; i < LU.Columns; i++)
			{
				num *= LU.GetValue(i, i);
			}
			return num;
		}

		public int Rank()
		{
			int num = 0;
			for (int i = 0; i < LU.Columns; i++)
			{
				if (LU.GetValue(i, i) != 0.0)
				{
					num++;
				}
			}
			return num;
		}

		private Matrix SolveInternal(Matrix B)
		{
			int columns = B.Columns;
			Matrix subMatrix = B.GetSubMatrix(pivots, 0, columns - 1);
			for (int i = 0; i < LU.Columns; i++)
			{
				for (int j = i + 1; j < LU.Columns; j++)
				{
					for (int k = 0; k < columns; k++)
					{
						subMatrix.SetValue(j, k, subMatrix.GetValue(j, k) - subMatrix.GetValue(i, k) * LU.GetValue(j, i));
					}
				}
			}
			for (int num = LU.Columns - 1; num >= 0; num--)
			{
				for (int l = 0; l < columns; l++)
				{
					subMatrix.SetValue(num, l, subMatrix.GetValue(num, l) / LU.GetValue(num, num));
				}
				for (int m = 0; m < num; m++)
				{
					for (int n = 0; n < columns; n++)
					{
						subMatrix.SetValue(m, n, subMatrix.GetValue(m, n) - subMatrix.GetValue(num, n) * LU.GetValue(m, num));
					}
				}
			}
			return subMatrix;
		}

		public void Decompose(Matrix matrix)
		{
			LU = matrix.Clone();
			pivots = new int[LU.Rows];
			for (int i = 0; i < LU.Rows; i++)
			{
				pivots[i] = i;
			}
			pivotSign = 1;
			double[] array = new double[LU.Rows];
			for (int j = 0; j < LU.Columns; j++)
			{
				for (int k = 0; k < LU.Rows; k++)
				{
					array[k] = LU.GetValue(k, j);
				}
				for (int l = 0; l < LU.Rows; l++)
				{
					int num = Math.Min(l, j);
					double num2 = 0.0;
					for (int m = 0; m < num; m++)
					{
						num2 += LU.GetValue(l, m) * array[m];
					}
					LU.SetValue(l, j, array[l] - num2);
					array[l] -= num2;
				}
				int num3 = j;
				for (int n = j + 1; n < LU.Rows; n++)
				{
					if (Math.Abs(array[n]) > Math.Abs(array[num3]))
					{
						num3 = n;
					}
				}
				if (num3 != j)
				{
					for (int num4 = 0; num4 < LU.Columns; num4++)
					{
						double value = LU[num3, num4];
						LU.SetValue(num3, num4, LU[j, num4]);
						LU.SetValue(j, num4, value);
					}
					Swapper.Swap(pivots, num3, j);
					pivotSign = -pivotSign;
				}
				if (j < LU.Rows && LU.GetValue(j, j) != 0.0)
				{
					for (int num5 = j + 1; num5 < LU.Rows; num5++)
					{
						LU.SetValue(num5, j, LU.GetValue(num5, j) / LU.GetValue(j, j));
					}
				}
			}
		}

		private Matrix GetLowerTriangularFactor()
		{
			Matrix matrix = new Matrix(LU.Rows, LU.Columns);
			for (int i = 0; i < LU.Rows; i++)
			{
				for (int j = 0; j < LU.Columns; j++)
				{
					if (i > j)
					{
						matrix.SetValue(i, j, LU.GetValue(i, j));
					}
					else if (i == j)
					{
						matrix.SetValue(i, j, 1.0);
					}
					else
					{
						matrix.SetValue(i, j, 0.0);
					}
				}
			}
			return matrix;
		}

		private Matrix GetUpperTriangularFactor()
		{
			Matrix matrix = new Matrix(LU.Rows, LU.Columns);
			for (int i = 0; i < LU.Rows; i++)
			{
				for (int j = 0; j < LU.Columns; j++)
				{
					if (i <= j)
					{
						matrix.SetValue(i, j, LU.GetValue(i, j));
					}
					else
					{
						matrix.SetValue(i, j, 0.0);
					}
				}
			}
			return matrix;
		}

		public Matrix Solve(Matrix right)
		{
			Guard.ArgumentNotNull(right, "right");
			Matrix.ValidateEqualRows(right, LU);
			if (!NonSingular)
			{
				throw new ArgumentException("This operation is only valid on non-singular matrices.");
			}
			return SolveInternal(right);
		}
	}
}
