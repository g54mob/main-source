using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace VampireSurvivors.Tools
{
	public static class VSUtils
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRestartAppWithFrameDelay_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			private SwitchToMainThreadAwaitable.Awaiter _003C_003Eu__1;

			private Cysharp.Threading.Tasks.YieldAwaitable.Awaiter _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		private sealed class _003CRestartAppWithFrameDelayRoutine_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CRestartAppWithFrameDelayRoutine_003Ed__4(int _003C_003E1__state)
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

		public static bool IsEditor()
		{
			return false;
		}

		public static string FormatTime(float seconds)
		{
			return null;
		}

		public static void RestartApp()
		{
		}

		public static void RestartAppWithFrameDelayCoroutine()
		{
		}

		[IteratorStateMachine(typeof(_003CRestartAppWithFrameDelayRoutine_003Ed__4))]
		private static IEnumerator RestartAppWithFrameDelayRoutine()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRestartAppWithFrameDelay_003Ed__5))]
		public static UniTaskVoid RestartAppWithFrameDelay()
		{
			return default(UniTaskVoid);
		}
	}
}
