using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ModIO.Implementation
{
	internal class OpenCallbacks
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRun_003Ed__3<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<T> _003C_003Et__builder;

			public OpenCallbacks _003C_003E4__this;

			public TaskCompletionSource<bool> tcs;

			public Task<T> task;

			private TaskAwaiter<T> _003C_003Eu__1;

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
		private struct _003CShutDown_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public OpenCallbacks _003C_003E4__this;

			private Dictionary<TaskCompletionSource<bool>, Task>.Enumerator _003Cenumerator_003E5__2;

			private TaskAwaiter<bool> _003C_003Eu__1;

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

		private Dictionary<TaskCompletionSource<bool>, Task> openCallbacks;

		public TaskCompletionSource<bool> New()
		{
			return null;
		}

		public TaskCompletionSource<bool> New(Task task)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CRun_003Ed__3<>))]
		public Task<T> Run<T>(TaskCompletionSource<bool> tcs, Task<T> task)
		{
			return null;
		}

		public void Remove(TaskCompletionSource<bool> tcs)
		{
		}

		public void Complete(TaskCompletionSource<bool> tcs)
		{
		}

		public void Clear(TaskCompletionSource<bool> tcs)
		{
		}

		public void CancelAll()
		{
		}

		[AsyncStateMachine(typeof(_003CShutDown_003Ed__8))]
		public Task ShutDown()
		{
			return null;
		}
	}
}
