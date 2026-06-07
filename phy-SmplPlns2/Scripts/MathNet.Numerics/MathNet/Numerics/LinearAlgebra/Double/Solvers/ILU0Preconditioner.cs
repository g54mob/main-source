using System;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Double.Solvers
{
	public sealed class ILU0Preconditioner : IPreconditioner<double>
	{
		private SparseMatrix _decompositionLU;

		internal Matrix<double> UpperTriangle()
		{
			SparseMatrix sparseMatrix = new SparseMatrix(_decompositionLU.RowCount);
			for (int i = 0; i < _decompositionLU.RowCount; i++)
			{
				for (int j = i; j < _decompositionLU.ColumnCount; j++)
				{
					sparseMatrix[i, j] = _decompositionLU[i, j];
				}
			}
			return sparseMatrix;
		}

		internal Matrix<double> LowerTriangle()
		{
			SparseMatrix sparseMatrix = new SparseMatrix(_decompositionLU.RowCount);
			for (int i = 0; i < _decompositionLU.RowCount; i++)
			{
				for (int j = 0; j <= i; j++)
				{
					if (i == j)
					{
						sparseMatrix[i, j] = 1.0;
					}
					else
					{
						sparseMatrix[i, j] = _decompositionLU[i, j];
					}
				}
			}
			return sparseMatrix;
		}

		public void Initialize(Matrix<double> matrix)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException("matrix");
			}
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			_decompositionLU = SparseMatrix.OfMatrix(matrix);
			for (int i = 0; i < _decompositionLU.RowCount; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (_decompositionLU[i, j] == 0.0)
					{
						continue;
					}
					double num = _decompositionLU[i, j] / _decompositionLU[j, j];
					_decompositionLU[i, j] = num;
					if (_decompositionLU[j, i] != 0.0)
					{
						_decompositionLU[i, i] -= num * _decompositionLU[j, i];
					}
					for (int k = j + 1; k < _decompositionLU.RowCount; k++)
					{
						if (k != i && _decompositionLU[i, k] != 0.0)
						{
							_decompositionLU[i, k] -= num * _decompositionLU[j, k];
						}
					}
				}
			}
		}

		public void Approximate(Vector<double> rhs, Vector<double> lhs)
		{
			if (_decompositionLU == null)
			{
				throw new ArgumentException("The requested matrix does not exist.");
			}
			if (lhs.Count != rhs.Count || lhs.Count != _decompositionLU.RowCount)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			DenseVector denseVector = new DenseVector(_decompositionLU.RowCount);
			for (int i = 0; i < _decompositionLU.RowCount; i++)
			{
				denseVector.Clear();
				_decompositionLU.Row(i, denseVector);
				double num = 0.0;
				for (int j = 0; j < i; j++)
				{
					num += denseVector[j] * lhs[j];
				}
				lhs[i] = rhs[i] - num;
			}
			for (int num2 = _decompositionLU.RowCount - 1; num2 > -1; num2--)
			{
				_decompositionLU.Row(num2, denseVector);
				double num3 = 0.0;
				for (int num4 = _decompositionLU.RowCount - 1; num4 > num2; num4--)
				{
					num3 += denseVector[num4] * lhs[num4];
				}
				lhs[num2] = 1.0 / denseVector[num2] * (lhs[num2] - num3);
			}
		}
	}
}
