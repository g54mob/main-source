using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Pathfinding.Util
{
	public class ParallelWorkQueue<T>
	{
		[CompilerGenerated]
		private sealed class _003CRun_003Ed__7 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private int _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public ParallelWorkQueue<T> _003C_003E4__this;

			private int progressTimeoutMillis;

			public int _003C_003E3__progressTimeoutMillis;

			int IEnumerator<int>.Current
			{
				[DebuggerHidden]
				get
				{
					return 0;
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
			public _003CRun_003Ed__7(int _003C_003E1__state)
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
			IEnumerator<int> IEnumerable<int>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public Action<T, int> action;

		public readonly int threadCount;

		private readonly Queue<T> queue;

		private readonly int initialCount;

		private ManualResetEvent[] waitEvents;

		private Exception innerException;

		public ParallelWorkQueue(Queue<T> queue)
		{
		}

		[IteratorStateMachine(typeof(ParallelWorkQueue<>._003CRun_003Ed__7))]
		public IEnumerable<int> Run(int progressTimeoutMillis)
		{
			return null;
		}

		private void RunTask(int threadIndex)
		{
		}
	}
}
