using System;
using System.Diagnostics;
using System.Threading;

namespace MathNet.Numerics.LinearAlgebra.Solvers
{
	public sealed class CancellationStopCriterion<T> : IIterationStopCriterion<T> where T : struct, IEquatable<T>, IFormattable
	{
		private readonly CancellationToken _masterToken;

		private CancellationTokenSource _currentTcs;

		public IterationStatus Status
		{
			[DebuggerStepThrough]
			get
			{
				if (!_currentTcs.Token.IsCancellationRequested)
				{
					return IterationStatus.Continue;
				}
				return IterationStatus.Cancelled;
			}
		}

		public CancellationStopCriterion()
		{
			_masterToken = CancellationToken.None;
			_currentTcs = CancellationTokenSource.CreateLinkedTokenSource(CancellationToken.None);
		}

		public CancellationStopCriterion(CancellationToken masterToken)
		{
			_masterToken = masterToken;
			_currentTcs = CancellationTokenSource.CreateLinkedTokenSource(masterToken);
		}

		public IterationStatus DetermineStatus(int iterationNumber, Vector<T> solutionVector, Vector<T> sourceVector, Vector<T> residualVector)
		{
			if (!_currentTcs.Token.IsCancellationRequested)
			{
				return IterationStatus.Continue;
			}
			return IterationStatus.Cancelled;
		}

		public void Cancel()
		{
			_currentTcs.Cancel();
		}

		public void Reset()
		{
			_currentTcs = CancellationTokenSource.CreateLinkedTokenSource(_masterToken);
		}

		public IIterationStopCriterion<T> Clone()
		{
			return new CancellationStopCriterion<T>(_masterToken);
		}
	}
}
