using System;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public sealed class UnitPreconditioner<T> : IPreconditioner<T> where T : struct, IEquatable<T>, IFormattable
	{
		private int _size;

		public void Initialize(Matrix<T> matrix)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			_size = matrix.RowCount;
		}

		public void Approximate(Vector<T> rhs, Vector<T> lhs)
		{
			if (lhs.Count != rhs.Count || lhs.Count != _size)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			rhs.CopyTo(lhs);
		}
	}
}
