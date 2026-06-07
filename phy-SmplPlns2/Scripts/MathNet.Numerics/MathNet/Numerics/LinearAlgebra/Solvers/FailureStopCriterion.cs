using System;
using System.Diagnostics;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public sealed class FailureStopCriterion<T> : IIterationStopCriterion<T> where T : struct, IEquatable<T>, IFormattable
	{
		private IterationStatus _status;

		private int _lastIteration = -1;

		public IterationStatus Status
		{
			[DebuggerStepThrough]
			get
			{
				return _status;
			}
		}

		public IterationStatus DetermineStatus(int iterationNumber, Vector<T> solutionVector, Vector<T> sourceVector, Vector<T> residualVector)
		{
			if (iterationNumber < 0)
			{
				throw new ArgumentOutOfRangeException("iterationNumber");
			}
			if (solutionVector.Count != residualVector.Count)
			{
				throw new ArgumentException("The array arguments must have the same length.");
			}
			if (_lastIteration >= iterationNumber)
			{
				return _status;
			}
			double d = residualVector.InfinityNorm();
			double d2 = solutionVector.InfinityNorm();
			_status = ((double.IsNaN(d2) || double.IsNaN(d)) ? IterationStatus.Failure : IterationStatus.Continue);
			_lastIteration = iterationNumber;
			return _status;
		}

		public void Reset()
		{
			_status = IterationStatus.Continue;
			_lastIteration = -1;
		}

		public IIterationStopCriterion<T> Clone()
		{
			return new FailureStopCriterion<T>();
		}
	}
}
