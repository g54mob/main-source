using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal class ToUniTaskAsyncEnumerableTask<T> : IUniTaskAsyncEnumerable<T>
	{
		private class _ToUniTaskAsyncEnumerableTask : IUniTaskAsyncEnumerator<T>, IUniTaskAsyncDisposable
		{
			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CMoveNextAsync_003Ed__7 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

				public _ToUniTaskAsyncEnumerableTask _003C_003E4__this;

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

			private readonly Task<T> source;

			private CancellationToken cancellationToken;

			private T current;

			private bool called;

			public T Current => default(T);

			public _ToUniTaskAsyncEnumerableTask(Task<T> source, CancellationToken cancellationToken)
			{
			}

			[AsyncStateMachine(typeof(ToUniTaskAsyncEnumerableTask<>._ToUniTaskAsyncEnumerableTask._003CMoveNextAsync_003Ed__7))]
			public UniTask<bool> MoveNextAsync()
			{
				return default(UniTask<bool>);
			}

			public UniTask DisposeAsync()
			{
				return default(UniTask);
			}
		}

		private readonly Task<T> source;

		public ToUniTaskAsyncEnumerableTask(Task<T> source)
		{
		}

		public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}
	}
}
