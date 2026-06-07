using System;

namespace MathNet.Numerics.LinearAlgebra.Factorization
{
	public abstract class LU<T> : ISolver<T> where T : struct, IEquatable<T>, IFormattable
	{
		private static readonly T One = BuilderInstance<T>.Matrix.One;

		private readonly Lazy<Matrix<T>> _lazyL;

		private readonly Lazy<Matrix<T>> _lazyU;

		private readonly Lazy<Permutation> _lazyP;

		protected readonly Matrix<T> Factors;

		protected readonly int[] Pivots;

		public Matrix<T> L => _lazyL.Value;

		public Matrix<T> U => _lazyU.Value;

		public Permutation P => _lazyP.Value;

		public abstract T Determinant { get; }

		protected LU(Matrix<T> factors, int[] pivots)
		{
			Factors = factors;
			Pivots = pivots;
			_lazyL = new Lazy<Matrix<T>>(ComputeL);
			_lazyU = new Lazy<Matrix<T>>(Factors.UpperTriangle);
			_lazyP = new Lazy<Permutation>(() => Permutation.FromInversions(Pivots));
		}

		private Matrix<T> ComputeL()
		{
			Matrix<T> matrix = Factors.LowerTriangle();
			for (int i = 0; i < matrix.RowCount; i++)
			{
				matrix.At(i, i, One);
			}
			return matrix;
		}

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

		public abstract Matrix<T> Inverse();
	}
}
