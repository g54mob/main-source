using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace VampireSurvivors.Framework.Loading
{
	public class AsyncLoader
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCleanup_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public AsyncLoader _003C_003E4__this;

			private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

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

		private readonly List<Action<Action>> _loadCalls;

		private int _remainingLoadCalls;

		private Action _onComplete;

		public AsyncLoader(Action onComplete)
		{
		}

		private void OnLoad()
		{
		}

		[AsyncStateMachine(typeof(_003CCleanup_003Ed__5))]
		private void Cleanup()
		{
		}

		public void Add(Action<Action> loadCall)
		{
		}

		public void Load()
		{
		}
	}
}
