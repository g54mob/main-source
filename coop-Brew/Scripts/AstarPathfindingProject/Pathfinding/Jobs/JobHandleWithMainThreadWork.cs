using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Jobs;

namespace Pathfinding.Jobs
{
	public struct JobHandleWithMainThreadWork<T> where T : struct
	{
		[CompilerGenerated]
		private sealed class _003CCompleteTimeSliced_003Ed__4 : IEnumerable<T?>, IEnumerable, IEnumerator<T?>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T? _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public JobHandleWithMainThreadWork<T> _003C_003E4__this;

			public JobHandleWithMainThreadWork<T> _003C_003E3___003C_003E4__this;

			private float maxMillisPerStep;

			public float _003C_003E3__maxMillisPerStep;

			T? IEnumerator<T?>.Current
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
			public _003CCompleteTimeSliced_003Ed__4(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<T?> IEnumerable<T?>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private JobDependencyTracker tracker;

		private IEnumerator<(JobHandle, T)> coroutine;

		public JobHandleWithMainThreadWork(IEnumerator<(JobHandle, T)> handles, JobDependencyTracker tracker)
		{
			this.tracker = null;
			coroutine = null;
		}

		public void Complete()
		{
		}

		[IteratorStateMachine(typeof(JobHandleWithMainThreadWork<>._003CCompleteTimeSliced_003Ed__4))]
		public IEnumerable<T?> CompleteTimeSliced(float maxMillisPerStep)
		{
			return null;
		}
	}
}
