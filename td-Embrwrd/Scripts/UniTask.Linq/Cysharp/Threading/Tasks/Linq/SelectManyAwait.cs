using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal sealed class SelectManyAwait<TSource, TCollection, TResult> : IUniTaskAsyncEnumerable<TResult>
	{
		private sealed class _SelectManyAwait : MoveNextSource, IUniTaskAsyncEnumerator<TResult>, IUniTaskAsyncDisposable
		{
			[StructLayout((LayoutKind)3)]
			[CompilerGenerated]
			private struct _003CDisposeAsync_003Ed__32 : IAsyncStateMachine
			{
				public int _003C_003E1__state;

				public AsyncUniTaskMethodBuilder _003C_003Et__builder;

				public _SelectManyAwait _003C_003E4__this;

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

			private static readonly Action<object> sourceMoveNextCoreDelegate;

			private static readonly Action<object> selectedSourceMoveNextCoreDelegate;

			private static readonly Action<object> selectedEnumeratorDisposeAsyncCoreDelegate;

			private static readonly Action<object> selectorAwaitCoreDelegate;

			private static readonly Action<object> resultSelectorAwaitCoreDelegate;

			private readonly IUniTaskAsyncEnumerable<TSource> source;

			private readonly Func<TSource, UniTask<IUniTaskAsyncEnumerable<TCollection>>> selector1;

			private readonly Func<TSource, int, UniTask<IUniTaskAsyncEnumerable<TCollection>>> selector2;

			private readonly Func<TSource, TCollection, UniTask<TResult>> resultSelector;

			private CancellationToken cancellationToken;

			private TSource sourceCurrent;

			private int sourceIndex;

			private IUniTaskAsyncEnumerator<TSource> sourceEnumerator;

			private IUniTaskAsyncEnumerator<TCollection> selectedEnumerator;

			private UniTask<bool>.Awaiter sourceAwaiter;

			private UniTask<bool>.Awaiter selectedAwaiter;

			private UniTask.Awaiter selectedDisposeAsyncAwaiter;

			private UniTask<IUniTaskAsyncEnumerable<TCollection>>.Awaiter collectionSelectorAwaiter;

			private UniTask<TResult>.Awaiter resultSelectorAwaiter;

			public TResult Current { get; private set; }

			public _SelectManyAwait(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<IUniTaskAsyncEnumerable<TCollection>>> selector1, Func<TSource, int, UniTask<IUniTaskAsyncEnumerable<TCollection>>> selector2, Func<TSource, TCollection, UniTask<TResult>> resultSelector, CancellationToken cancellationToken)
			{
			}

			public UniTask<bool> MoveNextAsync()
			{
				return default(UniTask<bool>);
			}

			private void MoveNextSource()
			{
			}

			private void MoveNextSelected()
			{
			}

			private static void SourceMoveNextCore(object state)
			{
			}

			private static void SeletedSourceMoveNextCore(object state)
			{
			}

			private static void SelectedEnumeratorDisposeAsyncCore(object state)
			{
			}

			private static void SelectorAwaitCore(object state)
			{
			}

			private static void ResultSelectorAwaitCore(object state)
			{
			}

			[AsyncStateMachine(typeof(SelectManyAwait<, , >._SelectManyAwait._003CDisposeAsync_003Ed__32))]
			public UniTask DisposeAsync()
			{
				return default(UniTask);
			}
		}

		private readonly IUniTaskAsyncEnumerable<TSource> source;

		private readonly Func<TSource, UniTask<IUniTaskAsyncEnumerable<TCollection>>> selector1;

		private readonly Func<TSource, int, UniTask<IUniTaskAsyncEnumerable<TCollection>>> selector2;

		private readonly Func<TSource, TCollection, UniTask<TResult>> resultSelector;

		public SelectManyAwait(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<IUniTaskAsyncEnumerable<TCollection>>> selector, Func<TSource, TCollection, UniTask<TResult>> resultSelector)
		{
		}

		public SelectManyAwait(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, int, UniTask<IUniTaskAsyncEnumerable<TCollection>>> selector, Func<TSource, TCollection, UniTask<TResult>> resultSelector)
		{
		}

		public IUniTaskAsyncEnumerator<TResult> GetAsyncEnumerator(CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}
	}
}
