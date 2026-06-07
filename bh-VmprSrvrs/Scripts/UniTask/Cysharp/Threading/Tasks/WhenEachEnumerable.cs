using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks
{
	internal sealed class WhenEachEnumerable<T> : IUniTaskAsyncEnumerable<WhenEachResult<T>>
	{
		private sealed class Enumerator : IUniTaskAsyncEnumerator<WhenEachResult<T>>, IUniTaskAsyncDisposable
		{
			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CDisposeAsync_003Ed__12 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskMethodBuilder _003C_003Et__builder;

				public Enumerator _003C_003E4__this;

				private UniTask.Awaiter _003C_003Eu__1;

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
			private struct _003CRunWhenEachTask_003Ed__11 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

				public UniTask<T> task;

				public Enumerator self;

				public int length;

				private UniTask<T>.Awaiter _003C_003Eu__1;

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

			private readonly IEnumerable<UniTask<T>> source;

			private CancellationToken cancellationToken;

			private Channel<WhenEachResult<T>> channel;

			private IUniTaskAsyncEnumerator<WhenEachResult<T>> channelEnumerator;

			private int completeCount;

			private WhenEachState state;

			public WhenEachResult<T> Current => default(WhenEachResult<T>);

			public Enumerator(IEnumerable<UniTask<T>> source, CancellationToken cancellationToken)
			{
			}

			public UniTask<bool> MoveNextAsync()
			{
				return default(UniTask<bool>);
			}

			private static void ConsumeAll(Enumerator self, UniTask<T>[] array, int length)
			{
			}

			[AsyncStateMachine(typeof(WhenEachEnumerable<>.Enumerator._003CRunWhenEachTask_003Ed__11))]
			private static UniTaskVoid RunWhenEachTask(Enumerator self, UniTask<T> task, int length)
			{
				return default(UniTaskVoid);
			}

			[AsyncStateMachine(typeof(WhenEachEnumerable<>.Enumerator._003CDisposeAsync_003Ed__12))]
			public UniTask DisposeAsync()
			{
				return default(UniTask);
			}
		}

		private IEnumerable<UniTask<T>> source;

		public WhenEachEnumerable(IEnumerable<UniTask<T>> source)
		{
		}

		public IUniTaskAsyncEnumerator<WhenEachResult<T>> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}
	}
}
