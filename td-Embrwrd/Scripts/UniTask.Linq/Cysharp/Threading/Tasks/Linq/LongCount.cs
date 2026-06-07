using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal static class LongCount
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLongCountAsync_003Ed__0<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<long> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			private long _003Ccount_003E5__2;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLongCountAsync_003Ed__1<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<long> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, bool> predicate;

			private long _003Ccount_003E5__2;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLongCountAwaitAsync_003Ed__2<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<long> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<bool>> predicate;

			private long _003Ccount_003E5__2;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLongCountAwaitWithCancellationAsync_003Ed__3<TSource> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<long> _003C_003Et__builder;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<bool>> predicate;

			private long _003Ccount_003E5__2;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

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

		[AsyncStateMachine(typeof(_003CLongCountAsync_003Ed__0<>))]
		internal static UniTask<long> LongCountAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
		{
			return default(UniTask<long>);
		}

		[AsyncStateMachine(typeof(_003CLongCountAsync_003Ed__1<>))]
		internal static UniTask<long> LongCountAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, bool> predicate, CancellationToken cancellationToken)
		{
			return default(UniTask<long>);
		}

		[AsyncStateMachine(typeof(_003CLongCountAwaitAsync_003Ed__2<>))]
		internal static UniTask<long> LongCountAwaitAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<bool>> predicate, CancellationToken cancellationToken)
		{
			return default(UniTask<long>);
		}

		[AsyncStateMachine(typeof(_003CLongCountAwaitWithCancellationAsync_003Ed__3<>))]
		internal static UniTask<long> LongCountAwaitWithCancellationAsync<TSource>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<bool>> predicate, CancellationToken cancellationToken)
		{
			return default(UniTask<long>);
		}
	}
}
