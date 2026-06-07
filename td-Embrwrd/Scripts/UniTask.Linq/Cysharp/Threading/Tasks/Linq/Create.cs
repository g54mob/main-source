using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal sealed class Create<T> : IUniTaskAsyncEnumerable<T>
	{
		private sealed class _Create : MoveNextSource, IUniTaskAsyncEnumerator<T>, IUniTaskAsyncDisposable
		{
			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CRunWriterTask_003Ed__12 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

				public UniTask task;

				public _Create _003C_003E4__this;

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

			private readonly Func<IAsyncWriter<T>, CancellationToken, UniTask> create;

			private readonly CancellationToken cancellationToken;

			private int state;

			private AsyncWriter writer;

			public T Current { get; private set; }

			public _Create(Func<IAsyncWriter<T>, CancellationToken, UniTask> create, CancellationToken cancellationToken)
			{
			}

			public UniTask DisposeAsync()
			{
				return default(UniTask);
			}

			public UniTask<bool> MoveNextAsync()
			{
				return default(UniTask<bool>);
			}

			private void MoveNext()
			{
			}

			[AsyncStateMachine(typeof(Create<>._Create._003CRunWriterTask_003Ed__12))]
			private UniTaskVoid RunWriterTask(UniTask task)
			{
				return default(UniTaskVoid);
			}

			public void SetResult(T value)
			{
			}
		}

		private sealed class AsyncWriter : IUniTaskSource, IAsyncWriter<T>
		{
			private readonly _Create enumerator;

			private UniTaskCompletionSourceCore<AsyncUnit> core;

			public AsyncWriter(_Create enumerator)
			{
			}

			public void GetResult(short token)
			{
			}

			public UniTaskStatus GetStatus(short token)
			{
				return default(UniTaskStatus);
			}

			public UniTaskStatus UnsafeGetStatus()
			{
				return default(UniTaskStatus);
			}

			public void OnCompleted(Action<object> continuation, object state, short token)
			{
			}

			public UniTask YieldAsync(T value)
			{
				return default(UniTask);
			}

			public void SignalWriter()
			{
			}
		}

		private readonly Func<IAsyncWriter<T>, CancellationToken, UniTask> create;

		public Create(Func<IAsyncWriter<T>, CancellationToken, UniTask> create)
		{
		}

		public IUniTaskAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}
	}
}
