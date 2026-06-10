using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModIO.Implementation.Wss.Messages;
using ModIO.Implementation.Wss.Messages.Objects;

namespace ModIO.Implementation.Wss
{
	internal static class Wss
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBeginAuthenticationProcess_003Ed__0 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<ExternalAuthenticationToken>> _003C_003Et__builder;

			private TaskAwaiter<ResultAnd<WssDeviceLoginResponse>> _003C_003Eu__1;

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
		private struct _003CWaitForAccessToken_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<Result> _003C_003Et__builder;

			private Result _003Cresult_003E5__2;

			private TaskAwaiter<ResultAnd<WssMessage>> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

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

		[AsyncStateMachine(typeof(_003CBeginAuthenticationProcess_003Ed__0))]
		public static Task<ResultAnd<ExternalAuthenticationToken>> BeginAuthenticationProcess(bool restartProcess = false)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWaitForAccessToken_003Ed__1))]
		private static Task<Result> WaitForAccessToken()
		{
			return null;
		}
	}
}
