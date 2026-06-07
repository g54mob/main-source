using System;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public interface IPreconditioner<T> where T : struct, IEquatable<T>, IFormattable
	{
		void Initialize(Matrix<T> matrix);

		void Approximate(Vector<T> rhs, Vector<T> lhs);
	}
}
