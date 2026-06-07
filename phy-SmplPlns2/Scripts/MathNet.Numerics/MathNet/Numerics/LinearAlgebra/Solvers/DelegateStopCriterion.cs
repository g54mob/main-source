using System;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public class DelegateStopCriterion<T> : IIterationStopCriterion<T> where T : struct, IEquatable<T>, IFormattable
	{
		private readonly Func<int, Vector<T>, Vector<T>, Vector<T>, IterationStatus> _determine;

		private IterationStatus _status;

		public IterationStatus Status => _status;

		public DelegateStopCriterion(Func<int, Vector<T>, Vector<T>, Vector<T>, IterationStatus> determine)
		{
			_determine = determine;
		}

		public IterationStatus DetermineStatus(int iterationNumber, Vector<T> solutionVector, Vector<T> sourceVector, Vector<T> residualVector)
		{
			return _status = _determine(iterationNumber, solutionVector, sourceVector, residualVector);
		}

		public void Reset()
		{
			_status = IterationStatus.Continue;
		}

		public IIterationStopCriterion<T> Clone()
		{
			return new DelegateStopCriterion<T>(_determine);
		}
	}
}
