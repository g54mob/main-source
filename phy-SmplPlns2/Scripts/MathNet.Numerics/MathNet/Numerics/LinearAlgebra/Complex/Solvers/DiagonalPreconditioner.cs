using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex.Solvers
{
	public sealed class DiagonalPreconditioner : IPreconditioner<System.Numerics.Complex>
	{
		private System.Numerics.Complex[] _inverseDiagonals;

		internal DiagonalMatrix DiagonalEntries()
		{
			DiagonalMatrix diagonalMatrix = new DiagonalMatrix(_inverseDiagonals.Length);
			for (int i = 0; i < _inverseDiagonals.Length; i++)
			{
				diagonalMatrix.At(i, i, 1 / _inverseDiagonals[i]);
			}
			return diagonalMatrix;
		}

		public void Initialize(Matrix<System.Numerics.Complex> matrix)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			_inverseDiagonals = new System.Numerics.Complex[matrix.RowCount];
			for (int i = 0; i < matrix.RowCount; i++)
			{
				_inverseDiagonals[i] = 1 / matrix.At(i, i);
			}
		}

		public void Approximate(Vector<System.Numerics.Complex> rhs, Vector<System.Numerics.Complex> lhs)
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
