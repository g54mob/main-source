using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal static class Contains
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CContainsAsync_003Ed__0<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public IEqualityComparer<TSource> comparer;

			public TSource value;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__2;

			private object _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			private bool _003C_003E7__wrap4;

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

		[AsyncStateMachine(typeof(_003CContainsAsync_003Ed__0<>))]
		internal static UniTask<bool> ContainsAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<bool>);
		}
	}
}
