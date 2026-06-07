using System;
using System.Diagnostics;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public sealed class DivergenceStopCriterion<T> : IIterationStopCriterion<T> where T : struct, IEquatable<T>, IFormattable
	{
		private double _maximumRelativeIncrease;

		private int _minimumNumberOfIterations;

		private IterationStatus _status;

		private double[] _residualHistory;

		private int _lastIteration = -1;

		public double MaximumRelativeIncrease
		{
			[DebuggerStepThrough]
			get
			{
				return _maximumRelativeIncrease;
			}
			[DebuggerStepThrough]
			set
			{
				if (value <= 0.0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_maximumRelativeIncrease = value;
			}
		}

		public int MinimumNumberOfIterations
		{
			[DebuggerStepThrough]
			get
			{
				return _minimumNumberOfIterations;
			}
			[DebuggerStepThrough]
			set
			{
				if (value < 3)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_minimumNumberOfIterations = value;
			}
		}

		private int RequiredHistoryLength
		{
			[DebuggerStepThrough]
			get
			{
				return _minimumNumberOfIterations + 1;
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

		public DivergenceStopCriterion(double maximumRelativeIncrease = 0.08, int minimumIterations = 10)
		{
			if (maximumRelativeIncrease <= 0.0)
			{
				throw new ArgumentOutOfRangeException("maximumRelativeIncrease");
			}
			if (minimumIterations < 3)
			{
				throw new ArgumentOutOfRangeException("minimumIterations");
			}
			_maximumRelativeIncrease = maximumRelativeIncrease;
			_minimumNumberOfIterations = minimumIterations;
		}

		public IterationStatus DetermineStatus(int iterationNumber, Vector<T> solutionVector, Vector<T> sourceVector, Vector<T> residualVector)
		{
			if (iterationNumber < 0)
			{
				throw new ArgumentOutOfRangeException("iterationNumber");
			}
			if (_lastIteration >= iterationNumber)
			{
				return _status;
			}
			if (_residualHistory == null || _residualHistory.Length != RequiredHistoryLength)
			{
				_residualHistory = new double[RequiredHistoryLength];
			}
			for (int i = 1; i < _residualHistory.Length; i++)
			{
				_residualHistory[i - 1] = _residualHistory[i];
			}
			_residualHistory[_residualHistory.Length - 1] = residualVector.InfinityNorm();
			if (double.IsNaN(_residualHistory[_residualHistory.Length - 1]))
			{
				_status = IterationStatus.Diverged;
				return _status;
			}
			_status = (IsDiverging() ? IterationStatus.Diverged : IterationStatus.Continue);
			_lastIteration = iterationNumber;
			return _status;
		}

		private bool IsDiverging()
		{
			for (int i = 1; i < _residualHistory.Length; i++)
			{
				if (_residualHistory[i] - _residualHistory[i - 1] < 0.0 || _residualHistory[i - 1] * (1.0 + _maximumRelativeIncrease) >= _residualHistory[i])
				{
					return false;
				}
			}
			return true;
		}

		public void Reset()
		{
			_status = IterationStatus.Continue;
			_lastIteration = -1;
			_residualHistory = null;
		}

		public IIterationStopCriterion<T> Clone()
		{
			return new DivergenceStopCriterion<T>(_maximumRelativeIncrease, _minimumNumberOfIterations);
		}
	}
}
