using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;

namespace Cysharp.Threading.Tasks.Linq
{
	internal static class ToDictionary
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CToDictionaryAsync_003Ed__0<TSource, TKey> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Dictionary<TKey, TSource>> _003C_003Et__builder;

			public IEqualityComparer<TKey> comparer;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, TKey> keySelector;

			private Dictionary<TKey, TSource> _003Cdict_003E5__2;

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
		private struct _003CToDictionaryAsync_003Ed__1<TSource, TKey, TElement> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Dictionary<TKey, TElement>> _003C_003Et__builder;

			public IEqualityComparer<TKey> comparer;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, TKey> keySelector;

			public Func<TSource, TElement> elementSelector;

			private Dictionary<TKey, TElement> _003Cdict_003E5__2;

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
		private struct _003CToDictionaryAwaitAsync_003Ed__2<TSource, TKey> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Dictionary<TKey, TSource>> _003C_003Et__builder;

			public IEqualityComparer<TKey> comparer;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<TKey>> keySelector;

			private Dictionary<TKey, TSource> _003Cdict_003E5__2;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private TSource _003Cv_003E5__6;

			private UniTask<TKey>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CToDictionaryAwaitAsync_003Ed__3<TSource, TKey, TElement> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Dictionary<TKey, TElement>> _003C_003Et__builder;

			public IEqualityComparer<TKey> comparer;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, UniTask<TKey>> keySelector;

			public Func<TSource, UniTask<TElement>> elementSelector;

			private Dictionary<TKey, TElement> _003Cdict_003E5__2;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private TSource _003Cv_003E5__6;

			private TKey _003Ckey_003E5__7;

			private UniTask<TKey>.Awaiter _003C_003Eu__1;

			private UniTask<TElement>.Awaiter _003C_003Eu__2;

			private UniTask<bool>.Awaiter _003C_003Eu__3;

			private UniTask.Awaiter _003C_003Eu__4;

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
		private struct _003CToDictionaryAwaitWithCancellationAsync_003Ed__4<TSource, TKey> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Dictionary<TKey, TSource>> _003C_003Et__builder;

			public IEqualityComparer<TKey> comparer;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<TKey>> keySelector;

			private Dictionary<TKey, TSource> _003Cdict_003E5__2;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private TSource _003Cv_003E5__6;

			private UniTask<TKey>.Awaiter _003C_003Eu__1;

			private UniTask<bool>.Awaiter _003C_003Eu__2;

			private UniTask.Awaiter _003C_003Eu__3;

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
		private struct _003CToDictionaryAwaitWithCancellationAsync_003Ed__5<TSource, TKey, TElement> : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncUniTaskMethodBuilder<Dictionary<TKey, TElement>> _003C_003Et__builder;

			public IEqualityComparer<TKey> comparer;

			public IUniTaskAsyncEnumerable<TSource> source;

			public CancellationToken cancellationToken;

			public Func<TSource, CancellationToken, UniTask<TKey>> keySelector;

			public Func<TSource, CancellationToken, UniTask<TElement>> elementSelector;

			private Dictionary<TKey, TElement> _003Cdict_003E5__2;

			private IUniTaskAsyncEnumerator<TSource> _003Ce_003E5__3;

			private object _003C_003E7__wrap3;

			private int _003C_003E7__wrap4;

			private TSource _003Cv_003E5__6;

			private TKey _003Ckey_003E5__7;

			private UniTask<TKey>.Awaiter _003C_003Eu__1;

			private UniTask<TElement>.Awaiter _003C_003Eu__2;

			private UniTask<bool>.Awaiter _003C_003Eu__3;

			private UniTask.Awaiter _003C_003Eu__4;

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

		[AsyncStateMachine(typeof(_003CToDictionaryAsync_003Ed__0<, >))]
		internal static UniTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TSource, TKey>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<Dictionary<TKey, TSource>>);
		}

		[AsyncStateMachine(typeof(_003CToDictionaryAsync_003Ed__1<, , >))]
		internal static UniTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TSource, TKey, TElement>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<Dictionary<TKey, TElement>>);
		}

		[AsyncStateMachine(typeof(_003CToDictionaryAwaitAsync_003Ed__2<, >))]
		internal static UniTask<Dictionary<TKey, TSource>> ToDictionaryAwaitAsync<TSource, TKey>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<TKey>> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<Dictionary<TKey, TSource>>);
		}

		[AsyncStateMachine(typeof(_003CToDictionaryAwaitAsync_003Ed__3<, , >))]
		internal static UniTask<Dictionary<TKey, TElement>> ToDictionaryAwaitAsync<TSource, TKey, TElement>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, UniTask<TKey>> keySelector, Func<TSource, UniTask<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<Dictionary<TKey, TElement>>);
		}

		[AsyncStateMachine(typeof(_003CToDictionaryAwaitWithCancellationAsync_003Ed__4<, >))]
		internal static UniTask<Dictionary<TKey, TSource>> ToDictionaryAwaitWithCancellationAsync<TSource, TKey>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<TKey>> keySelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<Dictionary<TKey, TSource>>);
		}

		[AsyncStateMachine(typeof(_003CToDictionaryAwaitWithCancellationAsync_003Ed__5<, , >))]
		internal static UniTask<Dictionary<TKey, TElement>> ToDictionaryAwaitWithCancellationAsync<TSource, TKey, TElement>(IUniTaskAsyncEnumerable<TSource> source, Func<TSource, CancellationToken, UniTask<TKey>> keySelector, Func<TSource, CancellationToken, UniTask<TElement>> elementSelector, IEqualityComparer<TKey> comparer, CancellationToken cancellationToken)
		{
			return default(UniTask<Dictionary<TKey, TElement>>);
		}
	}
}
