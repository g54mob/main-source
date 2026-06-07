using System;
using NGenerics.Algorithms;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
	[Serializable]
	public class QRDecomposition : IDecomposition
	{
		private Matrix qr;

		private double[] diagonal;

		public bool IsFullRank
		{
			get
			{
				for (int i = 0; i < qr.Columns; i++)
				{
					if (diagonal[i] == 0.0)
					{
						return false;
					}
				}
				return true;
			}
		}

		public Matrix H
		{
			get
			{
				Matrix matrix = new Matrix(qr.Rows, qr.Columns);
				for (int i = 0; i < qr.Rows; i++)
				{
					for (int j = 0; j < qr.Columns; j++)
					{
						if (i >= j)
						{
							matrix.SetValue(i, j, qr.GetValue(i, j));
						}
						else
						{
							matrix.SetValue(i, j, 0.0);
						}
					}
				}
				return matrix;
			}
		}

		public Matrix UpperTriangularMatrix
		{
			get
			{
				Matrix matrix = new Matrix(qr.Columns, qr.Columns);
				for (int i = 0; i < qr.Columns; i++)
				{
					for (int j = 0; j < qr.Columns; j++)
					{
						if (i < j)
						{
							matrix.SetValue(i, j, qr.GetValue(i, j));
						}
						else if (i == j)
						{
							matrix.SetValue(i, j, diagonal[i]);
						}
						else
						{
							matrix.SetValue(i, j, 0.0);
						}
					}
				}
				return matrix;
			}
		}

		public Matrix OrthogonalFactor
		{
			get
			{
				Matrix matrix = new Matrix(qr.Rows, qr.Columns);
				for (int num = qr.Columns - 1; num >= 0; num--)
				{
					for (int i = 0; i < qr.Rows; i++)
					{
						matrix.SetValue(i, num, 0.0);
					}
					matrix.SetValue(num, num, 1.0);
					for (int j = num; j < qr.Columns; j++)
					{
						if (qr.GetValue(num, num) != 0.0)
						{
							double num2 = 0.0;
							for (int k = num; k < qr.Rows; k++)
							{
								num2 += qr.GetValue(k, num) * matrix.GetValue(k, j);
							}
							num2 = (0.0 - num2) / qr.GetValue(num, num);
							for (int l = num; l < qr.Rows; l++)
							{
								matrix.SetValue(l, j, matrix.GetValue(l, j) + num2 * qr.GetValue(l, num));
							}
						}
					}
				}
				return matrix;
			}
		}

		public Matrix LeftFactorMatrix
		{
			get
			{
				return OrthogonalFactor;
			}
		}

		public Matrix RightFactorMatrix
		{
			get
			{
				return UpperTriangularMatrix;
			}
		}

		public QRDecomposition(Matrix matrix)
		{
			Guard.ArgumentNotNull(matrix, "matrix");
			Decompose(matrix);
		}

		public void Decompose(Matrix matrix)
		{
			qr = matrix.Clone();
			diagonal = new double[qr.Columns];
			for (int i = 0; i < qr.Columns; i++)
			{
				double num = 0.0;
				for (int j = i; j < qr.Rows; j++)
				{
					num = MathAlgorithms.Hypotenuse(num, qr[j, i]);
				}
				if (num != 0.0)
				{
					if (qr.GetValue(i, i) < 0.0)
					{
						num = 0.0 - num;
					}
					for (int k = i; k < qr.Rows; k++)
					{
						qr.SetValue(k, i, qr.GetValue(k, i) / num);
					}
					qr.SetValue(i, i, qr.GetValue(i, i) + 1.0);
					for (int l = i + 1; l < qr.Columns; l++)
					{
						double num2 = 0.0;
						for (int m = i; m < qr.Rows; m++)
						{
							num2 += qr.GetValue(m, i) * qr.GetValue(m, l);
						}
						num2 = (0.0 - num2) / qr.GetValue(i, i);
						for (int n = i; n < qr.Rows; n++)
						{
							qr.SetValue(n, l, qr.GetValue(n, l) + num2 * qr.GetValue(n, i));
						}
					}
				}
				diagonal[i] = 0.0 - num;
			}
		}

		public Matrix Solve(Matrix right)
		{
			Guard.ArgumentNotNull(right, "right");
			Matrix.ValidateEqualRows(right, qr);
			if (!IsFullRank)
			{
				throw new ArgumentException("Matrix is rank deficient.");
			}
			int columns = right.Columns;
			Matrix matrix = right.Clone();
			for (int i = 0; i < qr.Columns; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					double num = 0.0;
					for (int k = i; k < qr.Rows; k++)
					{
						num += qr.GetValue(k, i) * matrix.GetValue(k, j);
					}
					num = (0.0 - num) / qr.GetValue(i, i);
					for (int l = i; l < qr.Rows; l++)
					{
						matrix.SetValue(l, j, matrix.GetValue(l, j) + num * qr.GetValue(l, i));
					}
				}
			}
			for (int num2 = qr.Columns - 1; num2 >= 0; num2--)
			{
				for (int m = 0; m < columns; m++)
				{
					matrix.SetValue(num2, m, matrix.GetValue(num2, m) / diagonal[num2]);
				}
				for (int n = 0; n < num2; n++)
				{
					for (int num3 = 0; num3 < columns; num3++)
					{
						matrix.SetValue(n, num3, matrix.GetValue(n, num3) - matrix.GetValue(num2, num3) * qr.GetValue(n, num2));
					}
				}
			}
			return matrix.GetSubMatrix(0, 0, qr.Columns, columns);
		}
	}
}
