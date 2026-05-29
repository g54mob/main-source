using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ParadoxNotion.Services
{
	public static class Threader
	{
		[CompilerGenerated]
		private sealed class _003CThreadMonitor_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Thread thread;

			public Action callback;

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
			public _003CThreadMonitor_003Ed__10(int _003C_003E1__state)
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

		public static bool applicationIsPlaying { get; private set; }

		public static bool isMainThread => false;

		static Threader()
		{
		}

		public static Thread StartAction(Thread thread, Action function, Action callback = null)
		{
			return null;
		}

		public static Thread StartFunction<TResult>(Thread thread, Func<TResult> function, Action<TResult> callback = null)
		{
			return null;
		}

		private static void Begin(Thread thread, Action callback)
		{
		}

		[IteratorStateMachine(typeof(_003CThreadMonitor_003Ed__10))]
		private static IEnumerator ThreadMonitor(Thread thread, Action callback)
		{
			return null;
		}
	}
}
