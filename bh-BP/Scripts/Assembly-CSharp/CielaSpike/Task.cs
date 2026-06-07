using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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

		[CompilerGenerated]
		private sealed class _003CWait_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Task _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWait_003Ed__19(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
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

		[IteratorStateMachine(typeof(_003CWait_003Ed__19))]
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
