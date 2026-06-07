using System;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public interface IIterativeSolverSetup<T> where T : struct, IEquatable<T>, IFormattable
	{
		Type SolverType { get; }

		Type PreconditionerType { get; }

		double SolutionSpeed { get; }

		double Reliability { get; }

		IIterativeSolver<T> CreateSolver();

		IPreconditioner<T> CreatePreconditioner();
	}
}
