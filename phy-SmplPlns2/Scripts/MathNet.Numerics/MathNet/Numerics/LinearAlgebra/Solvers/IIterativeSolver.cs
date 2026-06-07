using System;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public interface IIterativeSolver<T> where T : struct, IEquatable<T>, IFormattable
	{
		void Solve(Matrix<T> matrix, Vector<T> input, Vector<T> result, Iterator<T> iterator, IPreconditioner<T> preconditioner);
	}
}
