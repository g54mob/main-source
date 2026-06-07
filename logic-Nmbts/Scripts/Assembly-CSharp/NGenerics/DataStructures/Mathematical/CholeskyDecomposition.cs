using System;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
	[Serializable]
	public class CholeskyDecomposition : IDecomposition
	{
		private readonly int dimension;

		private const string isNotPositiveDefinite = "The Input matrix is not positive definite.";

		private const string haveNonMatchingDimensions = "The input parameters supplied have non-matching dimensions.";

		public Matrix LeftFactorMatrix { get; private set; }

		public Matrix RightFactorMatrix
		{
			get
			{
				return LeftFactorMatrix.Transpose();
			}
		}

		public CholeskyDecomposition(Matrix matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			dimension = matrix.Rows;
			Decompose(matrix);
		}

		public void Decompose(Matrix matrix)
		{
			Guard.ArgumentNotNull(matrix, "a");
			matrix.ValidateIsSymmetric();
			int rows = matrix.Rows;
			Matrix matrix2 = new Matrix(rows, rows);
			for (int i = 0; i < rows; i++)
			{
				for (int j = i; j < rows; j++)
				{
					double num = matrix[i, j];
					for (int num2 = i - 1; num2 >= 0; num2--)
					{
						num -= matrix2[i, num2] * matrix2[j, num2];
					}
					if (i == j)
					{
						if (num <= 0.0)
						{
							throw new ArgumentException("The Input matrix is not positive definite.");
						}
						matrix2[i, i] = Math.Sqrt(num);
					}
					else
					{
						matrix2[j, i] = num / matrix2[i, i];
					}
				}
			}
			LeftFactorMatrix = matrix2;
		}

		public static Matrix QuickDecompose(Matrix a)
		{
			Guard.ArgumentNotNull(a, "a");
			a.ValidateIsSymmetric();
			int rows = a.Rows;
			Matrix matrix = new Matrix(rows, rows);
			for (int i = 0; i < rows; i++)
			{
				for (int j = i; j < rows; j++)
				{
					double num = a[i, j];
					for (int num2 = i - 1; num2 >= 0; num2--)
					{
						num -= matrix[i, num2] * matrix[j, num2];
					}
					if (i == j)
					{
						if (num <= 0.0)
						{
							throw new ArgumentException("The Input matrix is not positive definite.");
						}
						matrix[i, i] = Math.Sqrt(num);
					}
					else
					{
						matrix[j, i] = num / matrix[i, i];
					}
				}
			}
			return matrix;
		}

		public static double[] QuickSolveLinearEquation(Matrix a, double[] b)
		{
			Guard.ArgumentNotNull(a, "a");
			Guard.ArgumentNotNull(b, "b");
			a.ValidateIsSymmetric();
			int rows = a.Rows;
			if (b.Length != rows)
			{
				throw new ArgumentException("The input parameters supplied have non-matching dimensions.");
			}
			Matrix matrix = QuickDecompose(a);
			double[] array = new double[rows];
			for (int i = 0; i < rows; i++)
			{
				double num = b[i];
				for (int num2 = i - 1; num2 >= 0; num2--)
				{
					num -= matrix[i, num2] * array[num2];
				}
				array[i] = num / matrix[i, i];
			}
			for (int num3 = rows - 1; num3 >= 0; num3--)
			{
				double num = array[num3];
				for (int num2 = num3 + 1; num2 < rows; num2++)
				{
					num -= matrix[num2, num3] * array[num2];
				}
				array[num3] = num / matrix[num3, num3];
			}
			return array;
		}

		public Matrix Solve(Matrix right)
		{
			Guard.ArgumentNotNull(right, "b");
			if (right.Columns != 1 || right.Rows != dimension)
			{
				throw new ArgumentException("The input parameters supplied have non-matching dimensions.");
			}
			double[] array = new double[dimension];
			double[] array2 = new double[dimension];
			for (int i = 0; i < dimension; i++)
			{
				array2[i] = right.GetValue(i, 0);
			}
			for (int j = 0; j < dimension; j++)
			{
				double num = array2[j];
				for (int num2 = j - 1; num2 >= 0; num2--)
				{
					num -= LeftFactorMatrix[j, num2] * array[num2];
				}
				array[j] = num / LeftFactorMatrix[j, j];
			}
			for (int num3 = dimension - 1; num3 >= 0; num3--)
			{
				double num = array[num3];
				for (int num2 = num3 + 1; num2 < dimension; num2++)
				{
					num -= LeftFactorMatrix[num2, num3] * array[num2];
				}
				array[num3] = num / LeftFactorMatrix[num3, num3];
			}
			return new Matrix(dimension, 1, array);
		}
	}
}
