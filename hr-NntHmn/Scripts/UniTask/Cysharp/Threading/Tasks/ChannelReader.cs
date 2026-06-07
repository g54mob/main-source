using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks
{
	public abstract class ChannelReader<T>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CReadAsyncCore_003Ed__5 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<T> _003C_003Et__builder;

			public ChannelReader<T> _003C_003E4__this;

			public CancellationToken cancellationToken;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

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

		public abstract UniTask Completion { get; }

		public abstract bool TryRead(out T item);

		public abstract UniTask<bool> WaitToReadAsync(CancellationToken cancellationToken = default(CancellationToken));

		public virtual UniTask<T> ReadAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask<T>);
		}

		[AsyncStateMachine(typeof(ChannelReader<>._003CReadAsyncCore_003Ed__5))]
		private UniTask<T> ReadAsyncCore(CancellationToken cancellationToken = default(CancellationToken))
		{
			return default(UniTask<T>);
		}

		public abstract IUniTaskAsyncEnumerable<T> ReadAllAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
