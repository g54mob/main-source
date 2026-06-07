using System;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public interface IIterationStopCriterion<T> where T : struct, IEquatable<T>, IFormattable
	{
		IterationStatus Status { get; }

		IterationStatus DetermineStatus(int iterationNumber, Vector<T> solutionVector, Vector<T> sourceVector, Vector<T> residualVector);

		void Reset();

		IIterationStopCriterion<T> Clone();
	}
}
