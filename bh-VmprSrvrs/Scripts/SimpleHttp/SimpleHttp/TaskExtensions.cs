using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SimpleHttp
{
	public static class TaskExtensions
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CWithTimeout_003Ed__0<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

			public Task<T> task;

			public int timeoutInMs;

			public string description;

			private TaskAwaiter<Task> _003C_003Eu__1;

			private TaskAwaiter<T> _003C_003Eu__2;

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
		private struct _003CWithTimeout_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public Task task;

			public int timeoutInMs;

			public string description;

			private TaskAwaiter<Task> _003C_003Eu__1;

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

		[AsyncStateMachine(typeof(_003CWithTimeout_003Ed__0<>))]
		public static Task<T> WithTimeout<T>(this Task<T> task, int timeoutInMs, string description = "")
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CWithTimeout_003Ed__1))]
		public static Task WithTimeout(this Task task, int timeoutInMs, string description = "")
		{
			return null;
		}
	}
}
