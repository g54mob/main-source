using System;
using System.Collections.Generic;
using System.Linq;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public sealed class Iterator<T> where T : struct, IEquatable<T>, IFormattable
	{
		private readonly List<IIterationStopCriterion<T>> _stopCriteria;

		private IterationStatus _status;

		public IterationStatus Status => _status;

		public Iterator()
		{
			_stopCriteria = new List<IIterationStopCriterion<T>>(Matrix<T>.Build.IterativeSolverStopCriteria());
		}

		public Iterator(params IIterationStopCriterion<T>[] stopCriteria)
		{
			_stopCriteria = new List<IIterationStopCriterion<T>>(stopCriteria);
		}

		public Iterator(IEnumerable<IIterationStopCriterion<T>> stopCriteria)
		{
			_stopCriteria = new List<IIterationStopCriterion<T>>(stopCriteria);
		}

		public IterationStatus DetermineStatus(int iterationNumber, Vector<T> solutionVector, Vector<T> sourceVector, Vector<T> residualVector)
		{
			if (_stopCriteria.Count == 0)
			{
				throw new ArgumentException("There is no stop criterion in the collection.");
			}
			if (iterationNumber < 0)
			{
				throw new ArgumentOutOfRangeException("iterationNumber");
			}
			if (_status == IterationStatus.Cancelled)
			{
				return _status;
			}
			foreach (IIterationStopCriterion<T> stopCriterion in _stopCriteria)
			{
				IterationStatus iterationStatus = stopCriterion.DetermineStatus(iterationNumber, solutionVector, sourceVector, residualVector);
				if (iterationStatus != IterationStatus.Continue)
				{
					_status = iterationStatus;
					return _status;
				}
			}
			_status = IterationStatus.Continue;
			return _status;
		}

		public void Cancel()
		{
			_status = IterationStatus.Cancelled;
		}

		public void Reset()
		{
			_status = IterationStatus.Continue;
			foreach (IIterationStopCriterion<T> stopCriterion in _stopCriteria)
			{
				stopCriterion.Reset();
			}
		}

		public Iterator<T> Clone()
		{
			return new Iterator<T>(_stopCriteria.Select((IIterationStopCriterion<T> sc) => sc.Clone()));
		}
	}
}
