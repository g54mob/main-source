using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex.Solvers
{
	public sealed class ILU0Preconditioner : IPreconditioner<System.Numerics.Complex>
	{
		private SparseMatrix _decompositionLU;

		internal Matrix<System.Numerics.Complex> UpperTriangle()
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

		internal Matrix<System.Numerics.Complex> LowerTriangle()
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

		public void Initialize(Matrix<System.Numerics.Complex> matrix)
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
					if (!(_decompositionLU[i, j] != 0.0))
					{
						continue;
					}
					System.Numerics.Complex complex = _decompositionLU[i, j] / _decompositionLU[j, j];
					_decompositionLU[i, j] = complex;
					if (_decompositionLU[j, i] != 0.0)
					{
						_decompositionLU[i, i] -= complex * _decompositionLU[j, i];
					}
					for (int k = j + 1; k < _decompositionLU.RowCount; k++)
					{
						if (k != i && _decompositionLU[i, k] != 0.0)
						{
							_decompositionLU[i, k] -= complex * _decompositionLU[j, k];
						}
					}
				}
			}
		}

		public void Approximate(Vector<System.Numerics.Complex> rhs, Vector<System.Numerics.Complex> lhs)
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
				System.Numerics.Complex zero = System.Numerics.Complex.Zero;
				for (int j = 0; j < i; j++)
				{
					zero += denseVector[j] * lhs[j];
				}
				lhs[i] = rhs[i] - zero;
			}
			for (int num = _decompositionLU.RowCount - 1; num > -1; num--)
			{
				_decompositionLU.Row(num, denseVector);
				System.Numerics.Complex zero2 = System.Numerics.Complex.Zero;
				for (int num2 = _decompositionLU.RowCount - 1; num2 > num; num2--)
				{
					zero2 += denseVector[num2] * lhs[num2];
				}
				lhs[num] = 1 / denseVector[num] * (lhs[num] - zero2);
			}
		}
	}
}
