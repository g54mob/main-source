using System;
using System.Diagnostics;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public sealed class IterationCountStopCriterion<T> : IIterationStopCriterion<T> where T : struct, IEquatable<T>, IFormattable
	{
		public const int DefaultMaximumNumberOfIterations = 1000;

		private int _maximumNumberOfIterations;

		private IterationStatus _status;

		public int MaximumNumberOfIterations
		{
			[DebuggerStepThrough]
			get
			{
				return _maximumNumberOfIterations;
			}
			[DebuggerStepThrough]
			set
			{
				if (value < 1)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_maximumNumberOfIterations = value;
			}
		}

		public IterationStatus Status
		{
			[DebuggerStepThrough]
			get
			{
				return _status;
			}
		}

		public IterationCountStopCriterion()
			: this(1000)
		{
		}

		public IterationCountStopCriterion(int maximumNumberOfIterations)
		{
			if (maximumNumberOfIterations < 1)
			{
				throw new ArgumentOutOfRangeException("maximumNumberOfIterations");
			}
			_maximumNumberOfIterations = maximumNumberOfIterations;
		}

		public void ResetMaximumNumberOfIterationsToDefault()
		{
			_maximumNumberOfIterations = 1000;
		}

		public IterationStatus DetermineStatus(int iterationNumber, Vector<T> solutionVector, Vector<T> sourceVector, Vector<T> residualVector)
		{
			if (iterationNumber < 0)
			{
				throw new ArgumentOutOfRangeException("iterationNumber");
			}
			_status = ((iterationNumber >= _maximumNumberOfIterations) ? IterationStatus.StoppedWithoutConvergence : IterationStatus.Continue);
			return _status;
		}

		public void Reset()
		{
			_status = IterationStatus.Continue;
		}

		public IIterationStopCriterion<T> Clone()
		{
			return new IterationCountStopCriterion<T>(_maximumNumberOfIterations);
		}
	}
}
