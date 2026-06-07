using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal class AsyncSelectorWithCancellationEnumerableSorter<TElement, TKey> : AsyncEnumerableSorter<TElement>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CComputeKeysAsync_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder _003C_003Et__builder;

			public AsyncSelectorWithCancellationEnumerableSorter<TElement, TKey> _003C_003E4__this;

			public int count;

			public TElement[] elements;

			private int _003Ci_003E5__2;

			private TKey[] _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			private UniTask<TKey>.Awaiter _003C_003Eu__1;

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

		private readonly Func<TElement, CancellationToken, UniTask<TKey>> keySelector;

		private readonly IComparer<TKey> comparer;

		private readonly bool descending;

		private readonly AsyncEnumerableSorter<TElement> next;

		private CancellationToken cancellationToken;

		private TKey[] keys;

		internal AsyncSelectorWithCancellationEnumerableSorter(Func<TElement, CancellationToken, UniTask<TKey>> keySelector, IComparer<TKey> comparer, bool descending, AsyncEnumerableSorter<TElement> next, CancellationToken cancellationToken)
		{
		}

		[AsyncStateMachine(typeof(AsyncSelectorWithCancellationEnumerableSorter<, >._003CComputeKeysAsync_003Ed__7))]
		internal override UniTask ComputeKeysAsync(TElement[] elements, int count)
		{
			return default(UniTask);
		}

		internal override int CompareKeys(int index1, int index2)
		{
			return 0;
		}
	}
}
