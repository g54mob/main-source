using System;

namespace MathNet.Numerics.LinearAlgebra.Factorization
{
	public abstract class QR<T> : ISolver<T> where T : struct, IEquatable<T>, IFormattable
	{
		private readonly Lazy<Matrix<T>> _lazyR;

		protected readonly Matrix<T> FullR;

		protected readonly QRMethod Method;

		public Matrix<T> Q { get; }

		public Matrix<T> R => _lazyR.Value;

		public abstract T Determinant { get; }

		public abstract bool IsFullRank { get; }

		protected QR(Matrix<T> q, Matrix<T> rFull, QRMethod method)
		{
			Q = q;
			FullR = rFull;
			Method = method;
			_lazyR = new Lazy<Matrix<T>>(FullR.UpperTriangle);
		}

		public virtual Matrix<T> Solve(Matrix<T> input)
		{
			Matrix<T> result = Matrix<T>.Build.SameAs(input, FullR.ColumnCount, input.ColumnCount, fullyMutable: true);
			Solve(input, result);
			return result;
		}

		public abstract void Solve(Matrix<T> input, Matrix<T> result);

		public virtual Vector<T> Solve(Vector<T> input)
		{
			Vector<T> result = Vector<T>.Build.SameAs(input, FullR.ColumnCount);
			Solve(input, result);
			return result;
		}

		public abstract void Solve(Vector<T> input, Vector<T> result);
	}
}
