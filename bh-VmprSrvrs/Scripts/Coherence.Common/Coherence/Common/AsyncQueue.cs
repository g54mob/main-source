using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Coherence.Common
{
	public class AsyncQueue<T>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CDequeueAsync_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncValueTaskMethodBuilder<T> _003C_003Et__builder;

			public AsyncQueue<T> _003C_003E4__this;

			public CancellationToken cancellationToken;

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

		private readonly SemaphoreSlim semaphore;

		private readonly ConcurrentQueue<T> queue;

		public void Enqueue(T item)
		{
		}

		[AsyncStateMachine(typeof(AsyncQueue<>._003CDequeueAsync_003Ed__3))]
		public ValueTask<T> DequeueAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(ValueTask<T>);
		}
	}
}
