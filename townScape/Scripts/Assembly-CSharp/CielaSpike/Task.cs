using System;
using System.Collections;

namespace CielaSpike
{
	public class Task : IEnumerator
	{
		private enum RunningState
		{
			Init = 0,
			RunningAsync = 1,
			PendingYield = 2,
			ToBackground = 3,
			RunningSync = 4,
			CancellationRequested = 5,
			Done = 6,
			Error = 7
		}

		private readonly IEnumerator _innerRoutine;

		private RunningState _state;

		private RunningState _previousState;

		private object _pendingCurrent;

		public object Current { get; private set; }

		public TaskState State => default(TaskState);

		public Exception Exception { get; private set; }

		public bool MoveNext()
		{
			return false;
		}

		public void Reset()
		{
		}

		public Task(IEnumerator routine)
		{
		}

		public void Cancel()
		{
		}

		public IEnumerator Wait()
		{
			return null;
		}

		private void GotoState(RunningState state)
		{
		}

		private void SetPendingCurrentObject(object current)
		{
		}

		private bool OnMoveNext()
		{
			return false;
		}

		private void MoveNextAsync()
		{
		}

		private void BackgroundRunner(object state)
		{
		}

		private void MoveNextUnity()
		{
		}
	}
}
