using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Algorithms;
using NGenerics.DataStructures.General;
using NGenerics.Extensions;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
	[Serializable]
	public class Matrix : ObjectMatrix<double>, IMathematicalMatrix, IMatrix<double>, IEquatable<IMathematicalMatrix>, ICollection<double>, IEnumerable<double>, IEnumerable, ICloneable
	{
		private const string incompatibleMatrices = "Incompatible matrices.  For this operation the matrices should be of the same size.";

		private const string incompatibleMatricesTimes = "Incompatible matrices for this operation.  The rows of the input matrix must be equal to the columns of this matrix.";

		public bool IsPositiveDefinite
		{
			get
			{
				if (noOfRows == noOfColumns)
				{
					for (int i = 0; i < noOfRows; i++)
					{
						for (int j = 0; j < i; j++)
						{
							if (GetValue(i, j) != GetValue(j, i))
							{
								return false;
							}
						}
					}
					return true;
				}
				return false;
			}
		}

		public bool IsSymmetric
		{
			get
			{
				if (noOfRows == noOfColumns)
				{
					for (int i = 0; i < noOfRows; i++)
					{
						for (int j = 0; j < i; j++)
						{
							if (GetValue(i, j) != GetValue(j, i))
							{
								return false;
							}
						}
					}
					return true;
				}
				return false;
			}
		}

		public bool IsSingular
		{
			get
			{
				return Determinant() == 0.0;
			}
		}

		public bool IsDiagonal
		{
			get
			{
				if (noOfRows == noOfColumns)
				{
					for (int i = 0; i < noOfRows; i++)
					{
						for (int j = 0; j < i; j++)
						{
							if (GetValue(i, j) != 0.0 || GetValue(j, i) != 0.0)
							{
								return false;
							}
						}
					}
					return true;
				}
				return false;
			}
		}

		public TriangularMatrixType IsTriangular
		{
			get
			{
				if (noOfRows == noOfColumns)
				{
					bool flag = true;
					bool flag2 = true;
					for (int i = 0; i < noOfRows; i++)
					{
						for (int j = 0; j < i; j++)
						{
							if (GetValue(i, j) != 0.0)
							{
								flag = false;
							}
							if (GetValue(j, i) != 0.0)
							{
								flag2 = false;
							}
						}
					}
					if (flag)
					{
						if (!flag2)
						{
							return TriangularMatrixType.Upper;
						}
						return TriangularMatrixType.Diagonal;
					}
					if (!flag2)
					{
						return TriangularMatrixType.None;
					}
					return TriangularMatrixType.Lower;
				}
				return TriangularMatrixType.None;
			}
		}

		public double Trace
		{
			get
			{
				double num = 0.0;
				int num2 = Math.Min(noOfRows, noOfColumns);
				for (int i = 0; i < num2; i++)
				{
					num += GetValue(i, i);
				}
				return num;
			}
		}

		public double OneNorm
		{
			get
			{
				double num = 0.0;
				for (int i = 0; i < noOfColumns; i++)
				{
					double num2 = 0.0;
					for (int j = 0; j < noOfRows; j++)
					{
						num2 += Math.Abs(GetValue(j, i));
					}
					if (num < num2)
					{
						num = num2;
					}
				}
				return num;
			}
		}

		public double InfinityNorm
		{
			get
			{
				double num = 0.0;
				for (int i = 0; i < noOfRows; i++)
				{
					double num2 = 0.0;
					for (int j = 0; j < noOfColumns; j++)
					{
						num2 += Math.Abs(GetValue(i, j));
					}
					if (num < num2)
					{
						num = num2;
					}
				}
				return num;
			}
		}

		public double FrobeniusNorm
		{
			get
			{
				double num = 0.0;
				for (int i = 0; i < noOfRows; i++)
				{
					for (int j = 0; j < noOfColumns; j++)
					{
						num = MathAlgorithms.Hypotenuse(num, GetValue(i, j));
					}
				}
				return num;
			}
		}

		public Matrix(int rows, int columns)
			: base(rows, columns)
		{
		}

		public Matrix(int rows, int columns, double[] data)
			: base(rows, columns, data)
		{
		}

		public Matrix(int rows, int columns, double[,] data)
			: base(rows, columns, data)
		{
		}

		IMatrix<double> IMatrix<double>.GetSubMatrix(int rowStart, int columnStart, int rowCount, int columnCount)
		{
			return GetSubMatrix(rowStart, columnStart, rowCount, columnCount);
		}

		IMathematicalMatrix IMathematicalMatrix.Multiply(IMathematicalMatrix matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			if (noOfColumns != matrix.Rows)
			{
				throw new ArgumentException("Incompatible matrices for this operation.  The rows of the input matrix must be equal to the columns of this matrix.", "matrix");
			}
			Matrix matrix2 = new Matrix(noOfRows, matrix.Columns);
			for (int i = 0; i < noOfRows; i++)
			{
				for (int j = 0; j < matrix.Columns; j++)
				{
					double num = 0.0;
					for (int k = 0; k < noOfColumns; k++)
					{
						num += GetValue(i, k) * matrix[k, j];
					}
					matrix2.SetValue(i, j, num);
				}
			}
			return matrix2;
		}

		IMathematicalMatrix IMathematicalMatrix.Multiply(double number)
		{
			return Multiply(number);
		}

		IMathematicalMatrix IMathematicalMatrix.Add(IMathematicalMatrix matrix)
		{
			return AddInternal(this, matrix);
		}

		IMathematicalMatrix IMathematicalMatrix.Negate()
		{
			return Negate();
		}

		IMathematicalMatrix IMathematicalMatrix.Inverse()
		{
			return Inverse();
		}

		IMathematicalMatrix IMathematicalMatrix.Minor(int row, int column)
		{
			return Minor(row, column);
		}

		IMathematicalMatrix IMathematicalMatrix.Adjoint()
		{
			return Adjoint();
		}

		IMathematicalMatrix IMathematicalMatrix.Concatenate(IMathematicalMatrix rightMatrix)
		{
			return ConcatenateInternal(this, rightMatrix);
		}

		IMathematicalMatrix IMathematicalMatrix.Subtract(IMathematicalMatrix matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			if (noOfRows != matrix.Rows || noOfColumns != matrix.Columns)
			{
				throw new ArgumentException("Incompatible matrices.  For this operation the matrices should be of the same size.", "matrix");
			}
			Matrix matrix2 = new Matrix(noOfRows, noOfColumns);
			for (int i = 0; i < noOfRows; i++)
			{
				for (int j = 0; j < noOfColumns; j++)
				{
					matrix2.SetValue(i, j, GetValue(i, j) - matrix[i, j]);
				}
			}
			return matrix2;
		}

		IMathematicalMatrix IMathematicalMatrix.Transpose()
		{
			return Transpose();
		}

		public Matrix Minor(int row, int column)
		{
			if (row > base.Rows - 1 || row < 0)
			{
				throw new ArgumentOutOfRangeException("row");
			}
			if (column > base.Columns - 1 || column < 0)
			{
				throw new ArgumentOutOfRangeException("column");
			}
			Matrix matrix = new Matrix(base.Rows - 1, base.Columns - 1);
			int num = 0;
			for (int i = 0; i < base.Rows; i++)
			{
				if (i == row)
				{
					continue;
				}
				int num2 = 0;
				for (int j = 0; j < base.Columns; j++)
				{
					if (j != column)
					{
						matrix.SetValue(num, num2, GetValue(i, j));
						num2++;
					}
				}
				num++;
			}
			return matrix;
		}

		public double Determinant()
		{
			return new LUDecomposition(this).Determinant();
		}

		public double Rank()
		{
			return new LUDecomposition(this).Rank();
		}

		public static Matrix LinearSolve(Matrix leftMatrix, Matrix rightMatrix)
		{
			Guard.ArgumentNotNull(leftMatrix, "leftMatrix");
			return leftMatrix.Inverse() * rightMatrix;
		}

		public Matrix Adjoint()
		{
			ValidateIsSquare();
			Matrix matrix = new Matrix(base.Rows, base.Columns);
			for (int i = 0; i < base.Rows; i++)
			{
				for (int j = 0; j < base.Columns; j++)
				{
					matrix.SetValue(i, j, Math.Pow(-1.0, i + j) * Minor(i, j).Determinant());
				}
			}
			return matrix.Transpose();
		}

		public Matrix Multiply(Matrix matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			if (noOfColumns != matrix.noOfRows)
			{
				throw new ArgumentException("Incompatible matrices for this operation.  The rows of the input matrix must be equal to the columns of this matrix.", "matrix");
			}
			Matrix matrix2 = new Matrix(noOfRows, matrix.noOfColumns);
			for (int i = 0; i < noOfRows; i++)
			{
				for (int j = 0; j < matrix.noOfColumns; j++)
				{
					double num = 0.0;
					for (int k = 0; k < noOfColumns; k++)
					{
						num += GetValue(i, k) * matrix.GetValue(k, j);
					}
					matrix2.SetValue(i, j, num);
				}
			}
			return matrix2;
		}

		public Matrix Multiply(double number)
		{
			Matrix matrix = new Matrix(noOfRows, noOfColumns);
			for (int i = 0; i < noOfRows; i++)
			{
				for (int j = 0; j < noOfColumns; j++)
				{
					matrix.SetValue(i, j, GetValue(i, j) * number);
				}
			}
			return matrix;
		}

		public Matrix Add(Matrix matrix)
		{
			return AddInternal(this, matrix);
		}

		public Matrix Negate()
		{
			return this * -1.0;
		}

		public Matrix Subtract(Matrix matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			if (noOfRows != matrix.noOfRows || noOfColumns != matrix.noOfColumns)
			{
				throw new ArgumentException("Incompatible matrices.  For this operation the matrices should be of the same size.", "matrix");
			}
			Matrix matrix2 = new Matrix(noOfRows, noOfColumns);
			for (int i = 0; i < noOfRows; i++)
			{
				for (int j = 0; j < noOfColumns; j++)
				{
					matrix2.SetValue(i, j, GetValue(i, j) - matrix.GetValue(i, j));
				}
			}
			return matrix2;
		}

		public Matrix Transpose()
		{
			Matrix matrix = new Matrix(noOfColumns, noOfRows);
			for (int i = 0; i < noOfRows; i++)
			{
				for (int j = 0; j < noOfColumns; j++)
				{
					matrix.SetValue(j, i, GetValue(i, j));
				}
			}
			return matrix;
		}

		public Matrix Inverse()
		{
			return Solve(IdentityMatrix(noOfRows, noOfRows));
		}

		public static Matrix Diagonal(int rows, int columns, double value)
		{
			Matrix matrix = new Matrix(rows, columns);
			int num = Math.Min(rows, columns);
			for (int i = 0; i < num; i++)
			{
				matrix.SetValue(i, i, value);
			}
			return matrix;
		}

		public static Matrix IdentityMatrix(int rows, int columns)
		{
			return Diagonal(rows, columns, 1.0);
		}

		public Matrix Solve(Matrix rightHandSide)
		{
			IDecomposition decomposition = ((!base.IsSquare) ? ((IDecomposition)new QRDecomposition(this)) : ((IDecomposition)new LUDecomposition(this)));
			return decomposition.Solve(rightHandSide);
		}

		public void MultiplyRow(int row, double number)
		{
			if (row > base.Rows - 1 || row < 0)
			{
				throw new ArgumentOutOfRangeException("row");
			}
			for (int i = 0; i < base.Columns; i++)
			{
				SetValue(row, i, GetValue(row, i) * number);
			}
		}

		public void MultiplyColumn(int column, double number)
		{
			if (column > base.Columns - 1 || column < 0)
			{
				throw new ArgumentOutOfRangeException("column");
			}
			for (int i = 0; i < base.Rows; i++)
			{
				SetValue(i, column, GetValue(i, column) * number);
			}
		}

		public Matrix Concatenate(Matrix rightMatrix)
		{
			return ConcatenateInternal(this, rightMatrix);
		}

		public Matrix Clone()
		{
			return new Matrix(noOfRows, noOfColumns, (double[])data.Clone());
		}

		public void ChangeSignColumn(int columnIndex)
		{
			if (columnIndex < 0 || columnIndex > noOfColumns - 1)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			for (int i = 0; i < noOfRows; i++)
			{
				SetValue(i, columnIndex, 0.0 - GetValue(i, columnIndex));
			}
		}

		public void ChangeSignRow(int rowIndex)
		{
			if (rowIndex < 0 || rowIndex > noOfRows - 1)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			for (int i = 0; i < noOfColumns; i++)
			{
				SetValue(rowIndex, i, 0.0 - GetValue(rowIndex, i));
			}
		}

		internal static void ValidateEqualRows(IMatrix<double> leftMatrix, IMatrix<double> rightMatrix)
		{
			if (leftMatrix.Rows != rightMatrix.Rows)
			{
				throw new ArgumentException("The current operation is only valid for matrices with equal number of rows.");
			}
		}

		internal void ValidateIsSymmetric()
		{
			if (!IsSymmetric)
			{
				throw new ArgumentException("The operation is only valid on a symmetric matrix.");
			}
		}

		internal Matrix GetSubMatrix(int[] rows, int columnStart, int columnEnd)
		{
			Matrix matrix = new Matrix(rows.Length, columnEnd - columnStart + 1);
			for (int i = 0; i < rows.Length; i++)
			{
				for (int j = columnStart; j <= columnEnd; j++)
				{
					matrix.SetValue(i, j - columnStart, GetValue(rows[i], j));
				}
			}
			return matrix;
		}

		private static Matrix AddInternal(IMatrix<double> leftMatrix, IMatrix<double> rightMatrix)
		{
			Guard.ArgumentNotNull(leftMatrix, "leftMatrix");
			Guard.ArgumentNotNull(rightMatrix, "rightMatrix");
			if (leftMatrix.Rows != rightMatrix.Rows || leftMatrix.Columns != rightMatrix.Columns)
			{
				throw new ArgumentException("Incompatible matrices.  For this operation the matrices should be of the same size.", "rightMatrix");
			}
			Matrix matrix = new Matrix(leftMatrix.Rows, leftMatrix.Columns);
			for (int i = 0; i < leftMatrix.Rows; i++)
			{
				for (int j = 0; j < leftMatrix.Columns; j++)
				{
					matrix.SetValue(i, j, leftMatrix[i, j] + rightMatrix[i, j]);
				}
			}
			return matrix;
		}

		private static Matrix ConcatenateInternal(IMatrix<double> leftMatrix, IMatrix<double> rightMatrix)
		{
			Guard.ArgumentNotNull(rightMatrix, "rightMatrix");
			ValidateEqualRows(leftMatrix, rightMatrix);
			Matrix matrix = new Matrix(leftMatrix.Rows, leftMatrix.Columns + rightMatrix.Columns);
			for (int i = 0; i < leftMatrix.Rows; i++)
			{
				for (int j = 0; j < leftMatrix.Columns; j++)
				{
					matrix.SetValue(i, j, leftMatrix[i, j]);
				}
			}
			for (int k = 0; k < rightMatrix.Rows; k++)
			{
				for (int l = 0; l < rightMatrix.Columns; l++)
				{
					matrix.SetValue(k, l + leftMatrix.Columns, rightMatrix[k, l]);
				}
			}
			return matrix;
		}

		public static Matrix operator +(Matrix left, Matrix right)
		{
			Guard.ArgumentNotNull(left, "left");
			return left.Add(right);
		}

		public static Matrix operator -(Matrix left, Matrix right)
		{
			Guard.ArgumentNotNull(left, "left");
			return left.Subtract(right);
		}

		public static Matrix operator *(Matrix left, Matrix right)
		{
			Guard.ArgumentNotNull(left, "m1");
			Guard.ArgumentNotNull(left, "m2");
			return left.Multiply(right);
		}

		public static Matrix operator *(double number, Matrix matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			return matrix.Multiply(number);
		}

		public static Matrix operator *(Matrix matrix, double number)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			return matrix.Multiply(number);
		}

		void ICollection<double>.Add(double item)
		{
			throw new NotSupportedException();
		}

		bool ICollection<double>.Remove(double item)
		{
			throw new NotSupportedException();
		}

		public new Matrix GetSubMatrix(int rowStart, int columnStart, int rowCount, int columnCount)
		{
			ObjectMatrix<double> subMatrix = base.GetSubMatrix(rowStart, columnStart, rowCount, columnCount);
			return new Matrix(rowCount, columnCount, subMatrix.Data);
		}

		object ICloneable.Clone()
		{
			return Clone();
		}

		public bool Equals(IMathematicalMatrix other)
		{
			if (other == null)
			{
				return false;
			}
			if (other.Rows != base.Rows)
			{
				return false;
			}
			if (other.Columns != base.Columns)
			{
				return false;
			}
			for (int i = 0; i < base.Rows; i++)
			{
				for (int j = 0; j < base.Columns; j++)
				{
					if (GetValue(i, j) != other[i, j])
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool Equals(IMathematicalMatrix other, double precision)
		{
			if (other == null)
			{
				return false;
			}
			if (other.Rows != base.Rows)
			{
				return false;
			}
			if (other.Columns != base.Columns)
			{
				return false;
			}
			for (int i = 0; i < base.Rows; i++)
			{
				for (int j = 0; j < base.Columns; j++)
				{
					if (!GetValue(i, j).IsSimilarTo(other[i, j], precision))
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
