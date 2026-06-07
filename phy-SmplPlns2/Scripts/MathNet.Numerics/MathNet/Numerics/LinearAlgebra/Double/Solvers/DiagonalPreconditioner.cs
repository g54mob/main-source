using System;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Double.Solvers
{
	public sealed class DiagonalPreconditioner : IPreconditioner<double>
	{
		private double[] _inverseDiagonals;

		internal DiagonalMatrix DiagonalEntries()
		{
			DiagonalMatrix diagonalMatrix = new DiagonalMatrix(_inverseDiagonals.Length);
			for (int i = 0; i < _inverseDiagonals.Length; i++)
			{
				diagonalMatrix[i, i] = 1.0 / _inverseDiagonals[i];
			}
			return diagonalMatrix;
		}

		public void Initialize(Matrix<double> matrix)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			_inverseDiagonals = new double[matrix.RowCount];
			for (int i = 0; i < matrix.RowCount; i++)
			{
				_inverseDiagonals[i] = 1.0 / matrix[i, i];
			}
		}

		public void Approximate(Vector<double> rhs, Vector<double> lhs)
		{
			if (_inverseDiagonals == null)
			{
				throw new ArgumentException("The requested matrix does not exist.");
			}
			if (lhs.Count != rhs.Count || lhs.Count != _inverseDiagonals.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "rhs");
			}
			for (int i = 0; i < _inverseDiagonals.Length; i++)
			{
				lhs[i] = rhs[i] * _inverseDiagonals[i];
			}
		}
	}
}
