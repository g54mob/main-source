using System;
using System.Numerics;

namespace MathNet.Numerics.LinearAlgebra.Factorization
{
	public abstract class Evd<T> : ISolver<T> where T : struct, IEquatable<T>, IFormattable
	{
		public bool IsSymmetric { get; }

		public abstract T Determinant { get; }

		public abstract int Rank { get; }

		public abstract bool IsFullRank { get; }

		public Vector<System.Numerics.Complex> EigenValues { get; }

		public Matrix<T> EigenVectors { get; }

		public Matrix<T> D { get; }

		protected Evd(Matrix<T> eigenVectors, Vector<System.Numerics.Complex> eigenValues, Matrix<T> blockDiagonal, bool isSymmetric)
		{
			EigenVectors = eigenVectors;
			EigenValues = eigenValues;
			D = blockDiagonal;
			IsSymmetric = isSymmetric;
		}

		public virtual Matrix<T> Solve(Matrix<T> input)
		{
			Matrix<T> result = Matrix<T>.Build.SameAs(EigenVectors, EigenVectors.ColumnCount, input.ColumnCount, fullyMutable: true);
			Solve(input, result);
			return result;
		}

		public abstract void Solve(Matrix<T> input, Matrix<T> result);

		public virtual Vector<T> Solve(Vector<T> input)
		{
			Vector<T> result = Vector<T>.Build.SameAs(EigenVectors, EigenVectors.ColumnCount);
			Solve(input, result);
			return result;
		}

		public abstract void Solve(Vector<T> input, Vector<T> result);
	}
}
