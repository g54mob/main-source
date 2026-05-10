using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks
{
	public static class UniTaskValueTaskExtensions
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CAsUniTask_003Ed__2<T> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public ValueTask<T> task;

			private ValueTaskAwaiter<T> _003C_003Eu__1;

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
		private struct _003CAsUniTask_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public ValueTask task;

			private ValueTaskAwaiter _003C_003Eu__1;

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

		public static ValueTask AsValueTask(this in UniTask task)
		{
			return default(ValueTask);
		}

		public static ValueTask<T> AsValueTask<T>(this in UniTask<T> task)
		{
			return default(ValueTask<T>);
		}

		[AsyncStateMachine(typeof(_003CAsUniTask_003Ed__2<>))]
		public static UniTask<T> AsUniTask<T>(this ValueTask<T> task)
		{
			return default(UniTask<T>);
		}

		[AsyncStateMachine(typeof(_003CAsUniTask_003Ed__3))]
		public static UniTask AsUniTask(this ValueTask task)
		{
			return default(UniTask);
		}
	}
}
