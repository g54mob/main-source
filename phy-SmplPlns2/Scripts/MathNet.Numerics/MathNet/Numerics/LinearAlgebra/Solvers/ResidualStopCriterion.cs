using System;
using System.Diagnostics;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public sealed class ResidualStopCriterion<T> : IIterationStopCriterion<T> where T : struct, IEquatable<T>, IFormattable
	{
		private double _maximum;

		private int _minimumIterationsBelowMaximum;

		private IterationStatus _status;

		private int _iterationCount;

		private int _lastIteration = -1;

		public double Maximum
		{
			[DebuggerStepThrough]
			get
			{
				return _maximum;
			}
			[DebuggerStepThrough]
			set
			{
				if (value < 0.0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_maximum = value;
			}
		}

		public int MinimumIterationsBelowMaximum
		{
			[DebuggerStepThrough]
			get
			{
				return _minimumIterationsBelowMaximum;
			}
			[DebuggerStepThrough]
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_minimumIterationsBelowMaximum = value;
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

		public ResidualStopCriterion(double maximum, int minimumIterationsBelowMaximum = 0)
		{
			if (maximum < 0.0)
			{
				throw new ArgumentOutOfRangeException("maximum");
			}
			if (minimumIterationsBelowMaximum < 0)
			{
				throw new ArgumentOutOfRangeException("minimumIterationsBelowMaximum");
			}
			_maximum = maximum;
			_minimumIterationsBelowMaximum = minimumIterationsBelowMaximum;
		}

		public IterationStatus DetermineStatus(int iterationNumber, Vector<T> solutionVector, Vector<T> sourceVector, Vector<T> residualVector)
		{
			if (iterationNumber < 0)
			{
				throw new ArgumentOutOfRangeException("iterationNumber");
			}
			if (solutionVector.Count != sourceVector.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "sourceVector");
			}
			if (solutionVector.Count != residualVector.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "residualVector");
			}
			double num = residualVector.InfinityNorm();
			double num2 = _maximum * sourceVector.InfinityNorm();
			if (double.IsNaN(num2) || double.IsNaN(num))
			{
				_iterationCount = 0;
				_status = IterationStatus.Diverged;
				return _status;
			}
			if (num <= num2)
			{
				if (_lastIteration <= iterationNumber)
				{
					_iterationCount = iterationNumber - _lastIteration;
					_status = ((_iterationCount >= _minimumIterationsBelowMaximum) ? IterationStatus.Converged : IterationStatus.Continue);
				}
			}
			else
			{
				_iterationCount = 0;
				_status = IterationStatus.Continue;
			}
			_lastIteration = iterationNumber;
			return _status;
		}

		public void Reset()
		{
			_status = IterationStatus.Continue;
			_iterationCount = 0;
			_lastIteration = -1;
		}

		public IIterationStopCriterion<T> Clone()
		{
			return new ResidualStopCriterion<T>(_maximum, _minimumIterationsBelowMaximum);
		}
	}
}
