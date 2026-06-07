using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Coherence.Cloud;

namespace VampireSurvivors
{
	public static class CoherenceLoginModule
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLeaveExistingLobbies_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public LoginOperation loginResponse;

			private IEnumerator<string> _003C_003E7__wrap1;

			private TaskAwaiter<LobbySession> _003C_003Eu__1;

			private TaskAwaiter<bool> _003C_003Eu__2;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003COnCompleteLogin_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public LoginOperation loginOperation;

			public Action<bool> onComplete;

			private TaskAwaiter _003C_003Eu__1;

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

		public static void Login(Action<bool> onComplete)
		{
		}

		[AsyncStateMachine(typeof(_003COnCompleteLogin_003Ed__1))]
		private static void OnCompleteLogin(LoginOperation loginOperation, Action<bool> onComplete)
		{
		}

		[AsyncStateMachine(typeof(_003CLeaveExistingLobbies_003Ed__2))]
		private static Task LeaveExistingLobbies(LoginOperation loginResponse)
		{
			return null;
		}
	}
}
