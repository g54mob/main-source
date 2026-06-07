using System;

namespace MathNet.Numerics.LinearAlgebra.Factorization
{
	public interface ISolver<T> where T : struct, IEquatable<T>, IFormattable
	{
		Matrix<T> Solve(Matrix<T> input);

		void Solve(Matrix<T> input, Matrix<T> result);

		Vector<T> Solve(Vector<T> input);

		void Solve(Vector<T> input, Vector<T> result);
	}
}
