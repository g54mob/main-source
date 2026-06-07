using System;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Solvers
{
	public sealed class DiagonalPreconditioner : IPreconditioner<MathNet.Numerics.Complex32>
	{
		private MathNet.Numerics.Complex32[] _inverseDiagonals;

		internal DiagonalMatrix DiagonalEntries()
		{
			DiagonalMatrix diagonalMatrix = new DiagonalMatrix(_inverseDiagonals.Length);
			for (int i = 0; i < _inverseDiagonals.Length; i++)
			{
				diagonalMatrix[i, i] = 1f / _inverseDiagonals[i];
			}
			return diagonalMatrix;
		}

		public void Initialize(Matrix<MathNet.Numerics.Complex32> matrix)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			_inverseDiagonals = new MathNet.Numerics.Complex32[matrix.RowCount];
			for (int i = 0; i < matrix.RowCount; i++)
			{
				_inverseDiagonals[i] = 1f / matrix[i, i];
			}
		}

		public void Approximate(Vector<MathNet.Numerics.Complex32> rhs, Vector<MathNet.Numerics.Complex32> lhs)
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
