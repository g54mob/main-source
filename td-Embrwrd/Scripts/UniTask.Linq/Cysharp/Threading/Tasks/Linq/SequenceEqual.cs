using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal static class SequenceEqual
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CSequenceEqualAsync_003Ed__0<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<bool> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> first;

			public CancellationToken cancellationToken;

			public IUniTaskAsyncEnumerable<TSource> second;

			public IEqualityComparer<TSource> comparer;

			private IUniTaskAsyncEnumerator<TSource> _003Ce1_003E5__2;

			private object _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			private bool _003C_003E7__wrap4;

			private IUniTaskAsyncEnumerator<TSource> _003Ce2_003E5__6;

			private object _003C_003E7__wrap6;

			private int _003C_003E7__wrap7;

			private bool _003C_003E7__wrap8;

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

		[AsyncStateMachine(typeof(_003CSequenceEqualAsync_003Ed__0<>))]
		internal static UniTask<bool> SequenceEqualAsync<TSource>(IUniTaskAsyncEnumerable<TSource> first, IUniTaskAsyncEnumerable<TSource> second, IEqualityComparer<TSource> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<bool>);
		}
	}
}
