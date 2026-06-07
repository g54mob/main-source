using System;

namespace MathNet.Numerics.LinearAlgebra.Factorization
{
	public abstract class Cholesky<T> : ISolver<T> where T : struct, IEquatable<T>, IFormattable
	{
		public Matrix<T> Factor { get; }

		public abstract T Determinant { get; }

		public abstract T DeterminantLn { get; }

		protected Cholesky(Matrix<T> factor)
		{
			Factor = factor;
		}

		public abstract void Factorize(Matrix<T> matrix);

		public virtual Matrix<T> Solve(Matrix<T> input)
		{
			Matrix<T> result = Matrix<T>.Build.SameAs(input, input.RowCount, input.ColumnCount, fullyMutable: true);
			Solve(input, result);
			return result;
		}

		public abstract void Solve(Matrix<T> input, Matrix<T> result);

		public virtual Vector<T> Solve(Vector<T> input)
		{
			Vector<T> result = Vector<T>.Build.SameAs(input, input.Count);
			Solve(input, result);
			return result;
		}

		public abstract void Solve(Vector<T> input, Vector<T> result);
	}
}
