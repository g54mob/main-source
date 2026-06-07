using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal abstract class AsyncEnumerableSorter<TElement>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSortAsync_003Ed__2 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<int[]> _003C_003Et__builder;

			public AsyncEnumerableSorter<TElement> _003C_003E4__this;

			public TElement[] elements;

			public int count;

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

		internal abstract UniTask ComputeKeysAsync(TElement[] elements, int count);

		internal abstract int CompareKeys(int index1, int index2);

		[AsyncStateMachine(typeof(AsyncEnumerableSorter<>._003CSortAsync_003Ed__2))]
		internal UniTask<int[]> SortAsync(TElement[] elements, int count)
		{
			return default(UniTask<int[]>);
		}

		private void QuickSort(int[] map, int left, int right)
		{
		}
	}
}
