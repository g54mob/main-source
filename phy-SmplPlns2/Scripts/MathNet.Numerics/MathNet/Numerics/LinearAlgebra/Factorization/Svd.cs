using System;

namespace MathNet.Numerics.LinearAlgebra.Factorization
{
	public abstract class Svd<T> : ISolver<T> where T : struct, IEquatable<T>, IFormattable
	{
		private readonly Lazy<Matrix<T>> _lazyW;

		protected readonly bool VectorsComputed;

		public Vector<T> S { get; }

		public Matrix<T> U { get; }

		public Matrix<T> VT { get; }

		public Matrix<T> W => _lazyW.Value;

		public abstract int Rank { get; }

		public abstract double L2Norm { get; }

		public abstract T ConditionNumber { get; }

		public abstract T Determinant { get; }

		protected Svd(Vector<T> s, Matrix<T> u, Matrix<T> vt, bool vectorsComputed)
		{
			S = s;
			U = u;
			VT = vt;
			VectorsComputed = vectorsComputed;
			_lazyW = new Lazy<Matrix<T>>(ComputeW);
		}

		private Matrix<T> ComputeW()
		{
			int rowCount = U.RowCount;
			int columnCount = VT.ColumnCount;
			Matrix<T> matrix = Matrix<T>.Build.SameAs(U, rowCount, columnCount);
			for (int i = 0; i < rowCount; i++)
			{
				for (int j = 0; j < columnCount; j++)
				{
					if (i == j)
					{
						matrix.At(i, i, S[i]);
					}
				}
			}
			return matrix;
		}

		public virtual Matrix<T> Solve(Matrix<T> input)
		{
			if (!VectorsComputed)
			{
				throw new InvalidOperationException("The singular vectors were not computed.");
			}
			Matrix<T> result = Matrix<T>.Build.SameAs(U, VT.ColumnCount, input.ColumnCount, fullyMutable: true);
			Solve(input, result);
			return result;
		}

		public abstract void Solve(Matrix<T> input, Matrix<T> result);

		public virtual Vector<T> Solve(Vector<T> input)
		{
			if (!VectorsComputed)
			{
				throw new InvalidOperationException("The singular vectors were not computed.");
			}
			Vector<T> result = Vector<T>.Build.SameAs(U, VT.ColumnCount);
			Solve(input, result);
			return result;
		}

		public abstract void Solve(Vector<T> input, Vector<T> result);
	}
}
