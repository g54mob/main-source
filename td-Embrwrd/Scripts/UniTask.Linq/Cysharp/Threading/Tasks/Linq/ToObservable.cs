using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal sealed class ToObservable<T> : IObservable<T>
	{
		internal sealed class CancellationTokenDisposable : IDisposable
		{
			private readonly CancellationTokenSource cts;

			public CancellationToken Token => default(CancellationToken);

			public void Dispose()
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CRunAsync_003Ed__3 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskVoidMethodBuilder _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<T> src;

			public CancellationToken cancellationToken;

			public IObserver<T> observer;

			private IUniTaskAsyncEnumerator<T> _003Ce_003E5__2;

			private object _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			private UniTask<bool>.Awaiter _003C_003Eu__1;

			private UniTask.Awaiter _003C_003Eu__2;

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

		private readonly IUniTaskAsyncEnumerable<T> source;

		public ToObservable(IUniTaskAsyncEnumerable<T> source)
		{
		}

		public IDisposable Subscribe(IObserver<T> observer)
		{
			return null;
		}

		[AsyncStateMachine(typeof(ToObservable<>._003CRunAsync_003Ed__3))]
		private static UniTaskVoid RunAsync(IUniTaskAsyncEnumerable<T> src, IObserver<T> observer, CancellationToken cancellationToken)
		{
			return default(UniTaskVoid);
		}
	}
}
